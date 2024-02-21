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

namespace sigac.view.ViewsGestionAplicaciones.ViewsFuentesInformacion
{
    public partial class FuentesInformacion : System.Web.UI.Page
    {
        private List<FuenteIViewModel> ListaFuenteIViewState
        {
            get
            {
                return ViewState["ListaFuenteI"] as List<FuenteIViewModel> ?? new List<FuenteIViewModel>();
            }
            set
            {
                ViewState["ListaFuenteI"] = value;
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
            List<FuenteIViewModel> fuentei = ConsultarFuenteI();

            // Establecer la lista de dimension en ViewState
            ListaFuenteIViewState = fuentei;

            GridViewFuenteI.DataSource = fuentei;
            GridViewFuenteI.DataBind();

            // Ocultar la columna "ID"
            GridViewFuenteI.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<FuenteIViewModel> ConsultarFuenteI()
        {
            List<FuenteIViewModel> listaFuentesI = new List<FuenteIViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_FNI";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FuenteIViewModel fuentei = new FuenteIViewModel
                            {
                                Id = reader["strCod_fni"].ToString(),
                                Nombre = reader["strNombre_fni"].ToString(),
                                Descripcion = reader["strDescripcion_fni"].ToString(),
                                Orden = reader["strOrden_fni"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtFechaMod_fni"]),
                                IdVariab = reader["strCod_variab"].ToString(),
                                Est = Convert.ToBoolean(reader["bitAdd_fni"])
                            };

                            listaFuentesI.Add(fuentei);
                        }
                    }
                }
            }

            return listaFuentesI;
        }

        protected void EliminarFuenteI(object sender, CommandEventArgs e)
        {
            string idFuentesI = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsFuentesInformacion/FuenteInformacionMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsFuentesInformacion/FuenteInformacionMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsFuentesInformacion/FuenteInformacionMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsFuentesInformacion/FuenteInformacionMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class FuenteIViewModel
    {
        [JsonProperty("strCod_fni")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_fni")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_fni")]
        public string Descripcion { get; set; }

        [JsonProperty("strOrden_fni")]
        public string Orden { get; set; }

        [JsonProperty("dtFechaMod_fni")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [JsonProperty("strCod_variab")]
        [Required]
        public string IdVariab { get; set; }

        [JsonProperty("bitAdd_fni")]
        public bool Est { get; set; }

    }
}