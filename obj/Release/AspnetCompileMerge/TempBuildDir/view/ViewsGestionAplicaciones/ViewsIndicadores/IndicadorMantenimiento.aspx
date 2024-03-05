<%@ Page Title="IndicadorMantenimiento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndicadorMantenimiento.aspx.cs" Inherits="sigac.view.ViewsGestionAplicaciones.ViewsIndicadores.IndicadorMantenimiento" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.7.1/css/buttons.dataTables.min.css">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.7.1/js/buttons.print.min.js"></script>

<!-- jQuery -->
<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>


        <div class="contenido" style="background-color: #EBEDEF;">
            <div class="main">
                <div class="container"style="width:100%; background-color: #fff; padding:12px; " >
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

    <!-- Segunda columna -->
    <div class="col-md-5">
        

        

        <div class="mb-4-custom">
            <label class="form-label">Cálculo:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbcalculo" required="true"></asp:TextBox>
        </div>

        <div class="mb-4-custom">
        <label class="form-label">Variables Seleccionadas:</label>
        <div id="selectedVariablesContainer"></div>
    </div>

    </div>
</div>


            <div class="row">


                <h2>Inserte las variables correspondientes</h2>
<!-- Elemento centrado -->
<!-- <div class="mx-auto" style="width: fit-content;"> -->

                        <!-- Primera columna -->
    <div class="col-md-6">
  
           <div class="mb-4-custom">
       <label class="form-label">Funcion :</label>
       <asp:DropDownList runat="server" CssClass="form-control" ID="ddlfunc" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceFuncionalidad" DataTextField="strNombre_func" DataValueField="strCod_func">
           <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
       </asp:DropDownList>
   </div>
   <div class="mb-4-custom">
       <label class="form-label">Dimensión :</label>
       <asp:DropDownList runat="server" CssClass="form-control" ID="ddldimen" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceDimencion" DataTextField="strNombre_dimen" DataValueField="strCod_dimen">
           <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
       </asp:DropDownList>
   </div>
    
    
   <div class="mb-4-custom">
       <label class="form-label">Tipo Proceso :</label>
       <asp:DropDownList runat="server" CssClass="form-control" ID="ddltpro" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceTProceso" DataTextField="strNombre_tpro" DataValueField="strCod_tpro">
           <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
       </asp:DropDownList>
   </div>
   <div class="mb-4-custom">
       <label class="form-label">Proceso:</label>
       <asp:DropDownList runat="server" CssClass="form-control" ID="ddlproces" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceProceso" DataTextField="strNombre_proces" DataValueField="strCod_proces">
           <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
       </asp:DropDownList>
   </div>
    
    
   <div class="mb-4-custom">
       <label class="form-label">Componente:</label>
       <asp:DropDownList runat="server" CssClass="form-control" ID="ddlcomp" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceComponente" DataTextField="strNombre_comp" DataValueField="strCod_comp">
           <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
       </asp:DropDownList>
   </div>
        
 <div class="mb-4-custom">
     <label class="form-label">Padre:</label>
     <input type="text" id="txtSearchPadre" class="form-control" oninput="filtrarDatosPadre()" placeholder="Buscar Padre" />

     <asp:DropDownList runat="server" CssClass="form-control" ID="ddlpadre" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourcePadre" DataTextField="strNombre_padre" DataValueField="strCod_padre">
         <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
     </asp:DropDownList>
 </div>
        
         <div class="mb-4-custom">
     <label class="form-label">Periodo:</label>
     <asp:DropDownList runat="server" CssClass="form-control" ID="ddlperiod" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourcePeriodicidad" DataTextField="strNombre_period" DataValueField="strCod_period">
         <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
     </asp:DropDownList>
 </div>


        
                
 <div class="mb-4-custom">
     <label class="form-label">Responsable de Evidencias :</label>
     <asp:DropDownList runat="server" CssClass="form-control" ID="ddlResponEvid" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceEquip" DataTextField="strNombre_Equip" DataValueField="strCod_Equip">
         <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
     </asp:DropDownList>
 </div>


    </div>

    <div class="col-md-1">
    </div>

    <!-- Segunda columna -->
    <div class="col-md-5">
        
    
    
