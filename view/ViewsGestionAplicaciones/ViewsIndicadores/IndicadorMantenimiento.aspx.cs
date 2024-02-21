using Antlr.Runtime;
using sigac.view.ViewsGestionAplicaciones.ViewsPeriodicidades;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sigac.view.ViewsGestionAplicaciones.ViewsIndicadores
{
    public partial class IndicadorMantenimiento : System.Web.UI.Page
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string sID = Request.QueryString["id"].ToString();
                    CargarDatos(sID);
                    CargarVariables(); // Agregar esta línea para cargar las variables

                }
                if (Request.QueryString["op"] != null)
                {
                    string sOpc = Request.QueryString["op"].ToString();
                    SetupPageBasedOnOperation(sOpc);
                }
            }
        }

        private void CargarDatos(string sID)
        {
            InidicadorViewModel indicador = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    string queryString = "SELECT * FROM GC_INDIC WHERE strCod_indic = @ID";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        command.Parameters.AddWithValue("@ID", sID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                indicador = new InidicadorViewModel
                                {
                                    Id = reader["strCod_indic"].ToString(),
                                    Nombre = reader["strNombre_indic"].ToString(),
                                    Descripcion = reader["strDescripcion_indic"].ToString(),
                                    Calculo = reader["strFmCalculo_indic"].ToString(),

                                    func = reader["strCod_func"].ToString(),
                                    dimen = reader["strCod_dimen"].ToString(),
                                    tpro = reader["strCod_tpro"].ToString(),
                                    proces = reader["strCod_proces"].ToString(),
                                    comp = reader["strCod_comp"].ToString(),

                                    period = reader["strCod_period"].ToString(),
                                    variab = reader["string_variab"].ToString(),
                                    fni = reader["string_fni"].ToString(),
                                    evid = reader["string_evid"].ToString(),
                                    padre = reader["strCod_padre"].ToString(),

                                    EquipProces = reader["strCod_EquipProces"].ToString(),

                                    EquipIndMom1 = reader["strCod_EquipIndMom1"].ToString(),
                                    EquipFueMom1 = reader["strCod_EquipFueMom1"].ToString(),

                                    EquipIndMom2 = reader["strCod_EquipIndMom2"].ToString(),
                                    EquipFueMom2 = reader["strCod_EquipFueMom2"].ToString(),

                                    EquipIndMom3 = reader["strCod_EquipIndMom3"].ToString(),


                                    EvidProces = reader["strCod_EvidProces"].ToString(),

                                };
                            }
                        }
                    }
                }

                if (indicador != null)
                {
                    tbid.Text = indicador.Id;
                    tbnombre.Text = indicador.Nombre;
                    tbdescripcion.Text = indicador.Descripcion;
                    tbcalculo.Text = indicador.Calculo;

                    ddlfunc.SelectedValue = indicador.func;
                    ddldimen.SelectedValue = indicador.dimen;
                    ddltpro.SelectedValue = indicador.tpro;
                    ddlproces.SelectedValue = indicador.proces;
                    ddlcomp.SelectedValue = indicador.comp;

                    ddlperiod.SelectedValue = indicador.period;
                    hfSelectedVariab.Value = indicador.variab;
                    hfSelectedFni.Value = indicador.fni;
                    hfSelectedEvid.Value = indicador.evid;
                    ddlpadre.SelectedValue = indicador.padre;

                    ddlEquipProces.SelectedValue = indicador.EquipProces;
                    ddlEquipIndMom1.SelectedValue = indicador.EquipIndMom1;
                    ddlEquipFueMom1.SelectedValue = indicador.EquipFueMom1;
                    ddlEquipIndMom2.SelectedValue = indicador.EquipIndMom2;
                    ddlEquipFueMom2.SelectedValue = indicador.EquipFueMom2;
                    ddlEquipIndMom3.SelectedValue = indicador.EquipIndMom3;

                    ddlResponEvid.SelectedValue = indicador.EvidProces;
                }
            }
            catch (Exception ex)
            {
                HandleError("Error al cargar datos.", ex);
            }
        }
        private void CargarVariables()
        {
            CargarListBoxDesdeString(hfSelectedVariab.Value, lbVariab);
            CargarListBoxDesdeString(hfSelectedFni.Value, lbFni);
            CargarListBoxDesdeString(hfSelectedEvid.Value, lbEvid);
        }

        // Nuevo método para cargar los ListBox desde un string
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

        private void SetupPageBasedOnOperation(string sOpc)
        {
            switch (sOpc)
            {
                case "C":
                    Lbltitulo.Text = "Ingresar nuevo Indicador";
                    BtnCreate.Visible = true;
                    tbid.Text = Guid.NewGuid().ToString();
                    break;
                case "R":
                    Lbltitulo.Text = "Vista Indicador";
                    break;
                case "U":
                    Lbltitulo.Text = "Actualizar Indicador";
                    tbid.ReadOnly = true;
                    BtnUpdate.Visible = true;
                    break;
                case "D":
                    Lbltitulo.Text = "Eliminar Indicador";
                    tbid.ReadOnly = true;
                    BtnDelete.Visible = true;
                    break;
            }
        }




        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    string insert = "INSERT INTO dbo.GC_INDIC VALUES (@ID, @Nombre, @Descripcion, @Calculo, GETDATE(), 0, '', '', '', " +
                           "'', '', '', GETDATE(), '', '', '', '', '', 0, 0.00, @Func, @Dimen, @Tpro, @Proces, @Comp, @Period, " +
                           "@Padre, @EquipProces, @EquipIndMom1, @EquipFueMom1, @EquipIndMom2, @EquipFueMom2, @EquipIndMom3, @Variab, @Fni, @Evid,@ResponEvid)";

                    using (SqlCommand command = new SqlCommand(insert, cn))
                        {
                            command.Parameters.AddWithValue("@ID", Guid.NewGuid().ToString());
                            command.Parameters.AddWithValue("@Nombre", tbnombre.Text);
                            command.Parameters.AddWithValue("@Descripcion", tbdescripcion.Text);
                            command.Parameters.AddWithValue("@Calculo", tbcalculo.Text);
                            command.Parameters.AddWithValue("@Func", ddlfunc.SelectedValue);
                            command.Parameters.AddWithValue("@Dimen", ddldimen.SelectedValue);
                            command.Parameters.AddWithValue("@Tpro", ddltpro.SelectedValue);
                            command.Parameters.AddWithValue("@Proces", ddlproces.SelectedValue);
                            command.Parameters.AddWithValue("@Comp", ddlcomp.SelectedValue);
                            command.Parameters.AddWithValue("@Period", ddlperiod.SelectedValue);

                            command.Parameters.AddWithValue("@Variab", hfSelectedVariab.Value);
                            command.Parameters.AddWithValue("@Fni", hfSelectedFni.Value);
                            command.Parameters.AddWithValue("@Evid", hfSelectedEvid.Value);

                            command.Parameters.AddWithValue("@Padre", ddlpadre.SelectedValue);
                            command.Parameters.AddWithValue("@EquipProces", ddlEquipProces.SelectedValue);
                            command.Parameters.AddWithValue("@EquipIndMom1", ddlEquipIndMom1.SelectedValue);
                            command.Parameters.AddWithValue("@EquipFueMom1", ddlEquipFueMom1.SelectedValue);
                            command.Parameters.AddWithValue("@EquipIndMom2", ddlEquipIndMom2.SelectedValue);
                            command.Parameters.AddWithValue("@EquipFueMom2", ddlEquipFueMom2.SelectedValue);
                            command.Parameters.AddWithValue("@EquipIndMom3", ddlEquipIndMom3.SelectedValue);
                        command.Parameters.AddWithValue("@ResponEvid", ddlResponEvid.SelectedValue);


                        command.ExecuteNonQuery();
                    }
                }

                ShowSuccessMessage("Datos guardados exitosamente.", "Indicadores.aspx");
            }
            catch (Exception ex)
            {
                HandleError("Error al guardar los datos.", ex);
            }
        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    string update = "UPDATE dbo.GC_INDIC SET strNombre_indic = @Nombre, strDescripcion_indic = @Descripcion, " +
                                    "strFmCalculo_indic = @Calculo, strCod_func = @Func, " +
                                    "strCod_dimen = @Dimen, strCod_tpro = @Tpro, strCod_proces = @Proces, " +
                                    "strCod_comp = @Comp, strCod_period = @Period, string_variab = @Variab, " +
                                    "string_fni = @Fni, string_evid = @Evid, strCod_padre = @Padre, " +
                                    "strCod_EquipProces = @EquipProces, strCod_EquipIndMom1 = @EquipIndMom1, " +
                                    "strCod_EquipFueMom1 = @EquipFueMom1, strCod_EquipIndMom2 = @EquipIndMom2, " +
                                    "strCod_EquipFueMom2 = @EquipFueMom2, strCod_EquipIndMom3 = @EquipIndMom3, strCod_EvidProces = @ResponEvid " +
                                    "WHERE strCod_indic = @ID";

                    using (SqlCommand command = new SqlCommand(update, cn))
                    {
                        command.Parameters.AddWithValue("@ID", tbid.Text);
                        command.Parameters.AddWithValue("@Nombre", tbnombre.Text);
                        command.Parameters.AddWithValue("@Descripcion", tbdescripcion.Text);
                        command.Parameters.AddWithValue("@Calculo", tbcalculo.Text);
                        command.Parameters.AddWithValue("@Func", ddlfunc.SelectedValue);
                        command.Parameters.AddWithValue("@Dimen", ddldimen.SelectedValue);
                        command.Parameters.AddWithValue("@Tpro", ddltpro.SelectedValue);
                        command.Parameters.AddWithValue("@Proces", ddlproces.SelectedValue);
                        command.Parameters.AddWithValue("@Comp", ddlcomp.SelectedValue);
                        command.Parameters.AddWithValue("@Period", ddlperiod.SelectedValue);
                        command.Parameters.AddWithValue("@Variab", hfSelectedVariab.Value);
                        command.Parameters.AddWithValue("@Fni", hfSelectedFni.Value);
                        command.Parameters.AddWithValue("@Evid", hfSelectedEvid.Value);
                        command.Parameters.AddWithValue("@Padre", ddlpadre.SelectedValue);
                        command.Parameters.AddWithValue("@EquipProces", ddlEquipProces.SelectedValue);
                        command.Parameters.AddWithValue("@EquipIndMom1", ddlEquipIndMom1.SelectedValue);
                        command.Parameters.AddWithValue("@EquipFueMom1", ddlEquipFueMom1.SelectedValue);
                        command.Parameters.AddWithValue("@EquipIndMom2", ddlEquipIndMom2.SelectedValue);
                        command.Parameters.AddWithValue("@EquipFueMom2", ddlEquipFueMom2.SelectedValue);
                        command.Parameters.AddWithValue("@EquipIndMom3", ddlEquipIndMom3.SelectedValue);
                        command.Parameters.AddWithValue("@ResponEvid", ddlResponEvid.SelectedValue);

                        command.ExecuteNonQuery();
                    }
                }

                ShowSuccessMessage("Datos actualizados exitosamente.", "Indicadores.aspx");
            }
            catch (Exception ex)
            {
                HandleError("Error al actualizar los datos.", ex);
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    string delete = "DELETE FROM dbo.GC_INDIC WHERE strCod_indic = @ID";
                    using (SqlCommand command = new SqlCommand(delete, cn))
                    {
                        command.Parameters.AddWithValue("@ID", tbid.Text);
                        command.ExecuteNonQuery();
                    }
                }

                Response.Redirect("Indicadores.aspx");
            }
            catch (Exception ex)
            {
                HandleError("Error al eliminar los datos.", ex);
            }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Indicadores.aspx");
        }

        private void ShowSuccessMessage(string message, string redirectUrl)
        {
            string script = $@"<script>
                                Swal.fire({{
                                    title: 'Éxito',
                                    text: '{message}',
                                    icon: 'success',
                                    confirmButtonText: 'OK'
                                }}).then((result) => {{
                                    if (result.isConfirmed) {{
                                        window.location.href = '{redirectUrl}';
                                    }}
                                }});
                              </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script);
        }

        private void ShowErrorMessage(string message)
        {
            string script = $@"<script>
                        Swal.fire({{
                            title: 'Error',
                            text: '{message}',
                            icon: 'error',
                            confirmButtonText: 'OK'
                        }});
                      </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlertError", script);
        }

        private void HandleError(string errorMessage, Exception ex)
        {
            // Registrar la traza completa en el manejo de errores.
            string errorScript = $@"<script>
                                     Swal.fire({{
                                        title: 'Error',
                                        text: '{errorMessage}. Detalles: {ex.ToString()}',
                                        icon: 'error',
                                        confirmButtonText: 'OK'
                                    }});
                                 </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlertError", errorScript);
        }
    }
}
