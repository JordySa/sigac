using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsFunciones
{
    public partial class Funciones : System.Web.UI.Page
    {
            // Define una propiedad para almacenar la lista de dimensiones en ViewState
            private List<FuncionViewModel> ListaFuncionViewState
            {
                get
                {
                    return ViewState["ListaFuncion"] as List<FuncionViewModel> ?? new List<FuncionViewModel>();
                }
                set
                {
                    ViewState["ListaFuncion"] = value;
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
            List<FuncionViewModel> funcion = ConsultarFunciones();

            // Establecer la lista de dimension en ViewState
            ListaFuncionViewState = funcion;

            GridViewFunciones.DataSource = funcion;
            GridViewFunciones.DataBind();

            // Ocultar la columna "ID"
            GridViewFunciones.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<FuncionViewModel> ConsultarFunciones()
        {
            List<FuncionViewModel> listaFunciones = new List<FuncionViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT * FROM GC_FUNC";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FuncionViewModel funcion = new FuncionViewModel
                            {
                                Id = reader["strCod_func"].ToString(),
                                Nombre = reader["strNombre_func"].ToString(),
                                Descripcion = reader["strDescripcion_func"].ToString(),
                                Orden = reader["strOrden_func"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtFechaMod_func"]),
                                Est = Convert.ToBoolean(reader["bitAdd_func"])
                            };

                            listaFunciones.Add(funcion);
                        }
                    }
                }
            }

            return listaFunciones;
        }

        protected void EliminarFuncion(object sender, CommandEventArgs e)
        {
            string idFuncion = e.CommandArgument.ToString();


            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsFunciones/FuncionMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsFunciones/FuncionMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsFunciones/FuncionMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionAplicaciones/ViewsFunciones/FuncionMantenimiento.aspx?id=" + id + "&op=D");
        }

    }

    [Serializable]
    public class FuncionViewModel
    {
        [JsonProperty("strCod_fun")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strNombre_func")]
        [Required]
        public string Nombre { get; set; }

        [JsonProperty("strDescripcion_func")]
        public string Descripcion { get; set; }

        [JsonProperty("strOrden_func")]
        public string Orden { get; set; }

        [JsonProperty("dtFechaMod_func")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }


        [JsonProperty("bitAdd_func")]
        public bool Est { get; set; }

    }
}