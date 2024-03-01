using sigac.view.ViewsGestionAplicaciones.ViewsFunciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionProcesos.ViewsFuenteInformacion
{
    public partial class FuenteIndormacionMantenimiento : System.Web.UI.Page
    {


        readonly SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";


private string rutaCarpeta = @"C:\Users\chris\OneDrive\Escritorio\git\correccion\sigac\file-source";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                // Verificar si los parámetros nombreFNi, nombreIndic, nombrePadre y momento están presentes en la URL
                if (Request.QueryString["nombreFNi"] != null &&
                    Request.QueryString["nombreIndic"] != null &&
                    Request.QueryString["nombrePadre"] != null &&
                    Request.QueryString["dimension"] != null &&
                    Request.QueryString["momento"] != null)
                {
                    // Obtener los valores de nombreFNi, nombreIndic, nombrePadre y momento de la URL
                    string nombreFNi = Request.QueryString["nombreFNi"].ToString();
                    string nombreIndic = Request.QueryString["nombreIndic"].ToString();
                    string dimension = Request.QueryString["dimension"].ToString();
                    string nombrePadreId = Request.QueryString["nombrePadre"].ToString(); // Supongo que esta es la ID del padre
                    int momento = Convert.ToInt32(Request.QueryString["momento"]);

                    // Mostrar los valores en controles, como TextBoxes
                    TxtNombreFNi.Text = nombreFNi;
                    TxtNombreIndic.Text = nombreIndic;
                    TxtNombrePadre.Text = ObtenerNombrePadrePorId(nombrePadreId); // Obtener el nombre del padre por ID
                    TxtMomento.Text = momento.ToString();
                    TxtDimension.Text = dimension.ToString();

                    // Consultar la base de datos para obtener el nombre del proyecto
                    string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sqlQuery = "";

                        if (momento == 1)
                        {
                            sqlQuery = @"SELECT TOP 1 strNombre_proyec
                        FROM GC_PROYEC 
                        WHERE ',' + LTRIM(RTRIM(strCod_indic)) + ',' LIKE @NombreIndic
                        AND GETDATE() BETWEEN dtFechaInicioFInMomento1_proyec AND dtFechaFinFInMomento1_proyec";
                        }
                        else if (momento == 2)
                        {
                            sqlQuery = @"SELECT TOP 1 strNombre_proyec
                        FROM GC_PROYEC 
                        WHERE ',' + LTRIM(RTRIM(strCod_indic)) + ',' LIKE @NombreIndic
                        AND GETDATE() BETWEEN dtFechaInicioFInMomento2_proyec AND dtFechaFinFInMomento2_proyec";
                        }
                        else
                        {
                            // Construir la consulta SQL para otros momentos
                            sqlQuery = @"SELECT TOP 1 strNombre_proyec
                        FROM GC_PROYEC 
                        WHERE ',' + LTRIM(RTRIM(strCod_indic)) + ',' LIKE @NombreIndic
                        AND GETDATE() BETWEEN dtFechaInicioFInMomento3_proyec AND dtFechaFinFInMomento3_proyec";
                        }


                        // Crear el comando SQL
                        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                        {
                            // Añadir parámetros a la consulta
                            command.Parameters.AddWithValue("@NombreIndic", "%," + nombreIndic + ",%");

                            // Ejecutar la consulta y obtener el resultado
                            string projectName = command.ExecuteScalar() as string;

                            if (string.IsNullOrEmpty(projectName))
                            {
                                // Mostrar mensaje de error con SweetAlert2
                                MostrarError("El proyecto no existe.");

                                // Redirigir a la vista especificada
                                Response.Redirect("~/view/PanelControl");
                            }
                            else
                            {
                                // Mostrar el resultado en un control, como un TextBox
                                TxtNombreProyecto.Text = projectName;

                                // Nueva consulta SQL y condicional
                                string sqlGargaFinQuery = @"SELECT *
                                FROM GC_GARGA_FIN
                                WHERE strProyecto_fin = @NombreProyecto 
                                  AND strFni_carga_fin = @NombreFNi";

                                using (SqlCommand commandGargaFin = new SqlCommand(sqlGargaFinQuery, connection))
                                {
                                    // Añadir parámetros a la nueva consulta
                                    commandGargaFin.Parameters.AddWithValue("@NombreProyecto", projectName);
                                    commandGargaFin.Parameters.AddWithValue("@NombreFNi", nombreFNi);

                                    using (SqlDataReader reader = commandGargaFin.ExecuteReader())
                                    {


                                        if (Request.QueryString["op"] != null)
                                        {
                                            sOpc = Request.QueryString["op"].ToString();
                                            switch (sOpc)
                                            {
                                                case "CU":

                                                    if (reader.HasRows)
                                                    {
                                                        this.Lbltitulo.Text = "Actualizar Fuente de Información";
                                                        this.tbid.ReadOnly = true;
                                                        this.BtnUpdate.Visible = true;
                                                        CargarDatos();  // <-- Mover aquí la llamada a CargarDatos()

                                                    }
                                                    else
                                                    {
                                                        // Si no existe el dato
                                                        this.Lbltitulo.Text = "Ingresar nueva Fuente de Información";
                                                        this.BtnCreate.Visible = true;
                                                        // Generar un nuevo UUID para la creación
                                                        this.tbid.Text = Guid.NewGuid().ToString();
                                                    }
                                                    break;
                                                case "R":
                                                    this.Lbltitulo.Text = "Vista de Fuente de Información";
                                                    CargarDatos();  // <-- Mover aquí la llamada a CargarDatos()

                                                    break;

                                            }
                                        }


                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Request.QueryString["id"] != null)
                    {
                        sID = Request.QueryString["id"].ToString();
                        CargarDatosAdmin();
                    }
                    if (Request.QueryString["op"] != null)
                    {
                        sOpc = Request.QueryString["op"].ToString();
                        switch (sOpc)
                        {
                            case "C":
                                this.Lbltitulo.Text = "Ingresar nueva Fuente de Información";
                                this.BtnCreate.Visible = true;
                                // Generar un nuevo UUID para la creación
                                this.tbid.Text = Guid.NewGuid().ToString();
                                this.BtnReturnAdmin.Visible = true;
                                this.BtnReturn.Visible = false;
                                break;
                            case "R":
                                this.Lbltitulo.Text = "Vista Fuente de Información";
                                this.BtnReturnAdmin.Visible = true;
                                this.BtnReturn.Visible = false;
                                CargarDatosAdmin();
                                break;
                            case "U":
                                this.Lbltitulo.Text = "Actualizar Fuente de Información";
                                this.tbid.ReadOnly = true;
                                this.BtnUpdate.Visible = true;
                                this.BtnReturnAdmin.Visible = true;
                                this.BtnReturn.Visible = false;
                                break;
                            case "D":
                                this.Lbltitulo.Text = "Eliminar Fuente de Información";
                                this.tbid.ReadOnly = true;
                                this.BtnDelete.Visible = true;
                                this.BtnReturnAdmin.Visible = true;
                                this.BtnReturn.Visible = false;
                                break;
                        }
                    }
                    else
                    {
                        // Manejar el caso donde no se proporcionan los parámetros esperados en la URL
                        // Puedes redirigir a otra página o mostrar un mensaje de error, según tus necesidades
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
        }

        private string ObtenerNombrePadrePorId(string nombrePadreId)
        {
            // Consultar la base de datos para obtener el nombre del padre por ID
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
            string nombrePadre = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Construir la consulta SQL para obtener el nombre del padre por ID
                string sqlQuery = @"SELECT strNombre_padre
                                   FROM GC_PADRE 
                                   WHERE strCod_padre = @NombrePadreId";

                // Crear el comando SQL
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Añadir parámetros a la consulta
                    command.Parameters.AddWithValue("@NombrePadreId", nombrePadreId);

                    // Ejecutar la consulta y obtener el resultado
                    nombrePadre = command.ExecuteScalar() as string;
                }
            }

            return nombrePadre;
        }

        private void MostrarError(string mensaje)
        {
            // Use SweetAlert2 to display the error message
            string script = $@"
                <script>
                    document.addEventListener('DOMContentLoaded', function() {{
                        Swal.fire({{
                            icon: 'error',
                            title: 'Error',
                            text: '{mensaje}',
                            confirmButtonColor: '#3085d6',
                            confirmButtonText: 'OK'
                        }});
                    }});
                </script>";

            // Add the script to the Page's header
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script);
        }




        private void CargarDatosAdmin()
        {
            FuenteIndormacionViewModel funcion = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_GARGA_FIN WHERE strCod_carga_fin = '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        funcion = new FuenteIndormacionViewModel
                        {
                            Id = reader["strCod_carga_fin"].ToString(),
                            NombreFNi = reader["strFni_carga_fin"].ToString(),
                            NombreIndic = reader["strIndicador_carga_fin"].ToString(),
                            NombrePadre = reader["strPadre_carga_fin"].ToString(),
                            File = reader["strFile_carga_fin"].ToString(),
                            ProyectoFNi = reader["strProyecto_fin"].ToString(),
                            Momento = reader["strMomento_carga_fin"].ToString(),
                            Dimencion = reader["strDimencion"].ToString()
                        };
                    }
                }
            }
            cn.Close();
            if (funcion != null)
            {

                this.tbid.Text = funcion.Id;
                this.TxtNombreFNi.Text = funcion.NombreFNi;
                this.TxtMomento.Text = funcion.Momento;
                this.TxtNombreProyecto.Text = funcion.ProyectoFNi;
                this.TxtDimension.Text = funcion.Dimencion;


                // Obtener la lista de nombres de archivos desde el campo File en la base de datos
                List<string> nombresArchivosBD = funcion.File.Split(',').Select(x => x.Trim()).ToList();


                // Actualizar la GridView con la lista de archivos cargados
                ActualizarGridViewAdmin(rutaCarpeta, nombresArchivosBD);
            }
        }


        private void ActualizarGridViewAdmin(string rutaCarpeta, List<string> nombresArchivosBD)
        {
            // Obtener la lista de archivos en la carpeta
            string[] archivos = Directory.GetFiles(rutaCarpeta);

            // Crear una lista de objetos para la GridView
            List<object> listaArchivos = new List<object>();

            foreach (string archivo in archivos)
            {
                FileInfo infoArchivo = new FileInfo(archivo);

                // Obtener el nombre del archivo
                string nombreArchivo = Path.GetFileName(archivo);

                // Verificar si el nombre del archivo está en la lista de nombres obtenida de la base de datos
                if (nombresArchivosBD.Contains(nombreArchivo))
                {
                    // Agregar información a la lista
                    listaArchivos.Add(new { NombreArchivo = nombreArchivo, Tamaño = infoArchivo.Length, Ruta = archivo });
                }
            }

            // Enlazar la lista de archivos a la GridView
            gvArchivos.DataSource = listaArchivos;
            gvArchivos.DataBind();
        }

        private void CargarDatos()
        {
            FuenteIndormacionViewModel cargaFni = null;

            // Abre la conexión antes de usarla
            cn.Open();

            string queryString = @"SELECT *
                           FROM GC_GARGA_FIN
                           WHERE strProyecto_fin = @NombreProyecto 
                             AND strFni_carga_fin = @NombreFNi";

            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                command.Parameters.AddWithValue("@NombreProyecto", TxtNombreProyecto.Text); // Usa el valor del TextBox
                command.Parameters.AddWithValue("@NombreFNi", TxtNombreFNi.Text); // Usa el valor del TextBox

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cargaFni = new FuenteIndormacionViewModel
                        {
                            Id = reader["strCod_carga_fin"].ToString(),
                            File = reader["strFile_carga_fin"].ToString(),
                        };
                    }
                }
            }

            // Cierra la conexión después de usarla
            cn.Close();

            if (cargaFni != null)
            {
                this.tbid.Text = cargaFni.Id;

                // Obtener la lista de nombres de archivos desde el campo File en la base de datos
                List<string> nombresArchivosBD = cargaFni.File.Split(',').Select(x => x.Trim()).ToList();


                // Utilizar la ruta de la carpeta proporcionada
                string rutaCompleta = Path.Combine(rutaCarpeta, nombresArchivosBD.FirstOrDefault());

                // Actualizar la GridView con la lista de archivos cargados
                ActualizarGridViewPanelControl(rutaCarpeta, nombresArchivosBD);
            }
        }






        private void ActualizarGridViewPanelControl(string rutaCarpeta, List<string> nombresArchivosBD)
        {
            // Obtener la lista de archivos en la carpeta
            string[] archivos = Directory.GetFiles(rutaCarpeta);

            // Crear una lista de objetos para la GridView
            List<object> listaArchivos = new List<object>();

            foreach (string archivo in archivos)
            {
                FileInfo infoArchivo = new FileInfo(archivo);

                // Obtener el nombre del archivo
                string nombreArchivo = Path.GetFileName(archivo);

                // Verificar si el nombre del archivo está en la lista de nombres obtenida de la base de datos
                if (nombresArchivosBD.Contains(nombreArchivo))
                {
                    // Agregar información a la lista
                    listaArchivos.Add(new { NombreArchivo = nombreArchivo, Tamaño = infoArchivo.Length, Ruta = archivo });
                }
            }

            // Enlazar la lista de archivos a la GridView
            gvArchivos.DataSource = listaArchivos;
            gvArchivos.DataBind();
        }


        protected void DescargarArchivo(object sender, EventArgs e)
        {
            // Obtener el nombre del archivo a descargar desde el CommandArgument del LinkButton
            LinkButton lnkDescargar = (LinkButton)sender;
            string nombreArchivo = lnkDescargar.CommandArgument;

            // Ruta completa del archivo a descargar
            string rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

            // Obtener la longitud del archivo
            FileInfo infoArchivo = new FileInfo(rutaArchivo);
            long tamanoArchivo = infoArchivo.Length;

            // Descargar el archivo al cliente
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);
            Response.AppendHeader("Content-Length", tamanoArchivo.ToString());
            Response.WriteFile(rutaArchivo);
            Response.Flush();
            Response.End();
        }

        protected void EliminarArchivo(object sender, EventArgs e)
        {
            // Obtener el nombre del archivo a eliminar desde el CommandArgument del LinkButton
            LinkButton lnkEliminar = (LinkButton)sender;
            string nombreArchivo = lnkEliminar.CommandArgument;

            // Ruta completa del archivo a eliminar
            string rutaArchivoEliminar = Path.Combine(rutaCarpeta, nombreArchivo);

            // Eliminar el archivo
            File.Delete(rutaArchivoEliminar);

            // Actualizar la GridView después de eliminar el archivo
            ActualizarGridView(rutaCarpeta);
        }


        protected void SubirArchivos_Click(object sender, EventArgs e)
        {
            // Ruta de la carpeta para guardar los archivos

            // Verificar si se seleccionaron archivos
            if (fileUpload.HasFiles)
            {
                // Recorrer cada archivo seleccionado
                foreach (HttpPostedFile archivo in fileUpload.PostedFiles)
                {
                    // Obtener el nombre del archivo sin la extensión
                    string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(archivo.FileName);

                    // Obtener la extensión del archivo
                    string extensionArchivo = Path.GetExtension(archivo.FileName);

                    // Construir un nuevo nombre de archivo con la fecha actual
                    string nuevoNombreArchivo = nombreArchivoSinExtension + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extensionArchivo;

                    // Guardar el archivo en la carpeta especificada con el nuevo nombre
                    archivo.SaveAs(Path.Combine(rutaCarpeta, nuevoNombreArchivo));
                }

                // Actualizar la GridView con la lista de archivos cargados
                ActualizarGridView(rutaCarpeta);
            }
        }

        private List<string> ObtenerListaArchivos(string rutaCarpeta)
        {
            // Obtener la lista de archivos en la carpeta
            string[] archivos = Directory.GetFiles(rutaCarpeta);

            // Crear una lista de nombres de archivos
            List<string> nombresArchivos = new List<string>();

            foreach (string archivo in archivos)
            {
                // Obtener el nombre del archivo
                string nombreArchivo = Path.GetFileName(archivo);

                // Agregar el nombre del archivo a la lista
                nombresArchivos.Add(nombreArchivo);
            }

            return nombresArchivos;
        }


        private List<string> nombresArchivosMostrados = new List<string>();

        private void ActualizarGridView(string rutaCarpeta)
        {
            // Obtener la lista de archivos en la carpeta
            string[] archivos = Directory.GetFiles(rutaCarpeta);

            // Crear una lista de objetos para la GridView
            List<object> listaArchivos = new List<object>();

            foreach (string archivo in archivos)
            {
                FileInfo infoArchivo = new FileInfo(archivo);

                // Verificar si el archivo fue creado o modificado en las últimas 24 horas
                TimeSpan diferenciaTiempo = DateTime.Now - infoArchivo.LastWriteTime;

                if (diferenciaTiempo.TotalMinutes <= 1)
                {
                    // Obtener el nombre del archivo
                    string nombreArchivo = Path.GetFileName(archivo);

                    // Agregar información a la lista
                    listaArchivos.Add(new { NombreArchivo = nombreArchivo, Tamaño = infoArchivo.Length, Ruta = archivo });

                    // Agregar el nombre del archivo a la lista de archivos mostrados
                    nombresArchivosMostrados.Add(nombreArchivo);
                }
            }

            // Enlazar la lista de archivos a la GridView
            gvArchivos.DataSource = listaArchivos;
            gvArchivos.DataBind();
        }








        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta de la carpeta para guardar los archivos

                // Llamada al método para actualizar la GridView y obtener los nombres de archivos mostrados
                ActualizarGridView(rutaCarpeta);

                // Construir la parte de la sentencia SQL para los nombres de archivos
                string nombresArchivosStr = string.Join(",", nombresArchivosMostrados);

                // Lógica para insertar datos
                string insert = $"INSERT INTO dbo.GC_GARGA_FIN VALUES ('{this.tbid.Text.ToString()}', '{this.TxtNombreProyecto.Text.ToString()}', '{this.TxtNombreIndic.Text.ToString()}', '{nombresArchivosStr}', 0 , '{this.TxtNombreFNi.Text.ToString()}', '{this.TxtNombrePadre.Text.ToString()}', '{this.TxtMomento.Text.ToString()}', '{this.TxtDimension.Text.ToString()}', GETDATE(), NULL,  NULL, NULL, NULL, NULL,  0,NULL)";

                cn.Open();
                using (SqlCommand command = new SqlCommand(insert, cn))
                {
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
                    window.location.href = '/view/PanelControl.aspx';
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

                // Ruta de la carpeta para guardar los archivos

                // Llamada al método para actualizar la GridView y obtener los nombres de archivos mostrados
                ActualizarGridView(rutaCarpeta);

                // Construir la parte de la sentencia SQL para los nombres de archivos
                string nombresArchivosStr = string.Join(",", nombresArchivosMostrados);
                // Supongamos que strCod_func es la columna que identifica de manera única cada registro
                string update = $@"
            UPDATE dbo.GC_GARGA_FIN 
            SET strFile_carga_fin = '{nombresArchivosStr}'
            WHERE strCod_carga_fin = '{this.tbid.Text}'";

                cn.Open();
                using (SqlCommand command = new SqlCommand(update, cn))
                {
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
                                    window.location.href = '/view/PanelControl.aspx';
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
        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/view/PanelControl.aspx");
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string delete = $"DELETE FROM dbo.GC_GARGA_FIN WHERE strCod_carga_fin = '{this.tbid.Text}'";
            cn.Open();
            using (SqlCommand command = new SqlCommand(delete, cn))
            {
                command.ExecuteNonQuery();
            }
            cn.Close();
            Response.Redirect("/view/PanelControl.aspx");
        }

    }

}