<div class="mb-4-custom">
    <label class="form-label">Variable:</label>
    <asp:ListBox runat="server" CssClass="form-control" ID="lbVariab" SelectionMode="Multiple" ondblclick="deseleccionarElementoVariab()">
    </asp:ListBox>
<asp:DropDownList runat="server" CssClass="form-control" ID="ddlvariab" AppendDataBoundItems="true" DataSourceID="SqlDataSourceVariab" DataTextField="strDescripcion_variab" DataValueField="strNombre_variab" onchange="seleccionarElementoVariab()">
    <asp:ListItem Text="-- Seleccione --" Value="" />
</asp:DropDownList>

</div>




<div class="mb-4-custom">
    <label class="form-label">Fuente de Información:</label>

    <asp:ListBox runat="server" CssClass="form-control" ID="lbFni" SelectionMode="Multiple" ondblclick="deseleccionarElementoFni()">
    </asp:ListBox>
    <input type="text" id="txtSearchFIn" class="form-control" oninput="filtrarDatosFIn()" placeholder="Buscar Evidencia" />

    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlfni" AppendDataBoundItems="true" DataSourceID="SqlDataSourceFni" DataTextField="strNombre_fni" DataValueField="strNombre_fni" onchange="seleccionarElementoFni()">
        <asp:ListItem Text="-- Seleccione --" Value="" />
    </asp:DropDownList>
</div>
<button type="button" class="btn btn-primary" onclick="seleccionarTodosFni()">Seleccionar Todos</button>
<button type="button" class="btn btn-secondary" onclick="deseleccionarSeleccionadosFni()">Deseleccionar Seleccionados</button>

    

<div class="mb-4-custom">
    <label class="form-label">Evidencia:</label>
    
    <asp:ListBox runat="server" CssClass="form-control" ID="lbEvid" SelectionMode="Multiple" ondblclick="deseleccionarElementoEvid()">
    </asp:ListBox>
    
<input type="text" id="txtSearch" class="form-control" oninput="filtrarDatos()" placeholder="Buscar Evidencia" />
    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlevid" AppendDataBoundItems="true" DataSourceID="SqlDataSourceEvid" DataTextField="strNombre_evid" DataValueField="strNombre_evid" onchange="seleccionarElementoEvid()">
        <asp:ListItem Text="-- Seleccione --" Value="" />
    </asp:DropDownList>
</div>
<button type="button" class="btn btn-primary" onclick="seleccionarTodosEvid()">Seleccionar Todos</button>
<button type="button" class="btn btn-secondary" onclick="deseleccionarSeleccionadosEvid()">Deseleccionar Seleccionados</button>








   

    </div>
      
        
<!-- </div> -->

