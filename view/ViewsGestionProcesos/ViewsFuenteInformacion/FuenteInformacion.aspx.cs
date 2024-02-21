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

namespace sigac.view.ViewsGestionProcesos.ViewsFuenteInformacion
{
    public partial class FuenteInformacion : System.Web.UI.Page
    {
        private List<FuenteIndormacionViewModel> ListaFuenteIndormacionViewState
        {
            get
            {
                return ViewState["FuenteIndormacion"] as List<FuenteIndormacionViewModel> ?? new List<FuenteIndormacionViewModel>();
            }
            set
            {
                ViewState["FuenteIndormacion"] = value;
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
            List<FuenteIndormacionViewModel> FuenteIndormacion = ConsultarFuenteIndormacion();

            // Establecer la lista de dimension en ViewState
            ListaFuenteIndormacionViewState = FuenteIndormacion;

            GridViewFuenteIndormacion.DataSource = FuenteIndormacion;
            GridViewFuenteIndormacion.DataBind();

            // Ocultar la columna "ID"
            GridViewFuenteIndormacion.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<FuenteIndormacionViewModel> ConsultarFuenteIndormacion()
        {
            List<FuenteIndormacionViewModel> listaFuenteIndormacion = new List<FuenteIndormacionViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_GARGA_FIN";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FuenteIndormacionViewModel FuenteIndormacion = new FuenteIndormacionViewModel
                            {
                                Id = reader["strCod_carga_fin"].ToString(),
                                NombreFNi = reader["strFni_carga_fin"].ToString(),
                                NombreIndic = reader["strIndicador_carga_fin"].ToString(),
                                NombrePadre = reader["strPadre_carga_fin"].ToString(),
                                File = reader["strFile_carga_fin"].ToString(),
                                ProyectoFNi = reader["strProyecto_fin"].ToString(),
                                Momento = reader["strMomento_carga_fin"].ToString()
                            };

                            listaFuenteIndormacion.Add(FuenteIndormacion);
                        }
                    }
                }
            }

            return listaFuenteIndormacion;
        }

        protected void EliminarTipoP(object sender, CommandEventArgs e)
        {
            string idTipoP = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsFuenteInformacion/FuenteIndormacionMantenimiento.aspx?&op=CU");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsFuenteInformacion/FuenteIndormacionMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsFuenteInformacion/FuenteIndormacionMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsFuenteInformacion/FuenteIndormacionMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class FuenteIndormacionViewModel
    {
        [JsonProperty("strCod_carga_fin")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strCod_indic")]
        [Required]
        public string IdIndic { get; set; }

        [JsonProperty("strNombre_indic")]
        [Required]
        public string NombreIndic { get; set; }

        [JsonProperty("strFni_carga_fin")]
        [Required]
        public string NombreFNi { get; set; }

        [JsonProperty("strCod_padre")]
        [Required]
        public string NombrePadre { get; set; }

        [JsonProperty("strFile_carga_fin")]
        public string File { get; set; }

        [JsonProperty("strFile_carga_fin")]
        public string ProyectoFNi { get; set; }

        [JsonProperty("strFile_carga_fin")]
        public string Momento { get; set; }




    }
}
