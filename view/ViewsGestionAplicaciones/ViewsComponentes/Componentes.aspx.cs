using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace sigac.view.ViewsGestionAplicaciones.ViewsComponentes
{
    public partial class Componentes : Page
    {
        // Define una propiedad para almacenar la lista de componentes en ViewState
        private List<ComponenteViewModel> ListaComponenteViewState
        {
            get
            {
                return ViewState["ListaComponente"] as List<ComponenteViewModel> ?? new List<ComponenteViewModel>();
            }
            set
            {
                ViewState["ListaComponente"] = value;
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
            List<ComponenteViewModel> componentes = ConsultarComponentes();

            // Establecer la lista de componentes en ViewState
            ListaComponenteViewState = componentes;

            GridViewComponentes.DataSource = componentes;
            GridViewComponentes.DataBind();

            // Ocultar la columna "ID"
            GridViewComponentes.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<ComponenteViewModel> ConsultarComponentes()
        {
            List<ComponenteViewModel> listaComponentes = new List<ComponenteViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_COMP";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ComponenteViewModel componente = new ComponenteViewModel
                            {
                                Id = reader["strCod_comp"].ToString(),
                                Nombre = reader["strNombre_comp"].ToString(),
                                Descripcion = reader["strDescripcion_comp"].ToString(),
                                Orden = reader["strOrden_comp"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtFechaMod_comp"]),
                                IdProces = reader["strCod_proces"].ToString(),
                                Est = Convert.ToBoolean(reader["bitAdd_comp"])
                            };

                            listaComponentes.Add(componente);
                        }
                    }
                }
            }

            return listaComponentes;
        }

        protected void EliminarComponente(object sender, CommandEventArgs e)
        {
            string idComponente = e.CommandArgument.ToString();

            // Aquí puedes implementar la lógica para eliminar el componente
            // por ejemplo, llamando a un servicio o manejador de base de datos.

            // Después de eliminar, actualiza la vista
            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsComponentes/ComponenteMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsComponentes/ComponenteMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsComponentes/ComponenteMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsComponentes/ComponenteMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class ComponenteViewModel
    {
        [JsonProperty("strCod_comp")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_comp")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_comp")]
        public string Descripcion { get; set; }

        [JsonProperty("strOrden_comp")]
        public string Orden { get; set; }

        [JsonProperty("dtFechaMod_comp")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [JsonProperty("strCod_proces")]
        [Required]
        public string IdProces { get; set; }

        [JsonProperty("bitAdd_comp")]
        public bool Est { get; set; }

    }
}