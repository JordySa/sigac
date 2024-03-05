<%@ Page Title="FuenteIndormacionMantenimiento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionIndicadoresMantenimiento.aspx.cs" Inherits="sigac.view.ViewsGestionProcesos.ViewsGestionIndicadores.GestionIndicadoresMantenimiento" %>



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

    <div class="mx-auto" style="width:100%" >
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


    <div class="col-md-12">

            <!-- Primera columna -->
        <!--
                <div >
            <label class="form-label">Dimension:</label>
    <asp:TextBox runat="server" ID="TxtDimension" ReadOnly="true" BorderWidth="0" CssClass="label-like"></asp:TextBox>
</div>
            -->
<div>
 <label class="form-label">Indicador:</label>
<asp:TextBox runat="server" ID="TxtNombreIndic" BorderWidth="0" CssClass="label-like" Width="100%" ReadOnly="true"></asp:TextBox>
</div>
        <!--
            <div>
            <label class="form-label">Nombre Padre:</label>
<asp:TextBox runat="server" ID="TxtNombrePadre"  CssClass="label-like" Width="100%" ReadOnly="true"></asp:TextBox>
</div>-->
<div>
            <label class="form-label">Momento:</label>
    <asp:TextBox runat="server" ID="TxtMomento" ReadOnly="true" BorderWidth="0" CssClass="label-like"></asp:TextBox>
</div>
<div>



            <label class="form-label">Nombre del proyecto:</label>
    <asp:TextBox runat="server" ID="TxtNombreProyecto" ReadOnly="true" Width="100%"  BorderWidth="0" CssClass="label-like"></asp:TextBox>
</div>




        <!--

                        <div>
            <label class="form-label">Fuentes de Información:</label>
    <asp:Label  runat="server" ID="TxtFNi"  BorderWidth="0" ></asp:Label>
</div>
                <div>
            <label class="form-label">Nombre Variables:</label>
    <asp:Label  runat="server" ID="TxtNombreVariable"  BorderWidth="0" ></asp:Label>
</div>-->
        
<div>
    <label class="form-label">Nombre Fuente de Información:</label>
    <asp:Label  runat="server" ID="TxtNombreFNi"  BorderWidth="0" ></asp:Label>
</div>
<asp:GridView runat="server" ID="gvArchivos" AutoGenerateColumns="false" CssClass="table">
<Columns>
    <asp:BoundField DataField="NombreArchivo" HeaderText="Nombre del Archivo" />
    <asp:BoundField DataField="Tamaño" HeaderText="Tamaño (bytes)" />
    <asp:TemplateField HeaderText="Acciones">
        <ItemTemplate>
            <asp:LinkButton runat="server" ID="lnkDescargar" CommandArgument='<%# Eval("NombreArchivo") %>' OnClick="DescargarArchivo">Descargar</asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>

        
<div>
    <label class="form-label">Variables:</label>
        


<div class="containerVariable">


<asp:Label runat="server" ID="LbAI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="AI" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCASA"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CASA" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPSGIIE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSGIIE" Visible="false"></asp:TextBox>



<asp:Label runat="server" ID="LbPSGR"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSGR" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPSIF"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSIF" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPSOP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSOP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPSPW"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSPW" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPSSB"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSSB" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPSSI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSSI" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPSSS"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSSS" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPTU"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PTU" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPVC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PVC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCASI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CASI" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbTAJC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TAJC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbTAP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TAP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNTD"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NTD" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbTDP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TDP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNTE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NTE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbTEPN"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TEPN" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbTET"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TET" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbTG"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TG" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbTPA"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TPA" Visible="false"></asp:TextBox>

    <asp:Label runat="server" ID="LbTPI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TPI" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCASiGAC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CASiGAC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbTRI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TRI" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCASV"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CASV" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCO"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CO" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCT"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CT" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCTSA"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CTSA" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCTSI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CTSI" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCTSiGAC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CTSiGAC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCTSV"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CTSV" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbAJCC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="AJCC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbDFC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="DFC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbDMUM"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="DMUM" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbDPM"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="DPM" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbDPV"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="DPV" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbDRC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="DRC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbDRO"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="DRO" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbDT"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="DT" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbEAE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="EAE" Visible="false"></asp:TextBox>

    <asp:Label runat="server" ID="LbEM"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="EM" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbEMNI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="EMNI" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbAME"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="AME" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbEMPC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="EMPC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbEMPN"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="EMPN" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbEMPNP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="EMPNP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="Label1"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="TextBox1" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbEPM"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="EPM" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbEPV"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="EPV" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbGTAA"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="GTAA" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbHCA"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="HCA" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbHCD"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="HCD" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbIAW"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="IAW" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbAMLE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="AMLE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNAASS"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NAASS" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNACD"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NACD" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNAPD"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NAPD" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNAW"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NAW" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNCE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NCE" Visible="false"></asp:TextBox>

    <asp:Label runat="server" ID="LbNCERA"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NCERA" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNCRW"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NCRW" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNCW"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NCW" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNDASS"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NDASS" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNDE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NDE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbAMLP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="AMLP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNDEAI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NDEAI" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNDEASI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NDEASI" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNDEEL"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NDEEL" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNEASS"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NEASS" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNEB"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NEB" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNEESAV"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NEESAV" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNEESOP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NEESOP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNFA"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NFA" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNGE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NGE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNIR"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NIR" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbAMP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="AMP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNIRE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NIRE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNLI"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NLI" Visible="false"></asp:TextBox>

    <asp:Label runat="server" ID="LbNMT"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NMT" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbDATO"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="DATO" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNOR"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NOR" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNOVR"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NOVR" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNPED"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NPED" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNPEGIIE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NPEGIIE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNPESB"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NPESB" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbARC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="ARC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNPESS"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NPESS" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNPF"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NPF" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNPG"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NPG" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNPIE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NPIE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNPME"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NPME" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNPPSR"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NPPSR" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbNUR"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="NUR" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbOP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="OP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPAE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PAE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPAP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PAP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbBPV"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="BPV" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPCMO"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PCMO" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPCPM"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PCPM" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPCPOC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PCPOC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPDAE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PDAE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPDB"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PDB" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPDC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PDC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPDD"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PDD" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPDEM"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PDEM" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPDFCAD"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PDFCAD" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPDFCD"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PDFCD" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbCA"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="CA" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPDIF"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PDIF" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPDIR"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PDIR" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPFP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PFP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPIE"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PIE" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPIP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PIP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPIFP"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PIFP" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPLRAC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PLRAC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPNC"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PNC" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPSAV"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSAV" Visible="false"></asp:TextBox>

