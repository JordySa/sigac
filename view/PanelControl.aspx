<%@ Page Title="Panel de Control" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelControl.aspx.cs" Inherits="sigac.view.PanelControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <div class="contenido" style="background-color: #EBEDEF;">
            <div class="main">
                <div class="container-fluid" style="width:100%; background-color:white;">
                    <h2 class="mb-4">Panel de Controles</h2>
                    <div class="card">


                        
                    <div class="container-fluid">
                                                            <div class="content">
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                                                                <ul class="nav nav-tabs" id="myTab" role="tablist">
    <li class="nav-item">
        <a class="nav-link active" id="moment_one-tab" data-toggle="tab" href="#moment_one" role="tab" aria-controls="moment_one" aria-selected="true">MOMENTO 1</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" id="moment_two-tab" data-toggle="tab" href="#moment_two" role="tab" aria-controls="moment_two" aria-selected="false">MOMENTO 2</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" id="moment_three-tab" data-toggle="tab" href="#moment_three" role="tab" aria-controls="moment_three" aria-selected="false">MOMENTO 3</a>
    </li>
</ul>
    <div class="tab-content" id="myTabContent">
        
                                <div class="tab-pane fade show active" id="moment_one" role="tabpanel" aria-labelledby="moment_one-tab">
             
            <div class="accordion" id="accordionFunction1">
<div class="card">
    <div class="card-header" id="headingZero1">
        <h2 class="mb-0">
            <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseZero1" aria-expanded="true" aria-controls="collapseZero1">
                FUENTES DE INFORMACIÓN
            </button>
        </h2>
    </div>

    <div id="collapseZero1" class="collapse" aria-labelledby="headingZero1" data-parent="#accordionFunction1">
        <div class="card-body">
            <div class="d-flex flex-row">
                <div class="col-lg-4">

                    <asp:Literal ID="LiteralPlanificacionFNiMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                </div>

                <div class="col-lg-4">

                    <asp:Literal ID="LiteralEjecucionFNiMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                </div>

                <div class="col-lg-4">

                    <asp:Literal ID="LiteralResultadosFNiMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                </div>
            </div>  
            

        </div>
    </div>
</div>



<div class="card">
        <div class="card-header" id="headingOne1">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne1" aria-expanded="true" aria-controls="collapseOne1">
                    DOCENCIA
                </button>
            </h2>
        </div>
<div id="collapseOne1" class="collapse" aria-labelledby="headingOne1" data-parent="#accordionFunction1">
        <div class="card-body">
            <div class="d-flex flex-row">

                <div class="col-md-4">

                <asp:Literal ID="LiteralDocentePlanificacionIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                </div>

                <div class="col-md-4">

                <asp:Literal ID="LiteralDocenteEjecucionIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                </div>

                <div class="col-md-4">

                <asp:Literal ID="LiteralDocenteResultadoIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                </div>

            </div>
        </div>
    </div>
</div>




<div class="card">
    <div class="card-header" id="headingTwo1">
        <h2 class="mb-0">
            <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo1" aria-expanded="true" aria-controls="collapseTwo1">
                INVESTIGACIÓN
            </button>
        </h2>
    </div>
<div id="collapseTwo1" class="collapse" aria-labelledby="headingTwo1" data-parent="#accordionFunction1">
    <div class="card-body">
            <div class="d-flex flex-row">

            <div class="col-md-4">

            <asp:Literal ID="LiteralInvestigacionPlanificacionIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

            </div>

            <div class="col-md-4">

            <asp:Literal ID="LiteralInvestigacionEjecucionIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

            </div>

            <div class="col-md-4">

            <asp:Literal ID="LiteralInvestigacionResultadoIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

            </div>

        </div>

    </div>
</div>
</div>


