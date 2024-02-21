using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionUsuarios.ViewsUsuarios
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private List<UsuarioViewModel> ListaUsuarioViewState
        {
            get
            {
                return ViewState["Usuario"] as List<UsuarioViewModel> ?? new List<UsuarioViewModel>();
            }
            set
            {
                ViewState["Usuario"] = value;
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
            List<UsuarioViewModel> usuario = ConsultarUsuario();

            // Establecer la lista de dimension en ViewState
            ListaUsuarioViewState = usuario;

            GridViewUsuario.DataSource = usuario;
            GridViewUsuario.DataBind();

            // Ocultar la columna "ID"
            GridViewUsuario.Columns.Cast<DataControlField>().FirstOrDefault(f => f.HeaderText == "ID").Visible = false;
        }

        private List<UsuarioViewModel> ConsultarUsuario()
        {
            List<UsuarioViewModel> listaUsuario = new List<UsuarioViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                string queryString = "SELECT GC_USERS.*, GC_ROL.strResProces_Rol FROM GC_USERS INNER JOIN GC_ROL ON GC_USERS.strCod_Rol = GC_ROL.strCod_Rol";
                using (SqlCommand command = new SqlCommand(queryString, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuarioViewModel usuario = new UsuarioViewModel
                            {
                                Id = reader["strCod_user"].ToString(),
                                Usuario = reader["strUsername_user"].ToString(),
                                Contraseña = reader["strPasswordHash_user"].ToString(),
                                Nombre = reader["strFirstName_user"].ToString(),
                                Apellido = reader["strLastName_user"].ToString(),
                                Correo = reader["strEmail_user"].ToString(),
                                Fecha = Convert.ToDateTime(reader["dtDateCreated_user"]),
                                Est = reader["bitAdd_user"].ToString(),
                                Rol = reader["strCod_Rol"].ToString(),
                                Equipo = reader["strCod_Equip"].ToString(),
                                NombreRol = reader["strResProces_Rol"].ToString()
                            };

                            listaUsuario.Add(usuario);
                        }
                    }
                }
            }

            return listaUsuario;
        }

        protected void EliminarUsuario(object sender, CommandEventArgs e)
        {
            string idUsuario = e.CommandArgument.ToString();

            // Lógica para eliminar usuario
            BindGridView();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsUsuarios/UsuarioMantenimiento.aspx?op=C");
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsUsuarios/UsuarioMantenimiento.aspx?id=" + id + "&op=R");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsUsuarios/UsuarioMantenimiento.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnView = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnView.NamingContainer;
            id = selectedRow.Cells[0].Text;
            Response.Redirect("~/view/ViewsGestionUsuarios/ViewsUsuarios/UsuarioMantenimiento.aspx?id=" + id + "&op=D");
        }
    }


[Serializable]
    public class UsuarioViewModel
    {
        [JsonProperty("strCod_user")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("strUsername_user")]
        [Required]
        public string Usuario { get; set; }

        [JsonProperty("strPasswordHash_user")]
        public string Contraseña { get; set; }

        [JsonProperty("strFirstName_user")]
        public string Nombre { get; set; }

        [JsonProperty("strLastName_user")]
        public string Apellido { get; set; }

        [JsonProperty("strEmail_user")]
        public string Correo { get; set; }

        [JsonProperty("dtDateCreated_user")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [JsonProperty("bitAdd_user")]
        [Required]
        public string Est { get; set; }

        [JsonProperty("strCod_respons")]
        [Required]
        public string Rol { get; set; }

        [JsonProperty("strCod_Equip")]
        [Required]
        public string Equipo { get; set; }



        // Nueva propiedad para el nombre del rol
        [JsonProperty("strResProces_Rol")]
        public string NombreRol { get; set; }
    }
}