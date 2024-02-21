using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsFuentesInformacion
{
    public partial class FuenteInformacionMantenimiento : System.Web.UI.Page
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
                            this.Lbltitulo.Text = "Ingresar nuevo Fuente de Informacion";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista Fuente de Informacion";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Fuente de Informacion";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Fuente de Informacion";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }


        private void CargarDatos()
        {
            FuenteIViewModel fuentei = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_FNI WHERE strCod_fni = '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fuentei = new FuenteIViewModel
                        {
                            Id = reader["strCod_fni"].ToString(),
                            Nombre = reader["strNombre_fni"].ToString(),
                            Descripcion = reader["strDescripcion_fni"].ToString(),
                            Orden = reader["strOrden_fni"].ToString(),
                            Est = Convert.ToBoolean(reader["bitAdd_fni"])
                        };
                    }
                }
            }
            cn.Close();
            if (fuentei != null)
            {
                this.tbid.Text = fuentei.Id;
                this.tbnombre.Text = fuentei.Nombre;
                this.tbdescripcion.Text = fuentei.Descripcion;
                this.tborden.Text = fuentei.Orden;
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Lógica para insertar datos
                string insert = $"INSERT INTO dbo.GC_FNI VALUES ('{this.tbid.Text.ToString()}', '{this.tbnombre.Text.ToString()}', '{this.tbdescripcion.Text.ToString()}', '{this.tborden.Text.ToString()}', GETDATE(),'', '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, '')";
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
                                    window.location.href = 'FuentesInformacion.aspx';
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
                // Supongamos que strCod_fuentei la columna que identifica de manera única cada registro
                string update = $@"
                UPDATE dbo.GC_FNI 
                SET strNombre_fni = '{this.tbnombre.Text}', 
                    strDescripcion_fni = '{this.tbdescripcion.Text}', 
                    strOrden_fni = '{this.tborden.Text}'
                WHERE strCod_fni = '{this.tbid.Text}'";


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
                              window.location.href = 'FuentesInformacion.aspx';
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
            string delete = $"DELETE FROM dbo.GC_FNI WHERE strCod_fni = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("FuentesInformacion.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("FuentesInformacion.aspx");
        }
    }

}