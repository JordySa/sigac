using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si el usuario no está autenticado, redirige a Login.aspx
            if (Session["UsuarioAutenticado"] == null || !(bool)Session["UsuarioAutenticado"])
            {
                Response.Redirect("/Login.aspx");
            }
            // Continúa con el resto de la lógica del Page_Load si el usuario está autenticado


        }
        /*
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cierra la sesión y redirige a Login.aspx
            Session["UsuarioAutenticado"] = false;
            Response.Redirect("/Login.aspx");
        }*/
    }
}