<div class="card">
    <div class="card-header" id="headingThree1">
        <h2 class="mb-0">
            <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree1" aria-expanded="false" aria-controls="collapseThree1">
                VINCULACIÓN

            </button>
        </h2>
    </div>
    <div id="collapseThree1" class="collapse" aria-labelledby="headingThree1" data-parent="#accordionFunction1">
        <div class="card-body">
            <div class="d-flex flex-row">

                <div class="col-md-4">

                <asp:Literal ID="LiteralVinculacionPlanificacionIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                </div>

                <div class="col-md-4">

                <asp:Literal ID="LiteralVinculacionEjecucionIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                </div>

                <div class="col-md-4">

                <asp:Literal ID="LiteralVinculacionResultadoIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                </div>

            </div>
        </div>
    </div>
</div>



<div class="card">
    <div class="card-header" id="headingFour1">
        <h2 class="mb-0">
            <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFour1" aria-expanded="false" aria-controls="collapseFour1">
             CONDICIONES INSTITUCIONALES
            </button>
        </h2>
    </div>
    <div id="collapseFour1" class="collapse" aria-labelledby="headingFour1" data-parent="#accordionFunction1">
            <div class="card-body">
                <div class="d-flex flex-row">

                    <div class="col-md-4">

                    <asp:Literal ID="LiteralCondicionInstitucionalPlanificacionIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                    </div>

                    <div class="col-md-4">

                    <asp:Literal ID="LiteralCondicionInstitucionalEjecucionIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                    </div>

                    <div class="col-md-4">

                    <asp:Literal ID="LiteralCondicionInstitucionalResultadoIndicMomento1" runat="server" Mode="PassThrough"></asp:Literal>

                    </div>

                </div>
            </div>

    </div>
</div>
</div>       
</div>


        
                                  <!-- Contenido de la pestaña MOMENTO 2 -->
                                <div class="tab-pane fade" id="moment_two" role="tabpanel" aria-labelledby="moment_two-tab">
                                 
            <div class="accordion" id="accordionFunction2">
    <div class="card">
        <div class="card-header" id="headingZero2">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseZero2" aria-expanded="true" aria-controls="collapseZero2">
                    FUENTES DE INFORMACIÓN
                </button>
            </h2>
        </div>
        <div id="collapseZero2" class="collapse" aria-labelledby="headingZero2" data-parent="#accordionFunction2">
            <div class="card-body">
                <div class="d-flex flex-row">
                    <div class="col-lg-4">
                        <asp:Literal ID="LiteralPlanificacionFNiMomento2" runat="server" Mode="PassThrough"></asp:Literal>
                    </div>

                    <div class="col-lg-4">
                        <asp:Literal ID="LiteralEjecucionFNiMomento2" runat="server" Mode="PassThrough"></asp:Literal>
                    </div>

                    <div class="col-lg-4">
                        <asp:Literal ID="LiteralResultadosFNiMomento2" runat="server" Mode="PassThrough"></asp:Literal>
                    </div>
                </div>
            </div>

        </div>
    </div>


    <div class="card">
        <div class="card-header" id="headingOne2">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne2" aria-expanded="true" aria-controls="collapseOne2">
                    DOCENCIA
                </button>
            </h2>
        </div>
        <div id="collapseOne2" class="collapse" aria-labelledby="headingOne2" data-parent="#accordionFunction2">
            <div class="card-body">
    <div class="d-flex flex-row">
        <div class="col-md-4">
            <asp:Literal ID="LiteralDocentePlanificacionIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralDocenteEjecucionIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralDocenteResultadoIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
        </div>
        </div>
    </div>

        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingTwo2">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo2" aria-expanded="false" aria-controls="collapseTwo2">
                    INVESTIGACIÓN
                </button>
            </h2>
        </div>
        <div id="collapseTwo2" class="collapse" aria-labelledby="headingTwo2" data-parent="#accordionFunction2">
            <div class="card-body">
    <div class="d-flex flex-row">
        <div class="col-md-4">
            <asp:Literal ID="LiteralInvestigacionPlanificacionIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralInvestigacionEjecucionIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralInvestigacionResultadoIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
        </div>
    </div>
