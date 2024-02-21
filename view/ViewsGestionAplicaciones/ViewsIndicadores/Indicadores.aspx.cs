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

namespace sigac.view.ViewsGestionAplicaciones.ViewsIndicadores
{
    public partial class Indicadores : System.Web.UI.Page
    {
        private List<InidicadorViewModel> ListaIndicadorViewState
        {
            get
            {
                return ViewState["Indicador"] as List<InidicadorViewModel> ?? new List<InidicadorViewModel>();
            }
            set
            {
                ViewState["Indicador"] = value;
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
            List<InidicadorViewModel> indicador = ConsultarIndicador();

            // Establecer la lista de dimension en ViewState
            ListaIndicadorViewState = indicador;

            GridViewIndicador.DataSource = indicador;
            GridViewIndicador.DataBind();

            // Ocultar la columna "ID"
            GridViewIndicador.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<InidicadorViewModel> ConsultarIndicador()
        {
            List<InidicadorViewModel> listaIndicador = new List<InidicadorViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT GC_INDIC.*, GC_FUNC.strNombre_func, " +
                      "GC_DIMEN.strNombre_dimen, GC_TPROCES.strNombre_tpro, " +
                      "GC_PROCES.strNombre_proces, GC_COMP.strNombre_comp, " +
                      "GC_PERIOD.strNombre_period, GC_PADRE.strNombre_padre " +
                      "FROM GC_INDIC " +
                      "INNER JOIN GC_FUNC ON GC_INDIC.strCod_func = GC_FUNC.strCod_func " +
                      "INNER JOIN GC_DIMEN ON GC_INDIC.strCod_dimen = GC_DIMEN.strCod_dimen " +
                      "INNER JOIN GC_TPROCES ON GC_INDIC.strCod_tpro = GC_TPROCES.strCod_tpro " +
                      "INNER JOIN GC_PROCES ON GC_INDIC.strCod_proces = GC_PROCES.strCod_proces " +
                      "INNER JOIN GC_COMP ON GC_INDIC.strCod_comp = GC_COMP.strCod_comp " +
                      "INNER JOIN GC_PERIOD ON GC_INDIC.strCod_period = GC_PERIOD.strCod_period " +
                      "INNER JOIN GC_PADRE ON GC_INDIC.strCod_padre = GC_PADRE.strCod_padre";

                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InidicadorViewModel indicador = new InidicadorViewModel
                            {
                                Id = reader["strCod_indic"].ToString(),
                                Nombre = reader["strNombre_indic"].ToString(),
                                Descripcion = reader["strDescripcion_indic"].ToString(),
                                Calculo = reader["strFmCalculo_indic"].ToString(),

                                func = reader["strNombre_func"].ToString(),
                                dimen = reader["strNombre_dimen"].ToString(),
                                tpro = reader["strNombre_tpro"].ToString(),
                                proces = reader["strNombre_proces"].ToString(),
                                comp = reader["strNombre_comp"].ToString(),

                                period = reader["strNombre_period"].ToString(),
                                variab = reader["string_variab"].ToString(),
                                fni = reader["string_fni"].ToString(),
                                evid = reader["string_evid"].ToString(),
                                padre = reader["strNombre_padre"].ToString(),

                                EquipProces = reader["strCod_EquipProces"].ToString(),

                                EquipIndMom1 = reader["strCod_EquipIndMom1"].ToString(),
                                EquipFueMom1 = reader["strCod_EquipFueMom1"].ToString(),

                                EquipIndMom2 = reader["strCod_EquipIndMom2"].ToString(),
                                EquipFueMom2 = reader["strCod_EquipFueMom2"].ToString(),

                                EquipIndMom3 = reader["strCod_EquipIndMom3"].ToString(),

                                EvidProces = reader["strCod_EvidProces"].ToString(),

                            };

                            listaIndicador.Add(indicador);
                        }
                    }
                }
            }

            return listaIndicador;
        }

    

    protected void EliminarPeriodicidad(object sender, CommandEventArgs e)
        {
            string idPeriodicidad = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsIndicadores/IndicadorMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsIndicadores/IndicadorMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsIndicadores/IndicadorMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsIndicadores/IndicadorMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class InidicadorViewModel
    {
        [JsonProperty("strCod_indic")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_indic")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_indic")]
        public string Descripcion { get; set; }

        [JsonProperty("strFmCalculo_indic")]
        public string Calculo { get; set; }



        [JsonProperty("strCod_func")]
        [Required]
        public string func { get; set; }

        [JsonProperty("strCod_dimen")]
        [Required]
        public string dimen { get; set; }


        [JsonProperty("strCod_tpro")]
        [Required]
        public string tpro { get; set; }

        [JsonProperty("strCod_proces")]
        [Required]
        public string proces { get; set; }

        [JsonProperty("strCord_comp")]
        [Required]
        public string comp { get; set; }

        [JsonProperty("strCod_period")]
        [Required]
        public string period { get; set; }

        [JsonProperty("string_variab")]
        [Required]
        public string variab { get; set; }

        [JsonProperty("string_fni")]
        [Required]
        public string fni { get; set; }

        [JsonProperty("string_evid")]
        [Required]
        public string evid { get; set; }


        [JsonProperty("strCod_padre")]
        [Required]
        public string padre { get; set; }




        [JsonProperty("strCod_EquipProces")]
        [Required]
        public string EquipProces { get; set; }



        [JsonProperty("strCod_EquipIndMom1")]
        [Required]
        public string EquipIndMom1 { get; set; }


        [JsonProperty("strCod_EquipFueMom1")]
        [Required]
        public string EquipFueMom1 { get; set; }


        [JsonProperty("strCod_EquipIndMom2")]
        [Required]
        public string EquipIndMom2 { get; set; }


        [JsonProperty("strCod_EquipFueMom2")]
        [Required]
        public string EquipFueMom2 { get; set; }


        [JsonProperty("strCod_EquipIndMom3")]
        [Required]
        public string EquipIndMom3 { get; set; }



        // Nueva propiedad para el nombre del rol
        [JsonProperty("strNombre_func")]
        public string NombreFunc{ get; set; }


        [JsonProperty("strCod_EvidProces")]
        [Required]
        public string EvidProces { get; set; }



    }
}