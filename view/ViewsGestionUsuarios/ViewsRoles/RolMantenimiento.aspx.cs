using sigac.view.ViewsGestionProcesos.ViewsMomentos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionUsuarios.ViewsRoles
{
    public partial class RolMantenimiento : System.Web.UI.Page
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
                            this.Lbltitulo.Text = "Ingresar nuevo Rol";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista del Rol";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Rol";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            // Llama a CargarDatos() en caso de actualizar para mostrar las fechas
                            CargarDatos();
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Rol";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }




        private void CargarDatos()
        {
            MomentoViewModel momento = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_ROL WHERE strCod_Rol= '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        momento = new MomentoViewModel
                        {
                            Id = reader["strCod_Rol"].ToString(),
                            Nombre = reader["strResProces_Rol"].ToString()
                        };
                    }
                }
            }
            cn.Close();
            if (momento != null)
            {
                this.tbid.Text = momento.Id;
                this.tbnombre.Text = momento.Nombre;
            }
        }



        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Parsea las fechas al formato esperado en la base de datos

                // Utiliza parámetros en lugar de concatenar directamente en la cadena SQL
                string insert = "INSERT INTO dbo.GC_ROL VALUES (@Id, @Nombre, '', '', '', '', '', '', '', '',  GETDATE(), '', '', '', '', 0, 0.00 )";

                cn.Open();
                using (SqlCommand command = new SqlCommand(insert, cn))
                {
                    // Agrega los parámetros con sus respectivos valores
                    command.Parameters.AddWithValue("@Id", this.tbid.Text.ToString());
                    command.Parameters.AddWithValue("@Nombre", this.tbnombre.Text.ToString()); ;

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
                            window.location.href = 'Roles.aspx';
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

                // Utiliza parámetros en lugar de concatenar directamente en la cadena SQL
                string update = @"
            UPDATE dbo.GC_ROL
            SET strResProces_Rol = @Nombre 
            WHERE strCod_Rol = @Id";

                cn.Open();
                using (SqlCommand command = new SqlCommand(update, cn))
                {
                    // Agrega los parámetros con sus respectivos valores
                    command.Parameters.AddWithValue("@Id", this.tbid.Text.ToString());
                    command.Parameters.AddWithValue("@Nombre", this.tbnombre.Text.ToString()); ;
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
                        window.location.href = 'Roles.aspx';
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
            string delete = $"DELETE FROM dbo.GC_ROL WHERE strCod_Rol = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("Roles.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Roles.aspx");
        }
    }
}