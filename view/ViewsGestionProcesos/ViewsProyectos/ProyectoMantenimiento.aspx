
<%@ Page Title="ProyectoMantenimiento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProyectoMantenimiento.aspx.cs" Inherits="sigac.view.ViewsGestionProcesos.ViewsProyectos.ProyectoMantenimiento" Culture="es-CO" UICulture="es-CO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta charset="utf-8" />
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css">
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.7.1/css/buttons.dataTables.min.css">
<script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.js"></script>
<script src="https://cdn.datatables.net/buttons/1.7.1/js/dataTables.buttons.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
<script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.html5.min.js"></script>
<script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.print.min.js"></script>



<div class="contenido" style="background-color: #EBEDEF;">
<div class="main">
<div class="container" style="width:100%; background-color: #fff; padding:5%; ">
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

        <h2>Proyecto</h2>
        <!-- Primera columna -->
        <div class="col-md-6">
            <div class="mb-4-custom">
                <label class="form-label">Nombre:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbnombre" required="true"></asp:TextBox>
            </div>
            <div class="mb-4-custom">
                <label class="form-label" >Descripción:</label>
                   <asp:TextBox runat="server" CssClass="form-control" ID="tbdescripcion" required="true"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-1"></div>

                
        <div class="col-md-5">
            <div class="mb-4-custom">
                <label class="form-label">Fecha de Inicio:</label>
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbDateI" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
            </div>



        <!-- Segunda columna -->
            <div class="mb-4-custom">
                <label class="form-label">Fecha de Finalización:</label>
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbDateF" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
            </div>
        </div>

        <!-- Elemento centrado -->




                <div class="mb-4-custom">
                    <label class="form-label">Indicador:</label>
                        <asp:ListBox runat="server" CssClass="form-control" ID="lbIndic" SelectionMode="Multiple" ondblclick="deseleccionarElementoIndic()">
                        </asp:ListBox>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlindic" AppendDataBoundItems="true" DataSourceID="SqlDataSourceIndicador" DataTextField="strNombre_indic" DataValueField="strNombre_indic" onchange="seleccionarElementoIndic()">
                            <asp:ListItem Text="-- Seleccione --" Value="" />
                        </asp:DropDownList>
                </div>
                <button type="button" class="btn btn-primary" onclick="seleccionarTodosIndic()">Seleccionar Todos</button>
                <button type="button" class="btn btn-secondary" onclick="deseleccionarSeleccionadosIndic()">Deseleccionar Seleccionados</button>





            <div class="mb-4-custom">
            <label class="form-label">Estado:</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEst" required="true">
                    <asp:ListItem Text="-- Seleccione --" Value="" />
                    <asp:ListItem Text="Activo" Value="1" />
                    <asp:ListItem Text="Inactivo" Value="0" />
                </asp:DropDownList>
            </div>




     
    </div>

    <div class="row">

        <h3 style="text-align:center">Fechas Momento 1</h3>
        <!-- Primera columna -->
              
        <div class="col-md-7">
            <div class="mb-4-custom">
                <label class="form-label">Fecha de  Fuentes de información Momento Inicio:</label>
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoIFIn1" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
            </div>

        <!-- Segunda columna -->
            <div class="mb-4-custom">
                <label class="form-label">Fecha de Fuentes de información  Momento Finalización:</label>
                  <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoFFIn1" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
            </div>
        </div>

                
        <div class="col-md-5">
        <div class="mb-4-custom">
            <label class="form-label">Fecha de Indicador Inicio:</label>
             <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoIInd1" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
        </div>

    <!-- Segunda columna -->
        <div class="mb-4-custom">
            <label class="form-label">Fecha de Indicador Finalización:</label>
              <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoFInd1" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
        </div>
    </div>
           
    </div>


        
    <div class="row">

