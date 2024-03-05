
<%@ Page Title="FuenteIndormacionMantenimiento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FuenteIndormacionMantenimiento.aspx.cs" Inherits="sigac.view.ViewsGestionProcesos.ViewsFuenteInformacion.FuenteIndormacionMantenimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.7.1/css/buttons.dataTables.min.css">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.print.min.js"></script>



        <div class="contenido" style="background-color: #EBEDEF;">
            <div class="main">
                <div class="container" style="width:100%; background-color: #fff; padding:12px; ">
                    <div class="vertical-space">  


    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>

    <div class="mx-auto" style="width:100%">
        <asp:Label runat="server" CssClass="h2" ID="Lbltitulo"> </asp:Label>
    </div>
    
    <form id="form1" runat="server" class="">
        <div>
            <!--
            <div class="mb-3">
                <label class="form-label">ID:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbid" ReadOnly="true" required="true"></asp:TextBox>
            </div>  
            -->


            <div class="row">


    <div class="col-md-12">

            <!-- Primera columna -->

                <div>
            <label class="form-label">Nombre Fuente de Información:</label>
    <asp:Label  runat="server" ID="TxtNombreFNi"  BorderWidth="0" ></asp:Label>
</div>
                <div>
            <label class="form-label">Dimensión:</label>
    <asp:TextBox runat="server" ID="TxtDimension" ReadOnly="true" BorderWidth="0" CssClass="label-like"></asp:TextBox>
</div>
            <!--
<div>
            <label class="form-label">Indicador:</label>
<asp:TextBox runat="server" ID="TxtNombreIndic"  CssClass="label-like" Width="100%" ReadOnly="true"></asp:TextBox>
</div>-->

            <!--<div>
            <label class="form-label">Nombre Padre:</label>
<asp:TextBox runat="server" ID="TxtNombrePadre"  CssClass="label-like" Width="100%" ReadOnly="true"></asp:TextBox>
</div>-->
<div>
            <label class="form-label">Momento:</label>
    <asp:TextBox runat="server" ID="TxtMomento" ReadOnly="true" BorderWidth="0" CssClass="label-like"></asp:TextBox>
</div>
<div>
            <label class="form-label">Nombre de documentos:</label>
    <asp:TextBox runat="server" ID="NameDOc" ReadOnly="true" BorderWidth="0" CssClass="label-like"></asp:TextBox>
</div>
<div>
            <label class="form-label">Nombre del proyecto:</label>
    <asp:TextBox runat="server" ID="TxtNombreProyecto" ReadOnly="true" BorderWidth="0" CssClass="label-like"></asp:TextBox>
</div>


<div class="mb-4-custom">
    <label class="form-label">Documentos:</label>
    <asp:FileUpload runat="server" CssClass="form-control" ID="fileUpload" multiple="multiple" />
    <asp:Button runat="server" Text="Subir Archivos" OnClick="SubirArchivos_Click" CssClass="btn btn-primary mt-2" />
</div>

<asp:GridView runat="server" ID="gvArchivos" AutoGenerateColumns="false" CssClass="table">
    <Columns>
        <asp:BoundField DataField="NombreArchivo" HeaderText="Nombre del Archivo" />
        <asp:BoundField DataField="Tamaño" HeaderText="Tamaño (bytes)" />
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkDescargar" CommandArgument='<%# Eval("NombreArchivo") %>' OnClick="DescargarArchivo">Descargar</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkEliminar" CommandArgument='<%# Eval("NombreArchivo") %>' OnClick="EliminarArchivo">Eliminar</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


    </div>
    <div class="col-md-1">
    </div>

        </div>


            
            <asp:Button runat="server" class="btn btn-primary" ID="BtnCreate" OnClick="BtnCreate_Click" Text="Crear"  Visible="false"/>
            <asp:Button runat="server" class="btn btn-primary" ID="BtnUpdate" OnClick="BtnUpdate_Click" Text="Editar" Visible="false"/>
            <asp:Button runat="server" class="btn btn-primary" ID="BtnDelete" OnClick="BtnDelete_Click" Text="Eliminar" Visible="false"/> 

        
<asp:Button runat="server" class="btn btn-primary btn-dark" ID="BtnReturn" Text="Volver" Visible="true" OnClientClick="return redirectToPage();" />
<asp:Button runat="server" class="btn btn-primary btn-dark" ID="BtnReturnAdmin" Text="Volver" Visible="false" OnClientClick="return redirectToPageAdmin();" />


        </div>






    </form>

              
        </div>
                    </div>

                </div>        



                </div>
    <style>
        .mb-4-custom {
    margin-bottom: 1.5rem; /* Puedes ajustar el valor según sea necesario */
}
    </style>

    <script type="text/javascript">
        function redirectToPage() {
            // Agrega aquí la URL a la que quieres redirigir
            var url = '/view/PanelControl.aspx';

            // Realiza la redirección en JavaScript
            window.location.href = url;

            // Devuelve false para evitar el envío del formulario si es un botón dentro de un formulario
            return false;
        }
        function redirectToPageAdmin() {
            // Agrega aquí la URL a la que quieres redirigir
            var url = '/view/ViewsGestionProcesos/ViewsFuenteInformacion/FuenteInformacion.aspx';

            // Realiza la redirección en JavaScript
            window.location.href = url;

            // Devuelve false para evitar el envío del formulario si es un botón dentro de un formulario
            return false;
        }
    </script>

</asp:Content>
