using sigac.view.ViewsGestionAplicaciones.ViewsPeriodicidades;
using sigac.view.ViewsGestionProcesos.ViewsProyectos;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace sigac.view.ViewsGestionUsuarios.ViewsUsuarios
{
    public partial class UsuarioMantenimiento : Page
    {
        readonly SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"];
                    CargarDatos();
                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"];
                    switch (sOpc)
                    {
                        case "C":
                            Lbltitulo.Text = "Ingresar nuevo Usuario";
                            BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            Lbltitulo.Text = "Vista Usuario";
                            break;
                        case "U":
                            Lbltitulo.Text = "Actualizar Usuario";
                            tbid.ReadOnly = true;
                            BtnUpdate.Visible = true;
                            break;
                        case "D":
                            Lbltitulo.Text = "Eliminar Usuario";
                            tbid.ReadOnly = true;
                            BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        private void CargarDatos()
        {
            UsuarioViewModel usuario = null;
            cn.Open();
            string queryString = "SELECT * FROM GC_USERS WHERE strCod_user= @ID";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                command.Parameters.AddWithValue("@ID", sID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new UsuarioViewModel
                        {
                            Id = reader["strCod_user"].ToString(),
                            Usuario = reader["strUsername_user"].ToString(),
                            Contraseña = reader["strPasswordHash_user"].ToString(),
                            Nombre = reader["strFirstName_user"].ToString(),
                            Apellido = reader["strLastName_user"].ToString(),
                            Correo = reader["strEmail_user"].ToString(),
                            Fecha = Convert.ToDateTime(reader["dtDateCreated_user"]),
                            Est = reader["bitAdd_user"].ToString(),

                            Rol = reader["strCod_Rol"].ToString(),
                            Equipo = reader["strCod_Equip"].ToString()
                        };
                    }
                }
            }
            cn.Close();

            if (usuario != null)
            {
                tbid.Text = usuario.Id;
                tbusuario.Text = usuario.Usuario;
                tbpassword.Text = usuario.Contraseña;
                tbnombre.Text = usuario.Nombre;
                tbapellido.Text = usuario.Apellido;
                tbemail.Text = usuario.Correo;
                ddlEst.SelectedValue = usuario.Est;

                // Seleccionar el valor correspondiente en el DropDownList
                ddlRol.SelectedValue = usuario.Rol;
                ddlequip.SelectedValue = usuario.Equipo;
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string insert = @"
                    INSERT INTO dbo.GC_USERS 
                    VALUES (@Usuario, @Contraseña, @Nombre, @Apellido, @Correo, GETDATE(), '', 0, '', 0, 0, '', 0, '', '', '', '', '', '', '', '', '', '', '', '', '', 0, 0.00, @Rol,@Equip)";

                cn.Open();
                using (SqlCommand command = new SqlCommand(insert, cn))
                {
                    string encriptado = Helper.Encrypt.EncryptCadena(tbpassword.Text, Helper.Encrypt.KeySecret);

                    command.Parameters.AddWithValue("@Usuario", tbusuario.Text);
                    command.Parameters.AddWithValue("@Contraseña", encriptado);
                    command.Parameters.AddWithValue("@Nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@Apellido", tbapellido.Text);
                    command.Parameters.AddWithValue("@Correo", tbemail.Text);
                    command.Parameters.AddWithValue("@Rol", ddlRol.SelectedValue);
                    command.Parameters.AddWithValue("@Equip", ddlequip.SelectedValue);

                    command.ExecuteNonQuery();
                }
                cn.Close();

                MostrarMensajeExitoso("Datos guardados exitosamente.", "Usuarios.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Hubo un error al guardar los datos. Detalles: {ex.Message}");
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string update = @"
                    UPDATE dbo.GC_USERS 
                    SET strUsername_user = @Usuario, 
                        strPasswordHash_user = @Contraseña,
                        strFirstName_user = @Nombre, 
                        strLastName_user = @Apellido, 
                        strEmail_user = @Correo, 
                        strCod_Rol = @Rol,
                        strCod_Equip = @Equip
                    WHERE strCod_user = @ID";

                cn.Open();
                using (SqlCommand command = new SqlCommand(update, cn))
                {
                    string encriptado = Helper.Encrypt.EncryptCadena(tbpassword.Text, Helper.Encrypt.KeySecret);

                    command.Parameters.AddWithValue("@ID", tbid.Text);
                    command.Parameters.AddWithValue("@Usuario", tbusuario.Text);
                    command.Parameters.AddWithValue("@Contraseña", encriptado);
                    command.Parameters.AddWithValue("@Nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@Apellido", tbapellido.Text);
                    command.Parameters.AddWithValue("@Correo", tbemail.Text);
                    command.Parameters.AddWithValue("@Rol", ddlRol.SelectedValue);
                    command.Parameters.AddWithValue("@Equip", ddlequip.SelectedValue);

                    command.ExecuteNonQuery();
                }
                cn.Close();

                MostrarMensajeExitoso("Datos actualizados exitosamente.", "Usuarios.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Hubo un error al actualizar los datos. Detalles: {ex.Message}");
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = "DELETE FROM dbo.GC_USERS WHERE strCod_user = @ID";
                cn.Open();
                using (SqlCommand command = new SqlCommand(delete, cn))
                {
                    command.Parameters.AddWithValue("@ID", tbid.Text);
                    command.ExecuteNonQuery();
                }
                cn.Close();

                Response.Redirect("Usuarios.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Hubo un error al eliminar el usuario. Detalles: {ex.Message}");
            }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        private void MostrarMensajeExitoso(string mensaje, string redireccion)
        {
            string script = $@"
                <script>
                    Swal.fire({{
                        title: 'Datos guardados',
                        text: '{mensaje}',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }}).then((result) => {{
                        if (result.isConfirmed) {{
                            window.location.href = '{redireccion}';
                        }}
                    }});
                </script>";
            ClientScript.RegisterStartupScript(GetType(), "SweetAlert", script);
        }

        private void MostrarMensajeError(string mensaje)
        {
            string script = $@"
                <script>
                    Swal.fire({{
                        title: 'Error',
                        text: '{mensaje}',
                        icon: 'error',
                        confirmButtonText: 'OK'
                    }});
                </script>";
            ClientScript.RegisterStartupScript(GetType(), "SweetAlertError", script);
        }
    }
}
