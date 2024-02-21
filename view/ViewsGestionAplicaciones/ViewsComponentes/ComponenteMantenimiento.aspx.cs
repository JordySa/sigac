﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsComponentes
{
    public partial class ComponenteMantenimiento : System.Web.UI.Page
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
                            this.Lbltitulo.Text = "Ingresar nuevo Componente";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista Componente";
                            break;
                        case "U":
                            this.Lbltitulo.Text = "Actualizar Componente";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Componente";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        private void CargarDatos()
        {
            ComponenteViewModel componente = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_COMP WHERE strCod_comp = '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        componente = new ComponenteViewModel
                        {
                            Id = reader["strCod_comp"].ToString(),
                            Nombre = reader["strNombre_comp"].ToString(),
                            Descripcion = reader["strDescripcion_comp"].ToString(),
                            Orden = reader["strOrden_comp"].ToString(),
                            Est = Convert.ToBoolean(reader["bitAdd_comp"])
                        };
                    }
                }
            }
            cn.Close();
            if (componente != null)
            {
                this.tbid.Text = componente.Id;
                this.tbnombre.Text = componente.Nombre;
                this.tbdescripcion.Text = componente.Descripcion;
                this.tborden.Text = componente.Orden;
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Lógica para insertar datos
                string insert = $"INSERT INTO dbo.GC_COMP VALUES ('{this.tbid.Text.ToString()}', '{this.tbnombre.Text.ToString()}', '{this.tbdescripcion.Text.ToString()}', '{this.tborden.Text.ToString()}', GETDATE(),'', '', '', '', '', '', '', GETDATE(), '', '', '', '', '', 0, NULL)";
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
                                    window.location.href = 'Componentes.aspx';
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
            string update = $"UPDATE dbo.GC_COMP SET strNombre_comp = '{this.tbnombre.Text}', strDescripcion_comp = '{this.tbdescripcion.Text}', strOrden_comp = '{this.tborden.Text}' WHERE strCod_comp = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(update, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("Componentes.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string delete = $"DELETE FROM dbo.GC_COMP WHERE strCod_comp = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("Componentes.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Componentes.aspx");
        }
    }
}