</div>

        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingThree2">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree2" aria-expanded="false" aria-controls="collapseThree2">
                    VINCULACIÓN
                </button>
            </h2>
        </div>
        <div id="collapseThree2" class="collapse" aria-labelledby="headingThree2" data-parent="#accordionFunction2">
            <div class="card-body">
        <div class="d-flex flex-row">
            <div class="col-md-4">
                <asp:Literal ID="LiteralVinculacionPlanificacionIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
            </div>

            <div class="col-md-4">
                <asp:Literal ID="LiteralVinculacionEjecucionIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
            </div>

            <div class="col-md-4">
                <asp:Literal ID="LiteralVinculacionResultadoIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
            </div>
            </div>
        </div>

        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingFour2">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFour2" aria-expanded="false" aria-controls="collapseFour2">
                    CONDICIONES INSTITUCIONALES
                </button>
            </h2>
        </div>
        <div id="collapseFour2" class="collapse" aria-labelledby="headingFour2" data-parent="#accordionFunction2">
            <div class="card-body">
    <div class="d-flex flex-row">
        <div class="col-md-4">
            <asp:Literal ID="LiteralCondicionInstitucionalPlanificacionIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralCondicionInstitucionalEjecucionIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralCondicionInstitucionalResultadoIndicMomento2" runat="server" Mode="PassThrough"></asp:Literal>
        </div>
        </div>
    </div>

        </div>
    </div>

</div>   
        </div>
                                <!-- Contenido de la pestaña MOMENTO 3 -->
                                <div class="tab-pane fade" id="moment_three" role="tabpanel" aria-labelledby="moment_three-tab">
                                    
            <div class="accordion" id="accordionFunction3">

    <div class="card">
        <div class="card-header" id="headingOne3">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne3" aria-expanded="true" aria-controls="collapseOne3">
                    DOCENCIA
                </button>
            </h2>
        </div>
        <div id="collapseOne3" class="collapse" aria-labelledby="headingOne3" data-parent="#accordionFunction3">
            
            <div class="card-body">
    <div class="d-flex flex-row">
        <div class="col-md-4">
            <asp:Literal ID="LiteralDocentePlanificacionIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralDocenteEjecucionIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralDocenteResultadoIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>
    </div>
</div>

        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingTwo3">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo3" aria-expanded="false" aria-controls="collapseTwo3">
                    INVESTIGACIÓN
                </button>
            </h2>
        </div>
        <div id="collapseTwo3" class="collapse" aria-labelledby="headingTwo3" data-parent="#accordionFunction3">
            <div class="card-body">
    <div class="d-flex flex-row">
        <div class="col-md-4">
            <asp:Literal ID="LiteralInvestigacionPlanificacionIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralInvestigacionEjecucionIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralInvestigacionResultadoIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>
    </div>
</div>


        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingThree3">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree3" aria-expanded="false" aria-controls="collapseThree3">
                    VINCULACIÓN
                </button>
            </h2>
        </div>
        <div id="collapseThree3" class="collapse" aria-labelledby="headingThree3" data-parent="#accordionFunction3">
            
            <div class="card-body">
    <div class="d-flex flex-row">
        <div class="col-md-4">
            <asp:Literal ID="LiteralVinculacionPlanificacionIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralVinculacionEjecucionIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralVinculacionResultadoIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>
    </div>
</div>

        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingFour3">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFour3" aria-expanded="false" aria-controls="collapseFour3">
                    CONDICIONES INSTITUCIONALES
                </button>
            </h2>
        </div>
        <div id="collapseFour3" class="collapse" aria-labelledby="headingFour3" data-parent="#accordionFunction3">
            
            <div class="card-body">
    <div class="d-flex flex-row">
        <div class="col-md-4">
            <asp:Literal ID="LiteralCondicionInstitucionalPlanificacionIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralCondicionInstitucionalEjecucionIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>

        <div class="col-md-4">
            <asp:Literal ID="LiteralCondicionInstitucionalResultadoIndicMomento3" runat="server" Mode="PassThrough"></asp:Literal>
        </div>
    </div>
