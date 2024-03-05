<%@ Page Title="FuenteInformacionMantenimiento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FuenteInformacionMantenimiento.aspx.cs" Inherits="sigac.view.ViewsGestionAplicaciones.ViewsFuentesInformacion.FuenteInformacionMantenimiento" %>


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
            <label class="form-label">Nombre:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbnombre" required="true"></asp:TextBox>
        </div>
        <div class="mb-4-custom">
            <label class="form-label">Descripción:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbdescripcion" required="true"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-1">
    </div>

    
</div>

<!-- Elemento centrado -->
<div class="mx-auto" style="width: fit-content;">
    <div class="mb-4-custom">
        <label class="form-label">Orden:</label>
        <div style="display: flex; align-items: center;">
            <button type="button" onclick="decrementarValor()">-</button>
            <asp:TextBox runat="server" CssClass="form-control" ID="tborden" oninput="validarNumerico(this);" required="true"></asp:TextBox>
            <button type="button" onclick="incrementarValor()">+</button>
        </div>
        <div id="mensajeError" style="color: red;"></div>
    </div>
</div>


            <asp:Button runat="server" class="btn btn-primary" ID="BtnCreate" OnClick="BtnCreate_Click" Text="Crear" Visible="false"/>
            <asp:Button runat="server" class="btn btn-primary" ID="BtnUpdate" OnClick="BtnUpdate_Click" Text="Editar" Visible="false"/>
            <asp:Button runat="server" class="btn btn-primary" ID="BtnDelete" OnClick="BtnDelete_Click" Text="Eliminar" Visible="false"/> 
        
<asp:Button runat="server" class="btn btn-primary btn-dark" ID="BtnReturn" Text="Volver" Visible="true" OnClientClick="return redirectToPage();" />
        </div>
    </form>

              
        </div>
                    </div>

                </div>        

    <asp:SqlDataSource ID="SqlDataSourceFuentesI" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_variab, strNombre_variab FROM GC_VARIAB"></asp:SqlDataSource>


                </div>
    <style>
        .mb-4-custom {
    margin-bottom: 1.5rem; /* Puedes ajustar el valor según sea necesario */
}
    </style>

    <script type="text/javascript">
    function redirectToPage() {
        // Agrega aquí la URL a la que quieres redirigir
        var url = 'FuentesInformacion.aspx';
        
        // Realiza la redirección en JavaScript
        window.location.href = url;

        // Devuelve false para evitar el envío del formulario si es un botón dentro de un formulario
        return false;
    }
    </script>

    <script>
        function validarNumerico(input) {
            // Elimina cualquier caracter no numérico
            input.value = input.value.replace(/[^0-9]/g, '');

            // Convierte el valor a entero
            var valor = parseInt(input.value, 10);

            // Verifica si el valor es un número entero no negativo
            if (isNaN(valor) || valor < 0) {
                input.value = '';  // Si no es un número entero no negativo, borra el contenido
            }

            // Muestra el mensaje de campo requerido si el campo está vacío
            var mensajeError = document.getElementById('mensajeError');
            mensajeError.innerHTML = input.value.trim() === '' ? 'Solo se requieren números enteros no negativos' : '';
        }

        function incrementarValor() {
            var tborden = document.getElementById('<%= tborden.ClientID %>');
        var valor = parseInt(tborden.value, 10);
        tborden.value = isNaN(valor) ? 1 : valor + 1;
    }

    function decrementarValor() {
        var tborden = document.getElementById('<%= tborden.ClientID %>');
            var valor = parseInt(tborden.value, 10);
            tborden.value = isNaN(valor) || valor <= 0 ? 0 : valor - 1;
        }
    </script>


</asp:Content>
