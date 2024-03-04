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

namespace sigac.view.ViewsGestionProcesos.ViewsGestionIndicadores
{
    public partial class GestionIndicadores : System.Web.UI.Page
    {
        private List<GestionIndicadorViewModel> ListaGestionIndicadorViewState
        {
            get
            {
                return ViewState["GestionIndicador"] as List<GestionIndicadorViewModel> ?? new List<GestionIndicadorViewModel>();
            }
            set
            {
                ViewState["GestionIndicador"] = value;
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
            List<GestionIndicadorViewModel> GestionIndicador = ConsultarGestionIndicador();

            // Establecer la lista de dimension en ViewState
            ListaGestionIndicadorViewState = GestionIndicador;

            GridViewGestionIndicador.DataSource = GestionIndicador;
            GridViewGestionIndicador.DataBind();

            // Ocultar la columna "ID"
            GridViewGestionIndicador.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<GestionIndicadorViewModel> ConsultarGestionIndicador()
        {
            List<GestionIndicadorViewModel> listaGestionIndicador = new List<GestionIndicadorViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_GESTION_INDIC";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GestionIndicadorViewModel GestionIndicador = new GestionIndicadorViewModel
                            {
                                Id = reader["strCod_gestion_indic"].ToString(),
                                NombreFNi = reader["strFni_gestion_indic"].ToString(),
                                NombreIndic = reader["strIndicador_gestion_indic"].ToString(),
                                NombrePadre = reader["strPadre_gestion_indic"].ToString(),
                                Argumento = reader["strArgumento_gestion_indic"].ToString(),
                                ProyectoFNi = reader["strFni_gestion_indic"].ToString(),
                                Momento = reader["strMomento_gestion_indic"].ToString(),
                                Variables = reader["strVariables_gestion_indic"].ToString(),
                                DatosVariables = reader["Variables_gestion_indic"].ToString(),
                                Formula = reader["Formula_gestion_indic"].ToString(),
                                Dimension = reader["strUser_Log"].ToString()
                            };

                            listaGestionIndicador.Add(GestionIndicador);
                        }
                    }
                }
            }

            return listaGestionIndicador;
        }

        protected void EliminarTipoP(object sender, CommandEventArgs e)
        {
            string idTipoP = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsGestionIndicadores/GestionIndicadorMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsGestionIndicadores/GestionIndicadoresMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsGestionIndicadores/GestionIndicadoresMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsGestionIndicadores/GestionIndicadoresMantenimiento.aspx?id=" + id + "&op=D");
        }


    }
    [Serializable]
    public class GestionIndicadorViewModel
    {
        [JsonProperty("strCod_carga_fin")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strCod_indic")]
        [Required]
        public string IdIndic { get; set; }

        [JsonProperty("strIndicador_gestion_indic")]
        [Required]
        public string NombreIndic { get; set; }

        [JsonProperty("string_fni")]
        [Required]
        public string NombreFNi { get; set; }

        [JsonProperty("strPadre_gestion_indic")]
        [Required]
        public string NombrePadre { get; set; }

        [JsonProperty("strVariables_gestion_indic")]
        public string Argumento { get; set; }

        [JsonProperty("strProyecto_gestion_indic")]
        public string ProyectoFNi { get; set; }

        [JsonProperty("strMomento_carga_fin")]
        public string Momento { get; set; }


        [JsonProperty("strVariables_gestion_indic")]
        public string Variables { get; set; }

        [JsonProperty("decValor_gestion_indic")]
        public string Valor { get; set; }

        [JsonProperty("Variables_gestion_indic")]
        public string DatosVariables { get; set; }

        [JsonProperty("Formula_gestion_indic")]
        public string Formula { get; set; }

        [JsonProperty("strUser_Log")]
        public string Dimension { get; set; }

    }
}