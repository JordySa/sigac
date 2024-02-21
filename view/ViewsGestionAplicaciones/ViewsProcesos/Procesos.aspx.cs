using Newtonsoft.Json;
using sigac.view.ViewsGestionAplicaciones.ViewsTiposProcesos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsProcesos
{
    public partial class Procesos : System.Web.UI.Page
    {

        private List<ProcesoViewModel> ListaProcesoViewState
        {
            get
            {
                return ViewState["Proceso"] as List<ProcesoViewModel> ?? new List<ProcesoViewModel>();
            }
            set
            {
                ViewState["Proceso"] = value;
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
            List<ProcesoViewModel> Proceso = ConsultarProceso();

            // Establecer la lista de dimension en ViewState
            ListaProcesoViewState = Proceso;

            GridViewProceso.DataSource = Proceso;
            GridViewProceso.DataBind();

            // Ocultar la columna "ID"
            GridViewProceso.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<ProcesoViewModel> ConsultarProceso()
        {
            List<ProcesoViewModel> listaProceso = new List<ProcesoViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_PROCES";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProcesoViewModel Proceso = new ProcesoViewModel
                            {
                                Id = reader["strCod_proces"].ToString(),
                                Nombre = reader["strNombre_proces"].ToString(),
                                Descripcion = reader["strDescripcion_proces"].ToString(),
                                Orden = reader["strOrden_proces"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtFechaMod_proces"]),
                                IdTPro = reader["strCod_tpro"].ToString(),
                                Est = Convert.ToBoolean(reader["bitAdd_proces"])
                            };

                            listaProceso.Add(Proceso);
                        }
                    }
                }
            }

            return listaProceso;
        }

        protected void EliminarTipoP(object sender, CommandEventArgs e)
        {
            string idTipoP = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsProcesos/ProcesoMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsProcesos/ProcesoMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsProcesos/ProcesoMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsProcesos/ProcesoMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class ProcesoViewModel
    {
        [JsonProperty("strCod_proces")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_proces")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_proces")]
        public string Descripcion { get; set; }

        [JsonProperty("strOrden_proces")]
        public string Orden { get; set; }

        [JsonProperty("dtFechaMod_proces")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [JsonProperty("strCod_tpro")]
        [Required]
        public string IdTPro { get; set; }

        [JsonProperty("bitAdd_proces")]
        public bool Est { get; set; }

    }
}