<asp:Label runat="server" ID="LbPSEL"></asp:Label>
<asp:TextBox runat="server" CssClass="form-control validar-numero" ID="PSEL" Visible="false"></asp:TextBox>




</div>
 
</div>        
        <!--
        <div>
            <label class="form-label">Formula:</label>
<asp:Literal runat="server" ID="TxtFormula" Mode="Encode" />
</div>

              
        <div>
            <label class="form-label">Contenedor:</label>
<asp:Literal runat="server" ID="TxtContenedor" Mode="Encode" />
</div>
                      
        <div>
            <label class="form-label">VariablesVacias:</label>
<asp:Literal runat="server" ID="VariablesVacias" Mode="Encode" />
</div>


         <asp:Label runat="server" ID="LbResultado">Resultado:</asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TxtResultado" ReadOnly="true"></asp:TextBox>
            -->
           

        <div class="mb-4-custom">
            <label class="form-label">Argumento:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbArgumento" ></asp:TextBox>
        </div>
    </div>
    <div class="col-md-1">
    </div>

        </div>


            
            <asp:Button runat="server" class="btn btn-primary" ID="BtnCreate" OnClick="BtnCreate_Click" Text="Crear"  Visible="false"/>
            <asp:Button runat="server" class="btn btn-primary" ID="BtnUpdate" OnClick="BtnUpdate_Click" Text="Editar" Visible="false"/>
            <asp:Button runat="server" class="btn btn-primary" ID="BtnDelete" OnClick="BtnDelete_Click" Text="Eliminar" Visible="false"/> 

        
<asp:Button runat="server" class="btn btn-primary btn-dark" ID="BtnReturn" Text="Volver" Visible="true" OnClientClick="return redirectToPage();" />
<asp:Button runat="server" class="btn btn-primary btn-dark" ID="BtnReturnAdmin" Text="Volver" Visible="false" OnClientClick="return redirectToPageAdmin();" />


        </div>






    </form>

              
        </div>
                    </div>

                </div>        



                </div>
    <style>
        .mb-4-custom {
    margin-bottom: 1.5rem; /* Puedes ajustar el valor según sea necesario */
}
    .containerVariable {
        display: flex;
        align-items: center;
    }

    .containerVariable .form-control {
        width: 25%;
    }
    </style>

    <script type="text/javascript">
        function redirectToPage() {
            // Agrega aquí la URL a la que quieres redirigir
            var url = '/view/PanelControl.aspx';

            // Realiza la redirección en JavaScript
            window.location.href = url;

            // Devuelve false para evitar el envío del formulario si es un botón dentro de un formulario
            return false;
        }
        function redirectToPageAdmin() {
            // Agrega aquí la URL a la que quieres redirigir
            var url = '/view/ViewsGestionProcesos/ViewsGestionIndicadores/GestionIndicadores.aspx';

            // Realiza la redirección en JavaScript
            window.location.href = url;

            // Devuelve false para evitar el envío del formulario si es un botón dentro de un formulario
            return false;
        }
    </script>



<script src="ruta/sweetAlert2.min.js"></script>
<link rel="stylesheet" href="ruta/sweetAlert2.min.css" />

<script>
    function validarNumero(inputElement) {
        // Obtener el valor del TextBox
        var inputValue = inputElement.value;

        // Verificar si el valor es un número (real o natural) y mayor o igual a 0
        if (!/^\d*\.?\d+$/.test(inputValue) || parseFloat(inputValue) < 0) {
            // Mostrar mensaje de error con SweetAlert2
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Por favor, ingrese un número válido mayor o igual a 0.',
                confirmButtonColor: 'red'
            });

            // Limpiar el valor del TextBox
            inputElement.value = '';
        }
    }

    // Asociar la función de validación a los TextBox con la clase "validar-numero" al perder el foco
    var elementos = document.getElementsByClassName('validar-numero');
    for (var i = 0; i < elementos.length; i++) {
        elementos[i].addEventListener('blur', function () {
            validarNumero(this);
        });
    }
</script>

</asp:Content>
