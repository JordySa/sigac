<%@ Page Title="Proyectos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proyectos.aspx.cs" Inherits="sigac.view.ViewsGestionProcesos.ViewsProyectos.Proyectos" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

      <form id="form1" runat="server">
        <div class="contenido" style="background-color: #EBEDEF;">
            <div class="main">
                <div class="container-fluid" ">
                    <h2 class="mb-4">GESTION DE PROYECTOS</h2>
                    <div class="vertical-space">                        
    
                        <asp:Button runat="server" class="btn btn-success" ID="BtnCreate" OnClick="BtnCreate_Click" Text="Agregar" />

                        <asp:GridView ID="GridViewProyecto" runat="server" CssClass="table table-striped table-bordered descarga" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ItemStyle-CssClass="oculto" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                <asp:BoundField DataField="IdIdic" HeaderText="Indicador" SortExpression="IdIdic" />
                                <asp:BoundField DataField="FechaI" HeaderText="Fecha de Inicio" SortExpression="FechaI" />
                                <asp:BoundField DataField="FechaF" HeaderText="Fecha Culminacion" SortExpression="FechaF" />


                                <%-- Momento Fuente de Informacion 1 --%>
                                <asp:BoundField DataField="FechaMomentoIFIn1" HeaderText="Fecha de Inicio Momento Fuente de Informacion 1" SortExpression="FechaMomentoIFIn1" />
                                <asp:BoundField DataField="FechaMomentoFFIn1" HeaderText="Fecha Culminacion Momento Fuente de Informacion 1" SortExpression="FechaMomentoFFIn1" />

                                <%-- Momento Fuente de Informacion  2 --%>
                                <asp:BoundField DataField="FechaMomentoIFIn2" HeaderText="Fecha de Inicio Momento Fuente de Informacion 2" SortExpression="FechaMomentoIFIn2" />
                                <asp:BoundField DataField="FechaMomentoFFIn2" HeaderText="Fecha Culminacion Momento Fuente de Informacion 2" SortExpression="FechaMomentoFFIn2" />

                                <%-- Momento Indicador 1 --%>
                                <asp:BoundField DataField="FechaMomentoIInd1" HeaderText="Fecha de Inicio Momento del Indicador 1" SortExpression="FechaMomentoIInd1" />
                                <asp:BoundField DataField="FechaMomentoFInd1" HeaderText="Fecha Culminacion Momento del Indicador 1" SortExpression="FechaMomentoFInd1" />

                                <%-- Momento Indicador 2 --%>
                                <asp:BoundField DataField="FechaMomentoIInd2" HeaderText="Fecha de Inicio Momento del Indicador 2" SortExpression="FechaMomentoIInd2" />
                                <asp:BoundField DataField="FechaMomentoFInd2" HeaderText="Fecha Culminacion Momento Fuente de Informacion 2" SortExpression="FechaMomentoFInd2" />

                                <%-- Momento Indicador 3 --%>
                                <asp:BoundField DataField="FechaMomentoIInd3" HeaderText="Fecha de Inicio Momento del Indicador 3" SortExpression="FechaMomentoIInd3" />
                                <asp:BoundField DataField="FechaMomentoFInd3" HeaderText="Fecha Culminacion Momento del Indicador 3" SortExpression="FechaMomentoFInd3" />


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
