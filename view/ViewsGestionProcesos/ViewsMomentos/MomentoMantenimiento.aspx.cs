using sigac.view.ViewsGestionProcesos.ViewsProyectos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionProcesos.ViewsMomentos
{
    public partial class MomentoMantenimiento : System.Web.UI.Page
    {
        readonly SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();
                    switch (sOpc)
                    {
                        case "C":
                            this.Lbltitulo.Text = "Ingresar nuevo Momento";
                            this.BtnCreate.Visible = true;
                            // Generar un nuevo UUID para la creación
                            this.tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            this.Lbltitulo.Text = "Vista del Momento";
                            break;
                        case "U":
                            tbDateI.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            tbDateF.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            this.Lbltitulo.Text = "Actualizar Momento";
                            this.tbid.ReadOnly = true;
                            this.BtnUpdate.Visible = true;
                            // Llama a CargarDatos() en caso de actualizar para mostrar las fechas
                            CargarDatos();
                            break;
                        case "D":
                            this.Lbltitulo.Text = "Eliminar Momento";
                            this.tbid.ReadOnly = true;
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }


        private void CargarDatos()
        {
            MomentoViewModel momento = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_MOMENTO WHERE strCod_momento= '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        momento = new MomentoViewModel
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
                    }
                }
            }
            cn.Close();
            if (momento != null)
            {
                this.tbid.Text = momento.Id;
                this.tbnombre.Text = momento.Nombre;
                this.tbarchivo.Text = momento.Archivo;
                this.tbnota.Text = momento.Nota;
                this.tbvalor.Text = momento.decValor;
                // Asignar fechas a los TextBox de fecha
                this.tbDateI.Text = momento.FechaI.ToString("yyyy-MM-dd");
                this.tbDateF.Text = momento.FechaF.ToString("yyyy-MM-dd");

                // Seleccionar el valor correspondiente en el DropDownListownList
                ddlRespons.SelectedValue = momento.IdRespons;
                ddlFni.SelectedValue = momento.IdFni;
                ddlFase.SelectedValue = momento.IdFase;


                // variables booleanas de la DropDownListwnList
                ddlEst.SelectedValue = momento.Est;
            }
        }



        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Parsea las fechas al formato esperado en la base de datos
                DateTime fechaInicio = DateTime.ParseExact(this.tbDateI.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(this.tbDateF.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                // Utiliza parámetros en lugar de concatenar directamente en la cadena SQL
                string insert = "INSERT INTO dbo.GC_MOMENTO VALUES (@Id, @Nombre, @FechaInicio, @FechaFin,@Archivo, '', '', @Est, '',@Nota, '', '', '','', '', '', '', 0, @Valor, '',@Fase,@Fni,@Respon )";

                cn.Open();
                using (SqlCommand command = new SqlCommand(insert, cn))
                {
                    // Agrega los parámetros con sus respectivos valores
                    command.Parameters.AddWithValue("@Id", this.tbid.Text.ToString());
                    command.Parameters.AddWithValue("@Nombre", this.tbnombre.Text.ToString()); ;
                    command.Parameters.AddWithValue("@Archivo", this.tbarchivo.Text.ToString()); ;
                    command.Parameters.AddWithValue("@Nota", this.tbnota.Text.ToString()); ;
                    command.Parameters.AddWithValue("@Valor", this.tbvalor.Text.ToString()); ;

                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);

                    command.Parameters.AddWithValue("@Est", this.ddlEst.Text.ToString());

                    command.Parameters.AddWithValue("@Respon", ddlRespons.SelectedValue);
                    command.Parameters.AddWithValue("@Fni", ddlFni.SelectedValue);
                    command.Parameters.AddWithValue("@Fase", ddlFase.SelectedValue);

                    command.ExecuteNonQuery();
                }
                cn.Close();

                // Mostrar una alerta SweetAlert2 después de guardar los datos
                string script = @"<script>
                    Swal.fire({
                        title: 'Datos guardados',
                        text: 'Los datos se han guardado exitosamente.',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = 'Momentos.aspx';
                        }
                    });
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y mostrar un mensaje de error
                string errorScript = $@"<script>
                            Swal.fire(title: 'Error',
                                text: 'Hubo un error al guardar los datos. Detalles: {ex.Message}',
                                icon: 'error',
                                confirmButtonText: 'OK'
                            );
                        </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlertError", errorScript);
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Parsea las fechas al formato esperado en la base de datos
                DateTime fechaInicio = DateTime.ParseExact(this.tbDateI.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(this.tbDateF.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                // Utiliza parámetros en lugar de concatenar directamente en la cadena SQL
                string update = @"
            UPDATE dbo.GC_MOMENTO 
            SET strNombre_proyec = @Nombre, 
                strDescripcion_proyec = @Descripcion, 
                dtFechaMod_proyec = @FechaInicio, 
                dtFecha_Log = @FechaFin,
                strCod_func = @Func,
                strCod_indic = @Indic
            WHERE strCod_momento = @Id";

                cn.Open();
                using (SqlCommand command = new SqlCommand(update, cn))
                {
                    // Agrega los parámetros con sus respectivos valores
                    command.Parameters.AddWithValue("@Id", this.tbid.Text.ToString());
                    command.Parameters.AddWithValue("@Nombre", this.tbnombre.Text.ToString()); ;
                    command.Parameters.AddWithValue("@Archivo", this.tbarchivo.Text.ToString()); ;
                    command.Parameters.AddWithValue("@Nota", this.tbnota.Text.ToString()); ;

                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);

                    command.Parameters.AddWithValue("@Est", this.ddlEst.Text.ToString());

                    command.Parameters.AddWithValue("@Respon", ddlRespons.SelectedValue);
                    command.Parameters.AddWithValue("@Fni", ddlFni.SelectedValue);
                    command.Parameters.AddWithValue("@Fase", ddlFase.SelectedValue);
                    command.ExecuteNonQuery();
                }
                cn.Close();

                // Mostrar una alerta SweetAlert2 después de guardar los datos
                string script = @"<script>
                Swal.fire({
                    title: 'Datos guardados',
                    text: 'Los datos se han guardado exitosamente.',
                    icon: 'success',
                    confirmButtonText: 'OK'
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = 'Proyectos.aspx';
                    }
                });
            </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y mostrar un mensaje de error
                string errorScript = $@"<script>
                    Swal.fire(title: 'Error',
                        text: 'Hubo un error al guardar los datos. Detalles: {ex.Message}',
                        icon: 'error',
                        confirmButtonText: 'OK'
                    );
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlertError", errorScript);
            }
        }



        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string delete = $"DELETE FROM dbo.GC_MOMENTO WHERE strCod_momento = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("Momentos.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Momentos.aspx");
        }
    }
}