<h3 style="text-align:center">Fechas Momento 2</h3>
<!-- Primera columna -->
              
    <div class="col-md-7">
        <div class="mb-4-custom">
            <label class="form-label">Fecha de  Fuentes de información Momento Inicio:</label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoIFIn2" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
        </div>

    <!-- Segunda columna -->
        <div class="mb-4-custom">
            <label class="form-label">Fecha de Fuentes de información  Momento Finalización:</label>
               <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoFFIn2" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
        </div>
    </div>

                
<!-- Primera columna -->
    <div class="col-md-5">
        <div class="mb-4-custom">
            <label class="form-label">Fecha de Indicador Inicio:</label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoIInd2" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
        </div>

    <!-- Segunda columna -->
        <div class="mb-4-custom">
            <label class="form-label">Fecha de Indicador Finalización:</label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoFInd2" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
        </div>
    </div>
           
</div>




        
    <div class="row">

<h3 style="text-align:center">Fechas Momento 3</h3>
<!-- Primera columna -->

             
<div class="col-md-4"></div>
                
    <div class="col-md-4">
        <div class="mb-4-custom">
            <label class="form-label">Fecha de Indicador Inicio:</label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoIInd3" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
        </div>

    <!-- Segunda columna -->
        <div class="mb-4-custom">
            <label class="form-label">Fecha de Indicador Finalización:</label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbMomentoFInd3" onfocus="this.type='date'" placeholder="yyyy-MM-dd" ClientIDMode="Static"></asp:TextBox>
        </div>
    </div>
  
<div class="col-md-5"></div>
</div>
        


<asp:HiddenField runat="server" ID="hfSelectedIndic" />


<asp:Button runat="server" class="btn btn-primary" ID="BtnCreate" OnClick="BtnCreate_Click" Text="Crear" Visible="false"/>
<asp:Button runat="server" class="btn btn-primary" ID="BtnUpdate" OnClick="BtnUpdate_Click" Text="Editar" Visible="false"/>
<asp:Button runat="server" class="btn btn-primary" ID="BtnDelete" OnClick="BtnDelete_Click" Text="Eliminar" Visible="false"/> 
        
<asp:Button runat="server" class="btn btn-primary btn-dark" ID="BtnReturn" Text="Volver" Visible="true" OnClientClick="return redirectToPage();" />



</form>

              
</div>
</div>

</div>        

<asp:SqlDataSource ID="SqlDataSourceIndicador" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_indic, strNombre_indic FROM GC_INDIC"></asp:SqlDataSource>



</div>
<style>
.mb-4-custom {
margin-bottom: 1.5rem; /* Puedes ajustar el valor según sea necesario */
}
</style>



