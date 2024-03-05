using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsEvidencias
{
    public partial class EvidenciaMantenimiento : System.Web.UI.Page
    {
        readonly SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();
                    switch (sOpc)
                    {
                        case "C":
                            this.Lbltitulo.Text = "Ingresar nuevo Evidencia";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista Evidencia";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Evidencia";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Evidencia";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }
        private void CargarDatos()
        {
            EvidenciaViewModel evidencia = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_EVID WHERE strCod_evid = '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        evidencia = new EvidenciaViewModel
                        {
                            Id = reader["strCod_evid"].ToString(),
                            Nombre = reader["strNombre_evid"].ToString(),
                            Descripcion = reader["strDescripcion_evid"].ToString(),
                            Orden = reader["strOrden_evid"].ToString(),
                            Est = Convert.ToBoolean(reader["bitAdd_evid"])
                        };
                    }
                }
            }
            cn.Close();
            if (evidencia != null)
            {
                this.tbid.Text = evidencia.Id;
                this.tbnombre.Text = evidencia.Nombre;
                this.tbdescripcion.Text = evidencia.Descripcion;
                this.tborden.Text = evidencia.Orden;
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string insert = @"INSERT INTO dbo.GC_EVID 
                          VALUES (@id, @nombre, @descripcion, @orden, GETDATE(), '', '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, '')";

                using (SqlCommand command = new SqlCommand(insert, cn))
                {
                    cn.Open();

                    command.Parameters.AddWithValue("@id", tbid.Text);
                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);

                    command.ExecuteNonQuery();
                }

                ShowSweetAlert("Datos guardados exitosamente", "Evidencias.aspx");
            }
            catch (Exception ex)
            {
                ShowErrorSweetAlert($"Hubo un error al guardar los datos. Detalles: {ex.Message}");
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string update = @"UPDATE dbo.GC_EVID 
                          SET strNombre_evid = @nombre, 
                              strDescripcion_evid = @descripcion, 
                              strOrden_evid = @orden
                          WHERE strCod_evid = @id";

                using (SqlCommand command = new SqlCommand(update, cn))
                {
                    cn.Open();

                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);
                    command.Parameters.AddWithValue("@id", tbid.Text);

                    command.ExecuteNonQuery();
                }

                ShowSweetAlert("Datos actualizados exitosamente", "Evidencias.aspx");
            }
            catch (Exception ex)
            {
                ShowErrorSweetAlert($"Hubo un error al actualizar los datos. Detalles: {ex.Message}");
            }
        }

        private void ShowSweetAlert(string message, string redirectUrl)
        {
            string script = $@"
        <script>
            Swal.fire({{
                title: 'Éxito',
                text: '{message}',
                icon: 'success',
                confirmButtonText: 'OK'
            }}).then((result) => {{
                if (result.isConfirmed) {{
                    window.location.href = '{redirectUrl}';
                }}
            }});
        </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script);
        }

        private void ShowErrorSweetAlert(string errorMessage)
        {
            string errorScript = $@"
        <script>
            Swal.fire({{
                title: 'Error',
                text: '{errorMessage}',
                icon: 'error',
                confirmButtonText: 'OK'
            }});
        </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlertError", errorScript);
        }



        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string delete = $"DELETE FROM dbo.GC_EVID WHERE strCod_evid = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("Evidencias.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Evidencias.aspx");
        }
    }

}