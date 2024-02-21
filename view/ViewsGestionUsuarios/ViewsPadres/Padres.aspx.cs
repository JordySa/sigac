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

namespace sigac.view.ViewsGestionUsuarios.ViewsPadres
{
    public partial class Padres : System.Web.UI.Page
    {

        private List<PadreViewModel> ListaPadreViewState
        {
            get
            {
                return ViewState["Padre"] as List<PadreViewModel> ?? new List<PadreViewModel>();
            }
            set
            {
                ViewState["Padre"] = value;
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
            List<PadreViewModel> Padre = ConsultarPadre();

            // Establecer la lista de dimension en ViewState
            ListaPadreViewState = Padre;

            GridViewPadre.DataSource = Padre;
            GridViewPadre.DataBind();

            // Ocultar la columna "ID"
            GridViewPadre.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<PadreViewModel> ConsultarPadre()
        {
            List<PadreViewModel> listaPadre = new List<PadreViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_PADRE";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PadreViewModel Padre = new PadreViewModel
                            {
                                Id = reader["strCod_padre"].ToString(),
                                Nombre = reader["strNombre_padre"].ToString(),
                                Denominacion = reader["strDenominacion_padre"].ToString(),
                            };

                            listaPadre.Add(Padre);
                        }
                    }
                }
            }

            return listaPadre;
        }

        protected void EliminarTipoP(object sender, CommandEventArgs e)
        {
            string idTipoP = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsPadres/PadreMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsPadres/PadreMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsPadres/PadreMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsPadres/PadreMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class PadreViewModel
    {
        [JsonProperty("strCod_padre")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_padre")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDenominacion_padre")]
        [Required]
        public string Denominacion { get; set; }

    }
}
