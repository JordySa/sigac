﻿<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="sigac.view.ViewsGestionUsuarios.ViewsUsuarios.Usuarios" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <form id="form1" runat="server">
        <div class="contenido" style="background-color: #EBEDEF;">
            <div class="main">
                <div class="container" style="width:100%; background-color: #fff; padding:12px; ">
                    <h2 class="mb-4">GESTIÓN DE USUARIOS</h2>
                    <div class="vertical-space">                        
    
                        <asp:Button runat="server" class="btn btn-success" ID="BtnCreate" OnClick="BtnCreate_Click" Text="Agregar" />

                        <asp:GridView ID="GridViewUsuario" runat="server" CssClass="table table-striped table-bordered descarga" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ItemStyle-CssClass="oculto" />
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                                <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                                <asp:BoundField DataField="Equipo" HeaderText="Equipo" SortExpression="Equipo" />
                                 <asp:TemplateField HeaderText="Rol" SortExpression="Rol">
                                            <ItemTemplate>
                                                <asp:Label ID="LblRol" runat="server" Text='<%# Eval("NombreRol") %>'></asp:Label>
                                            </ItemTemplate>
                                </asp:TemplateField>                                
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