</div>


        <div class="row">
            <h2 >Momentos</h2>
            <!-- Primera columna -->
            <div class="col-md-6">
  
                
 <div class="mb-4-custom">
     <label class="form-label">Responsable del Proceso :</label>
     <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEquipProces" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceEquip" DataTextField="strNombre_Equip" DataValueField="strCod_Equip">
         <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
     </asp:DropDownList>
 </div>

                           
 <div class="mb-4-custom">
     <label class="form-label">Responsable Indicador Momento 1 :</label>
     <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEquipIndMom1" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceEquip" DataTextField="strNombre_Equip" DataValueField="strCod_Equip">
         <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
     </asp:DropDownList>
 </div>
                           
 <div class="mb-4-custom">
     <label class="form-label">Responsable Fuentes de Información Momento 1:</label>
     <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEquipFueMom1" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceEquip" DataTextField="strNombre_Equip" DataValueField="strCod_Equip">
         <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
     </asp:DropDownList>
 </div>




            </div>

            <div class="col-md-1">
            </div>

            <!-- Segunda columna -->
            <div class="col-md-5">
        
                

                           
 <div class="mb-4-custom">
     <label class="form-label">Responsable Indicador Momento 2 :</label>
     <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEquipIndMom2" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceEquip" DataTextField="strNombre_Equip" DataValueField="strCod_Equip">
         <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
     </asp:DropDownList>
 </div>
                           
 <div class="mb-4-custom">
     <label class="form-label">Responsable Fuentes de Información Momento 2:</label>
     <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEquipFueMom2" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceEquip" DataTextField="strNombre_Equip" DataValueField="strCod_Equip">
         <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
     </asp:DropDownList>
 </div>
                           
 <div class="mb-4-custom">
     <label class="form-label">Responsable Indicador Momento 3 :</label>
     <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEquipIndMom3" required="true" AppendDataBoundItems="true" DataSourceID="SqlDataSourceEquip" DataTextField="strNombre_Equip" DataValueField="strCod_Equip">
         <asp:ListItem Text="-- Seleccione --" Value="" required="true" />
     </asp:DropDownList>
 </div>
   
                    <asp:HiddenField runat="server" ID="hfSelectedVariab" />
                
                    <asp:HiddenField runat="server" ID="hfSelectedFni" />
                    <asp:HiddenField runat="server" ID="hfSelectedEvid" />


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
            


    <asp:SqlDataSource ID="SqlDataSourceFuncionalidad" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_func, strNombre_func FROM GC_FUNC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceDimencion" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_dimen, strNombre_dimen FROM GC_DIMEN"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceTProceso" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_tpro, strNombre_tpro FROM GC_TPROCES"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceProceso" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_proces, strNombre_proces FROM GC_PROCES"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceComponente" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_comp, strNombre_comp FROM GC_COMP"></asp:SqlDataSource>
   
    <asp:SqlDataSource ID="SqlDataSourcePeriodicidad" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_period, strNombre_period FROM GC_PERIOD"></asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSourceVariab" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_variab, strDescripcion_variab, strNombre_variab FROM GC_VARIAB"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceFni" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_fni, strNombre_fni FROM GC_FNI"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceEvid" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_evid, strNombre_evid FROM GC_EVID"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourcePadre" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_padre, strNombre_padre FROM GC_PADRE"></asp:SqlDataSource>

            
    <asp:SqlDataSource ID="SqlDataSourceEquip" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnectionString %>" SelectCommand="SELECT strCod_Equip, strNombre_Equip FROM GC_EQUIP"></asp:SqlDataSource>


                </div>
    <style>
        .mb-4-custom {
    margin-bottom: 1.5rem; /* Puedes ajustar el valor según sea necesario */
}
    </style>

    <script type="text/javascript">
    function redirectToPage() {
        // Agrega aquí la URL a la que quieres redirigir
        var url = 'Indicadores.aspx';
        
        // Realiza la redirección en JavaScript
        window.location.href = url;

        // Devuelve false para evitar el envío del formulario si es un botón dentro de un formulario
        return false;
    }
    </script>


    <script>
        var selectedSetPadre = new Set();


        function filtrarDatosPadre() {
            var searchInput = document.getElementById('txtSearchPadre');
            var dropDownList = document.getElementById('<%= ddlpadre.ClientID %>');

     var searchTerm = searchInput.value.toLowerCase();

     // Filtrar el DropDownList basándose en el término de búsqueda
     for (var i = 0; i < dropDownList.options.length; i++) {
         var optionText = dropDownList.options[i].text.toLowerCase();
         dropDownList.options[i].style.display = optionText.includes(searchTerm) ? '' : 'none';
     }

     // Filtrar la ListBox basándose en el término de búsqueda
     for (var i = 0; i < listBox.options.length; i++) {
         var optionText = listBox.options[i].text.toLowerCase();
         listBox.options[i].style.display = optionText.includes(searchTerm) ? '' : 'none';
     }
 }

    </script>



