<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sigac.Login" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <!-- Agrega tus estilos y enlaces a bibliotecas externas aquí -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.18/dist/sweetalert2.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.18/dist/sweetalert2.all.min.js"></script>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
 <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>






    <script src="https://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
            <link href="style/login.css" rel="stylesheet" />


</head>
<body>
    <div class="contenedor">
            
    <div class="titulo1">
<img width="300" alt="UTC" src="https://raw.githubusercontent.com/JordySa/sigac/main/img/logo1.png">
        <div class="texto">SISTEMA INTEGRADO DE GESTIÓN</div>

                
    </div>    

    </div>
           <div class="contenido" style="background-color: #EBEDEF;">
    
         <div class="container" >


<div class="main" >
    <div class="login-container">
                    <div class="login ">
                        <div class="modal-content">
                            <div class="modal-header" style="border-bottom: 0px solid #e5e5e5;">
                                
                                <div class="avatar">
<img src="https://raw.githubusercontent.com/JordySa/sigac/main/img/avatar.png" class="imgRedonda" alt="Avatar">
                            </div>

                                
                            </div>
                             <form id="form1" class="formulario" runat="server">
                                <div class="formulario">
                                    <h2>Ingrese sus credenciales</h2>
                                    <asp:Label ID="lblMensaje" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                    <div>
                                        <label for="txtUsuario">Usuario:</label>
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su usuario"></asp:TextBox>
                                    </div>
                                    <div>
                                        <label for="txtContraseña">Contraseña:</label>
                                        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div>
                                        <asp:Button ID="btnLogin" runat="server" Text="Inicio de sesión" OnClick="btnLogin_Click" />
                                    </div>
                                    <br />
        
                                </div>
                            </form>
                            <!--
                            <div class="modal-footer">
                                <a >Olvido su contraseña?</a>
                            </div>
                                -->
                        </div>
                    </div>
           </div>

    
                    </div>






     

     <div class="col-sm-12 col-md-12 col-lg-4">

    </div>
     <div class="col-sm-12 col-md-12 col-lg-12" style="text-align:center">
        <a href="https://drive.google.com/file/d/1zBZJ1H1jxUPDD2nPmWl0sEe5Ubu-Ix-O/view" target="_blank">GUÍA DE MATRÍCULA</a>

    </div>

    <div class="col-sm-12 col-md-12 col-lg-3">

    </div>



         


        </div>     
    </div>  
</body>
</html>
