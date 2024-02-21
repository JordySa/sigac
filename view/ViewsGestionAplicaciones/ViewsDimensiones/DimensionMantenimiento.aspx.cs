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
                            this.Lbltitulo.Text = "Ingresar nuevo Dimension";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista Dimension";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Dimension";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Dimension";
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
                // Lógica para insertar datos
                string insert = $"INSERT INTO dbo.GC_DIMEN VALUES ('{this.tbid.Text.ToString()}', '{this.tbnombre.Text.ToString()}', '{this.tbdescripcion.Text.ToString()}', '{this.tborden.Text.ToString()}', GETDATE(),'', '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, NULL)";
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
                                    window.location.href = 'Dimensiones.aspx';
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
                string update = $"UPDATE dbo.GC_DIMEN SET strNombre_dimen = '{this.tbnombre.Text}', strDescripcion_dimen = '{this.tbdescripcion.Text}', strOrden_dimem = '{this.tborden.Text}' WHERE strCod_dimen = '{this.tbid.Text}'";
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
                                    window.location.href = 'Dimensiones.aspx';
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