<script>

    var selectedSetVariab = new Set();

    function seleccionarElementoVariab() {
        var listBox = document.getElementById('<%= lbVariab.ClientID %>');
        var dropDownList = document.getElementById('<%= ddlvariab.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedVariab.ClientID %>');
        var selectedVariablesContainer = document.getElementById('selectedVariablesContainer');
        var calculationTextBox = document.getElementById('<%= tbcalculo.ClientID %>');

        var selectedIndex = dropDownList.selectedIndex;

        // Verificar si el elemento seleccionado no es "-- Seleccione --" y no está en la lista existente
        if (selectedIndex !== 0 && !selectedSetVariab.has(selectedIndex)) {
            // Agregar el índice al conjunto y el elemento a la lista de variables existentes
            selectedSetVariab.add(selectedIndex);
            listBox.options[listBox.options.length] = new Option(dropDownList.options[selectedIndex].text, dropDownList.options[selectedIndex].value);

            // Limpiar la selección actual en la lista desplegable
            dropDownList.options[selectedIndex].selected = false;

            // Crear un array de valores separados por comas
            var selectedValues = Array.from(selectedSetVariab).map(index => dropDownList.options[index].value);
            var selectedVariab = selectedValues.join(',');

            // Asignar el array a tu campo oculto
            hiddenField.value = selectedVariab;

            // Update selected variables container
            updateSelectedVariablesContainer(selectedVariablesContainer, selectedSetVariab, dropDownList.options);

            // Update calculation textbox
            updateCalculationTextbox(calculationTextBox, selectedSetVariab, dropDownList.options);
        }
    }

    function deseleccionarElementoVariab() {
        var listBox = document.getElementById('<%= lbVariab.ClientID %>');
        var dropDownList = document.getElementById('<%= ddlvariab.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedVariab.ClientID %>');
        var selectedVariablesContainer = document.getElementById('selectedVariablesContainer');
        var calculationTextBox = document.getElementById('<%= tbcalculo.ClientID %>');

        // Obtener los índices de los elementos seleccionados en la lista
        var selectedIndices = Array.from(listBox.options).map(option => option.index);

        // Limpiar la lista de variables existentes
        listBox.options.length = 0;

        // Limpiar el conjunto de elementos seleccionados
        selectedSetVariab.clear();

        // Iterar a través de los índices y agregar los elementos nuevamente a la lista y al conjunto
        selectedIndices.forEach(index => {
            if (dropDownList.options[index].value !== "") {
                listBox.options[listBox.options.length] = new Option(dropDownList.options[index].text, dropDownList.options[index].value);
                selectedSetVariab.add(index);
            }
        });

        // Crear un array de valores separados por comas
        var selectedValues = Array.from(selectedSetVariab).map(index => dropDownList.options[index].value);
        var selectedVariab = selectedValues.join(',');

        // Asignar el array a tu campo oculto
        hiddenField.value = selectedVariab;

        // Update selected variables container
        updateSelectedVariablesContainer(selectedVariablesContainer, selectedSetVariab, dropDownList.options);

        // Update calculation textbox
        updateCalculationTextbox(calculationTextBox, selectedSetVariab, dropDownList.options);
    }

    function updateSelectedVariablesContainer(container, selectedSet, options) {
        container.innerHTML = ''; // Clear existing buttons

        selectedSet.forEach(index => {
            if (options[index].value !== "") {
                var button = document.createElement('button');
                button.innerHTML = options[index].text;
                button.onclick = function () {
                    // Deselect on button click
                    selectedSet.delete(index);
                    deseleccionarElementoVariab();
                };

                container.appendChild(button);
            }
        });
    }

    function updateCalculationTextbox(textBox, selectedSet, options) {
        var selectedValues = Array.from(selectedSet).map(index => options[index].value);
        var calculation = selectedValues.join(' / '); // Customize the calculation logic as needed
        textBox.value = calculation;
    }

</script>


    








