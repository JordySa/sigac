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

namespace sigac.view.ViewsGestionProcesos.ViewsMomentos
{
    public partial class Momentos : System.Web.UI.Page
    {

        private List<MomentoViewModel> ListaMomentoViewState
        {
            get
            {
                return ViewState["Momento"] as List<MomentoViewModel> ?? new List<MomentoViewModel>();
            }
            set
            {
                ViewState["Momento"] = value;
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
            List<MomentoViewModel> Momento = ConsultarMomento();

            // Establecer la lista de dimension en ViewState
            ListaMomentoViewState = Momento;

            GridViewMomento.DataSource = Momento;
            GridViewMomento.DataBind();

            // Ocultar la columna "ID"
            GridViewMomento.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<MomentoViewModel> ConsultarMomento()
        {
            List<MomentoViewModel> listaMomento = new List<MomentoViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_MOMENTO";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MomentoViewModel Momento = new MomentoViewModel
                            {
                                Id = reader["strCod_momento"].ToString(),
                                Nombre = reader["strNombre_momento"].ToString(),
                                FechaI = Convert.ToDateTime(reader["dtFechaInicio_momento"]),
                                FechaF = Convert.ToDateTime(reader["dtFechaFin_momento"]),
                                Archivo = reader["vrbFile_momento"].ToString(),
                                Est = reader["strEstado_momento"].ToString(),
                                Nota = reader["strNotas_momento"].ToString(),
                                decValor = reader["decValor_momento"].ToString(),
                                IdRespons = reader["strCod_respons"].ToString(),
                                IdFni = reader["strCod_fni"].ToString(),
                                IdFase = reader["strCod_fase"].ToString()
                            };

                            listaMomento.Add(Momento);
                        }
                    }
                }
            }

            return listaMomento;
        }

        protected void EliminarTipoP(object sender, CommandEventArgs e)
        {
            string idTipoP = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsMomentos/MomentoMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsMomentos/MomentoMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsMomentos/MomentoMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionProcesos/ViewsMomentos/MomentoMantenimiento.aspx?id=" + id + "&op=D");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cierra la sesión y redirige a Login.aspx
            Session["UsuarioAutenticado"] = false;
            Response.Redirect("/Login.aspx");
        }

    }

    [Serializable]
    public class MomentoViewModel
    {
        [JsonProperty("strCod_momento")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_momento")]
        [Required]
        public string Nombre { get; set; }



        [JsonProperty("dtFechaInicio_momento")]
        [DataType(DataType.DateTime)]
        public DateTime FechaI { get; set; }


        [JsonProperty("dtFechaFin_momento")]
        [DataType(DataType.DateTime)]
        public DateTime FechaF { get; set; }





        [JsonProperty("vrbFile_momento")]
        [Required]
        public string Archivo { get; set; }


        [JsonProperty("strEstado_momento")]
        [Required]
        public string Est { get; set; }

        [JsonProperty("strNotas_momento")]
        [Required]
        public string Nota { get; set; }
        [JsonProperty("decValor_momento")]
        [Required]
        public string decValor { get; set; }




        [JsonProperty("strCod_fase")]
        [Required]
        public string IdFase { get; set; }



        [JsonProperty("strCod_fni")]
        [Required]
        public string IdFni { get; set; }


        [JsonProperty("strCod_respons")]
        [Required]
        public string IdRespons { get; set; }
    }
}
