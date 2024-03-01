<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="sigac._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

          <div class="contenido">
        <div class="main">
            <span id="MainContent_lblMsg" class="alert alert-info" style="display:inline-block;color:#F20101;background-color:#D9EDF7;width:100%;">SISTEMA GESTIÓN DE CALIDAD SIGAC</span>

            <div class="container" style="width:100%">
                <div class="panel-heading">
                    <span class="alert  alert-dismissable"><strong>SELECCIONE LA OPCIÓN QUE DESEA REALIZAR..</strong></span><br />
                </div>
                
      <form id="form1" runat="server">
                <div class="Cerrar">
        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />            
                </div>
                    </form>
                <hr class="alert-info" />
                <div class="vista">

                    <% if (Session["UsuarioAutenticado"] != null && (bool)Session["UsuarioAutenticado"]) { %>
                        <% if (Session["UserRole"].ToString() == "1") { %>

                    <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
                        <a class="fa fa-home" href="http://www.utc.edu.ec" style="font-size:100px;"></a>
                        <br />
                        Página principal UTC
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
                        <a class="fa fa-tachometer" href="/view/PanelControl" style="font-size:100px;"></a>
                        <br />
                        Panel de Control
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
                        <a class="fa fa-users" href="/view/GestionUsuarios" style="font-size:100px;"></a>
                        <br />
                        Gestión de Usuarios
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
                        <a class="fa fa-cogs" href="/view/GestionAplicacion" style="font-size:100px;"></a>
                        <br />
                        Gestión de Aplicación
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
                        <a class="fa fa-th" href="/view/GestionProcesos" style="font-size:100px;"></a>
                        <br />
                        Gestión de Procesos
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
                        <a class="fa fa-file-pdf-o" href="/view/GestionInformes" style="font-size:100px;"></a>
                        <br />
                        Gestión de Informes
                    </div>
                    <!--
                    <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
                        <a class="fa fa-user" href="/view/Perfil" style="font-size:100px;"></a>
                        <br />
                        Perfil
                    </div>
                    -->
                        <% } else if (Session["UserRole"].ToString() == "2") { %>
                            <!-- Mostrar elementos para Empleados -->
                           
                    <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
                        <a class="fa fa-tachometer" href="/view/PanelControl" style="font-size:100px;"></a>
                        <br />
                        Panel de Control
                    </div>

                    <!--
                            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
<a href="https://app.powerbi.com/reportEmbed?reportId=24748a50-89c2-4fc6-a4b6-26a81b9dbdc5&autoAuth=true&ctid=136a0da6-6e34-4ca2-933d-36fa7895468e" target="_blank" style="font-size:100px;">
    <i class="fa fa-file-pdf-o"></i>
</a>
                                <br />
                                Gestión de Informes
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-md-auto">
                                <a class="fa fa-user" href="/view/Perfil" style="font-size:100px;"></a>
                                <br />
                                Perfil
                            </div>
                        -->
                        <% } %>
                        <!-- Otros elementos comunes para todos los roles -->
                        <!-- ... -->
                    <% } else { %>
                        <!-- Elementos para usuarios no autenticados -->
                        <!-- ... -->
                    <% } %>

                    
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