<script>
    var selectedSetFni = new Set();


    function filtrarDatosFIn() {
        var searchInput = document.getElementById('txtSearchFIn');
        var dropDownList = document.getElementById('<%= ddlfni.ClientID %>');
          var listBox = document.getElementById('<%= lbFni.ClientID %>');

          var searchTerm = searchInput.value.toLowerCase();

          // Filtrar el DropDownList basándose en el término de búsqueda
          for (var i = 0; i < dropDownList.options.length; i++) {
              var optionText = dropDownList.options[i].text.toLowerCase();
              dropDownList.options[i].style.display = optionText.includes(searchTerm) ? '' : 'none';
          }

          // Filtrar la ListBox basándose en el término de búsqueda
          for (var i = 0; i < listBox.options.length; i++) {
              var optionText = listBox.options[i].text.toLowerCase();
              listBox.options[i].style.display = optionText.includes(searchTerm) ? '' : 'none';
          }
      }


    function seleccionarTodosFni() {
        var listBox = document.getElementById('<%= lbFni.ClientID %>');
        var dropDownList = document.getElementById('<%= ddlfni.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedFni.ClientID %>');

        for (var i = 0; i < dropDownList.options.length; i++) {
            var selectedValue = dropDownList.options[i].value;

            if (selectedValue !== "") {
                var exists = Array.from(listBox.options).some(option => option.value === selectedValue);

                if (!exists) {
                    listBox.options[listBox.options.length] = new Option(dropDownList.options[i].text, selectedValue);
                    // Agregar el valor al conjunto
                    selectedSetFni.add(selectedValue);
                }
            }
        }

        // Crear un array de valores separados por comas
        var selectedValues = Array.from(selectedSetFni);
        var selectedFni = selectedValues.join(',');

        // Asignar el array a tu campo oculto
        hiddenField.value = selectedFni;
    }


    function seleccionarElementoFni() {
        var listBox = document.getElementById('<%= lbFni.ClientID %>');
        var dropDownList = document.getElementById('<%= ddlfni.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedFni.ClientID %>');

    var selectedIndex = dropDownList.selectedIndex;

    // Verificar si el elemento seleccionado no es "-- Seleccione --" y no está en la lista existente
        if (selectedIndex !== 0 && !selectedSetFni.has(selectedIndex)) {
        // Agregar el índice al conjunto y el elemento a la lista de Fuente de Informacion existentes
            selectedSetFni.add(selectedIndex);
        listBox.options[listBox.options.length] = new Option(dropDownList.options[selectedIndex].text, dropDownList.options[selectedIndex].value);

        // Limpiar la selección actual en la lista desplegable
        dropDownList.options[selectedIndex].selected = false;

        // Crear un array de valores separados por comas
            var selectedValues = Array.from(selectedSetFni).map(index => dropDownList.options[index].value);
        var selectedFni = selectedValues.join(',');

        // Asignar el array a tu campo oculto
        hiddenField.value = selectedFni;
    }
}

    function deseleccionarElementoFni() {
    var listBox = document.getElementById('<%= lbFni.ClientID %>');
    var dropDownList = document.getElementById('<%= ddlfni.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedFni.ClientID %>');

        // Obtener los índices de los elementos seleccionados en la lista
        var selectedIndices = Array.from(listBox.options).map(option => option.index);

        // Limpiar la lista de Fuentes de informacion existentes
        listBox.options.length = 0;

        // Limpiar el conjunto de elementos seleccionados
        selectedSetFni.clear();

        // Iterar a través de los índices y agregar los elementos nuevamente a la lista y al conjunto
        selectedIndices.forEach(index => {
            if (dropDownList.options[index].value !== "") {
                listBox.options[listBox.options.length] = new Option(dropDownList.options[index].text, dropDownList.options[index].value);
                selectedSetFni.add(index);
            }
        });

        // Crear un array de valores separados por comas
        var selectedValues = Array.from(selectedSetFni).map(index => dropDownList.options[index].value);
        var selectedFni = selectedValues.join(',');

        // Asignar el array a tu campo oculto
        hiddenField.value = selectedFni;
    }




