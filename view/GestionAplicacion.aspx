<%@ Page  Title="GestionAplicacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionAplicacion.aspx.cs" Inherits="sigac.view.GestionAplicacion" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

       <div class="contenido">


<div class="main">
            
    
    <span id="MainContent_lblMsg" class="alert alert-info" style="display:inline-block;color:#F20101;background-color:#D9EDF7;width:100%;">SISTEMA GESTIÓN DE CALIDAD SIGAC</span>
   


        <div class="container" style="width:100%">

        <div class="panel-heading">
            <span class="alert  alert-dismissable"><strong>SELECCIONE LA OPCIÓN QUE DESEA REALIZAR..</strong></span><br />
        </div>
        <hr class="alert-info" />
        <div class="vista" style="width:100%">


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a class="fa fa-home" href="/" style="font-size:100px;"></a>
                <br />
                Inicio
            </div>

            


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto  text-center">
                <a  class="fa fa-cog" href="/view/ViewsGestionAplicaciones/ViewsFunciones/Funciones" style="font-size:100px;"></a>
                <br />
                Funciones
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto  text-center">
                <a  class="fa fa-cube" href="/view/ViewsGestionAplicaciones/ViewsDimensiones/Dimensiones" style="font-size:100px;"></a>
                <br />
                Dimensiones
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto  text-center">
                <a  class="fa fa-cogs" href="/view/ViewsGestionAplicaciones/ViewsTiposProcesos/TiposProcesos" style="font-size:100px;"></a>
                <br />
                Tipos de Procesos
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto  text-center">
                <a  class="fa fa-file-text-o" href="/view/ViewsGestionAplicaciones/ViewsProcesos/Procesos" style="font-size:100px;"></a>
                <br />
                Procesos
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-th-large" href="/view/ViewsGestionAplicaciones/ViewsComponentes/Componentes" style="font-size:100px;"></a>
                <br />
                Componentes
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-files-o" href="/view/ViewsGestionAplicaciones/ViewsPeriodicidades/Periodicidades" style="font-size:100px;"></a>
                <br />
                Periodicidades
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-line-chart" href="/view/ViewsGestionAplicaciones/ViewsVariables/Variables" style="font-size:100px;"></a>
                <br />
                Variables
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-file-pdf-o" href="/view/ViewsGestionAplicaciones/ViewsFuentesInformacion/FuentesInformacion" style="font-size:100px;"></a>
                <br />
                Fuentes de Información
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-search" href="/view/ViewsGestionAplicaciones/ViewsEvidencias/Evidencias" style="font-size:100px;"></a>
                <br />
                Evidencias
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-indent" href="/view/ViewsGestionAplicaciones/ViewsIndicadores/Indicadores" style="font-size:100px;"></a>
                <br />
                Indicadores
            </div>


        </div>

        <br />
        <div class="col-sm-12 col-md-12 col-lg-12" style="text-align:center">
            <hr class="alert-info" />
            <a href="http://ior.ad/6z9G" target="_blank">GUÍA DEL USUARIO</a>

        </div>
            </div>

    </div>
            </div>

</asp:Content>