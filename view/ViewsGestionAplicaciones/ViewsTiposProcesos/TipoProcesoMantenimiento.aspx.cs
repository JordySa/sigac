using sigac.view.ViewsGestionAplicaciones.ViewsPeriodicidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsTiposProcesos
{
    public partial class TipoProcesoMantenimiento : System.Web.UI.Page
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
                            this.Lbltitulo.Text = "Ingresar nuevo Tipo de Proceso";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista Tipo de Proceso";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Tipo de Proceso";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Tipo de Proceso";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }




        private void CargarDatos()
        {
            TipoPViewModel tipoP = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_TPROCES WHERE strCod_tpro= '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipoP = new TipoPViewModel
                        {
                            Id = reader["strCod_tpro"].ToString(),
                            Nombre = reader["strNombre_tpro"].ToString(),
                            Descripcion = reader["strDescripcion_tpro"].ToString(),
                            Orden = reader["strOrden_tpro"].ToString(),
                            Est = Convert.ToBoolean(reader["bitAdd_tpro"])
                        };
                    }
                }
            }
            cn.Close();
            if (tipoP != null)
            {
                this.tbid.Text = tipoP.Id;
                this.tbnombre.Text = tipoP.Nombre;
                this.tbdescripcion.Text = tipoP.Descripcion;
                this.tborden.Text = tipoP.Orden;
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO dbo.GC_TPROCES " +
                                     "(strCod_tpro, strNombre_tpro, strDescripcion_tpro, strOrden_tpro, fechaCreacion_tpro) " +
                                     "VALUES (@id, @nombre, @descripcion, @orden, GETDATE())";

                using (SqlCommand command = new SqlCommand(insertQuery, cn))
                {
                    cn.Open();

                    command.Parameters.AddWithValue("@id", tbid.Text);
                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);

                    command.ExecuteNonQuery();
                }

                ShowSweetAlert("Datos guardados exitosamente", "TiposProcesos.aspx");
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
                string updateQuery = "UPDATE dbo.GC_TPROCES " +
                                     "SET strNombre_tpro = @nombre, " +
                                     "    strDescripcion_tpro = @descripcion, " +
                                     "    strOrden_tpro = @orden " +
                                     "WHERE strCod_tpro = @id";

                using (SqlCommand command = new SqlCommand(updateQuery, cn))
                {
                    cn.Open();

                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);
                    command.Parameters.AddWithValue("@id", tbid.Text);

                    command.ExecuteNonQuery();
                }

                ShowSweetAlert("Datos actualizados exitosamente", "TiposProcesos.aspx");
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
            string delete = $"DELETE FROM dbo.GC_TPROCES WHERE strCod_tpro = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("TiposProcesos.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TiposProcesos.aspx");
        }
    }
}