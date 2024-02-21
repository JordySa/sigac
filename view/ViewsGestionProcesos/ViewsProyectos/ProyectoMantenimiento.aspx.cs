using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionProcesos.ViewsProyectos
{
    public partial class ProyectoMantenimiento : Page
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
                    sID = Request.QueryString["id"];
                    CargarDatos();
                    CargarVariables(); // Agregar esta línea para cargar las variables
                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"];
                    switch (sOpc)
                    {
                        case "C":
                            Lbltitulo.Text = "Ingresar nuevo Proyecto";
                            BtnCreate.Visible = true;
                            tbid.Text = Guid.NewGuid().ToString();
                            break;
                        case "R":
                            Lbltitulo.Text = "Vista del Proyecto";
                            break;
                        case "U":
                            tbDateI.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            tbDateF.Text = DateTime.Now.ToString("yyyy-MM-dd");

                            tbMomentoIFIn1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            tbMomentoFFIn1.Text = DateTime.Now.ToString("yyyy-MM-dd");

                            tbMomentoIFIn2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            tbMomentoFFIn2.Text = DateTime.Now.ToString("yyyy-MM-dd");

                            tbMomentoIInd1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            tbMomentoFInd1.Text = DateTime.Now.ToString("yyyy-MM-dd");


                            tbMomentoIInd2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            tbMomentoFInd2.Text = DateTime.Now.ToString("yyyy-MM-dd");



                            tbMomentoIInd3.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            tbMomentoFInd3.Text = DateTime.Now.ToString("yyyy-MM-dd");


                            Lbltitulo.Text = "Actualización del Proyecto";
                            tbid.ReadOnly = true;
                            BtnUpdate.Visible = true;
                            CargarDatos();
                            break;
                        case "D":
                            Lbltitulo.Text = "Eliminar Proyecto";
                            tbid.ReadOnly = true;
                            BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        private void CargarVariables()
        {
            CargarListBoxDesdeString(hfSelectedIndic.Value, lbIndic);
        }
        private void CargarListBoxDesdeString(string valores, ListBox listBox)
        {
            listBox.Items.Clear();

            if (!string.IsNullOrEmpty(valores))
            {
                string[] valoresArray = valores.Split(',');

                foreach (var valor in valoresArray)
                {
                    listBox.Items.Add(new ListItem(valor, valor));
                }
            }
        }

        private void CargarDatos()
        {
            ProyectoViewModel proyecto = null;
            cn.Open();
            string queryString = "SELECT * FROM GC_PROYEC WHERE strCod_proyec= @ID";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                command.Parameters.AddWithValue("@ID", sID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proyecto = new ProyectoViewModel
                        {
                            Id = reader["strCod_proyec"].ToString(),
                            Nombre = reader["strNombre_proyec"].ToString(),
                            Descripcion = reader["strDescripcion_proyec"].ToString(),
                            FechaI = Convert.ToDateTime(reader["dtFechaInicio_proyec"]),
                            FechaF = Convert.ToDateTime(reader["dtFechaFin_proyec"]),
                            Est = reader["intEst_proyec"].ToString(),
                            IdFunc = reader["strCod_func"].ToString(),
                            IdIdic = reader["strCod_indic"].ToString(),
                            FechaMomentoIFIn1 = Convert.ToDateTime(reader["dtFechaInicioFInMomento1_proyec"]),
                            FechaMomentoFFIn1 = Convert.ToDateTime(reader["dtFechaFinFInMomento1_proyec"]),

                            FechaMomentoIFIn2 = Convert.ToDateTime(reader["dtFechaInicioFInMomento2_proyec"]),
                            FechaMomentoFFIn2 = Convert.ToDateTime(reader["dtFechaFinFInMomento2_proyec"]),


                            FechaMomentoIInd1 = Convert.ToDateTime(reader["dtFechaInicioIndMomento1_proyec"]),
                            FechaMomentoFInd1 = Convert.ToDateTime(reader["dtFechaFinIndMomento1_proyec"]),


                            FechaMomentoIInd2 = Convert.ToDateTime(reader["dtFechaInicioIndMomento2_proyec"]),
                            FechaMomentoFInd2 = Convert.ToDateTime(reader["dtFechaFinIndMomento2_proyec"]),


                            FechaMomentoIInd3 = Convert.ToDateTime(reader["dtFechaInicioIndMomento3_proyec"]),
                            FechaMomentoFInd3 = Convert.ToDateTime(reader["dtFechaFinIndMomento3_proyec"])
                        };
                    }
                }
            }
            cn.Close();
            if (proyecto != null)
            {
                tbid.Text = proyecto.Id;
                tbnombre.Text = proyecto.Nombre;
                tbdescripcion.Text = proyecto.Descripcion;

                tbDateI.Text = proyecto.FechaI.ToString("yyyy-MM-dd");
                tbDateF.Text = proyecto.FechaF.ToString("yyyy-MM-dd");



                tbMomentoIFIn1.Text = proyecto.FechaMomentoIFIn1.ToString("yyyy-MM-dd");
                tbMomentoFFIn1.Text = proyecto.FechaMomentoFFIn1.ToString("yyyy-MM-dd");

                tbMomentoIFIn2.Text = proyecto.FechaMomentoIFIn2.ToString("yyyy-MM-dd");
                tbMomentoFFIn2.Text = proyecto.FechaMomentoFFIn2.ToString("yyyy-MM-dd");


                tbMomentoIInd1.Text = proyecto.FechaMomentoIInd1.ToString("yyyy-MM-dd");
                tbMomentoFInd1.Text = proyecto.FechaMomentoFInd1.ToString("yyyy-MM-dd");


                tbMomentoIInd2.Text = proyecto.FechaMomentoIInd2.ToString("yyyy-MM-dd");
                tbMomentoFInd2.Text = proyecto.FechaMomentoFInd2.ToString("yyyy-MM-dd");


                tbMomentoIInd3.Text = proyecto.FechaMomentoIInd3.ToString("yyyy-MM-dd");
                tbMomentoFInd3.Text = proyecto.FechaMomentoFInd3.ToString("yyyy-MM-dd");


                hfSelectedIndic.Value = proyecto.IdIdic;
                ddlEst.SelectedValue = proyecto.Est;
            }
        }


        private bool VerificarRangoFechasAceptable(DateTime fechaInicioRango, DateTime fechaFinRango, DateTime fechaInicio, DateTime fechaFin)
        {
            return (fechaInicio >= fechaInicioRango && fechaFin <= fechaFinRango);
        }
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {

                //Funcion Inicial
                DateTime fechaInicioFInMomento1 = DateTime.ParseExact(tbMomentoIFIn1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinFInMomento1 = DateTime.ParseExact(tbMomentoFFIn1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime fechaInicioFInMomento2 = DateTime.ParseExact(tbMomentoIFIn2.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinFInMomento2 = DateTime.ParseExact(tbMomentoFFIn2.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                //Indicador
                DateTime fechaInicioIndMomento1 = DateTime.ParseExact(tbMomentoIInd1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinIndMomento1 = DateTime.ParseExact(tbMomentoFInd1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime fechaInicioIndMomento2 = DateTime.ParseExact(tbMomentoIInd2.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinIndMomento2 = DateTime.ParseExact(tbMomentoFInd2.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime fechaInicioIndMomento3 = DateTime.ParseExact(tbMomentoIInd3.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinIndMomento3 = DateTime.ParseExact(tbMomentoFInd3.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);


                // Validar el rango de fechas aceptables
                DateTime fechaInicio = DateTime.ParseExact(tbDateI.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(tbDateF.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                if (!VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioFInMomento1, fechaFinFInMomento1)
                    || !VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioIndMomento1, fechaFinFInMomento2)
                    || !VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioFInMomento2, fechaFinFInMomento2)
                    || !VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioIndMomento2, fechaFinIndMomento2)
                    || !VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioIndMomento3, fechaFinIndMomento3))
                {
                    MostrarMensajeError("Las fechas de los momentos no deben estar fuera del rango especificado.");
                    return;
                }




                string insert = @"
                    INSERT INTO dbo.GC_PROYEC 
                    VALUES (@Id, @Nombre, @Descripcion, GETDATE(), @Est, '', '', '', '', '', '', GETDATE(), '', '', '', '', '', '', 0.00, '', @FechaInicio, @FechaFin, @FechaInicioFInMomento1, @FechaFinFInMomento1, @FechaInicioFInMomento2, @FechaFinFInMomento2, @FechaInicioIndMomento3, @FechaFinIndMomento3, @FechaInicioIndMomento1, @FechaFinIndMomento1, @FechaInicioIndMomento2, @FechaFinIndMomento2, @Indic)";

                cn.Open();
                using (SqlCommand command = new SqlCommand(insert, cn))
                {
                    command.Parameters.AddWithValue("@Id", tbid.Text);
                    command.Parameters.AddWithValue("@Nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@Descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);
                    command.Parameters.AddWithValue("@Est", ddlEst.Text);
                    command.Parameters.AddWithValue("@Indic", hfSelectedIndic.Value);


                    //Fuente de informacion
                    command.Parameters.AddWithValue("@FechaInicioFInMomento1", fechaInicioFInMomento1);
                    command.Parameters.AddWithValue("@FechaFinFInMomento1", fechaFinFInMomento1);

                    command.Parameters.AddWithValue("@FechaInicioFInMomento2", fechaInicioFInMomento2);
                    command.Parameters.AddWithValue("@FechaFinFInMomento2", fechaFinFInMomento2);

                    //Indicador
                    command.Parameters.AddWithValue("@FechaInicioIndMomento1", fechaInicioIndMomento1);
                    command.Parameters.AddWithValue("@FechaFinIndMomento1", fechaFinIndMomento1);


                    command.Parameters.AddWithValue("@FechaInicioIndMomento2", fechaInicioIndMomento2);
                    command.Parameters.AddWithValue("@FechaFinIndMomento2", fechaFinIndMomento2);

                    command.Parameters.AddWithValue("@FechaInicioIndMomento3", fechaInicioIndMomento3);
                    command.Parameters.AddWithValue("@FechaFinIndMomento3", fechaFinIndMomento3);


                    command.ExecuteNonQuery();
                }
                cn.Close();

                MostrarMensajeExitoso("Datos guardados exitosamente.", "Proyectos.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Hubo un error al guardar los datos. Detalles: {ex.Message}");
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                //Funcion Inicial
                DateTime fechaInicioFInMomento1 = DateTime.ParseExact(tbMomentoIFIn1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinFInMomento1 = DateTime.ParseExact(tbMomentoFFIn1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime fechaInicioFInMomento2 = DateTime.ParseExact(tbMomentoIFIn2.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinFInMomento2 = DateTime.ParseExact(tbMomentoFFIn2.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                //Indicador
                DateTime fechaInicioIndMomento1 = DateTime.ParseExact(tbMomentoIInd1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinIndMomento1 = DateTime.ParseExact(tbMomentoFInd1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime fechaInicioIndMomento2 = DateTime.ParseExact(tbMomentoIInd2.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinIndMomento2 = DateTime.ParseExact(tbMomentoFInd2.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime fechaInicioIndMomento3 = DateTime.ParseExact(tbMomentoIInd3.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFinIndMomento3 = DateTime.ParseExact(tbMomentoFInd3.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                // Validar el rango de fechas aceptables
                DateTime fechaInicio = DateTime.ParseExact(tbDateI.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(tbDateF.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                if (!VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioFInMomento1, fechaFinFInMomento1)
                    || !VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioIndMomento1, fechaFinFInMomento2)
                    || !VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioFInMomento2, fechaFinFInMomento2)
                    || !VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioIndMomento2, fechaFinIndMomento2)
                    || !VerificarRangoFechasAceptable(fechaInicio, fechaFin, fechaInicioIndMomento3, fechaFinIndMomento3))
                {
                    
                    MostrarMensajeError("Las fechas de los momentos no deben estar fuera del rango especificado.");
                    return;
                }

                    string update = @"
    UPDATE dbo.GC_PROYEC 
    SET strNombre_proyec = @Nombre, 
        strDescripcion_proyec = @Descripcion, 
        dtFechaInicio_proyec = @FechaInicio, 
        dtFechaFin_proyec = @FechaFin,
        intEst_proyec = @Est, 
        strCod_indic = @Indic,
        dtFechaInicioFInMomento1_proyec = @FechaInicioFInMomento1,
        dtFechaFinFInMomento1_proyec = @FechaFinFInMomento1,
        dtFechaInicioFInMomento2_proyec = @FechaInicioFInMomento2,
        dtFechaFinFInMomento2_proyec = @FechaFinFInMomento2,
        dtFechaInicioIndMomento1_proyec = @FechaInicioIndMomento1,
        dtFechaFinIndMomento1_proyec = @FechaFinIndMomento1,
        dtFechaInicioIndMomento2_proyec = @FechaInicioIndMomento2,
        dtFechaFinIndMomento2_proyec = @FechaFinIndMomento2,
        dtFechaInicioIndMomento3_proyec = @FechaInicioIndMomento3,
        dtFechaFinIndMomento3_proyec = @FechaFinIndMomento3
    WHERE strCod_proyec = @Id";
                cn.Open();
                using (SqlCommand command = new SqlCommand(update, cn))
                {
                    command.Parameters.AddWithValue("@Id", tbid.Text);
                    command.Parameters.AddWithValue("@Nombre", tbnombre.Text);
                    command.Parameters.AddWithValue("@Descripcion", tbdescripcion.Text);
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);
                    command.Parameters.AddWithValue("@Est", ddlEst.Text);
                    command.Parameters.AddWithValue("@Indic", hfSelectedIndic.Value);



                    //Fuente de informacion
                    command.Parameters.AddWithValue("@FechaInicioFInMomento1", fechaInicioFInMomento1);
                    command.Parameters.AddWithValue("@FechaFinFInMomento1", fechaFinFInMomento1);

                    command.Parameters.AddWithValue("@FechaInicioFInMomento2", fechaInicioFInMomento2);
                    command.Parameters.AddWithValue("@FechaFinFInMomento2", fechaFinFInMomento2);

                    //Indicador
                    command.Parameters.AddWithValue("@FechaInicioIndMomento1", fechaInicioIndMomento1);
                    command.Parameters.AddWithValue("@FechaFinIndMomento1", fechaFinIndMomento1);


                    command.Parameters.AddWithValue("@FechaInicioIndMomento2", fechaInicioIndMomento2);
                    command.Parameters.AddWithValue("@FechaFinIndMomento2", fechaFinIndMomento2);

                    command.Parameters.AddWithValue("@FechaInicioIndMomento3", fechaInicioIndMomento3);
                    command.Parameters.AddWithValue("@FechaFinIndMomento3", fechaFinIndMomento3);


                    command.ExecuteNonQuery();
                }
                cn.Close();

                MostrarMensajeExitoso("Datos actualizados exitosamente.", "Proyectos.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Hubo un error al actualizar los datos. Detalles: {ex.Message}");
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = $"DELETE FROM dbo.GC_PROYEC WHERE strCod_proyec = '{tbid.Text}'";
                cn.Open();
                using (SqlCommand command = new SqlCommand(delete, cn))
                {
                    command.ExecuteNonQuery();
                }
                cn.Close();

                Response.Redirect("Proyectos.aspx");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Hubo un error al eliminar el proyecto. Detalles: {ex.Message}");
            }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proyectos.aspx");
        }

        protected void BtnMostrarVentanaFlotante_Click(object sender, EventArgs e)
        {
            string urlVentanaFlotante = "/view/ViewsGestionProcesos/ViewsMomentos/MomentoMantenimiento?op=C";
            string script = $"window.open('{urlVentanaFlotante}', 'VentanaFlotante', 'width=' + screen.width + ', height=' + screen.height + ', scrollbars=yes, resizable=yes');";
            ScriptManager.RegisterStartupScript(this, GetType(), "VentanaFlotante", script, true);
        }

        private void MostrarMensajeExitoso(string mensaje, string redireccion)
        {
            string script = $@"
                <script>
                    Swal.fire({{
                        title: 'Datos guardados',
                        text: '{mensaje}',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    }}).then((result) => {{
                        if (result.isConfirmed) {{
                            window.location.href = '{redireccion}';
                        }}
                    }});
                </script>";
            ClientScript.RegisterStartupScript(GetType(), "SweetAlert", script);
        }

        private void MostrarMensajeError(string mensaje)
        {
            string script = $@"
                <script>
                    Swal.fire({{
                        title: 'Error',
                        text: '{mensaje}',
                        icon: 'error',
                        confirmButtonText: 'OK'
                    }});
                </script>";
            ClientScript.RegisterStartupScript(GetType(), "SweetAlertError", script);
        }
    }
}
