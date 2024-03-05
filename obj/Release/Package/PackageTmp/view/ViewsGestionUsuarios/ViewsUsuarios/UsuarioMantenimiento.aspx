<%@ Page Title="UsuarioMantenimiento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="UsuarioMantenimiento.aspx.cs" Inherits="sigac.view.ViewsGestionUsuarios.ViewsUsuarios.UsuarioMantenimiento" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    



        <div class="contenido" style="background-color: #EBEDEF;">
            <div class="main">
                <div class="container" style="width:100%; background-color: #fff; padding:12px; ">
                    <div class="vertical-space">  



    <div class="mx-auto" style="width:250px">
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


    <!-- Primera columna -->
    <div class="col-md-6">
        <div class="mb-4-custom">
            <label class="form-label">Usuario:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbusuario" required="true"></asp:TextBox>
        </div>
        
        <div class="mb-4-custom">
            <label class="form-label">Nombre:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbnombre" required="true"></asp:TextBox>
        </div>

        <div class="mb-4-custom">
            <label class="form-label">Apellido:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbapellido" required="true"></asp:TextBox>
        </div>

                <div class="mb-4-custom">
            <label class="form-label">Contraseña:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbpassword" TextMode="Password" placeholder="Ingrese su contraseña" required="true" ></asp:TextBox>
        </div>
    </div>

    <div class="col-md-1">
    </div>

    <!-- Segunda columna -->
    <div class="col-md-5">


        
        <div class="mb-4-custom">
            <label class="form-label">Email:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbemail" required="true"></asp:TextBox>
        </div>
        
         <div class="mb-4-custom">
             <label class="form-label">Rol:</label>
             <asp:DropDownList runat="server" CssClass="form-control" ID="ddlRol" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceRol" DataTextField="strResProces_Rol" DataValueField="strCod_Rol">
                 <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
             </asp:DropDownList>
         </div>


      <div class="mb-4-custom">
    <label class="form-label">Equipo:</label>
    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlequip" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceEquipo" DataTextField="strNombre_Equip" DataValueField="strCod_Equip">
        <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
    </asp:DropDownList>
</div>

    


        <div class="mb-4-custom">
            <label class="form-label">Estado:</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEst" required="true">
            <asp:ListItem Text="-- Seleccione --" Value="" />
            <asp:ListItem Text="Activo" Value="1" />
            <asp:ListItem Text="Inactivo" Value="0" />
        </asp:DropDownList>
        </div>
    </div>
</div>
                                        <asp:HiddenField runat="server" ID="hfSelectedEquip" />



            <asp:Button runat="server" class="btn btn-primary" ID="BtnCreate" OnClick="BtnCreate_Click" Text="Crear" Visible="false"/>
            <asp:Button runat="server" class="btn btn-primary" ID="BtnUpdate" OnClick="BtnUpdate_Click" Text="Editar" Visible="false"/>
            <asp:Button runat="server" class="btn btn-primary" ID="BtnDelete" OnClick="BtnDelete_Click" Text="Eliminar" Visible="false"/> 
        
<asp:Button runat="server" class="btn btn-primary btn-dark" ID="BtnReturn" Text="Volver" Visible="true" OnClientClick="return redirectToPage();" />
        </div>
    </form>

              
        </div>
                    </div>

                </div>        
    <asp:SqlDataSource ID="SqlDataSourceEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_equip, strNombre_equip FROM GC_EQUIP"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceRol" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_Rol, strResProces_Rol FROM GC_ROL"></asp:SqlDataSource>


                </div>
    <style>
        .mb-4-custom {
    margin-bottom: 1.5rem; /* Puedes ajustar el valor según sea necesario */
}
    </style>

    <script type="text/javascript">
    function redirectToPage() {
        // Agrega aquí la URL a la que quieres redirigir
        var url = 'Usuarios.aspx';
        
        // Realiza la redirección en JavaScript
        window.location.href = url;

        // Devuelve false para evitar el envío del formulario si es un botón dentro de un formulario
        return false;
    }
    </script>

    <script>
        function validarNumerico(input) {

            // Muestra el mensaje de campo requerido si el campo está vacío
            var mensajeError = document.getElementById('mensajeError');
            mensajeError.innerHTML = input.value.trim() === '' ? 'Solo Se Requiere Numeros' : '';
        }
    </script>


    
    


</asp:Content>

