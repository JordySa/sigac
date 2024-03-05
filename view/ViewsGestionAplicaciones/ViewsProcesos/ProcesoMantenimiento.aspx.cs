using sigac.view.ViewsGestionAplicaciones.ViewsComponentes;
using sigac.view.ViewsGestionAplicaciones.ViewsTiposProcesos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static sigac.view.ViewsGestionAplicaciones.ViewsProcesos.Procesos;

namespace sigac.view.ViewsGestionAplicaciones.ViewsProcesos
{
    public partial class ProcesoMantenimiento : System.Web.UI.Page
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
            ProcesoViewModel proceso = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_PROCES WHERE strCod_proces= '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proceso = new ProcesoViewModel
                        {
                            Id = reader["strCod_proces"].ToString(),
                            Nombre = reader["strNombre_proces"].ToString(),
                            Descripcion = reader["strDescripcion_proces"].ToString(),
                            Orden = reader["strOrden_proces"].ToString(),
                            Est = Convert.ToBoolean(reader["bitAdd_proces"])
                        };
                    }
                }
            }
            cn.Close();
            if (proceso != null)
            {
                this.tbid.Text = proceso.Id;
                this.tbnombre.Text = proceso.Nombre;
                this.tbdescripcion.Text = proceso.Descripcion;
                this.tborden.Text = proceso.Orden;
            }
        }



        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
            INSERT INTO dbo.GC_PROCES 
            VALUES (@id, @nombre, @descripcion, @orden, GETDATE(), '', '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, NULL)";

                using (SqlCommand command = new SqlCommand(insertQuery, cn))
                {
                    cn.Open();

                    // Configurar los parámetros
                    command.Parameters.AddWithValue("@id", tbid.Text);
                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);

                    // Ejecutar la consulta
                    command.ExecuteNonQuery();
                }

                ShowSweetAlert("Datos guardados exitosamente", "Procesos.aspx");
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
                string updateQuery = @"
            UPDATE dbo.GC_PROCES 
            SET strNombre_proces = @nombre, 
                strDescripcion_proces = @descripcion, 
                strOrden_proces = @orden
            WHERE strCod_proces = @id";

                using (SqlCommand command = new SqlCommand(updateQuery, cn))
                {
                    cn.Open();

                    // Configurar los parámetros
                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);
                    command.Parameters.AddWithValue("@id", tbid.Text);

                    // Ejecutar la consulta
                    command.ExecuteNonQuery();
                }

                ShowSweetAlert("Datos actualizados exitosamente", "Procesos.aspx");
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
            string delete = $"DELETE FROM dbo.GC_PROCES WHERE strCod_proces = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("Procesos.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Procesos.aspx");
        }
    }
}