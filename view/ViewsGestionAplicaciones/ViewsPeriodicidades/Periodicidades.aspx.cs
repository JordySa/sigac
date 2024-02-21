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

namespace sigac.view.ViewsGestionAplicaciones.ViewsPeriodicidades
{
    public partial class Periodicidades : System.Web.UI.Page
    {
        private List<PeriodicidadViewModel> ListaPeriodicidadViewState
        {
            get
            {
                return ViewState["Periodicidad"] as List<PeriodicidadViewModel> ?? new List<PeriodicidadViewModel>();
            }
            set
            {
                ViewState["Periodicidad"] = value;
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
            List<PeriodicidadViewModel> periodicidad = ConsultarPeriodicidad();

            // Establecer la lista de dimension en ViewState
            ListaPeriodicidadViewState = periodicidad;

            GridViewPeriodicidad.DataSource = periodicidad;
            GridViewPeriodicidad.DataBind();

            // Ocultar la columna "ID"
            GridViewPeriodicidad.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<PeriodicidadViewModel> ConsultarPeriodicidad()
        {
            List<PeriodicidadViewModel> listaPeriodicidad = new List<PeriodicidadViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_PERIOD";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PeriodicidadViewModel periodicidad = new PeriodicidadViewModel
                            {
                                Id = reader["strCod_period"].ToString(),
                                Nombre = reader["strNombre_period"].ToString(),
                                Descripcion = reader["strDescripcion_period"].ToString(),
                                Orden = reader["strOrden_period"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtFechaMod_period"]),
                                IdComp = reader["strCod_comp"].ToString(),
                                Est = Convert.ToBoolean(reader["bitAdd_period"])
                            };

                            listaPeriodicidad.Add(periodicidad);
                        }
                    }
                }
            }

            return listaPeriodicidad;
        }

        protected void EliminarPeriodicidad(object sender, CommandEventArgs e)
        {
            string idPeriodicidad = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsPeriodicidades/PeriodicidadMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsPeriodicidades/PeriodicidadMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsPeriodicidades/PeriodicidadMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsPeriodicidades/PeriodicidadMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class PeriodicidadViewModel
    {
        [JsonProperty("strCod_period")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_period")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_period")]
        public string Descripcion { get; set; }

        [JsonProperty("strOrden_period")]
        public string Orden { get; set; }

        [JsonProperty("dtFechaMod_period")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [JsonProperty("strCod_comp")]
        [Required]
        public string IdComp { get; set; }

        [JsonProperty("bitAdd_period")]
        public bool Est { get; set; }

    }
}