using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsDimensiones
{
    public partial class Dimensiones : System.Web.UI.Page
    {
        // Define una propiedad para almacenar la lista de dimensiones en ViewState
        private List<DimensionViewModel> ListaDimensionViewState
        {
            get
            {
                return ViewState["ListaDimension"] as List<DimensionViewModel> ?? new List<DimensionViewModel>();
            }
            set
            {
                ViewState["ListaDimension"] = value;
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
            List<DimensionViewModel> dimension = ConsultarDimensiones();

            // Establecer la lista de dimension en ViewState
            ListaDimensionViewState = dimension;

            GridViewDimensiones.DataSource = dimension;
            GridViewDimensiones.DataBind();

            // Ocultar la columna "ID"
            GridViewDimensiones.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<DimensionViewModel> ConsultarDimensiones()
        {
            List<DimensionViewModel> listaDimensiones = new List<DimensionViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_DIMEN";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DimensionViewModel dimension = new DimensionViewModel
                            {
                                Id = reader["strCod_dimen"].ToString(),
                                Nombre = reader["strNombre_dimen"].ToString(),
                                Descripcion = reader["strDescripcion_dimen"].ToString(),
                                Orden = reader["strOrden_dimem"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtFechaMod_dimen"]),
                                IdFunc = reader["strCod_func"].ToString(),
                                Est = Convert.ToBoolean(reader["bitAdd_dimen"])
                            };

                            listaDimensiones.Add(dimension);
                        }
                    }
                }
            }

            return listaDimensiones;
        }

        protected void EliminarDimension(object sender, CommandEventArgs e)
        {
            string idDimension = e.CommandArgument.ToString();

      
            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsDimensiones/DimensionMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsDimensiones/DimensionMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsDimensiones/DimensionMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsDimensiones/DimensionMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class DimensionViewModel
    {
        [JsonProperty("strCod_dimen")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_dimen")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_dimen")]
        public string Descripcion { get; set; }

        [JsonProperty("strOrden_dimem")]
        public string Orden { get; set; }

        [JsonProperty("dtFechaMod_dimen")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [JsonProperty("strCod_func")]
        [Required]
        public string IdFunc { get; set; }

        [JsonProperty("bitAdd_dimen")]
        public bool Est { get; set; }

    }
}