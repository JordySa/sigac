<%@ Page Title="KpiIndicador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteIndicadores.aspx.cs" Inherits="sigac.view.ViewsGestiónInformes.ViewsReporteIndicadores.ReporteIndicadores" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <div class="contenido" style="background-color: #EBEDEF;">
            <div class="main">
                <div class="container" style="width:100%; background-color: #fff; padding:12px; ">
                    <div class="vertical-space">                        
    
                        <iframe title="sigac" style="width:100%; height:100%; " src="https://app.powerbi.com/reportEmbed?reportId=24748a50-89c2-4fc6-a4b6-26a81b9dbdc5&autoAuth=true&ctid=136a0da6-6e34-4ca2-933d-36fa7895468e" frameborder="0" allowFullScreen="true"></iframe>

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
