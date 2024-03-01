using Microsoft.AspNet.FriendlyUrls;
using Newtonsoft.Json;
using sigac.Helper;
using sigac.view.ViewsGestionAplicaciones.ViewsDimensiones;
using sigac.view.ViewsGestionAplicaciones.ViewsFunciones;
using sigac.view.ViewsGestionAplicaciones.ViewsIndicadores;
using sigac.view.ViewsGestionUsuarios.ViewsPadres;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace sigac.view
{
    public partial class PanelControl : System.Web.UI.Page
    {
        private PanelViewModel PanelViewState
        {
            get
            {
                return ViewState["Indicador"] as PanelViewModel ?? new PanelViewModel();
            }
            set
            {
                ViewState["Indicador"] = value;
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

            // momento 1 fuente de informacion

            List<PanelViewModel> Momento1FInPlanificacion = ConsultarMomento1FInPlanificacion();
            GenerarHTMLMomento1FInPlanificacion(Momento1FInPlanificacion);

            List<PanelViewModel> Momento1FInEjecucion = ConsultarMomento1FInEjecucion();
            GenerarHTMLMomento1FInEjecucion(Momento1FInEjecucion);

            List<PanelViewModel> Momento1FInResultado = ConsultarMomento1FInResultados();
            GenerarHTMLMomento1FInResultado(Momento1FInResultado);

            // Momento 1 Funcion Indicador
            //Docente
            List<PanelViewModel> Momento1IndicDocentePlanificacion = ConsultarMomento1IndicDocentePlanificacion();
            GenerarHTMLMomento1IndicDocentePlanificacion(Momento1IndicDocentePlanificacion);

            List<PanelViewModel> Momento1IndicDocenteEjecucion = ConsultarMomento1IndicDocenteEjecucion();
            GenerarHTMLMomento1IndicDocenteEjecucion(Momento1IndicDocenteEjecucion);

            List<PanelViewModel> Momento1IndicDocenteResultado = ConsultarMomento1IndicDocenteResultado();
            GenerarHTMLMomento1IndicDocenteResultado(Momento1IndicDocenteResultado);


            //Investigacion
            List<PanelViewModel> Momento1IndicInvestigacionPlanificacion = ConsultarMomento1IndicInvestigacionPlanificacion();
            GenerarHTMLMomento1IndicInvestigacionPlanificacion(Momento1IndicInvestigacionPlanificacion);

            List<PanelViewModel> Momento1IndicInvestigacionEjecucion = ConsultarMomento1IndicInvestigacionEjecucion();
            GenerarHTMLMomento1IndicInvestigacionEjecucion(Momento1IndicInvestigacionEjecucion);

            List<PanelViewModel> Momento1IndicInvestigacionResultado = ConsultarMomento1IndicInvestigacionResultado();
            GenerarHTMLMomento1IndicInvestigacionResultado(Momento1IndicInvestigacionResultado);


            //Vinculacion
            List<PanelViewModel> Momento1IndicVinculacionPlanificacion = ConsultarMomento1IndicVinculacionPlanificacion();
            GenerarHTMLMomento1IndicVinculacionPlanificacion(Momento1IndicVinculacionPlanificacion);

            List<PanelViewModel> Momento1IndicVinculacionEjecucion = ConsultarMomento1IndicVinculacionEjecucion();
            GenerarHTMLMomento1IndicVinculacionEjecucion(Momento1IndicVinculacionEjecucion);

            List<PanelViewModel> Momento1IndicVinculacionResultado = ConsultarMomento1IndicVinculacionResultado();
            GenerarHTMLMomento1IndicVinculacionResultado(Momento1IndicVinculacionResultado);


            //Condiciones institucionales
            List<PanelViewModel> Momento1IndicCondicionInstitucionalPlanificacion = ConsultarMomento1IndicCondicionInstitucionalPlanificacion();
            GenerarHTMLMomento1IndicCondicionInstitucionalPlanificacion(Momento1IndicCondicionInstitucionalPlanificacion);

            List<PanelViewModel> Momento1IndicCondicionInstitucionalEjecucion = ConsultarMomento1IndicCondicionInstitucionalEjecucion();
            GenerarHTMLMomento1IndicCondicionInstitucionalEjecucion(Momento1IndicCondicionInstitucionalEjecucion);

            List<PanelViewModel> Momento1IndicCondicionInstitucionalResultado = ConsultarMomento1IndicCondicionInstitucionalResultado();
            GenerarHTMLMomento1IndicCondicionInstitucionalResultado(Momento1IndicCondicionInstitucionalResultado);






            // momento 2 fuente de informacion

            List<PanelViewModel> Momento2FInPlanificacion = ConsultarMomento2FInPlanificacion();
            GenerarHTMLMomento2FInPlanificacion(Momento2FInPlanificacion);

            List<PanelViewModel> Momento2FInEjecucion = ConsultarMomento2FInEjecucion();
            GenerarHTMLMomento2FInEjecucion(Momento2FInEjecucion);

            List<PanelViewModel> Momento2FInResultado = ConsultarMomento2FInResultados();
            GenerarHTMLMomento2FInResultado(Momento2FInResultado);

            // Momento 2 Funcion Indicador
            //Docente
            List<PanelViewModel> Momento2IndicDocentePlanificacion = ConsultarMomento2IndicDocentePlanificacion();
            GenerarHTMLMomento2IndicDocentePlanificacion(Momento2IndicDocentePlanificacion);

            List<PanelViewModel> Momento2IndicDocenteEjecucion = ConsultarMomento2IndicDocenteEjecucion();
            GenerarHTMLMomento2IndicDocenteEjecucion(Momento2IndicDocenteEjecucion);

            List<PanelViewModel> Momento2IndicDocenteResultado = ConsultarMomento2IndicDocenteResultado();
            GenerarHTMLMomento2IndicDocenteResultado(Momento2IndicDocenteResultado);


            //Investigacion
            List<PanelViewModel> Momento2IndicInvestigacionPlanificacion = ConsultarMomento2IndicInvestigacionPlanificacion();
            GenerarHTMLMomento2IndicInvestigacionPlanificacion(Momento2IndicInvestigacionPlanificacion);

            List<PanelViewModel> Momento2IndicInvestigacionEjecucion = ConsultarMomento2IndicInvestigacionEjecucion();
            GenerarHTMLMomento2IndicInvestigacionEjecucion(Momento2IndicInvestigacionEjecucion);

            List<PanelViewModel> Momento2IndicInvestigacionResultado = ConsultarMomento2IndicInvestigacionResultado();
            GenerarHTMLMomento2IndicInvestigacionResultado(Momento2IndicInvestigacionResultado);


            //Vinculacion
            List<PanelViewModel> Momento2IndicVinculacionPlanificacion = ConsultarMomento2IndicVinculacionPlanificacion();
            GenerarHTMLMomento2IndicVinculacionPlanificacion(Momento2IndicVinculacionPlanificacion);

            List<PanelViewModel> Momento2IndicVinculacionEjecucion = ConsultarMomento2IndicVinculacionEjecucion();
            GenerarHTMLMomento2IndicVinculacionEjecucion(Momento2IndicVinculacionEjecucion);

            List<PanelViewModel> Momento2IndicVinculacionResultado = ConsultarMomento2IndicVinculacionResultado();
            GenerarHTMLMomento2IndicVinculacionResultado(Momento2IndicVinculacionResultado);


            //Condiciones institucionales
            List<PanelViewModel> Momento2IndicCondicionInstitucionalPlanificacion = ConsultarMomento2IndicCondicionInstitucionalPlanificacion();
            GenerarHTMLMomento2IndicCondicionInstitucionalPlanificacion(Momento2IndicCondicionInstitucionalPlanificacion);

            List<PanelViewModel> Momento2IndicCondicionInstitucionalEjecucion = ConsultarMomento2IndicCondicionInstitucionalEjecucion();
            GenerarHTMLMomento2IndicCondicionInstitucionalEjecucion(Momento2IndicCondicionInstitucionalEjecucion);

            List<PanelViewModel> Momento2IndicCondicionInstitucionalResultado = ConsultarMomento2IndicCondicionInstitucionalResultado();
            GenerarHTMLMomento2IndicCondicionInstitucionalResultado(Momento2IndicCondicionInstitucionalResultado);














            // momento 3 

            // Momento 3 Funcion Indicador
            //Docente
            List<PanelViewModel> Momento3IndicDocentePlanificacion = ConsultarMomento3IndicDocentePlanificacion();
            GenerarHTMLMomento3IndicDocentePlanificacion(Momento3IndicDocentePlanificacion);

            List<PanelViewModel> Momento3IndicDocenteEjecucion = ConsultarMomento3IndicDocenteEjecucion();
            GenerarHTMLMomento3IndicDocenteEjecucion(Momento3IndicDocenteEjecucion);

            List<PanelViewModel> Momento3IndicDocenteResultado = ConsultarMomento3IndicDocenteResultado();
            GenerarHTMLMomento3IndicDocenteResultado(Momento3IndicDocenteResultado);


            //Investigacion
            List<PanelViewModel> Momento3IndicInvestigacionPlanificacion = ConsultarMomento3IndicInvestigacionPlanificacion();
            GenerarHTMLMomento3IndicInvestigacionPlanificacion(Momento3IndicInvestigacionPlanificacion);

            List<PanelViewModel> Momento3IndicInvestigacionEjecucion = ConsultarMomento3IndicInvestigacionEjecucion();
            GenerarHTMLMomento3IndicInvestigacionEjecucion(Momento3IndicInvestigacionEjecucion);

            List<PanelViewModel> Momento3IndicInvestigacionResultado = ConsultarMomento3IndicInvestigacionResultado();
            GenerarHTMLMomento3IndicInvestigacionResultado(Momento3IndicInvestigacionResultado);


            //Vinculacion
            List<PanelViewModel> Momento3IndicVinculacionPlanificacion = ConsultarMomento3IndicVinculacionPlanificacion();
            GenerarHTMLMomento3IndicVinculacionPlanificacion(Momento3IndicVinculacionPlanificacion);

            List<PanelViewModel> Momento3IndicVinculacionEjecucion = ConsultarMomento3IndicVinculacionEjecucion();
            GenerarHTMLMomento3IndicVinculacionEjecucion(Momento3IndicVinculacionEjecucion);

            List<PanelViewModel> Momento3IndicVinculacionResultado = ConsultarMomento3IndicVinculacionResultado();
            GenerarHTMLMomento3IndicVinculacionResultado(Momento3IndicVinculacionResultado);


            //Condiciones institucionales
            List<PanelViewModel> Momento3IndicCondicionInstitucionalPlanificacion = ConsultarMomento3IndicCondicionInstitucionalPlanificacion();
            GenerarHTMLMomento3IndicCondicionInstitucionalPlanificacion(Momento3IndicCondicionInstitucionalPlanificacion);

            List<PanelViewModel> Momento3IndicCondicionInstitucionalEjecucion = ConsultarMomento3IndicCondicionInstitucionalEjecucion();
            GenerarHTMLMomento3IndicCondicionInstitucionalEjecucion(Momento3IndicCondicionInstitucionalEjecucion);

            List<PanelViewModel> Momento3IndicCondicionInstitucionalResultado = ConsultarMomento3IndicCondicionInstitucionalResultado();
            GenerarHTMLMomento3IndicCondicionInstitucionalResultado(Momento3IndicCondicionInstitucionalResultado);



        }


        // Momento 1 Fuente de Informacion//


        private void GenerarHTMLMomento1FInPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div  class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;  
            string dimension = "Planificación";  


            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style='font-weight: bold; overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno
                string[] nombres = indicador.NombreFNi.Split(',');
                foreach (var nombre in nombres)
                {
                    // Agrega el NombreFNi, NombreIndic, NombrePadre y Momento con salto de línea
                    html += $"<div style='display: inline-block; margin-right: 5px; max-width: 100%; overflow: hidden; text-overflow: ellipsis;'>{nombre} ";

                    // Agrega los botones Ver y Editar junto a cada NombreFNI
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\",{momento}, \"{dimension}\")'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\",{momento}, \"{dimension}\")'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


                    html += "</div>";
                }
            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralPlanificacionFNiMomento1.Text = html;
        }
        private void GenerarHTMLMomento1FInEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style='font-weight: bold; overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno
                string[] nombres = indicador.NombreFNi.Split(',');
                foreach (var nombre in nombres)
                {
                    // Agrega el NombreFNi, NombreIndic, NombrePadre y Momento con salto de línea
                    html += $"<div style='display: inline-block; margin-right: 5px; max-width: 100%; overflow: hidden; text-overflow: ellipsis;'>{nombre} ";

                    // Agrega los botones Ver y Editar junto a cada NombreFNI
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", {momento}, \"{dimension}\")'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", {momento}, \"{dimension}\")'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


                    html += "</div>";
                }
            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralEjecucionFNiMomento1.Text = html;
        }
        private void GenerarHTMLMomento1FInResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Resultados";



            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style='font-weight: bold; overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno
                string[] nombres = indicador.NombreFNi.Split(',');
                foreach (var nombre in nombres)
                {
                    // Agrega el NombreFNi, NombreIndic, NombrePadre y Momento con salto de línea
                    html += $"<div style='display: inline-block; margin-right: 5px; max-width: 100%; overflow: hidden; text-overflow: ellipsis;'>{nombre} ";

                    // Agrega los botones Ver y Editar junto a cada NombreFNI
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", {momento}, \"{dimension}\")'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", {momento}, \"{dimension}\")'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


                    html += "</div>";
                }
            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralResultadosFNiMomento1.Text = html;
        }


        // Momento 1 Indicador //
        //Docente
        private void GenerarHTMLMomento1IndicDocentePlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                    // Agrega los botones Ver y Editar junto a cada NombreFNI
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralDocentePlanificacionIndicMomento1.Text = html;
        }

        private void GenerarHTMLMomento1IndicDocenteEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralDocenteEjecucionIndicMomento1.Text = html;
        }

        private void GenerarHTMLMomento1IndicDocenteResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralDocenteResultadoIndicMomento1.Text = html;
        }

        //Investigacion
        private void GenerarHTMLMomento1IndicInvestigacionPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralInvestigacionPlanificacionIndicMomento1.Text = html;
        }

        private void GenerarHTMLMomento1IndicInvestigacionEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralInvestigacionEjecucionIndicMomento1.Text = html;
        }

        private void GenerarHTMLMomento1IndicInvestigacionResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralInvestigacionResultadoIndicMomento1.Text = html;
        }


        //Vinculacion
        private void GenerarHTMLMomento1IndicVinculacionPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralVinculacionPlanificacionIndicMomento1.Text = html;
        }

        private void GenerarHTMLMomento1IndicVinculacionEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralVinculacionEjecucionIndicMomento1.Text = html;
        }

        private void GenerarHTMLMomento1IndicVinculacionResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralVinculacionResultadoIndicMomento1.Text = html;
        }
        //Condiciones institucionales
        private void GenerarHTMLMomento1IndicCondicionInstitucionalPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralCondicionInstitucionalPlanificacionIndicMomento1.Text = html;
        }

        private void GenerarHTMLMomento1IndicCondicionInstitucionalEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralCondicionInstitucionalEjecucionIndicMomento1.Text = html;
        }

        private void GenerarHTMLMomento1IndicCondicionInstitucionalResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 1;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralCondicionInstitucionalResultadoIndicMomento1.Text = html;
        }




        //Fuente de Informacion Fuente de Informacion Momento 1 //


        private List<PanelViewModel> ConsultarMomento1FInPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom1 = '{Session["UserEquipo"].ToString()}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    // Elimina la siguiente línea si no necesitas IdIndic
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }


        private List<PanelViewModel> ConsultarMomento1FInEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom1 = '{Session["UserEquipo"].ToString()}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    // Elimina la siguiente línea si no necesitas IdIndic
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento1FInResultados()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom1 = '{Session["UserEquipo"].ToString()}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    // Elimina la siguiente línea si no necesitas IdIndic
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        //Docente Indicador Momento 1 //
        //Docente
        private List<PanelViewModel> ConsultarMomento1IndicDocentePlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Docencia}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento1IndicDocenteEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Docencia}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento1IndicDocenteResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Docencia}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }
        //Investigacion
        private List<PanelViewModel> ConsultarMomento1IndicInvestigacionPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Investigación}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento1IndicInvestigacionEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Investigación}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento1IndicInvestigacionResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Investigación}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }
        //Vinculacion
        private List<PanelViewModel> ConsultarMomento1IndicVinculacionPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Vinculación}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento1IndicVinculacionEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Vinculación}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento1IndicVinculacionResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Vinculación}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }
        //Condiciones institucionales
        private List<PanelViewModel> ConsultarMomento1IndicCondicionInstitucionalPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.CondicionIns}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento1IndicCondicionInstitucionalEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.CondicionIns}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento1IndicCondicionInstitucionalResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom1 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.CondicionIns}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }




























        // Momento 2 Fuente de Informacion//


        private void GenerarHTMLMomento2FInPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Planificación";


            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style='font-weight: bold; overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno
                string[] nombres = indicador.NombreFNi.Split(',');
                foreach (var nombre in nombres)
                {
                    // Agrega el NombreFNi, NombreIndic, NombrePadre y Momento con salto de línea
                    html += $"<div style='display: inline-block; margin-right: 5px; max-width: 100%; overflow: hidden; text-overflow: ellipsis;'>{nombre} ";

                    // Agrega los botones Ver y Editar junto a cada NombreFNI
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\",{momento}, \"{dimension}\")'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\",{momento}, \"{dimension}\")'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


                    html += "</div>";
                }
            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralPlanificacionFNiMomento2.Text = html;
        }
        private void GenerarHTMLMomento2FInEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style='font-weight: bold; overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno
                string[] nombres = indicador.NombreFNi.Split(',');
                foreach (var nombre in nombres)
                {
                    // Agrega el NombreFNi, NombreIndic, NombrePadre y Momento con salto de línea
                    html += $"<div style='display: inline-block; margin-right: 5px; max-width: 100%; overflow: hidden; text-overflow: ellipsis;'>{nombre} ";

                    // Agrega los botones Ver y Editar junto a cada NombreFNI
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", {momento}, \"{dimension}\")'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", {momento}, \"{dimension}\")'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


                    html += "</div>";
                }
            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralEjecucionFNiMomento2.Text = html;
        }
        private void GenerarHTMLMomento2FInResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Resultados";


            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style='font-weight: bold; overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno
                string[] nombres = indicador.NombreFNi.Split(',');
                foreach (var nombre in nombres)
                {
                    // Agrega el NombreFNi, NombreIndic, NombrePadre y Momento con salto de línea
                    html += $"<div style='display: inline-block; margin-right: 5px; max-width: 100%; overflow: hidden; text-overflow: ellipsis;'>{nombre} ";

                    // Agrega los botones Ver y Editar junto a cada NombreFNI
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", {momento}, \"{dimension}\")'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                    html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickFIn(\"{nombre}\", \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", {momento}, \"{dimension}\")'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


                    html += "</div>";
                }
            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralResultadosFNiMomento2.Text = html;
        }


        // Momento 2 Indicador //
        //Docente
        private void GenerarHTMLMomento2IndicDocentePlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralDocentePlanificacionIndicMomento2.Text = html;
        }

        private void GenerarHTMLMomento2IndicDocenteEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralDocenteEjecucionIndicMomento2.Text = html;
        }

        private void GenerarHTMLMomento2IndicDocenteResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralDocenteResultadoIndicMomento2.Text = html;
        }

        //Investigacion
        private void GenerarHTMLMomento2IndicInvestigacionPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralInvestigacionPlanificacionIndicMomento2.Text = html;
        }

        private void GenerarHTMLMomento2IndicInvestigacionEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralInvestigacionEjecucionIndicMomento2.Text = html;
        }

        private void GenerarHTMLMomento2IndicInvestigacionResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralInvestigacionResultadoIndicMomento2.Text = html;
        }


        //Vinculacion
        private void GenerarHTMLMomento2IndicVinculacionPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralVinculacionPlanificacionIndicMomento2.Text = html;
        }

        private void GenerarHTMLMomento2IndicVinculacionEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralVinculacionEjecucionIndicMomento2.Text = html;
        }

        private void GenerarHTMLMomento2IndicVinculacionResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralVinculacionResultadoIndicMomento2.Text = html;
        }
        //Condiciones institucionales
        private void GenerarHTMLMomento2IndicCondicionInstitucionalPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralCondicionInstitucionalPlanificacionIndicMomento2.Text = html;
        }

        private void GenerarHTMLMomento2IndicCondicionInstitucionalEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralCondicionInstitucionalEjecucionIndicMomento2.Text = html;
        }

        private void GenerarHTMLMomento2IndicCondicionInstitucionalResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 2;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralCondicionInstitucionalResultadoIndicMomento2.Text = html;
        }




        //Fuente de Informacion Fuente de Informacion Momento 2 //


        private List<PanelViewModel> ConsultarMomento2FInPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    // Elimina la siguiente línea si no necesitas IdIndic
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }


        private List<PanelViewModel> ConsultarMomento2FInEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    // Elimina la siguiente línea si no necesitas IdIndic
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento2FInResultados()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    // Elimina la siguiente línea si no necesitas IdIndic
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        //Docente Indicador Momento 2 //
        //Docente
        private List<PanelViewModel> ConsultarMomento2IndicDocentePlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Docencia}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento2IndicDocenteEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Docencia}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento2IndicDocenteResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Docencia}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }
        //Investigacion
        private List<PanelViewModel> ConsultarMomento2IndicInvestigacionPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Investigación}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento2IndicInvestigacionEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Investigación}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento2IndicInvestigacionResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Investigación}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }
        //Vinculacion
        private List<PanelViewModel> ConsultarMomento2IndicVinculacionPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Vinculación}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento2IndicVinculacionEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Vinculación}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento2IndicVinculacionResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Vinculación}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }
        //Condiciones institucionales
        private List<PanelViewModel> ConsultarMomento2IndicCondicionInstitucionalPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.CondicionIns}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento2IndicCondicionInstitucionalEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.CondicionIns}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento2IndicCondicionInstitucionalResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipFueMom2 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.CondicionIns}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }



















        // Momento 3 


        // Momento 3 Indicador //
        //Docente
        private void GenerarHTMLMomento3IndicDocentePlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


                html += "</div>";
            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralDocentePlanificacionIndicMomento3.Text = html;
        }

        private void GenerarHTMLMomento3IndicDocenteEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


                html += "</div>";
            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralDocenteEjecucionIndicMomento3.Text = html;
        }

        private void GenerarHTMLMomento3IndicDocenteResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";


                html += "</div>";
            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralDocenteResultadoIndicMomento3.Text = html;
        }

        //Investigacion
        private void GenerarHTMLMomento3IndicInvestigacionPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralInvestigacionPlanificacionIndicMomento3.Text = html;
        }

        private void GenerarHTMLMomento3IndicInvestigacionEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralInvestigacionEjecucionIndicMomento3.Text = html;
        }

        private void GenerarHTMLMomento3IndicInvestigacionResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralInvestigacionResultadoIndicMomento3.Text = html;
        }


        //Vinculacion
        private void GenerarHTMLMomento3IndicVinculacionPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralVinculacionPlanificacionIndicMomento3.Text = html;
        }

        private void GenerarHTMLMomento3IndicVinculacionEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralVinculacionEjecucionIndicMomento3.Text = html;
        }

        private void GenerarHTMLMomento3IndicVinculacionResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralVinculacionResultadoIndicMomento3.Text = html;
        }
        //Condiciones institucionales
        private void GenerarHTMLMomento3IndicCondicionInstitucionalPlanificacion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Planificación</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Planificación";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralCondicionInstitucionalPlanificacionIndicMomento3.Text = html;
        }

        private void GenerarHTMLMomento3IndicCondicionInstitucionalEjecucion(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Ejecución</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Ejecución";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralCondicionInstitucionalEjecucionIndicMomento3.Text = html;
        }

        private void GenerarHTMLMomento3IndicCondicionInstitucionalResultado(List<PanelViewModel> indicadores)
        {
            // Construir el HTML para los resultados
            string html = "<div class='card'><div class='card-header' style='font-weight: bold;'>Resultados</div>";

            // Aplica el estilo white-space: nowrap; y max-width al div que contiene los nombres
            html += "<div class='card-body' style='max-width: 100%; overflow: hidden;'>";

            // Variable para almacenar el valor de Momento
            int momento = 3;
            string dimension = "Resultados";

            foreach (var indicador in indicadores)
            {
                // Agrega primero el NombreIndic en negrita con un salto de línea
                html += $"<div style=' overflow: hidden; text-overflow: ellipsis;'>{indicador.NombreIndic} </div>";

                // Divide los NombreFNi y agrega los botones para cada uno

                // Agrega los botones Ver y Editar junto a cada NombreFNI
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnEdit_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-pencil\" aria-hidden=\"true\"></i></button>";
                html += $"<button type='button' class='btn btn-primary btn-xs dt-action' onclick='BtnView_ClickIndic( \"{indicador.NombreIndic}\", \"{indicador.NombrePadre}\", \"{indicador.NombreFNi}\", \"{indicador.Variables}\", \"{indicador.Formula}\", \"{dimension}\", {momento})'><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></button>";



            }

            html += "</div></div>";
            // Asignar el HTML al control Literal
            LiteralCondicionInstitucionalResultadoIndicMomento3.Text = html;
        }






        //Docente Indicador Momento 3 //
        //Docente
        private List<PanelViewModel> ConsultarMomento3IndicDocentePlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Docencia}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento3IndicDocenteEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Docencia}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento3IndicDocenteResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Docencia}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }
        //Investigacion
        private List<PanelViewModel> ConsultarMomento3IndicInvestigacionPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Investigación}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento3IndicInvestigacionEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Investigación}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento3IndicInvestigacionResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Investigación}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }
        //Vinculacion
        private List<PanelViewModel> ConsultarMomento3IndicVinculacionPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Vinculación}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento3IndicVinculacionEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Vinculación}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento3IndicVinculacionResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.Vinculación}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }
        //Condiciones institucionales
        private List<PanelViewModel> ConsultarMomento3IndicCondicionInstitucionalPlanificacion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.CondicionIns}' and i.strCod_dimen = '{VariablesGenerales.Planificacion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento3IndicCondicionInstitucionalEjecucion()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.CondicionIns}' and i.strCod_dimen = '{VariablesGenerales.Ejecucion.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }

        private List<PanelViewModel> ConsultarMomento3IndicCondicionInstitucionalResultado()
        {
            List<PanelViewModel> lista = new List<PanelViewModel>();

            // Ajusta la cadena de conexión según tu configuración
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                if (Session["UserEquipo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    cn.Open();
                    string queryString = $"select * from GC_INDIC i inner join GC_EQUIP e on i.strCod_EquipProces = e.strCod_Equip inner join GC_USERS u on u.strCod_Equip = e.strCod_Equip  where i.strCod_EquipIndMom3 = '{Session["UserEquipo"].ToString()}'and i.strCod_func= '{VariablesGenerales.CondicionIns}' and i.strCod_dimen = '{VariablesGenerales.Resultados.ToString()}'";
                    using (SqlCommand command = new SqlCommand(queryString, cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PanelViewModel indicador = new PanelViewModel
                                {
                                    IdIndic = reader["strCod_indic"].ToString(),
                                    NombreIndic = reader["strNombre_indic"].ToString(),
                                    NombrePadre = reader["strCod_padre"].ToString(),
                                    NombreFNi = reader["string_fni"].ToString(),
                                    Variables = reader["string_variab"].ToString(),
                                    Formula = reader["strFmCalculo_indic"].ToString()
                                };

                                lista.Add(indicador);
                            }
                        }
                    }
                }
            }

            return lista;
        }





    }
    [Serializable]
    public class PanelViewModel
    {
        [JsonProperty("strCod_indic")]
        [Required]
        public string IdIndic { get; set; }

        [JsonProperty("strNombre_indic")]
        [Required]
        public string NombreIndic { get; set; }

        [JsonProperty("string_fni")]
        [Required]
        public string NombreFNi { get; set; }

        [JsonProperty("strCod_padre")]
        [Required]
        public string NombrePadre { get; set; }


        [JsonProperty("string_variab")]
        [Required]
        public string Variables { get; set; }

        [JsonProperty("strFmCalculo_indic")]
        [Required]
        public string Formula { get; set; }




    }
}
