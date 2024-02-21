<%@ Page Title="GestionUsuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="sigac.view.GestionUsuarios" %>

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
                <a  class="fa fa-cog" href="/view/ViewsGestionUsuarios/ViewsRoles/Roles" style="font-size:100px;"></a>
                <br />
                Roles
            </div>



            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-user" href="/view/ViewsGestionUsuarios/ViewsUsuarios/Usuarios" style="font-size:100px;"></a>
                <br />
                Usuarios
            </div>



            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-users" href="/view/ViewsGestionUsuarios/ViewsEquipos/Equipos" style="font-size:100px;"></a>
                <br />
                Equipos
            </div>



            

            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto text-center">
                <a  class="fa fa-users" href="/view/ViewsGestionUsuarios/ViewsPadres/Padres" style="font-size:100px;"></a>
                <br />
                Padres
            </div>
           
           



        </div>

       
            </div>

    </div>
            </div>

</asp:Content>

