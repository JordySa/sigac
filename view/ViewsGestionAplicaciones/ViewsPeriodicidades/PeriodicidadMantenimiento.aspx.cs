using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsPeriodicidades
{
    public partial class PeriodicidadMantenimiento : System.Web.UI.Page
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
                            this.Lbltitulo.Text = "Ingresar nuevo Periodicidad";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista Periodicidad";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Periodicidad";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Periodicidad";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }




        private void CargarDatos()
        {
            PeriodicidadViewModel periodicidad = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_PERIOD WHERE strCod_period= '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        periodicidad = new PeriodicidadViewModel
                        {
                            Id = reader["strCod_period"].ToString(),
                            Nombre = reader["strNombre_period"].ToString(),
                            Descripcion = reader["strDescripcion_period"].ToString(),
                            Orden = reader["strOrden_period"].ToString(),
                            Est = Convert.ToBoolean(reader["bitAdd_period"])
                        };
                    }
                }
            }
            cn.Close();
            if (periodicidad != null)
            {
                this.tbid.Text = periodicidad.Id;
                this.tbnombre.Text = periodicidad.Nombre;
                this.tbdescripcion.Text = periodicidad.Descripcion;
                this.tborden.Text = periodicidad.Orden;

            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Lógica para insertar datos
                string insertQuery = @"INSERT INTO dbo.GC_PERIOD 
                               VALUES (@id, @nombre, @descripcion, @orden, GETDATE(), '', '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, '')";

                using (SqlCommand command = new SqlCommand(insertQuery, cn))
                {
                    cn.Open();

                    command.Parameters.AddWithValue("@id", tbid.Text);
                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);

                    command.ExecuteNonQuery();
                }

                ShowSuccessSweetAlert("Datos guardados exitosamente", "Periodicidades.aspx");
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
                // Supongamos que strCod_period es la columna que identifica de manera única cada registro
                string updateQuery = @"UPDATE dbo.GC_PERIOD 
                               SET strNombre_period = @nombre, 
                                   strDescripcion_period = @descripcion, 
                                   strOrden_period = @orden
                               WHERE strCod_period = @id";

                using (SqlCommand command = new SqlCommand(updateQuery, cn))
                {
                    cn.Open();

                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);
                    command.Parameters.AddWithValue("@id", tbid.Text);

                    command.ExecuteNonQuery();
                }

                ShowSuccessSweetAlert("Datos actualizados exitosamente", "Periodicidades.aspx");
            }
            catch (Exception ex)
            {
                ShowErrorSweetAlert($"Hubo un error al actualizar los datos. Detalles: {ex.Message}");
            }
        }

        private void ShowSuccessSweetAlert(string message, string redirectUrl)
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
            string delete = $"DELETE FROM dbo.GC_PERIOD WHERE strCod_period = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("Periodicidades.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Periodicidades.aspx");
        }
    }
}