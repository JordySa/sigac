using sigac.view.ViewsGestionAplicaciones.ViewsPeriodicidades;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace sigac.view.ViewsGestionAplicaciones.ViewsVariables
{
    public partial class VariableMantenimiento : System.Web.UI.Page
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
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
                            this.Lbltitulo.Text = "Ingresar nuevo Variable";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista Variable";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Variable";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Variable";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        private void CargarDatos()
        {
            VariableViewModel variable = null;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                // Corregir la sintaxis de la consulta y usar parámetros
                string queryString = "SELECT * FROM GC_VARIAB WHERE strCod_variab = @ID";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    command.Parameters.AddWithValue("@ID", sID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            variable = new VariableViewModel
                            {
                                Id = reader["strCod_variab"].ToString(),
                                Nombre = reader["strNombre_variab"].ToString(),
                                Descripcion = reader["strDescripcion_variab"].ToString(),
                                Orden = reader["strOrden_variab"].ToString(),
                                Est = Convert.ToBoolean(reader["bitAdd_variab"])
                            };
                        }
                    }
                }
            }

            if (variable != null)
            {
                this.tbid.Text = variable.Id;
                this.tbnombre.Text = variable.Nombre;
                this.tbdescripcion.Text = variable.Descripcion;
                this.tborden.Text = variable.Orden;
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Lógica para insertar datos y usar parámetros
                string insert = "INSERT INTO dbo.GC_VARIAB VALUES (@ID, @Nombre, @Descripcion, @Orden, GETDATE(), '', '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, '')";
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand command = new SqlCommand(insert, cn))
                    {
                        command.Parameters.AddWithValue("@ID", this.tbid.Text);
                        command.Parameters.AddWithValue("@Nombre", this.tbnombre.Text);
                        command.Parameters.AddWithValue("@Descripcion", this.tbdescripcion.Text);
                        command.Parameters.AddWithValue("@Orden", this.tborden.Text);

                        command.ExecuteNonQuery();
                    }
                }

                // Mostrar una alerta SweetAlert2 después de guardar los datos
                string script = @"<script>
                            Swal.fire({
                                title: 'Datos guardados',
                                text: 'Los datos se han guardado exitosamente.',
                                icon: 'success',
                                confirmButtonText: 'OK'
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    window.location.href = 'Variables.aspx';
                                }
                            });
                         </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y mostrar un mensaje de error
                string errorScript = $@"<script>
                                     Swal.fire(title: 'Error',
                                        text: 'Hubo un error al guardar los datos. Detalles: {ex.Message}',
                                        icon: 'error',
                                        confirmButtonText: 'OK'
                                    );
                                 </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlertError", errorScript);
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Supongamos que strCod_variab la columna que identifica de manera única cada registro
                string update = @"
                UPDATE dbo.GC_VARIAB 
                SET strNombre_variab = @Nombre, 
                    strDescripcion_variab = @Descripcion, 
                    strOrden_variab = @Orden
                WHERE strCod_variab = @ID";

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand command = new SqlCommand(update, cn))
                    {
                        command.Parameters.AddWithValue("@Nombre", this.tbnombre.Text);
                        command.Parameters.AddWithValue("@Descripcion", this.tbdescripcion.Text);
                        command.Parameters.AddWithValue("@Orden", this.tborden.Text);
                        command.Parameters.AddWithValue("@ID", this.tbid.Text);

                        command.ExecuteNonQuery();
                    }
                }

                // Mostrar una alerta SweetAlert2 después de guardar los datos
                string script = @"<script>
                      Swal.fire({
                          title: 'Datos guardados',
                          text: 'Los datos se han guardado exitosamente.',
                          icon: 'success',
                          confirmButtonText: 'OK'
                      }).then((result) => {
                          if (result.isConfirmed) {
                              window.location.href = 'Variables.aspx';
                          }
                      });
                   </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y mostrar un mensaje de error
                string errorScript = $@"<script>
                               Swal.fire(title: 'Error',
                                  text: 'Hubo un error al guardar los datos. Detalles: {ex.Message}',
                                  icon: 'error',
                                  confirmButtonText: 'OK'
                              );
                           </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlertError", errorScript);
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string delete = "DELETE FROM dbo.GC_VARIAB WHERE strCod_variab = @ID";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (SqlCommand command = new SqlCommand(delete, cn))
                {
                    command.Parameters.AddWithValue("@ID", this.tbid.Text);
                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect("Variables.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Variables.aspx");
        }
    }
}
