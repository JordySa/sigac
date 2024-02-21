using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionUsuarios.ViewsEquipos
{
    public partial class Equipos : System.Web.UI.Page
    {

        private List<EquipoViewModel> ListaEquipoViewState
        {
            get
            {
                return ViewState["Equipo"] as List<EquipoViewModel> ?? new List<EquipoViewModel>();
            }
            set
            {
                ViewState["Equipo"] = value;
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
            List<EquipoViewModel> Equipo = ConsultarEquipo();

            // Establecer la lista de dimension en ViewState
            ListaEquipoViewState = Equipo;

            GridViewEquipo.DataSource = Equipo;
            GridViewEquipo.DataBind();

            // Ocultar la columna "ID"
            GridViewEquipo.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<EquipoViewModel> ConsultarEquipo()
        {
            List<EquipoViewModel> listaEquipo = new List<EquipoViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_EQUIP";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EquipoViewModel Equipo = new EquipoViewModel
                            {
                                Id = reader["strCod_Equip"].ToString(),
                                Nombre = reader["strNombre_Equip"].ToString(),
                                Est = reader["intEst_Equip"].ToString(),
                            };

                            listaEquipo.Add(Equipo);
                        }
                    }
                }
            }

            return listaEquipo;
        }

        protected void EliminarTipoP(object sender, CommandEventArgs e)
        {
            string idTipoP = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsEquipos/EquipoMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsEquipos/EquipoMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsEquipos/EquipoMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsEquipos/EquipoMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class EquipoViewModel
    {
        [JsonProperty("strCod_Equip")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_Equip")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("intEst_Equip")]
        [Required]
        public string Est { get; set; }

    }
}

