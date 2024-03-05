<%@ Page Title="Indicadores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Indicadores.aspx.cs" Inherits="sigac.view.ViewsGestionAplicaciones.ViewsIndicadores.Indicadores" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <div class="contenido" style="background-color: #EBEDEF;">
            <div class="main">
                <div class="container-fluid" >
                    <h2 class="mb-4">GESTIÓN DE INDICADORES</h2>
                    <div class="vertical-space">                        
    
                        <asp:Button runat="server" class="btn btn-success" ID="BtnCreate" OnClick="BtnCreate_Click" Text="Agregar" />

                        <asp:GridView ID="GridViewIndicador" runat="server" CssClass="table table-striped table-bordered descarga" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ItemStyle-CssClass="oculto" />



                                <asp:BoundField DataField="Nombre" HeaderText="Nombre:" SortExpression="Nombre" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción:" SortExpression="Descripcion" />
                                <asp:BoundField DataField="Calculo" HeaderText="Cálculo:" SortExpression="Calculo" />

                           
                           
                                 <asp:BoundField DataField="func" HeaderText="Función" SortExpression="func" /> 


                                <asp:BoundField DataField="dimen" HeaderText="Dimensión" SortExpression="dimen" />

                                
                                <asp:BoundField DataField="tpro" HeaderText="Tipo de Proceso" SortExpression="tpro" />
                                <asp:BoundField DataField="proces" HeaderText="Proceso" SortExpression="proces" />
                                <asp:BoundField DataField="comp" HeaderText="Componente" SortExpression="comp" />

                                
                                <asp:BoundField DataField="period" HeaderText="Periodo" SortExpression="period" />
                                <asp:BoundField DataField="variab" HeaderText="Variables" SortExpression="variab" />
                                <asp:BoundField DataField="fni" HeaderText="Fuente de Indicador" SortExpression="fni" />

                                
                                <asp:BoundField DataField="evid" HeaderText="Evidencia" SortExpression="evid" />
                                <asp:BoundField DataField="padre" HeaderText="Padre" SortExpression="padre" />


   

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