using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac
{
    public partial class Login : System.Web.UI.Page
    {
        readonly SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            // Si el usuario ya está autenticado, redirige a Site.Master
            if (Session["UsuarioAutenticado"] != null && (bool)Session["UsuarioAutenticado"])
            {
                Response.Redirect("/");
            }

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text.Trim();
            string contraseñaIngresada = txtContraseña.Text.Trim();

            // Realiza la autenticación comparando con los datos de la base de datos.
            if (AutenticarUsuario(usuarioIngresado, contraseñaIngresada))
            {
                // Autenticación exitosa, establece la variable de sesión y redirige a Site.Master
                Session["UsuarioAutenticado"] = true;
                Response.Redirect("/");
            }
            else
            {
                // Muestra un mensaje de error si la autenticación falla.
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
                lblMensaje.Visible = true;
            }
        }

        private bool AutenticarUsuario(string usuario, string contraseña)
        {
            cn.Open();

            var pass = string.Empty;

            string queryStringPass = $"SELECT strPasswordHash_user FROM GC_USERS WHERE strEmail_user = '{usuario}'"; //AND strPasswordHash_user = '{contraseña}'";
            using (SqlCommand command = new SqlCommand(queryStringPass, cn))
            {
                pass = command.ExecuteScalar() as string;
                if (string.IsNullOrEmpty(pass) )
                    return false;
                
                string encriptado = Helper.Encrypt.DecryptCadena(pass, Helper.Encrypt.KeySecret);
                if (contraseña.Trim() != encriptado.Trim())
                    return false;
            }

            cn.Close();

            cn.Open();
            string queryString = $"SELECT strCod_Rol, strCod_Equip  FROM GC_USERS WHERE strEmail_user = '{usuario}' AND strPasswordHash_user = '{pass}'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var role = string.Empty;
                    var equipo = string.Empty;
                    while (reader.Read())
                    {
                        role = reader["strCod_Rol"].ToString();
                        equipo = reader["strCod_Equip"].ToString();

                    }

                    if (!string.IsNullOrEmpty(role))
                    {
                        Session["UsuarioAutenticado"] = true;
                        Session["UserRole"] = role;
                        Session["UserEquipo"] = equipo;

                        cn.Close();
                        return true;
                    }
                }
                return false;
            }

        }






        [System.Web.Services.WebMethod]
        public static bool CerrarSesion()
        {
            // Cierra la sesión
            HttpContext.Current.Session["UsuarioAutenticado"] = false;

            // Devuelve true para indicar que la sesión se cerró correctamente
            return true;
        }

    }
}