</div>

        </div>
    </div>
</div>   
        </div>
    </div>                                    </div>
            </div>
        </div>
    </div>
</div>

                </div>



                        <div class="c-body">
            <main class="c-main">


                <div class="container-fluid">
                                                            <div class="content">
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                                                                
    <div class="tab-content" id="myTabContent">
        <div class="tab-pane fade" id="moment_one" role="tabpanel" aria-labelledby="moment_one-tab">
            <div class="accordion" id="accordionFunction1">
    <div class="card">
        <div class="card-header" id="headingZero1">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseZero1" aria-expanded="true" aria-controls="collapseZero1">
                    FUENTES DE INFORMACION
                </button>
            </h2>
        </div>
        <div id="collapseZero1" class="collapse" aria-labelledby="headingZero1" data-parent="#accordionFunction1">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingOne1">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne1" aria-expanded="true" aria-controls="collapseOne1">
                    DOCENCIA
                </button>
            </h2>
        </div>
        <div id="collapseOne1" class="collapse" aria-labelledby="headingOne1" data-parent="#accordionFunction1">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingTwo1">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo1" aria-expanded="false" aria-controls="collapseTwo1">
                    INVESTIGACION
                </button>
            </h2>
        </div>
        <div id="collapseTwo1" class="collapse" aria-labelledby="headingTwo1" data-parent="#accordionFunction1">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingThree1">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree1" aria-expanded="false" aria-controls="collapseThree1">
                    VINCULACION
                </button>
            </h2>
        </div>
        <div id="collapseThree1" class="collapse" aria-labelledby="headingThree1" data-parent="#accordionFunction1">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>           </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingFour1">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFour1" aria-expanded="false" aria-controls="collapseFour1">
                    CONDICIONES INSTITUCIONALES
                </button>
            </h2>
        </div>
        <div id="collapseFour1" class="collapse" aria-labelledby="headingFour1" data-parent="#accordionFunction1">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
</div>       
        </div>
        <div class="tab-pane fade" id="moment_two" role="tabpanel" aria-labelledby="moment_two-tab">
            <div class="accordion" id="accordionFunction2">
    <div class="card">
        <div class="card-header" id="headingZero2">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseZero2" aria-expanded="true" aria-controls="collapseZero2">
                    FUENTES DE INFORMACION
                </button>
            </h2>
        </div>
        <div id="collapseZero2" class="collapse" aria-labelledby="headingZero2" data-parent="#accordionFunction2">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingOne2">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne2" aria-expanded="true" aria-controls="collapseOne2">
                    DOCENCIA
                </button>
            </h2>
        </div>
        <div id="collapseOne2" class="collapse" aria-labelledby="headingOne2" data-parent="#accordionFunction2">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingTwo2">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo2" aria-expanded="false" aria-controls="collapseTwo2">
                    INVESTIGACION
                </button>
            </h2>
        </div>
        <div id="collapseTwo2" class="collapse" aria-labelledby="headingTwo2" data-parent="#accordionFunction2">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingThree2">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree2" aria-expanded="false" aria-controls="collapseThree2">
                    VINCULACION
                </button>
            </h2>
        </div>
        <div id="collapseThree2" class="collapse" aria-labelledby="headingThree2" data-parent="#accordionFunction2">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>           </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingFour2">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFour2" aria-expanded="false" aria-controls="collapseFour2">
                    CONDICIONES INSTITUCIONALES
                </button>
            </h2>
        </div>
        <div id="collapseFour2" class="collapse" aria-labelledby="headingFour2" data-parent="#accordionFunction2">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
