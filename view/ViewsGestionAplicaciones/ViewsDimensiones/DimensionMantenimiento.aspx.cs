using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Web.UI;

namespace sigac.view.ViewsGestionAplicaciones.ViewsDimensiones
{
    public partial class DimensionMantenimiento : System.Web.UI.Page
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
                            this.Lbltitulo.Text = "Ingresar nueva Dimensión";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista Dimensión";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Dimensión";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Dimensión";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        private void CargarDatos()
        {
            DimensionViewModel dimension = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_DIMEN WHERE strCod_dimen = '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dimension = new DimensionViewModel
                        {
                            Id = reader["strCod_dimen"].ToString(),
                            Nombre = reader["strNombre_dimen"].ToString(),
                            Descripcion = reader["strDescripcion_dimen"].ToString(),
                            Orden = reader["strOrden_dimem"].ToString(),
                            Est = Convert.ToBoolean(reader["bitAdd_dimen"])
                        };
                    }
                }
            }
            cn.Close();
            if (dimension != null)
            {
                this.tbid.Text = dimension.Id;
                this.tbnombre.Text = dimension.Nombre;
                this.tbdescripcion.Text = dimension.Descripcion;
                this.tborden.Text = dimension.Orden;
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string insert = @"INSERT INTO dbo.GC_DIMEN 
                          VALUES (@id, @nombre, @descripcion, @orden, GETDATE(), '', '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, NULL)";

                using (SqlCommand command = new SqlCommand(insert, cn))
                {
                    cn.Open();

                    command.Parameters.AddWithValue("@id", tbid.Text);
                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);

                    command.ExecuteNonQuery();
                }

                ShowSweetAlert("Datos guardados exitosamente", "Dimensiones.aspx");
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
                string update = @"UPDATE dbo.GC_DIMEN 
                          SET strNombre_dimen = @nombre, 
                              strDescripcion_dimen = @descripcion, 
                              strOrden_dimen = @orden 
                          WHERE strCod_dimen = @id";

                using (SqlCommand command = new SqlCommand(update, cn))
                {
                    cn.Open();

                    command.Parameters.AddWithValue("@nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@orden", tborden.Text);
                    command.Parameters.AddWithValue("@id", tbid.Text);

                    command.ExecuteNonQuery();
                }

                ShowSweetAlert("Datos actualizados exitosamente", "Dimensiones.aspx");
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
            string delete = $"DELETE FROM dbo.GC_DIMEN WHERE strCod_dimen = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("Dimensiones.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dimensiones.aspx");
        }
    }

}
