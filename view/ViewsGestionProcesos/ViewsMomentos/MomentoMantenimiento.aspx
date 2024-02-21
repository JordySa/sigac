<%@ Page Title="MomentoMantenimiento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MomentoMantenimiento.aspx.cs" Inherits="sigac.view.ViewsGestionProcesos.ViewsMomentos.MomentoMantenimiento" %>


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
                <div class="container" style="width:100%; background-color: #fff; padding:5%;" >
                    <div class="vertical-space">  


    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>

    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="Lbltitulo"> </asp:Label>
    </div>
    
    <form id="form1" runat="server" class="">
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
            <label class="form-label">Fecha de Inicio:</label>
<asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbDateI" onfocus="this.type='date'" placeholder="yyyy-MM-dd"></asp:TextBox>
        </div>

        <div class="mb-4-custom">
            <label class="form-label">Fecha de Finalización:</label>
<asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbDateF" onfocus="this.type='date'" placeholder="yyyy-MM-dd"></asp:TextBox>
        </div>


    </div>
    <div class="col-md-1">
    </div>
                
    <!-- Segunda columna -->
                
    <div class="col-md-5">

        
        <div class="mb-4-custom">
            <label class="form-label">Archivo:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbarchivo" required="true"></asp:TextBox>
        </div>
        <div class="mb-4-custom">
            <label class="form-label">Valor:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbvalor" oninput="validarNumerico(this);" required="true"></asp:TextBox>
            <div id="mensajeError" style="color: red;"></div>
        </div>


        <div class="mb-4-custom">
            <label class="form-label">estado:</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEst" required="true">
            <asp:ListItem Text="-- Seleccione --" Value="" />
            <asp:ListItem Text="Activo" Value="1" />
            <asp:ListItem Text="Inactivo" Value="0" />
        </asp:DropDownList>
        </div>


    </div>

<!-- Elemento centrado -->
        <div class="mb-4-custom">
             <label class="form-label">Responsable:</label>
             <asp:DropDownList runat="server" CssClass="form-control" ID="ddlRespons" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceRespons" DataTextField="strResProces_respons" DataValueField="strCod_respons">
                 <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
             </asp:DropDownList>
         </div>

         <div class="mb-4-custom">
             <label class="form-label">Fuentes de informacion:</label>
             <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFni" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceFni" DataTextField="strNombre_fni" DataValueField="strCod_fni">
                 <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
             </asp:DropDownList>
         </div>

                

         <div class="mb-4-custom">
             <label class="form-label">Fase:</label>
             <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFase" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceFase" DataTextField="strNombre_fase" DataValueField="strCod_fase">
                 <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
             </asp:DropDownList>
         </div>


                
        <div class="mb-4-custom">
            <label class="form-label">Nota:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbnota" required="true"></asp:TextBox>
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


    <asp:SqlDataSource ID="SqlDataSourceRespons" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_respons, strResProces_respons FROM GC_RESPONS"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceFni" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_fni, strNombre_fni FROM GC_FNI"></asp:SqlDataSource>      
    <asp:SqlDataSource ID="SqlDataSourceFase" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_fase, strNombre_fase FROM GC_FASE"></asp:SqlDataSource>


                </div>
    <style>
        .mb-4-custom {
    margin-bottom: 1.5rem; /* Puedes ajustar el valor según sea necesario */
}
    </style>

    <script type="text/javascript">
    function redirectToPage() {
        // Agrega aquí la URL a la que quieres redirigir
        var url = 'Momentos.aspx';
        
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

            // Muestra el mensaje de campo requerido si el campo está vacío
            var mensajeError = document.getElementById('mensajeError');
            mensajeError.innerHTML = input.value.trim() === '' ? 'Solo Se Requiere Numeros' : '';
        }
    </script>



    <script type="text/javascript">
        function mostrarAlerta(mensaje, tipo, redireccion) {
            Swal.fire({
                title: mensaje,
                icon: tipo,
                confirmButtonText: 'OK'
            }).then((result) => {
                if (result.isConfirmed && redireccion) {
                    window.location.href = redireccion;
                }
            });
        }

        function validarNumerico(input) {
            // Elimina cualquier caracter no numérico
            input.value = input.value.replace(/[^0-9]/g, '');

            // Muestra el mensaje de campo requerido si el campo está vacío
            var mensajeError = document.getElementById('mensajeError');
            mensajeError.innerHTML = input.value.trim() === '' ? 'Solo Se Requiere Numeros' : '';
        }

        function redirectToPage() {
            // Agrega aquí la URL a la que quieres redirigir
            var url = 'Momentos.aspx';

            // Realiza la redirección en JavaScript
            window.location.href = url;

            // Devuelve false para evitar el envío del formulario si es un botón dentro de un formulario
            return false;
        }
    </script>

</asp:Content>



