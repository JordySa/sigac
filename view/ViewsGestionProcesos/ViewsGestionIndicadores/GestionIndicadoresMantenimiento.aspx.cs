using NCalc;
using sigac.Helper;
using sigac.view.ViewsGestionAplicaciones.ViewsVariables;
using sigac.view.ViewsGestionProcesos.ViewsFuenteInformacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionProcesos.ViewsGestionIndicadores
{
    public partial class GestionIndicadoresMantenimiento : System.Web.UI.Page
    {
        string rutaCarpeta = @"C:\Users\chris\OneDrive\Escritorio\academico\universidad\practica\otro\sigac\file-source\";

        readonly SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                // Verificar si los parámetros nombreFNi, nombreIndic, nombrePadre y momento están presentes en la URL
                if (Request.QueryString["nombreIndic"] != null &&
                    Request.QueryString["nombrePadre"] != null &&
                    Request.QueryString["nombreFNi"] != null &&
                    Request.QueryString["variables"] != null &&
                    Request.QueryString["formula"] != null &&
                    Request.QueryString["dimension"] != null &&
                    Request.QueryString["momento"] != null)
                {
                    // Obtener los valores de nombreFNi, nombreIndic, nombrePadre y momento de la URL
                    string nombreIndic = Request.QueryString["nombreIndic"].ToString();
                    string nombrePadreId = Request.QueryString["nombrePadre"].ToString();
                    string nombreFNi = Request.QueryString["nombreFNi"].ToString();
                    string variables = Request.QueryString["variables"].ToString();
                    string formula = Request.QueryString["formula"].ToString();
                    string dimension = Request.QueryString["dimension"].ToString();
                    int momento = Convert.ToInt32(Request.QueryString["momento"]);


                    // Mostrar los valores en controles, como TextBoxes
                    TxtNombreIndic.Text = nombreIndic;
                    TxtNombrePadre.Text = ObtenerNombrePadrePorId(nombrePadreId);
                    TxtFNi.Text = nombreFNi;
                    ProcesarVariables(variables);
                    TxtNombreVariable.Text = variables;


                    TxtFormula.Text = Server.HtmlEncode(formula);

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
                                FROM GC_GESTION_INDIC
                                WHERE strProyecto_gestion_indic = @NombreProyecto 
                                  AND strIndicador_gestion_indic = @NombreIndic";

                                using (SqlCommand commandGargaFin = new SqlCommand(sqlGargaFinQuery, connection))
                                {

                                    // Añadir parámetros a la nueva consulta
                                    commandGargaFin.Parameters.AddWithValue("@NombreProyecto", projectName);
                                    commandGargaFin.Parameters.AddWithValue("@NombreIndic", nombreIndic);

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
                                                        this.Lbltitulo.Text = "Actualizar Funcion";
                                                        this.tbid.ReadOnly = true;
                                                        this.BtnUpdate.Visible = true;
                                                        CargarDatos();  // <-- Mover aquí la llamada a CargarDatos()

                                                    }
                                                    else
                                                    {
                                                        // Si no existe el dato
                                                        this.Lbltitulo.Text = "Ingresar nuevo Funcion";
                                                        this.BtnCreate.Visible = true;
                                                        // Generar un nuevo UUID para la creación
                                                        this.tbid.Text = Guid.NewGuid().ToString();

                                                    }
                                                    break;
                                                case "R":
                                                    this.Lbltitulo.Text = "Vista Funcion";
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
                    }
                    if (Request.QueryString["op"] != null)
                    {
                        sOpc = Request.QueryString["op"].ToString();
                        switch (sOpc)
                        {
                            case "C":
                                this.Lbltitulo.Text = "Ingresar nuevo Gestion Indicador";
                                this.BtnCreate.Visible = true;
                                // Generar un nuevo UUID para la creación
                                this.tbid.Text = Guid.NewGuid().ToString();
                                this.BtnReturnAdmin.Visible = true;
                                this.BtnReturn.Visible = false;

                                break;
                            case "R":
                                this.Lbltitulo.Text = "Vista Gestion Indicador";
                                this.BtnReturnAdmin.Visible = true;
                                this.BtnReturn.Visible = false;
                                CargarDatosAdmin();

                                break;
                            case "U":
                                this.Lbltitulo.Text = "Actualizar Gestion Indicador";
                                this.tbid.ReadOnly = true;
                                this.BtnUpdate.Visible = true;
                                this.BtnReturnAdmin.Visible = true;
                                this.BtnReturn.Visible = false;
                                CargarDatosAdmin();

                                break;
                            case "D":
                                this.Lbltitulo.Text = "Eliminar Gestion Indicador";
                                this.tbid.ReadOnly = true;
                                this.BtnDelete.Visible = true;
                                this.BtnReturnAdmin.Visible = true;
                                this.BtnReturn.Visible = false;
                                CargarDatosAdmin();

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


            List<FuenteIndormacionViewModel> listaCargasFni = CargarDatosFNi();

            if (listaCargasFni.Count > 0)
            {
                // Obtener la ruta de la carpeta

                // Llamar al método ActualizarGridViewFIn para mostrar los datos en la GridView
                ActualizarGridViewFIn(rutaCarpeta, listaCargasFni);

                // Asignar el primer NombreFNi a la etiqueta TxtNombreFNi (puedes ajustarlo según tu lógica)
                TxtNombreFNi.Text = listaCargasFni[0].NombreFNi;
            }
        }




        private List<FuenteIndormacionViewModel> CargarDatosFNi()
        {
            List<FuenteIndormacionViewModel> listaCargasFni = new List<FuenteIndormacionViewModel>();

            // Abre la conexión antes de usarla
            cn.Open();

            string queryString = @"SELECT *
                           FROM GC_GARGA_FIN
                           WHERE strProyecto_fin = @NombreProyecto 
                             AND strDimencion = @dimension and 
                            strMomento_carga_fin = @momento and
                            strIndicador_carga_fin = @nombreIndic";

            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                command.Parameters.AddWithValue("@NombreProyecto", TxtNombreProyecto.Text);
                command.Parameters.AddWithValue("@dimension", TxtDimension.Text);
                command.Parameters.AddWithValue("@nombreIndic", TxtNombreIndic.Text);
                command.Parameters.AddWithValue("@momento", TxtMomento.Text);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FuenteIndormacionViewModel cargaFni = new FuenteIndormacionViewModel
                        {
                            Id = reader["strCod_carga_fin"].ToString(),
                            File = reader["strFile_carga_fin"].ToString(),
                            NombreFNi = reader["strFni_carga_fin"].ToString(),
                        };

                        listaCargasFni.Add(cargaFni);
                    }
                }
            }

            // Cierra la conexión después de usarla
            cn.Close();

            return listaCargasFni;
        }

        private void ActualizarGridViewFIn(string rutaCarpeta, List<FuenteIndormacionViewModel> listaCargasFni)
        {
            // Crear una lista de objetos para la GridView
            List<object> listaArchivos = new List<object>();

            foreach (FuenteIndormacionViewModel cargaFni in listaCargasFni)
            {
                // Obtener la lista de nombres de archivos desde el campo File en la base de datos
                List<string> nombresArchivosBD = cargaFni.File.Split(',').Select(x => x.Trim()).ToList();

                // Obtener la lista de archivos en la carpeta
                string[] archivos = Directory.GetFiles(rutaCarpeta);

                foreach (string archivo in archivos)
                {
                    FileInfo infoArchivo = new FileInfo(archivo);

                    // Obtener el nombre del archivo
                    string nombreArchivo = Path.GetFileName(archivo);

                    // Verificar si el nombre del archivo está en la lista de nombres obtenida de la base de datos
                    if (nombresArchivosBD.Contains(nombreArchivo))
                    {
                        // Agregar información a la lista
                        listaArchivos.Add(new { NombreFIn = cargaFni.NombreFNi, NombreArchivo = nombreArchivo, Tamaño = infoArchivo.Length, Ruta = archivo });
                    }
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
            string rutaArchivo = Path.Combine(@"C:\Users\chris\OneDrive\Escritorio\academico\universidad\practica\sigac\file-source\", nombreArchivo);

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


        private void ProcesarVariables(string variables)
        {
            string[] variableArray = variables.Split(new[] { "," }, StringSplitOptions.None);

            foreach (string variable in variableArray)
            {
                // Llamar al nuevo método para procesar cada variable
                ProcesarVariableIndividual(variable.Trim());
            }
        }

        private void CargarDatosAdmin()
        {
            GestionIndicadorViewModel funcion = null;
            cn.Open();
            // Corregir la sintaxis de la consulta
            string queryString = "SELECT * FROM GC_GESTION_INDIC WHERE strCod_gestion_indic = '" + sID + "'";
            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        funcion = new GestionIndicadorViewModel
                        {
                            Id = reader["strCod_gestion_indic"].ToString(),
                            NombreFNi = reader["strFni_gestion_indic"].ToString(),
                            NombreIndic = reader["strIndicador_gestion_indic"].ToString(),
                            NombrePadre = reader["strPadre_gestion_indic"].ToString(),
                            Argumento = reader["strArgumento_gestion_indic"].ToString(),
                            ProyectoFNi = reader["strProyecto_gestion_indic"].ToString(),
                            Momento = reader["strMomento_gestion_indic"].ToString(),
                            Variables = reader["strVariables_gestion_indic"].ToString(),
                            DatosVariables = reader["Variables_gestion_indic"].ToString()
                        };
                    }
                }
            }
            cn.Close();
            if (funcion != null)
            {

                ProcesarVariables(funcion.Variables); // Cambié la referencia a la propiedad 'variables'
                this.tbid.Text = funcion.Id;
                this.TxtMomento.Text = funcion.Momento;
                this.TxtNombreProyecto.Text = funcion.ProyectoFNi;
                this.tbArgumento.Text = funcion.Argumento;
                this.TxtNombreIndic.Text = funcion.NombreIndic;

                // Procesar DatosVariables y asignar valores a TextBoxes
                AsignarValoresTextBox(funcion.DatosVariables);
            }
        }

        private void CargarDatos()
        {
            GestionIndicadorViewModel cargaIndic = null;

            // Abre la conexión antes de usarla
            cn.Open();

            string queryString = @"SELECT *
                           FROM GC_GESTION_INDIC
                           WHERE strProyecto_gestion_indic = @NombreProyecto 
                             AND strIndicador_gestion_indic = @nombreIndic";

            using (SqlCommand command = new SqlCommand(queryString, cn))
            {
                command.Parameters.AddWithValue("@NombreProyecto", TxtNombreProyecto.Text); // Usa el valor del TextBox
                command.Parameters.AddWithValue("@nombreIndic", TxtNombreIndic.Text); // Usa el valor del TextBox

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cargaIndic = new GestionIndicadorViewModel
                        {
                            Id = reader["strCod_gestion_indic"].ToString(),
                            Argumento = reader["strArgumento_gestion_indic"].ToString(),
                            DatosVariables = reader["Variables_gestion_indic"].ToString()
                        };
                    }
                }
            }

            // Cierra la conexión después de usarla
            cn.Close();

            if (cargaIndic != null)
            {
                this.tbid.Text = cargaIndic.Id;
                this.tbArgumento.Text = cargaIndic.Argumento;

                // Procesar DatosVariables y asignar valores a TextBoxes
                AsignarValoresTextBox(cargaIndic.DatosVariables);
            }
        }













        // extraccion de datos segun su ID
        private void AsignarValoresTextBox(string datosVariables)
        {
            // Separar variables y valores usando el delimitador '|'
            string[] paresVariableValor = datosVariables.Split('|');

            foreach (string par in paresVariableValor)
            {
                // Separar cada par variable-valor usando el delimitador ';'
                string[] variableValor = par.Split(';');

                if (variableValor.Length == 2)
                {
                    string variable = variableValor[0].Trim();
                    string valor = variableValor[1].Trim();

                    // Asignar valor al TextBox correspondiente según la variable
                    AsignarValorAlTextBox(variable, valor);
                }
            }
        }

        private void AsignarValorAlTextBox(string variable, string valor)
        {
            TextBox textBox = FindTextBoxById(variable);

            if (textBox != null)
            {
                textBox.Text = valor;
            }
        }

        private TextBox FindTextBoxById(string id)
        {
            // Buscar el control TextBox por su ID recursivamente
            Control control = FindControlRecursive(this, id);
            return control as TextBox;
        }

        private Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }

            foreach (Control control in root.Controls)
            {
                Control foundControl = FindControlRecursive(control, id);
                if (foundControl != null)
                {
                    return foundControl;
                }
            }

            return null;
        }


        //calculadora 



        /* boton para calcular 
                protected void BtnCalcular_Click(object sender, EventArgs e)
                {
                    // Obtener y ejecutar la fórmula al hacer clic en el botón de cálculo
                    string formula = TxtFormula.Text;
                    Dictionary<string, string> variablesYValores = ObtenerVariablesYValores();

                    // Mostrar los valores en el TxtContenedor
                    StringBuilder sb = new StringBuilder();
                    foreach (var kvp in variablesYValores)
                    {
                        sb.AppendLine($"{kvp.Key}: {kvp.Value}");
                    }
                    TxtContenedor.Text = sb.ToString();

                    // Ejecutar la fórmula
                    EjecutarFormula(formula, variablesYValores);
                }
                */


        private void EjecutarFormula(string formula, Dictionary<string, string> variablesYValores)
        {
            // Limpiar el TextBox de VariablesVacias al inicio de cada cálculo
            VariablesVacias.Text = string.Empty;

            // Reemplazar las variables en la fórmula con sus valores correspondientes
            foreach (var kvp in variablesYValores)
            {
                string variableName = kvp.Key;
                string variableValue = kvp.Value.Trim(); // Asegúrate de eliminar espacios en blanco

                // Verificar si la variable tiene un valor no vacío
                if (string.IsNullOrWhiteSpace(variableValue))
                {
                    variableValue = "0";  // Asignar un valor predeterminado de 0 si la variable está vacía
                    VariablesVacias.Text += $"{variableName}, ";  // Almacenar el nombre de la variable vacía
                }
                else
                {
                    VariablesVacias.Text = "Null";  // Asignar 'Null' si la variable no está vacía
                }

                try
                {
                    // Intentar convertir la cadena y reemplazar en la fórmula
                    float parsedValue;

                    // Intentar convertir con coma o punto como separador decimal
                    if (!float.TryParse(variableValue, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedValue))
                    {
                        // Si falla, intentar convertir con la configuración regional actual
                        if (!float.TryParse(variableValue, NumberStyles.Float, CultureInfo.CurrentCulture, out parsedValue))
                        {
                            throw new FormatException();
                        }
                    }

                    formula = formula.Replace(variableName, parsedValue.ToString(CultureInfo.InvariantCulture));
                }
                catch (FormatException)
                {
                    // Mostrar mensaje de error si la conversión falla
                    MostrarError($"Error al reemplazar la variable {variableName}. Verifica el valor ingresado.");
                    return; // Puedes ajustar este comportamiento según tus necesidades
                }
            }

            // Calcular el resultado de la fórmula
            double resultado = CalcularFormula(formula);

            if (!double.IsNaN(resultado))
            {
                // Mostrar el resultado en el TextBox
                TxtResultado.Text = resultado.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                // Mostrar mensaje de error si el resultado no es válido
                MostrarError("Error al calcular la fórmula. Verifica los valores de las variables.");
            }

            // Verificar si hay variables vacías y mostrar un mensaje
            if (!string.IsNullOrWhiteSpace(VariablesVacias.Text))
            {
                VariablesVacias.Text = VariablesVacias.Text.TrimEnd(',', ' ');  // Eliminar la última coma y espacio
                MostrarAdvertencia("Variables incompletas: " + VariablesVacias.Text);
            }
        }

        private void MostrarAdvertencia(string mensaje)
        {
            // Imprimir la advertencia en la consola
            Console.WriteLine($"Advertencia: {mensaje}");
        }

        private double CalcularFormula(string formula)
        {
            double resultado = double.NaN;

            try
            {
                // Utilizar NCalc para evaluar la expresión matemática
                Expression expression = new Expression(formula);
                object evaluationResult = expression.Evaluate();

                if (evaluationResult is double)
                {
                    resultado = (double)evaluationResult;
                }
                else if (evaluationResult is int)
                {
                    resultado = (int)evaluationResult;
                }
                else
                {
                    // Manejar otros tipos si es necesario
                    resultado = double.NaN;
                }
            }
            catch (Exception)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el cálculo
                // Puedes mostrar un mensaje de error o realizar acciones específicas según tu necesidad
                resultado = double.NaN;
            }

            return resultado;
        }





        //operaciones basicas
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener y ejecutar la fórmula al hacer clic en el botón de creación
                string formula = TxtFormula.Text;
                Dictionary<string, string> variablesYValores = ObtenerVariablesYValores();

                // Mostrar los valores en el TxtContenedor
                StringBuilder sb = new StringBuilder();
                foreach (var kvp in variablesYValores)
                {
                    sb.AppendLine($"{kvp.Key}: {kvp.Value}");
                }
                TxtContenedor.Text = sb.ToString();

                // Ejecutar la fórmula
                EjecutarFormula(formula, variablesYValores);

                // Lógica para insertar datos con parámetros
                string insert = @"INSERT INTO dbo.GC_GESTION_INDIC 
                  VALUES (@Id, @Argumento, @NombreVariable, @NombreIndic, @Momento, @NombrePadre, 
                          @FNi, @NombreProyecto, @Vacio, NULL, NULL, GETDATE(), '', '', '', '', '', 0, @DatosVariables, @Resultado)";

                cn.Open();
                using (SqlCommand command = new SqlCommand(insert, cn))
                {
                    // Agregar parámetros generales
                    command.Parameters.AddWithValue("@Id", tbid.Text);
                    command.Parameters.AddWithValue("@NombreIndic", TxtNombreIndic.Text);
                    command.Parameters.AddWithValue("@Momento", TxtMomento.Text);
                    command.Parameters.AddWithValue("@NombrePadre", TxtNombrePadre.Text);
                    command.Parameters.AddWithValue("@NombreProyecto", TxtNombreProyecto.Text);
                    command.Parameters.AddWithValue("@NombreVariable", TxtNombreVariable.Text);
                    command.Parameters.AddWithValue("@FNi", TxtFNi.Text);

                    command.Parameters.AddWithValue("@Argumento", tbArgumento.Text);
                    command.Parameters.AddWithValue("@Vacio", VariablesVacias.Text);
                    command.Parameters.AddWithValue("@Resultado", TxtResultado.Text);

                    // Construir el string de DatosVariables concatenando NombreVariable y Valor
                    string datosVariables = string.Join("|", variablesYValores.Select(kvp => $"{kvp.Key};{kvp.Value}"));
                    command.Parameters.AddWithValue("@DatosVariables", datosVariables);

                    // Ejecutar la consulta
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
                // Obtener y ejecutar la fórmula al hacer clic en el botón de cálculo
                string formula = TxtFormula.Text;
                Dictionary<string, string> variablesYValores = ObtenerVariablesYValores(); // Cambiado a Dictionary<string, string>

                // Obtener y ejecutar la fórmula al hacer clic en el botón de actualización
                string update = @"
            UPDATE dbo.GC_GESTION_INDIC 
            SET strArgumento_gestion_indic = @Argumento,
                Variables_Vacias_gestion_indic = @Vacio,
                Variables_gestion_indic = @DatosVariables,
                Total_gestion_indic = @Resultado
            WHERE strCod_gestion_indic = @Id";

                cn.Open();
                using (SqlCommand command = new SqlCommand(update, cn))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@Id", tbid.Text);
                    command.Parameters.AddWithValue("@Argumento", tbArgumento.Text);
                    command.Parameters.AddWithValue("@Vacio", VariablesVacias.Text);
                    command.Parameters.AddWithValue("@Resultado", TxtResultado.Text);
                    // Construir el string de DatosVariables concatenando NombreVariable y Valor
                    string datosVariables = string.Join("|", variablesYValores.Select(kvp => $"{kvp.Key};{kvp.Value}"));
                    command.Parameters.AddWithValue("@DatosVariables", datosVariables);

                    // Ejecutar la consulta
                    command.ExecuteNonQuery();
                }
                cn.Close();

                // Mostrar una alerta SweetAlert2 después de guardar los datos
                string script = @"<script>
          Swal.fire({
              title: 'Datos actualizados',
              text: 'Los datos se han actualizado exitosamente.',
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
                  text: 'Hubo un error al actualizar los datos. Detalles: {ex.Message}',
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
            Response.Redirect("Funciones.aspx");
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


        //diccionarios 
        private Dictionary<string, string> ObtenerVariablesYValores()
        {
            Dictionary<string, string> variablesYValores = new Dictionary<string, string>();

            // Obtener las variables permitidas desde la cadena de consulta
            string variablesQueryString = Request.QueryString["variables"].ToString();

            // Separar las variables por coma y crear la lista
            List<string> variablesPermitidas = variablesQueryString.Split(',').ToList();

            foreach (string variable in variablesPermitidas)
            {
                switch (variable)
                {
                    case "AI":
                        variablesYValores["AI"] = AI.Text.Trim();
                        break;
                    case "CASA":
                        variablesYValores["CASA"] = CASA.Text.Trim();
                        break;
                    case "PSGIIE":
                        variablesYValores["PSGIIE"] = PSGIIE.Text.Trim();
                        break;
                    case "PSGR":
                        variablesYValores["PSGR"] = PSGR.Text.Trim();
                        break;
                    case "PSIF":
                        variablesYValores["PSIF"] = PSIF.Text.Trim();
                        break;
                    case "PSOP":
                        variablesYValores["PSOP"] = PSOP.Text.Trim();
                        break;
                    case "PSPW":
                        variablesYValores["PSPW"] = PSPW.Text.Trim();
                        break;
                    case "PSSB":
                        variablesYValores["PSSB"] = PSSB.Text.Trim();
                        break;
                    case "PSSI":
                        variablesYValores["PSSI"] = PSSI.Text.Trim();
                        break;
                    case "PSSS":
                        variablesYValores["PSSS"] = PSSS.Text.Trim();
                        break;
                    case "PTU":
                        variablesYValores["PTU"] = PTU.Text.Trim();
                        break;
                    case "PVC":
                        variablesYValores["PVC"] = PVC.Text.Trim();
                        break;
                    case "CASI":
                        variablesYValores["CASI"] = CASI.Text.Trim();
                        break;
                    case "TAJC":
                        variablesYValores["TAJC"] = TAJC.Text.Trim();
                        break;
                    case "TAP":
                        variablesYValores["TAP"] = TAP.Text.Trim();
                        break;
                    case "NTD":
                        variablesYValores["NTD"] = NTD.Text.Trim();
                        break;
                    case "TDP":
                        variablesYValores["TDP"] = TDP.Text.Trim();
                        break;
                    case "NTE":
                        variablesYValores["NTE"] = NTE.Text.Trim();
                        break;
                    case "TEPN":
                        variablesYValores["TEPN"] = TEPN.Text.Trim();
                        break;
                    case "TET":
                        variablesYValores["TET"] = TET.Text.Trim();
                        break;
                    case "TG":
                        variablesYValores["TG"] = TG.Text.Trim();
                        break;
                    case "TPA":
                        variablesYValores["TPA"] = TPA.Text.Trim();
                        break;
                    case "TPI":
                        variablesYValores["TPI"] = TPI.Text.Trim();
                        break;
                    case "CASiGAC":
                        variablesYValores["CASiGAC"] = CASiGAC.Text.Trim();
                        break;
                    case "TRI":
                        variablesYValores["TRI"] = TRI.Text.Trim();
                        break;
                    case "CASV":
                        variablesYValores["CASV"] = CASV.Text.Trim();
                        break;
                    case "CO":
                        variablesYValores["CO"] = CO.Text.Trim();
                        break;
                    case "CT":
                        variablesYValores["CT"] = CT.Text.Trim();
                        break;
                    case "CTSA":
                        variablesYValores["CTSA"] = CTSA.Text.Trim();
                        break;
                    case "CTSI":
                        variablesYValores["CTSI"] = CTSI.Text.Trim();
                        break;
                    case "CTSiGAC":
                        variablesYValores["CTSiGAC"] = CTSiGAC.Text.Trim();
                        break;
                    case "CTSV":
                        variablesYValores["CTSV"] = CTSV.Text.Trim();
                        break;
                    case "AJCC":
                        variablesYValores["AJCC"] = AJCC.Text.Trim();
                        break;
                    case "DFC":
                        variablesYValores["DFC"] = DFC.Text.Trim();
                        break;
                    case "DMUM":
                        variablesYValores["DMUM"] = DMUM.Text.Trim();
                        break;
                    case "DPM":
                        variablesYValores["DPM"] = DPM.Text.Trim();
                        break;
                    case "DPV":
                        variablesYValores["DPV"] = DPV.Text.Trim();
                        break;
                    case "DRC":
                        variablesYValores["DRC"] = DRC.Text.Trim();
                        break;
                    case "DRO":
                        variablesYValores["DRO"] = DRO.Text.Trim();
                        break;
                    case "DT":
                        variablesYValores["DT"] = DT.Text.Trim();
                        break;
                    case "EAE":
                        variablesYValores["EAE"] = EAE.Text.Trim();
                        break;
                    case "EM":
                        variablesYValores["EM"] = EM.Text.Trim();
                        break;
                    case "EMNI":
                        variablesYValores["EMNI"] = EMNI.Text.Trim();
                        break;
                    case "AME":
                        variablesYValores["AME"] = AME.Text.Trim();
                        break;
                    case "EMPC":
                        variablesYValores["EMPC"] = EMPC.Text.Trim();
                        break;
                    case "EMPN":
                        variablesYValores["EMPN"] = EMPN.Text.Trim();
                        break;
                    case "EMPNP":
                        variablesYValores["EMPNP"] = EMPNP.Text.Trim();
                        break;
                    case "EPM":
                        variablesYValores["EPM"] = EPM.Text.Trim();
                        break;
                    case "EPV":
                        variablesYValores["EPV"] = EPV.Text.Trim();
                        break;
                    case "GTAA":
                        variablesYValores["GTAA"] = GTAA.Text.Trim();
                        break;
                    case "HCA":
                        variablesYValores["HCA"] = HCA.Text.Trim();
                        break;
                    case "HCD":
                        variablesYValores["HCD"] = HCD.Text.Trim();
                        break;
                    case "IAW":
                        variablesYValores["IAW"] = IAW.Text.Trim();
                        break;
                    case "AMLE":
                        variablesYValores["AMLE"] = AMLE.Text.Trim();
                        break;
                    case "NAASS":
                        variablesYValores["NAASS"] = NAASS.Text.Trim();
                        break;
                    case "NACD":
                        variablesYValores["NACD"] = NACD.Text.Trim();
                        break;
                    case "NAPD":
                        variablesYValores["NAPD"] = NAPD.Text.Trim();
                        break;
                    case "NAW":
                        variablesYValores["NAW"] = NAW.Text.Trim();
                        break;
                    case "NCE":
                        variablesYValores["NCE"] = NCE.Text.Trim();
                        break;
                    case "NCERA":
                        variablesYValores["NCERA"] = NCERA.Text.Trim();
                        break;
                    case "NCRW":
                        variablesYValores["NCRW"] = NCRW.Text.Trim();
                        break;
                    case "NCW":
                        variablesYValores["NCW"] = NCW.Text.Trim();
                        break;
                    case "NDASS":
                        variablesYValores["NDASS"] = NDASS.Text.Trim();
                        break;
                    case "NDE":
                        variablesYValores["NDE"] = NDE.Text.Trim();
                        break;
                    case "AMLP":
                        variablesYValores["AMLP"] = AMLP.Text.Trim();
                        break;
                    case "NDEAI":
                        variablesYValores["NDEAI"] = NDEAI.Text.Trim();
                        break;
                    case "NDEASI":
                        variablesYValores["NDEASI"] = NDEASI.Text.Trim();
                        break;
                    case "NDEEL":
                        variablesYValores["NDEEL"] = NDEEL.Text.Trim();
                        break;
                    case "NEASS":
                        variablesYValores["NEASS"] = NEASS.Text.Trim();
                        break;
                    case "NEB":
                        variablesYValores["NEB"] = NEB.Text.Trim();
                        break;
                    case "NEESAV":
                        variablesYValores["NEESAV"] = NEESAV.Text.Trim();
                        break;
                    case "NEESOP":
                        variablesYValores["NEESOP"] = NEESOP.Text.Trim();
                        break;
                    case "NFA":
                        variablesYValores["NFA"] = NFA.Text.Trim();
                        break;
                    case "NGE":
                        variablesYValores["NGE"] = NGE.Text.Trim();
                        break;
                    case "NIR":
                        variablesYValores["NIR"] = NIR.Text.Trim();
                        break;
                    case "AMP":
                        variablesYValores["AMP"] = AMP.Text.Trim();
                        break;
                    case "NIRE":
                        variablesYValores["NIRE"] = NIRE.Text.Trim();
                        break;
                    case "NLI":
                        variablesYValores["NLI"] = NLI.Text.Trim();
                        break;
                    case "NMT":
                        variablesYValores["NMT"] = NMT.Text.Trim();
                        break;
                    case "DATO":
                        variablesYValores["DATO"] = DATO.Text.Trim();
                        break;
                    case "NOR":
                        variablesYValores["NOR"] = NOR.Text.Trim();
                        break;
                    case "NOVR":
                        variablesYValores["NOVR"] = NOVR.Text.Trim();
                        break;
                    case "NP":
                        variablesYValores["NP"] = NP.Text.Trim();
                        break;
                    case "NPED":
                        variablesYValores["NPED"] = NPED.Text.Trim();
                        break;
                    case "NPEGIIE":
                        variablesYValores["NPEGIIE"] = NPEGIIE.Text.Trim();
                        break;
                    case "NPESB":
                        variablesYValores["NPESB"] = NPESB.Text.Trim();
                        break;
                    case "ARC":
                        variablesYValores["ARC"] = ARC.Text.Trim();
                        break;
                    case "NPESS":
                        variablesYValores["NPESS"] = NPESS.Text.Trim();
                        break;
                    case "NPF":
                        variablesYValores["NPF"] = NPF.Text.Trim();
                        break;
                    case "NPG":
                        variablesYValores["NPG"] = NPG.Text.Trim();
                        break;
                    case "NPIE":
                        variablesYValores["NPIE"] = NPIE.Text.Trim();
                        break;
                    case "NPME":
                        variablesYValores["NPME"] = NPME.Text.Trim();
                        break;
                    case "NPPSR":
                        variablesYValores["NPPSR"] = NPPSR.Text.Trim();
                        break;
                    case "NUR":
                        variablesYValores["NUR"] = NUR.Text.Trim();
                        break;
                    case "OP":
                        variablesYValores["OP"] = OP.Text.Trim();
                        break;
                    case "PAE":
                        variablesYValores["PAE"] = PAE.Text.Trim();
                        break;
                    case "PAP":
                        variablesYValores["PAP"] = PAP.Text.Trim();
                        break;
                    case "BPV":
                        variablesYValores["BPV"] = BPV.Text.Trim();
                        break;
                    case "PCMO":
                        variablesYValores["PCMO"] = PCMO.Text.Trim();
                        break;
                    case "PCPM":
                        variablesYValores["PCPM"] = PCPM.Text.Trim();
                        break;
                    case "PCPOC":
                        variablesYValores["PCPOC"] = PCPOC.Text.Trim();
                        break;
                    case "PDAE":
                        variablesYValores["PDAE"] = PDAE.Text.Trim();
                        break;
                    case "PDB":
                        variablesYValores["PDB"] = PDB.Text.Trim();
                        break;
                    case "PDC":
                        variablesYValores["PDC"] = PDC.Text.Trim();
                        break;
                    case "PDD":
                        variablesYValores["PDD"] = PDD.Text.Trim();
                        break;
                    case "PDEM":
                        variablesYValores["PDEM"] = PDEM.Text.Trim();
                        break;
                    case "PDFCAD":
                        variablesYValores["PDFCAD"] = PDFCAD.Text.Trim();
                        break;
                    case "PDFCD":
                        variablesYValores["PDFCD"] = PDFCD.Text.Trim();
                        break;
                    case "CA":
                        variablesYValores["CA"] = CA.Text.Trim();
                        break;
                    case "PDIF":
                        variablesYValores["PDIF"] = PDIF.Text.Trim();
                        break;
                    case "PDIR":
                        variablesYValores["PDIR"] = PDIR.Text.Trim();
                        break;
                    case "PFP":
                        variablesYValores["PFP"] = PFP.Text.Trim();
                        break;
                    case "PIE":
                        variablesYValores["PIE"] = PIE.Text.Trim();
                        break;
                    case "PIP":
                        variablesYValores["PIP"] = PIP.Text.Trim();
                        break;
                    case "PIFP":
                        variablesYValores["PIFP"] = PIFP.Text.Trim();
                        break;
                    case "PLRAC":
                        variablesYValores["PLRAC"] = PLRAC.Text.Trim();
                        break;
                    case "PNC":
                        variablesYValores["PNC"] = PNC.Text.Trim();
                        break;
                    case "PSAV":
                        variablesYValores["PSAV"] = PSAV.Text.Trim();
                        break;
                    case "PSEL":
                        variablesYValores["PSEL"] = PSEL.Text.Trim();
                        break;


                }
            }

            return variablesYValores;
        }

        private void ProcesarVariableIndividual(string variable)
        {
            switch (variable)
            {

                case "AI":
                    this.LbAI.Text = "AI:";
                    this.AI.Visible = true;
                    break;
                case "CASA":
                    this.LbCASA.Text = "CASA:";
                    this.CASA.Visible = true;
                    break;
                case "PSGIIE":
                    this.LbPSGIIE.Text = "PSGIIE:";
                    this.PSGIIE.Visible = true;
                    break;
                case "PSGR":
                    this.LbPSGR.Text = "PSGR:";
                    this.PSGR.Visible = true;
                    break;
                case "PSIF":
                    this.LbPSIF.Text = "PSIF:";
                    this.PSIF.Visible = true;
                    break;
                case "PSOP":
                    this.LbPSOP.Text = "PSOP:";
                    this.PSOP.Visible = true;
                    break;
                case "PSPW":
                    this.LbPSPW.Text = "PSPW:";
                    this.PSPW.Visible = true;
                    break;
                case "PSSB":
                    this.LbPSSB.Text = "PSSB:";
                    this.PSSB.Visible = true;
                    break;
                case "PSSI":
                    this.LbPSSI.Text = "PSSI:";
                    this.PSSI.Visible = true;
                    break;
                case "PSSS":
                    this.LbPSSS.Text = "PSSS:";
                    this.PSSS.Visible = true;
                    break;
                case "PTU":
                    this.LbPTU.Text = "PTU:";
                    this.PTU.Visible = true;
                    break;
                case "PVC":
                    this.LbPVC.Text = "PVC:";
                    this.PVC.Visible = true;
                    break;
                case "CASI":
                    this.LbCASI.Text = "CASI:";
                    this.CASI.Visible = true;
                    break;
                case "TAJC":
                    this.LbTAJC.Text = "TAJC:";
                    this.TAJC.Visible = true;
                    break;
                case "TAP":
                    this.LbTAP.Text = "TAP:";
                    this.TAP.Visible = true;
                    break;
                case "NTD":
                    this.LbNTD.Text = "NTD:";
                    this.NTD.Visible = true;
                    break;
                case "TDP":
                    this.LbTDP.Text = "TDP:";
                    this.TDP.Visible = true;
                    break;
                case "NTE":
                    this.LbNTE.Text = "NTE:";
                    this.NTE.Visible = true;
                    break;
                case "TEPN":
                    this.LbTEPN.Text = "TEPN:";
                    this.TEPN.Visible = true;
                    break;
                case "TET":
                    this.LbTET.Text = "TET:";
                    this.TET.Visible = true;
                    break;
                case "TG":
                    this.LbTG.Text = "TG:";
                    this.TG.Visible = true;
                    break;
                case "TPA":
                    this.LbTPA.Text = "TPA:";
                    this.TPA.Visible = true;
                    break;
                case "TPI":
                    this.LbTPI.Text = "TPI:";
                    this.TPI.Visible = true;
                    break;
                case "CASiGAC":
                    this.LbCASiGAC.Text = "CASiGAC:";
                    this.CASiGAC.Visible = true;
                    break;
                case "TRI":
                    this.LbTRI.Text = "TRI:";
                    this.TRI.Visible = true;
                    break;
                case "CASV":
                    this.LbCASV.Text = "CASV:";
                    this.CASV.Visible = true;
                    break;
                case "CO":
                    this.LbCO.Text = "CO:";
                    this.CO.Visible = true;
                    break;
                case "CT":
                    this.LbCT.Text = "CT:";
                    this.CT.Visible = true;
                    break;
                case "CTSA":
                    this.LbCTSA.Text = "CTSA:";
                    this.CTSA.Visible = true;
                    break;
                case "CTSI":
                    this.LbCTSI.Text = "CTSI:";
                    this.CTSI.Visible = true;
                    break;
                case "CTSiGAC":
                    this.LbCTSiGAC.Text = "CTSiGAC:";
                    this.CTSiGAC.Visible = true;
                    break;
                case "CTSV":
                    this.LbCTSV.Text = "CTSV:";
                    this.CTSV.Visible = true;
                    break;
                case "AJCC":
                    this.LbAJCC.Text = "AJCC:";
                    this.AJCC.Visible = true;
                    break;
                case "DFC":
                    this.LbDFC.Text = "DFC:";
                    this.DFC.Visible = true;
                    break;
                case "DMUM":
                    this.LbDMUM.Text = "DMUM:";
                    this.DMUM.Visible = true;
                    break;
                case "DPM":
                    this.LbDPM.Text = "DPM:";
                    this.DPM.Visible = true;
                    break;
                case "DPV":
                    this.LbDPV.Text = "DPV:";
                    this.DPV.Visible = true;
                    break;
                case "DRC":
                    this.LbDRC.Text = "DRC:";
                    this.DRC.Visible = true;
                    break;
                case "DRO":
                    this.LbDRO.Text = "DRO:";
                    this.DRO.Visible = true;
                    break;
                case "DT":
                    this.LbDT.Text = "DT:";
                    this.DT.Visible = true;
                    break;
                case "EAE":
                    this.LbEAE.Text = "EAE:";
                    this.EAE.Visible = true;
                    break;
                case "EM":
                    this.LbEM.Text = "EM:";
                    this.EM.Visible = true;
                    break;
                case "EMNI":
                    this.LbEMNI.Text = "EMNI:";
                    this.EMNI.Visible = true;
                    break;
                case "AME":
                    this.LbAME.Text = "AME:";
                    this.AME.Visible = true;
                    break;
                case "EMPC":
                    this.LbEMPC.Text = "EMPC:";
                    this.EMPC.Visible = true;
                    break;
                case "EMPN":
                    this.LbEMPN.Text = "EMPN:";
                    this.EMPN.Visible = true;
                    break;
                case "EMPNP":
                    this.LbEMPNP.Text = "EMPNP:";
                    this.EMPNP.Visible = true;
                    break;
                case "EPM":
                    this.LbEPM.Text = "EPM:";
                    this.EPM.Visible = true;
                    break;
                case "EPV":
                    this.LbEPV.Text = "EPV:";
                    this.EPV.Visible = true;
                    break;
                case "GTAA":
                    this.LbGTAA.Text = "GTAA:";
                    this.GTAA.Visible = true;
                    break;
                case "HCA":
                    this.LbHCA.Text = "HCA:";
                    this.HCA.Visible = true;
                    break;
                case "HCD":
                    this.LbHCD.Text = "HCD:";
                    this.HCD.Visible = true;
                    break;
                case "IAW":
                    this.LbIAW.Text = "IAW:";
                    this.IAW.Visible = true;
                    break;
                case "AMLE":
                    this.LbAMLE.Text = "AMLE:";
                    this.AMLE.Visible = true;
                    break;
                case "NAASS":
                    this.LbNAASS.Text = "NAASS:";
                    this.NAASS.Visible = true;
                    break;
                case "NACD":
                    this.LbNACD.Text = "NACD:";
                    this.NACD.Visible = true;
                    break;
                case "NAPD":
                    this.LbNAPD.Text = "NAPD:";
                    this.NAPD.Visible = true;
                    break;
                case "NAW":
                    this.LbNAW.Text = "NAW:";
                    this.NAW.Visible = true;
                    break;
                case "NCE":
                    this.LbNCE.Text = "NCE:";
                    this.NCE.Visible = true;
                    break;
                case "NCERA":
                    this.LbNCERA.Text = "NCERA:";
                    this.NCERA.Visible = true;
                    break;
                case "NCRW":
                    this.LbNCRW.Text = "NCRW:";
                    this.NCRW.Visible = true;
                    break;
                case "NCW":
                    this.LbNCW.Text = "NCW:";
                    this.NCW.Visible = true;
                    break;
                case "NDASS":
                    this.LbNDASS.Text = "NDASS:";
                    this.NDASS.Visible = true;
                    break;
                case "NDE":
                    this.LbNDE.Text = "NDE:";
                    this.NDE.Visible = true;
                    break;
                case "AMLP":
                    this.LbAMLP.Text = "AMLP:";
                    this.AMLP.Visible = true;
                    break;
                case "NDEAI":
                    this.LbNDEAI.Text = "NDEAI:";
                    this.NDEAI.Visible = true;
                    break;
                case "NDEASI":
                    this.LbNDEASI.Text = "NDEASI:";
                    this.NDEASI.Visible = true;
                    break;
                case "NDEEL":
                    this.LbNDEEL.Text = "NDEEL:";
                    this.NDEEL.Visible = true;
                    break;
                case "NEASS":
                    this.LbNEASS.Text = "NEASS:";
                    this.NEASS.Visible = true;
                    break;
                case "NEB":
                    this.LbNEB.Text = "NEB:";
                    this.NEB.Visible = true;
                    break;
                case "NEESAV":
                    this.LbNEESAV.Text = "NEESAV:";
                    this.NEESAV.Visible = true;
                    break;
                case "NEESOP":
                    this.LbNEESOP.Text = "NEESOP:";
                    this.NEESOP.Visible = true;
                    break;
                case "NFA":
                    this.LbNFA.Text = "NFA:";
                    this.NFA.Visible = true;
                    break;
                case "NGE":
                    this.LbNGE.Text = "NGE:";
                    this.NGE.Visible = true;
                    break;
                case "NIR":
                    this.LbNIR.Text = "NIR:";
                    this.NIR.Visible = true;
                    break;
                case "AMP":
                    this.LbAMP.Text = "AMP:";
                    this.AMP.Visible = true;
                    break;
                case "NIRE":
                    this.LbNIRE.Text = "NIRE:";
                    this.NIRE.Visible = true;
                    break;
                case "NLI":
                    this.LbNLI.Text = "NLI:";
                    this.NLI.Visible = true;
                    break;
                case "NMT":
                    this.LbNMT.Text = "NMT:";
                    this.NMT.Visible = true;
                    break;
                case "DATO":
                    this.LbDATO.Text = "DATO:";
                    this.DATO.Visible = true;
                    break;
                case "NOR":
                    this.LbNOR.Text = "NOR:";
                    this.NOR.Visible = true;
                    break;
                case "NOVR":
                    this.LbNOVR.Text = "NOVR:";
                    this.NOVR.Visible = true;
                    break;
                case "NP":
                    this.LbNP.Text = "NP:";
                    this.NP.Visible = true;
                    break;
                case "NPED":
                    this.LbNPED.Text = "NPED:";
                    this.NPED.Visible = true;
                    break;
                case "NPEGIIE":
                    this.LbNPEGIIE.Text = "NPEGIIE:";
                    this.NPEGIIE.Visible = true;
                    break;
                case "NPESB":
                    this.LbNPESB.Text = "NPESB:";
                    this.NPESB.Visible = true;
                    break;
                case "ARC":
                    this.LbARC.Text = "ARC:";
                    this.ARC.Visible = true;
                    break;
                case "NPESS":
                    this.LbNPESS.Text = "NPESS:";
                    this.NPESS.Visible = true;
                    break;
                case "NPF":
                    this.LbNPF.Text = "NPF:";
                    this.NPF.Visible = true;
                    break;
                case "NPG":
                    this.LbNPG.Text = "NPG:";
                    this.NPG.Visible = true;
                    break;
                case "NPIE":
                    this.LbNPIE.Text = "NPIE:";
                    this.NPIE.Visible = true;
                    break;
                case "NPME":
                    this.LbNPME.Text = "NPME:";
                    this.NPME.Visible = true;
                    break;
                case "NPPSR":
                    this.LbNPPSR.Text = "NPPSR:";
                    this.NPPSR.Visible = true;
                    break;
                case "NUR":
                    this.LbNUR.Text = "NUR:";
                    this.NUR.Visible = true;
                    break;
                case "OP":
                    this.LbOP.Text = "OP:";
                    this.OP.Visible = true;
                    break;
                case "PAE":
                    this.LbPAE.Text = "PAE:";
                    this.PAE.Visible = true;
                    break;
                case "PAP":
                    this.LbPAP.Text = "PAP:";
                    this.PAP.Visible = true;
                    break;
                case "BPV":
                    this.LbBPV.Text = "BPV:";
                    this.BPV.Visible = true;
                    break;
                case "PCMO":
                    this.LbPCMO.Text = "PCMO:";
                    this.PCMO.Visible = true;
                    break;
                case "PCPM":
                    this.LbPCPM.Text = "PCPM:";
                    this.PCPM.Visible = true;
                    break;
                case "PCPOC":
                    this.LbPCPOC.Text = "PCPOC:";
                    this.PCPOC.Visible = true;
                    break;
                case "PDAE":
                    this.LbPDAE.Text = "PDAE:";
                    this.PDAE.Visible = true;
                    break;
                case "PDB":
                    this.LbPDB.Text = "PDB:";
                    this.PDB.Visible = true;
                    break;
                case "PDC":
                    this.LbPDC.Text = "PDC:";
                    this.PDC.Visible = true;
                    break;
                case "PDD":
                    this.LbPDD.Text = "PDD:";
                    this.PDD.Visible = true;
                    break;
                case "PDEM":
                    this.LbPDEM.Text = "PDEM:";
                    this.PDEM.Visible = true;
                    break;
                case "PDFCAD":
                    this.LbPDFCAD.Text = "PDFCAD:";
                    this.PDFCAD.Visible = true;
                    break;
                case "PDFCD":
                    this.LbPDFCD.Text = "PDFCD:";
                    this.PDFCD.Visible = true;
                    break;
                case "CA":
                    this.LbCA.Text = "CA:";
                    this.CA.Visible = true;
                    break;
                case "PDIF":
                    this.LbPDIF.Text = "PDIF:";
                    this.PDIF.Visible = true;
                    break;
                case "PDIR":
                    this.LbPDIR.Text = "PDIR:";
                    this.PDIR.Visible = true;
                    break;
                case "PFP":
                    this.LbPFP.Text = "PFP:";
                    this.PFP.Visible = true;
                    break;
                case "PIE":
                    this.LbPIE.Text = "PIE:";
                    this.PIE.Visible = true;
                    break;

                case "PIP":
                    this.LbPIP.Text = "PIP:";
                    this.PIP.Visible = true;
                    break;
                case "PIFP":
                    this.LbPIFP.Text = "PIFP:";
                    this.PIFP.Visible = true;
                    break;
                case "PLRAC":
                    this.LbPLRAC.Text = "PLRAC:";
                    this.PLRAC.Visible = true;
                    break;
                case "PNC":
                    this.LbPNC.Text = "PNC:";
                    this.PNC.Visible = true;
                    break;
                case "PSAV":
                    this.LbPSAV.Text = "PSAV:";
                    this.PSAV.Visible = true;
                    break;
                case "PSEL":
                    this.LbPSEL.Text = "PSEL:";
                    this.PSEL.Visible = true;
                    break;
            }
        }

    }


}
