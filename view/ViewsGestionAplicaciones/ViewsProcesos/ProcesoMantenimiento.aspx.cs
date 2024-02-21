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
                string insert = $"INSERT INTO dbo.GC_PROCES VALUES ('{this.tbid.Text.ToString()}', '{this.tbnombre.Text.ToString()}', '{this.tbdescripcion.Text.ToString()}', '{this.tborden.Text.ToString()}', GETDATE(),'', '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, NULL)";
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
                                    window.location.href = 'Procesos.aspx';
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
                // Supongamos que strCod_ERIOD la columna que identifica de manera única cada registro
                string update = $@"
                UPDATE dbo.GC_PROCES 
                SET strNombre_proces = '{this.tbnombre.Text}', 
                    strDescripcion_proces = '{this.tbdescripcion.Text}', 
                    strOrden_proces = '{this.tborden.Text}'
                WHERE strCod_proces = '{this.tbid.Text}'";


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
                              window.location.href = 'Procesos.aspx';
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