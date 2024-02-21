using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac
{
    public partial class Header : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cierra la sesión y redirige a Login.aspx
            Session["UsuarioAutenticado"] = false;
            Response.Redirect("/Login.aspx");
        }
    }
}