using Newtonsoft.Json;
using sigac.view.ViewsGestionUsuarios.ViewsEquipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionUsuarios.ViewsRoles
{
    public partial class Roles : System.Web.UI.Page
    {

        private List<RolViewModel> ListaRolViewState
        {
            get
            {
                return ViewState["Rol"] as List<RolViewModel> ?? new List<RolViewModel>();
            }
            set
            {
                ViewState["Rol"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }



        private void BindGridView()
        {
            List<RolViewModel> Rol = ConsultarRol();

            // Establecer la lista de dimension en ViewState
            ListaRolViewState = Rol;

            GridViewRol.DataSource = Rol;
            GridViewRol.DataBind();

            // Ocultar la columna "ID"
            GridViewRol.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<RolViewModel> ConsultarRol()
        {
            List<RolViewModel> listaRol = new List<RolViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_ROL";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RolViewModel Rol = new RolViewModel
                            {
                                Id = reader["strCod_Rol"].ToString(),
                                Nombre = reader["strResProces_Rol"].ToString()
                            };

                            listaRol.Add(Rol);
                        }
                    }
                }
            }

            return listaRol;
        }

        protected void EliminarTipoP(object sender, CommandEventArgs e)
        {
            string idTipoP = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsRoles/RolMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsRoles/RolMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsRoles/RolMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsRoles/RolMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class RolViewModel
    {
        [JsonProperty("strCod_Rol")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strResProces_Rol")]
        [Required]
        public string Nombre { get; set; }


    }
}

