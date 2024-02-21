using Newtonsoft.Json;
using sigac.view.ViewsGestionAplicaciones.ViewsPeriodicidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsVariables
{
    public partial class Variables : System.Web.UI.Page
    {
        private List<VariableViewModel> ListaVariableViewState
        {
            get
            {
                return ViewState["Variable"] as List<VariableViewModel> ?? new List<VariableViewModel>();
            }
            set
            {
                ViewState["Variable"] = value;
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
            List<VariableViewModel> variable = ConsultarVariable();

            // Establecer la lista de dimension en ViewState
            ListaVariableViewState = variable;

            GridViewVariable.DataSource = variable;
            GridViewVariable.DataBind();

            // Ocultar la columna "ID"
            GridViewVariable.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<VariableViewModel> ConsultarVariable()
        {
            List<VariableViewModel> listaVariable = new List<VariableViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_VARIAB";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VariableViewModel variable = new VariableViewModel
                            {
                                Id = reader["strCod_variab"].ToString(),
                                Nombre = reader["strNombre_variab"].ToString(),
                                Descripcion = reader["strDescripcion_variab"].ToString(),
                                Orden = reader["strOrden_variab"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtFechaMod_variab"]),
                                IdPeriod = reader["strCod_period"].ToString(),
                                Est = Convert.ToBoolean(reader["bitAdd_variab"])
                            };

                            listaVariable.Add(variable);
                        }
                    }
                }
            }

            return listaVariable;
        }

        protected void EliminarVariable(object sender, CommandEventArgs e)
        {
            string idVariable = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsVariables/VariableMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsVariables/VariableMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsVariables/VariableMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsVariables/VariableMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class VariableViewModel
    {
        [JsonProperty("strCod_variab")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_variab")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_variab")]
        public string Descripcion { get; set; }

        [JsonProperty("strOrden_variab")]
        public string Orden { get; set; }

        [JsonProperty("dtFechaMod_variab")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [JsonProperty("strCod_period")]
        [Required]
        public string IdPeriod { get; set; }

        [JsonProperty("bitAdd_variab")]
        public bool Est { get; set; }

    }
}