</div>   
        </div>
        <div class="tab-pane fade" id="moment_three" role="tabpanel" aria-labelledby="moment_three-tab">
            <div class="accordion" id="accordionFunction3">
    <div class="card">
        <div class="card-header" id="headingZero3">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseZero3" aria-expanded="true" aria-controls="collapseZero3">
                    FUENTES DE INFORMACION
                </button>
            </h2>
        </div>
        <div id="collapseZero3" class="collapse" aria-labelledby="headingZero3" data-parent="#accordionFunction3">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingOne3">
            <h2 class="mb-0">
                <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne3" aria-expanded="true" aria-controls="collapseOne3">
                    DOCENCIA
                </button>
            </h2>
        </div>
        <div id="collapseOne3" class="collapse" aria-labelledby="headingOne3" data-parent="#accordionFunction3">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingTwo3">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo3" aria-expanded="false" aria-controls="collapseTwo3">
                    INVESTIGACION
                </button>
            </h2>
        </div>
        <div id="collapseTwo3" class="collapse" aria-labelledby="headingTwo3" data-parent="#accordionFunction3">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingThree3">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree3" aria-expanded="false" aria-controls="collapseThree3">
                    VINCULACION
                </button>
            </h2>
        </div>
        <div id="collapseThree3" class="collapse" aria-labelledby="headingThree3" data-parent="#accordionFunction3">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                                                                                 
                                <li><strong>Índice de actualización del sistema de vinculación con la sociedad</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/348">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                                                    </li>
                                                                                                                     
                                <li><strong>Número de programas de vinculación por carreras/programas</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/351">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                                                    </li>
                                                                                                                     
                                <li><strong>Número de programas de vinculación por líneas de investigación</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/349">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                                                    </li>
                                                     
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                                                                            <li><strong>Número de convenios operativos</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/353">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                                                                                                                                                
                                                                    </li>
                                                                                                                <li><strong>Número de proyectos institucionales por programas de vinculación</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/352">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                                                                                                                                                
                                                                    </li>
                                                                                                                <li><strong>Número de proyectos integradores por programas de vinculación</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/363">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                                                                                                                                                
                                                                    </li>
                                                                                                                <li><strong>Número de Redes vigentes</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/350">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                                                                                                                                                
                                                                    </li>
                                                       
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                                                                            <li><strong>Número de eventos de educación continua realizados</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/365">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                        
                                        
                                                                    </li>
                                                                                                                <li><strong>Número de ayudantes de vinculación</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/374">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                        
                                        
                                                                    </li>
                                                                                                                <li><strong>Promedio de beneficiarios por proyectos de vinculación</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/372">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                        
                                        
                                                                    </li>
                                                                                                                <li><strong>Porcentaje de docentes en programas de movilidad</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/373">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                        
                                        
                                                                    </li>
                                                                                                                <li><strong>Porcentaje de estudiantes en programas de movilidad</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/366">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                        
                                        
                                                                    </li>
                                                                                                                <li><strong>Porcentaje de docente participantes en proyectos de vinculación</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/371">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                        
                                        
                                                                    </li>
                                                                                                                <li><strong>Porcentaje de estudiantes participantes en proyectos de vinculación</strong> (1)
                                                                            <a class="btn btn-xs btn-warning" href="https://sigac.gestiondocumental.com.ec/admin/indicator-projects/364">
                                            <span class=" fas fa-eye"></span> 
                                        </a>
                                        
                                                                                                                                                                
                                        
                                        
                                                                    </li>
                                                       
                                    </ul>    
            </div>
        </div>
    </div>
