<%@ Page Title="GestionUsuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionInformes.aspx.cs" Inherits="sigac.view.GestionInformes" %>

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
                <a  class="fa fa-home" href="/" style="font-size:100px;"></a>
                <br />
                Inicio
            </div>


            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-tachometer" href="/view/ViewsGestiónInformes/ViewsReporteIndicadores/ReporteIndicadores" style="font-size:100px;"></a>
                <br />
                Kpi
            </div>
        </div>

       
            </div>

    </div>
            </div>

</asp:Content>


