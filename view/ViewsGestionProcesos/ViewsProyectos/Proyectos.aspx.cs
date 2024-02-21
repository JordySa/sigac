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

namespace sigac.view.ViewsGestionProcesos.ViewsProyectos
{
    public partial class Proyectos : System.Web.UI.Page
    {
        
        private List<ProyectoViewModel> ListaProyectoViewState
        {
            get
            {
                return ViewState["Proyecto"] as List<ProyectoViewModel> ?? new List<ProyectoViewModel>();
            }
            set
            {
                ViewState["Proyecto"] = value;
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
            List<ProyectoViewModel> Proyecto = ConsultarProyecto();

            // Establecer la lista de dimension en ViewState
            ListaProyectoViewState = Proyecto;

            GridViewProyecto.DataSource = Proyecto;
            GridViewProyecto.DataBind();

            // Ocultar la columna "ID"
            GridViewProyecto.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<ProyectoViewModel> ConsultarProyecto()
        {
            List<ProyectoViewModel> listaProyecto = new List<ProyectoViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_PROYEC";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProyectoViewModel Proyecto = new ProyectoViewModel
                            {
                                Id = reader["strCod_proyec"].ToString(),
                                Nombre = reader["strNombre_proyec"].ToString(),
                                Descripcion = reader["strDescripcion_proyec"].ToString(),
                                FechaI = Convert.ToDateTime(reader["dtFechaInicio_proyec"]),
                                FechaF = Convert.ToDateTime(reader["dtFechaFin_proyec"]),
                                Est = reader["intEst_proyec"].ToString(),
                                IdFunc = reader["strCod_func"].ToString(),
                                IdIdic = reader["strCod_indic"].ToString(),
                                FechaMomentoIFIn1 = Convert.ToDateTime(reader["dtFechaInicioFInMomento1_proyec"]),
                                FechaMomentoFFIn1 = Convert.ToDateTime(reader["dtFechaFinFInMomento1_proyec"]),

                                FechaMomentoIFIn2 = Convert.ToDateTime(reader["dtFechaInicioFInMomento2_proyec"]),
                                FechaMomentoFFIn2 = Convert.ToDateTime(reader["dtFechaFinFInMomento2_proyec"]),



                                FechaMomentoIInd1 = Convert.ToDateTime(reader["dtFechaInicioIndMomento1_proyec"]),
                                FechaMomentoFInd1 = Convert.ToDateTime(reader["dtFechaFinIndMomento1_proyec"]),

                                FechaMomentoIInd2 = Convert.ToDateTime(reader["dtFechaInicioIndMomento2_proyec"]),
                                FechaMomentoFInd2 = Convert.ToDateTime(reader["dtFechaFinIndMomento2_proyec"]),

                                FechaMomentoIInd3 = Convert.ToDateTime(reader["dtFechaInicioIndMomento3_proyec"]),
                                FechaMomentoFInd3 = Convert.ToDateTime(reader["dtFechaFinIndMomento3_proyec"])
                            };

                            listaProyecto.Add(Proyecto);
                        }
                    }
                }
            }

            return listaProyecto;
        }

        protected void EliminarTipoP(object sender, CommandEventArgs e)
        {
            string idTipoP = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsProyectos/ProyectoMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsProyectos/ProyectoMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsProyectos/ProyectoMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsProyectos/ProyectoMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class ProyectoViewModel
    {
        [JsonProperty("strCod_proyec")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_proyec")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_proyec")]
        public string Descripcion { get; set; }


        [JsonProperty("dtFechaInicio_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaI { get; set; }


        [JsonProperty("dtFechaFin_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaF { get; set; }





        [JsonProperty("dtFechaInicioFInMomento1_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoIFIn1 { get; set; }


        [JsonProperty("dtFechaFinFInMomento1_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoFFIn1 { get; set; }



        [JsonProperty("dtFechaInicioFInMomento2_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoIFIn2 { get; set; }


        [JsonProperty("dtFechaFinFInMomento2_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoFFIn2 { get; set; }









        [JsonProperty("dtFechaInicioIndMomento1_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoIInd1 { get; set; }


        [JsonProperty("dtFechaFinIndMomento1_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoFInd1 { get; set; }



        [JsonProperty("dtFechaInicioIndMomento2_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoIInd2 { get; set; }


        [JsonProperty("dtFechaFinIndMomento2_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoFInd2 { get; set; }



        [JsonProperty("dtFechaInicioIndMomento3_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoIInd3 { get; set; }


        [JsonProperty("dtFechaFinIndMomento3_proyec")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMomentoFInd3 { get; set; }










        [JsonProperty("intEst_proyec")]
        [Required]
        public string Est { get; set; }





        [JsonProperty("strCod_func")]
        [Required]
        public string IdFunc { get; set; }


        [JsonProperty("strCod_indic")]
        [Required]
        public string IdIdic { get; set; }


        [JsonProperty("strCod_momento")]
        [Required]
        public string Momento { get; set; }
    }
}