function deseleccionarSeleccionadosFni() {
    var listBox = document.getElementById('<%= lbFni.ClientID %>');
    var dropDownList = document.getElementById('<%= ddlfni.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedFni.ClientID %>');

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

<script>




    var selectedSetEvid = new Set();

    function filtrarDatos() {
        var searchInput = document.getElementById('txtSearch');
        var dropDownList = document.getElementById('<%= ddlevid.ClientID %>');
        var listBox = document.getElementById('<%= lbEvid.ClientID %>');

        var searchTerm = searchInput.value.toLowerCase();

        // Filtrar el DropDownList basándose en el término de búsqueda
        for (var i = 0; i < dropDownList.options.length; i++) {
            var optionText = dropDownList.options[i].text.toLowerCase();
            dropDownList.options[i].style.display = optionText.includes(searchTerm) ? '' : 'none';
        }

        // Filtrar la ListBox basándose en el término de búsqueda
        for (var i = 0; i < listBox.options.length; i++) {
            var optionText = listBox.options[i].text.toLowerCase();
            listBox.options[i].style.display = optionText.includes(searchTerm) ? '' : 'none';
        }
    }


    function seleccionarTodosEvid() {
        var listBox = document.getElementById('<%= lbEvid.ClientID %>');
        var dropDownList = document.getElementById('<%= ddlevid.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedEvid.ClientID %>');

        for (var i = 0; i < dropDownList.options.length; i++) {
            var selectedValue = dropDownList.options[i].value;

            if (selectedValue !== "") {
                var exists = Array.from(listBox.options).some(option => option.value === selectedValue);

                if (!exists) {
                    listBox.options[listBox.options.length] = new Option(dropDownList.options[i].text, selectedValue);
                    // Agregar el valor al conjunto
                    selectedSetEvid.add(selectedValue);
                }
            }
        }

        // Crear un array de valores separados por comas
        var selectedValues = Array.from(selectedSetEvid);
        var selectedEvid = selectedValues.join(',');

        // Asignar el array a tu campo oculto
        hiddenField.value = selectedEvid;
    }






    function seleccionarElementoEvid() {
        var listBox = document.getElementById('<%= lbEvid.ClientID %>');
        var dropDownList = document.getElementById('<%= ddlevid.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedEvid.ClientID %>');

    var selectedIndex = dropDownList.selectedIndex;

    // Verificar si el elemento seleccionado no es "-- Seleccione --" y no está en la lista existente
        if (selectedIndex !== 0 && !selectedSetEvid.has(selectedIndex)) {
        // Agregar el índice al conjunto y el elemento a la lista de Fuente de Informacion existentes
            selectedSetEvid.add(selectedIndex);
        listBox.options[listBox.options.length] = new Option(dropDownList.options[selectedIndex].text, dropDownList.options[selectedIndex].value);

        // Limpiar la selección actual en la lista desplegable
        dropDownList.options[selectedIndex].selected = false;

        // Crear un array de valores separados por comas
            var selectedValues = Array.from(selectedSetEvid).map(index => dropDownList.options[index].value);
        var selectedEvid = selectedValues.join(',');

        // Asignar el array a tu campo oculto
        hiddenField.value = selectedEvid;
    }
}

    function deseleccionarElementoEvid() {
    var listBox = document.getElementById('<%= lbEvid.ClientID %>');
    var dropDownList = document.getElementById('<%= ddlevid.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedEvid.ClientID %>');

        // Obtener los índices de los elementos seleccionados en la lista
        var selectedIndices = Array.from(listBox.options).map(option => option.index);

        // Limpiar la lista de Fuentes de informacion existentes
        listBox.options.length = 0;

        // Limpiar el conjunto de elementos seleccionados
        selectedSetEvid.clear();

        // Iterar a través de los índices y agregar los elementos nuevamente a la lista y al conjunto
        selectedIndices.forEach(index => {
            if (dropDownList.options[index].value !== "") {
                listBox.options[listBox.options.length] = new Option(dropDownList.options[index].text, dropDownList.options[index].value);
                selectedSetEvid.add(index);
            }
        });

        // Crear un array de valores separados por comas
        var selectedValues = Array.from(selectedSetEvid).map(index => dropDownList.options[index].value);
        var selectedEvid = selectedValues.join(',');

        // Asignar el array a tu campo oculto
        hiddenField.value = selectedEvid;
    }




    function deseleccionarSeleccionadosEvid() {
    var listBox = document.getElementById('<%= lbEvid.ClientID %>');
    var dropDownList = document.getElementById('<%= ddlevid.ClientID %>');
        var hiddenField = document.getElementById('<%= hfSelectedEvid.ClientID %>');

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





</asp:Content>


