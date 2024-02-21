using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace sigac.view.ViewsGestionAplicaciones.ViewsFunciones
{
    public partial class FuncionMantenimiento : System.Web.UI.Page
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
                            this.Lbltitulo.Text = "Ingresar nuevo Funcion";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista Funcion";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Funcion";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Funcion";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        private void CargarDatos()
        {
            FuncionViewModel funcion = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_FUNC WHERE strCod_func = '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        funcion = new FuncionViewModel
                        {
                            Id = reader["strCod_func"].ToString(),
                            Nombre = reader["strNombre_func"].ToString(),
                            Descripcion = reader["strDescripcion_func"].ToString(),
                            Orden = reader["strOrden_func"].ToString(),
                            Est = Convert.ToBoolean(reader["bitAdd_func"])
                        };
                    }
                }
            }
            cn.Close();
            if (funcion != null)
            {
                this.tbid.Text = funcion.Id;
                this.tbnombre.Text = funcion.Nombre;
                this.tbdescripcion.Text = funcion.Descripcion;
                this.tborden.Text = funcion.Orden;

                // Seleccionar el valor correspondiente en el DropDownList
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Lógica para insertar datos
                string insert = $"INSERT INTO dbo.GC_FUNC VALUES ('{this.tbid.Text.ToString()}', '{this.tbnombre.Text.ToString()}', '{this.tbdescripcion.Text.ToString()}', '{this.tborden.Text.ToString()}', GETDATE(), '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, NULL)";
                cn.Open();
                using (SqlCommand command = new SqlCommand(insert, cn))
                {
                    command.ExecuteNonQuery();
                }
                cn.Close();

                // Mostrar una alerta SweetAlert2 después de guardar los datos
                string script = @"<script>
                            Swal.fire({
                                title: 'Datos guardados',
                                text: 'Los datos se han guardado exitosamente.',
                                icon: 'success',
                                confirmButtonText: 'OK'
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    window.location.href = 'Funciones.aspx';
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
                // Supongamos que strCod_func es la columna que identifica de manera única cada registro
                string update = $@"
            UPDATE dbo.GC_FUNC 
            SET strNombre_func = '{this.tbnombre.Text}', 
                strDescripcion_func = '{this.tbdescripcion.Text}', 
                strOrden_func = '{this.tborden.Text}'
            WHERE strCod_func = '{this.tbid.Text}'";

                cn.Open();
                using (SqlCommand command = new SqlCommand(update, cn))
                {
                    command.ExecuteNonQuery();
                }
                cn.Close();

                // Mostrar una alerta SweetAlert2 después de guardar los datos
                string script = @"<script>
                      Swal.fire({
                          title: 'Datos guardados',
                          text: 'Los datos se han guardado exitosamente.',
                          icon: 'success',
                          confirmButtonText: 'OK'
                      }).then((result) => {
                          if (result.isConfirmed) {
                              window.location.href = 'Funciones.aspx';
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
            string delete = $"DELETE FROM dbo.GC_FUNC WHERE strCod_func = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("Funciones.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Funciones.aspx");
        }
    }

}