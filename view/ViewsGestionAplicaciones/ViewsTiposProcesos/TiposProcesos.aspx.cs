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

namespace sigac.view.ViewsGestionAplicaciones.ViewsTiposProcesos
{
    public partial class TiposProcesos : System.Web.UI.Page
    {
        private List<TipoPViewModel> ListaTipoPViewState
        {
            get
            {
                return ViewState["TipoP"] as List<TipoPViewModel> ?? new List<TipoPViewModel>();
            }
            set
            {
                ViewState["TipoP"] = value;
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
            List<TipoPViewModel> tipoP = ConsultarTipoP();

            // Establecer la lista de dimension en ViewState
            ListaTipoPViewState = tipoP;

            GridViewTipoP.DataSource = tipoP;
            GridViewTipoP.DataBind();

            // Ocultar la columna "ID"
            GridViewTipoP.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<TipoPViewModel> ConsultarTipoP()
        {
            List<TipoPViewModel> listaTipoP = new List<TipoPViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_TPROCES";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoPViewModel tipoP = new TipoPViewModel
                            {
                                Id = reader["strCod_tpro"].ToString(),
                                Nombre = reader["strNombre_tpro"].ToString(),
                                Descripcion = reader["strDescripcion_tpro"].ToString(),
                                Orden = reader["strOrden_tpro"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtFechaMod_tpro"]),
                                IdDimen = reader["strCod_dimen"].ToString(),
                                Est = Convert.ToBoolean(reader["bitAdd_tpro"])
                            };

                            listaTipoP.Add(tipoP);
                        }
                    }
                }
            }

            return listaTipoP;
        }

        protected void EliminarTipoP(object sender, CommandEventArgs e)
        {
            string idTipoP = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsTiposProcesos/TipoProcesoMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsTiposProcesos/TipoProcesoMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsTiposProcesos/TipoProcesoMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsTiposProcesos/TipoProcesoMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class TipoPViewModel
    {
        [JsonProperty("strCod_tpro")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_tpro")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_tpro")]
        public string Descripcion { get; set; }

        [JsonProperty("strOrden_tpro")]
        public string Orden { get; set; }

        [JsonProperty("dtFechaMod_tpro")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [JsonProperty("strCod_dimen")]
        [Required]
        public string IdDimen { get; set; }

        [JsonProperty("bitAdd_tpro")]
        public bool Est { get; set; }

    }
}