<script type="text/javascript">
function redirectToPage() {
// Agrega aquí la URL a la que quieres redirigir
var url = 'Proyectos.aspx';
        
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

    
<script>
// Obtener el elemento TextBox de la fecha de inicio por ID
var tbDateI = document.getElementById('<%= tbDateI.ClientID %>');

// Obtener el año actual
var currentYear = new Date().getFullYear();

// Establecer el límite para la fecha de inicio al año actual
tbDateI.setAttribute("min", currentYear + "-01-01");
tbDateI.setAttribute("max", currentYear + "-12-31");

// Fuente de Informacion Momento 1
// Obtener el elemento TextBox de la otra fecha por ID
var tbMomentoIFIn1 = document.getElementById('<%= tbMomentoIFIn1.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoIFIn1.setAttribute("min", currentYear + "-01-01");
tbMomentoIFIn1.setAttribute("max", currentYear + "-12-31");

var tbMomentoFFIn1 = document.getElementById('<%= tbMomentoFFIn1.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoFFIn1.setAttribute("min", currentYear + "-01-01");
tbMomentoFFIn1.setAttribute("max", currentYear + "-12-31");


// Indicador
// Obtener el elemento TextBox de la otra fecha por ID
var tbMomentoIInd1 = document.getElementById('<%= tbMomentoIInd1.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoIInd1.setAttribute("min", currentYear + "-01-01");
tbMomentoIInd1.setAttribute("max", currentYear + "-12-31");

var tbMomentoFInd1 = document.getElementById('<%= tbMomentoFInd1.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoFInd1.setAttribute("min", currentYear + "-01-01");
tbMomentoFInd1.setAttribute("max", currentYear + "-12-31");




// Fuente de Informacion Momento 2
// Obtener el elemento TextBox de la otra fecha por ID
var tbMomentoIFIn2 = document.getElementById('<%= tbMomentoIFIn2.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoIFIn2.setAttribute("min", currentYear + "-01-01");
tbMomentoIFIn2.setAttribute("max", currentYear + "-12-31");

var tbMomentoFFIn2 = document.getElementById('<%= tbMomentoFFIn2.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoFFIn2.setAttribute("min", currentYear + "-01-01");
tbMomentoFFIn2.setAttribute("max", currentYear + "-12-31");


// Indicador
// Obtener el elemento TextBox de la otra fecha por ID
var tbMomentoIInd2 = document.getElementById('<%= tbMomentoIInd2.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoIInd2.setAttribute("min", currentYear + "-01-01");
tbMomentoIInd2.setAttribute("max", currentYear + "-12-31");

var tbMomentoFInd2 = document.getElementById('<%= tbMomentoFInd2.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoFInd2.setAttribute("min", currentYear + "-01-01");
tbMomentoFInd2.setAttribute("max", currentYear + "-12-31");



// Indicador Momento 3
// Obtener el elemento TextBox de la otra fecha por ID
var tbMomentoIInd3 = document.getElementById('<%= tbMomentoIInd3.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoIInd3.setAttribute("min", currentYear + "-01-01");
tbMomentoIInd3.setAttribute("max", currentYear + "-12-31");

var tbMomentoFInd3 = document.getElementById('<%= tbMomentoFInd3.ClientID %>');

// Establecer el límite para la otra fecha al año actual
tbMomentoFInd3.setAttribute("min", currentYear + "-01-01");
tbMomentoFInd3.setAttribute("max", currentYear + "-12-31");
</script>
    
<script>
// Obtener el elemento TextBox por ID
var tbDateF = document.getElementById('<%= tbDateF.ClientID %>');

// Obtener el año actual
var currentYear = new Date().getFullYear();

// Calcular el año límite permitido (2 años en el futuro)
var maxYear = currentYear + 1;

// Establecer el límite para el año actual hasta 2 años en el futuro
tbDateF.setAttribute("min", currentYear + "-01-01");
tbDateF.setAttribute("max", maxYear + "-12-31");
</script>


<script>

var selectedSetIndic = new Set();
function seleccionarTodosIndic() {
var listBox = document.getElementById('<%= lbIndic.ClientID %>');
var dropDownList = document.getElementById('<%= ddlindic.ClientID %>');
var hiddenField = document.getElementById('<%= hfSelectedIndic.ClientID %>');

for (var i = 0; i < dropDownList.options.length; i++) {
var selectedValue = dropDownList.options[i].value;

if (selectedValue !== "") {
var exists = Array.from(listBox.options).some(option => option.value === selectedValue);

if (!exists) {
listBox.options[listBox.options.length] = new Option(dropDownList.options[i].text, selectedValue);
// Agregar el valor al conjunto
selectedSetIndic.add(selectedValue);
}
}
}

// Crear un array de valores separados por comas
var selectedValues = Array.from(selectedSetIndic);
var selectedIndic = selectedValues.join(',');

// Asignar el array a tu campo oculto
hiddenField.value = selectedIndic;
}




function seleccionarElementoIndic() {
var listBox = document.getElementById('<%= lbIndic.ClientID %>');
var dropDownList = document.getElementById('<%= ddlindic.ClientID %>');
var hiddenField = document.getElementById('<%= hfSelectedIndic.ClientID %>');

var selectedIndex = dropDownList.selectedIndex;

// Verificar si el elemento seleccionado no es "-- Seleccione --" y no está en la lista existente
if (selectedIndex !== 0 && !selectedSetIndic.has(selectedIndex)) {
// Agregar el índice al conjunto y el elemento a la lista de Indicadores existentes
selectedSetIndic.add(selectedIndex);
listBox.options[listBox.options.length] = new Option(dropDownList.options[selectedIndex].text, dropDownList.options[selectedIndex].value);

// Limpiar la selección actual en la lista desplegable
dropDownList.options[selectedIndex].selected = false;

// Crear un array de valores separados por comas
var selectedValues = Array.from(selectedSetIndic).map(index => dropDownList.options[index].value);
var selectedIndic = selectedValues.join(',');

// Asignar el array a tu campo oculto
hiddenField.value = selectedIndic;
}
}

function deseleccionarElementoIndic() {
var listBox = document.getElementById('<%= lbIndic.ClientID %>');
var dropDownList = document.getElementById('<%= ddlindic.ClientID %>');
var hiddenField = document.getElementById('<%= hfSelectedIndic.ClientID %>');

// Obtener el índice del elemento seleccionado en la lista de selección múltiple
var selectedIndex = listBox.selectedIndex;

// Verificar si se ha seleccionado un elemento
if (selectedIndex !== -1) {
// Remover el elemento seleccionado de la lista de selección múltiple
listBox.remove(selectedIndex);
selectedSetIndic.delete(selectedIndex);

// Crear un array de valores separados por comas
var selectedValues = Array.from(selectedSetIndic).map(index => dropDownList.options[index].value);
var selectedIndic = selectedValues.join(',');

// Asignar el array a tu campo oculto
hiddenField.value = selectedIndic;
}
}

function deseleccionarSeleccionadosIndic() {
var listBox = document.getElementById('<%= lbIndic.ClientID %>');
var dropDownList = document.getElementById('<%= ddlindic.ClientID %>');
var hiddenField = document.getElementById('<%= hfSelectedIndic.ClientID %>');

// Obtener los índices de los elementos seleccionados en la lista de selección múltiple
var selectedIndices = Array.from(listBox.options).map(option => option.index);

// Eliminar los elementos seleccionados en la lista de selección múltiple
selectedIndices.forEach(index => {
listBox.remove(index);
selectedSetIndic.delete(index);
});

// Crear un array de valores separados por comas
var selectedValues = Array.from(selectedSetIndic).map(index => dropDownList.options[index].value);
var selectedIndic = selectedValues.join(',');

// Asignar el array a tu campo oculto
hiddenField.value = selectedIndic;
}

function deseleccionarSeleccionadosIndic()
{
var listBox = document.getElementById('<%= lbIndic.ClientID %>');
var dropDownList = document.getElementById('<%= ddlindic.ClientID %>');
var hiddenField = document.getElementById('<%= hfSelectedIndic.ClientID %>');

for (var i = 0; i < listBox.options.length; i++) {
dropDownList.options[i].selected = false;
}
listBox.options.length = 0;

// Resetear el campo oculto cuando se deseleccionan todos
hiddenField.value = '';
}
function actualizarHiddenField(listBoxId, dropDownListId, hiddenFieldId) {
var listBox = document.getElementById(listBoxId);
var dropDownList = document.getElementById(dropDownListId);
var hiddenField = document.getElementById(hiddenFieldId);

// Restablecer el valor del HiddenField
hiddenField.value = '';

// Iterar a través de los elementos seleccionados y agregarlos al HiddenField
for (var i = 0; i < listBox.options.length; i++) {
if (listBox.options[i].selected) {
hiddenField.value += listBox.options[i].value + ',';
}
}
}

</script>
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            var labels = document.querySelectorAll(".form-label");

            labels.forEach(function (label) {
                label.textContent = reemplazarCaracteresEspeciales(label.textContent);
            });

            function reemplazarCaracteresEspeciales(texto) {
                try {
                    texto = decodeURIComponent(escape(texto));
                } catch (e) {
                    console.error("Error al decodificar:", e);
                }

                return texto;
            }
        });
    </script>

</asp:Content>
