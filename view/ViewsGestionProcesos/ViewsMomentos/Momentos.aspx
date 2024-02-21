<%@ Page Title="Proyectos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Momentos.aspx.cs" Inherits="sigac.view.ViewsGestionProcesos.ViewsMomentos.Momentos" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

      <form id="form1" runat="server">
          

        <div class="contenido" style="background-color: #EBEDEF;">
            <div class="main">
                

        <div class="Cerrar">
<asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />            
        </div>

                <div class="container-fluid" >
                    

                    <h2 class="mb-4">GESTION DE MOMENTOS</h2>
                    <div class="vertical-space">                        
    
                        <asp:Button runat="server" class="btn btn-success" ID="BtnCreate" OnClick="BtnCreate_Click" Text="Agregar" />

                        <asp:GridView ID="GridViewMomento" runat="server" CssClass="table table-striped table-bordered descarga" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ItemStyle-CssClass="oculto" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="FechaI" HeaderText="Fecha de Inicio" SortExpression="FechaI" />
                                <asp:BoundField DataField="FechaF" HeaderText="Fecha Culminacion" SortExpression="FechaF" />
                                <asp:BoundField DataField="Archivo" HeaderText="Archivo" SortExpression="Archivo" />
                                <asp:BoundField DataField="decValor" HeaderText="Valor" SortExpression="decValor" />
                                <asp:BoundField DataField="Est" HeaderText="Estado" SortExpression="Est" />
                                <asp:BoundField DataField="Nota" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="decValor" HeaderText="Valor" SortExpression="decValor" />
                                <asp:BoundField DataField="IdFase" HeaderText="Fase" SortExpression="IdFase" />
                                <asp:BoundField DataField="IdFni" HeaderText="Funcion Inicial" SortExpression="IdFni" />
                                <asp:BoundField DataField="IdRespons" HeaderText="Responsable" SortExpression="IdRespons" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:Button runat="server" class="btn btn-primary btn-xs dt-action" ID="BtnView" OnClick="BtnView_Click" Text="Ver" />
                                        <asp:Button runat="server" class="btn btn-primary btn-xs dt-action" ID="BtnEdit" OnClick="BtnEdit_Click" Text="Editar" />
                                        <asp:Button runat="server" class="btn btn-danger btn-xs dt-action" ID="BtnDelete" OnClick="BtnDelete_Click" Text="Eliminar" />                                            
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="thead-dark" />
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </form>




    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css">
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.7.1/css/buttons.dataTables.min.css">
<script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.js"></script>
<script src="https://cdn.datatables.net/buttons/1.7.1/js/dataTables.buttons.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
<script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.html5.min.js"></script>
<script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.print.min.js"></script>




<style>
    .oculto {
        display: none;
    }
</style>






</asp:Content>

