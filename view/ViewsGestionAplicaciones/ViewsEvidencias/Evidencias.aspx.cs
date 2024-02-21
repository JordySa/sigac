using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsEvidencias
{
    public partial class Evidencias : System.Web.UI.Page
    {
        private List<EvidenciaViewModel> ListaEvidenciaViewState
        {
            get
            {
                return ViewState["ListaEvidencia"] as List<EvidenciaViewModel> ?? new List<EvidenciaViewModel>();
            }
            set
            {
                ViewState["ListaEvidencia"] = value;
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
            List<EvidenciaViewModel> evidencia = ConsultarEvidencias();

            // Establecer la lista de dimension en ViewState
            ListaEvidenciaViewState = evidencia;

            GridViewEvidencias.DataSource = evidencia;
            GridViewEvidencias.DataBind();

            // Ocultar la columna "ID"
            GridViewEvidencias.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<EvidenciaViewModel> ConsultarEvidencias()
        {
            List<EvidenciaViewModel> listaEvidencias = new List<EvidenciaViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_EVID";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EvidenciaViewModel evidencia = new EvidenciaViewModel
                            {
                                Id = reader["strCod_evid"].ToString(),
                                Nombre = reader["strNombre_evid"].ToString(),
                                Descripcion = reader["strDescripcion_evid"].ToString(),
                                Orden = reader["strOrden_evid"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtFechaMod_evid"]),
                                IdFni = reader["strCod_fni"].ToString(),
                                Est = Convert.ToBoolean(reader["bitAdd_evid"])
                            };

                            listaEvidencias.Add(evidencia);
                        }
                    }
                }
            }

            return listaEvidencias;
        }

        protected void EliminarEvidencia(object sender, CommandEventArgs e)
        {
            string idEvidencia = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsEvidencias/EvidenciaMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsEvidencias/EvidenciaMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsEvidencias/EvidenciaMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsEvidencias/EvidenciaMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class EvidenciaViewModel
    {
        [JsonProperty("strCod_evid")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_evid")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_evid")]
        public string Descripcion { get; set; }

        [JsonProperty("strOrden_evid")]
        public string Orden { get; set; }

        [JsonProperty("dtFechaMod_evid")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [JsonProperty("strCod_fni")]
        [Required]
        public string IdFni { get; set; }

        [JsonProperty("bitAdd_evid")]
        public bool Est { get; set; }

    }
}