</div>           </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header" id="headingFour3">
            <h2 class="mb-0">
                <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseFour3" aria-expanded="false" aria-controls="collapseFour3">
                    CONDICIONES INSTITUCIONALES
                </button>
            </h2>
        </div>
        <div id="collapseFour3" class="collapse" aria-labelledby="headingFour3" data-parent="#accordionFunction3">
            <div class="card-body">
                <div class="row">
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>PLANIFICACION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                 
                                    </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>EJECUCION</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
    <div class="col-lg-4">
        <div class="card">
            <div class="card-header">
                <strong>RESULTADOS</strong>
            </div>
            <div class="card-body">
                <ul>
                                                                   
                                    </ul>    
            </div>
        </div>
    </div>
</div>            </div>
        </div>
    </div>
</div>   
        </div>
    </div>                                    </div>
            </div>
        </div>
    </div>
</div>

                </div>


            </main>
            <form id="logoutform" action="https://sigac.gestiondocumental.com.ec/logout" method="POST" style="display: none;">
                <input type="hidden" name="_token" value="QHca42OoAui5txqR6n260uOyp6HPtMQ8ZAlsN5mI">
            </form>
        </div>

                        <iframe title="sigac" width="1140" height="541.25" src="https://app.powerbi.com/reportEmbed?reportId=24748a50-89c2-4fc6-a4b6-26a81b9dbdc5&autoAuth=true&ctid=136a0da6-6e34-4ca2-933d-36fa7895468e" frameborder="0" allowFullScreen="true"></iframe>

                    </div>
                    </div>
            </div>
        </div>
    </form>

<!-- En tu archivo Fuente de Informacion-->
<script>
    function BtnEdit_ClickFIn(nombreFNi, nombreIndic, nombrePadre, momento, dimension) {
        // Redirige a la nueva vista para la acción "Editar"
        window.location.href = '/view/ViewsGestionProcesos/ViewsFuenteInformacion/FuenteIndormacionMantenimiento.aspx?nombreFNi=' + nombreFNi + '&nombreIndic=' + nombreIndic + '&nombrePadre=' + nombrePadre + '&momento=' + momento + '&dimension=' + dimension + '&op=CU';
    }
    function BtnView_ClickFIn(nombreFNi, nombreIndic, nombrePadre, momento, dimension) {
        // Redirige a la nueva vista para la acción "Ver"
        window.location.href = '/view/ViewsGestionProcesos/ViewsFuenteInformacion/FuenteIndormacionMantenimiento.aspx?nombreFNi=' + nombreFNi + '&nombreIndic=' + nombreIndic + '&nombrePadre=' + nombrePadre + '&momento=' + momento + '&dimension=' + dimension + '&op=R';
    }

    function BtnEdit_ClickIndic(nombreIndic, nombrePadre, nombreFNi, variables, formula, dimension, momento) {
        // Encodea la fórmula antes de pasarla como parámetro en la URL
        var encodedFormula = encodeURIComponent(formula);

        // Redirige a la nueva vista para la acción "Editar"
        window.location.href = '/view/ViewsGestionProcesos/ViewsGestionIndicadores/GestionIndicadoresMantenimiento.aspx?nombreIndic=' + nombreIndic + '&nombrePadre=' + nombrePadre + '&nombreFNi=' + nombreFNi + '&variables=' + variables + '&formula=' + encodedFormula + '&dimension=' + dimension + '&momento=' + momento + '&op=CU';
    }

    function BtnView_ClickIndic(nombreIndic, nombrePadre, nombreFNi, variables, formula, dimension, momento) {
        // Encodea la fórmula antes de pasarla como parámetro en la URL
        var encodedFormula = encodeURIComponent(formula);

        // Redirige a la nueva vista para la acción "Ver"
        window.location.href = '/view/ViewsGestionProcesos/ViewsGestionIndicadores/GestionIndicadoresMantenimiento.aspx?nombreIndic=' + nombreIndic + '&nombrePadre=' + nombrePadre + '&nombreFNi=' + nombreFNi + '&variables=' + variables + '&formula=' + encodedFormula + '&dimension=' + dimension + '&momento=' + momento + '&op=R';
    }

</script>

    





</asp:Content>
