<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapaTerminado.aspx.cs" Inherits="ConoceAColombia.web.Views.MapaTerminado.MapaTerminado" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Conoce a: Colombia</title>
    <!-- Bootstrap core CSS-->
    <link href="../../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template-->
    <link href="../../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Page level plugin CSS-->
    <link href="../../vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet">
    <!-- Custom styles for this template-->
    <link href="../../css/sb-admin.css" rel="stylesheet">

    <!-- Bootstrap core JavaScript-->
    <script src="../../vendor/jquery/jquery.min.js"></script>
    <script src="../../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    <!-- Page level plugin JavaScript-->
    <script src="../../vendor/chart.js/Chart.min.js"></script>
    <script src="../../vendor/datatables/jquery.dataTables.js"></script>
    <script src="../../vendor/datatables/dataTables.bootstrap4.js"></script>
    <!-- Custom scripts for all pages-->
    <script src="../../js/sb-admin.min.js"></script>
    <!-- Custom scripts for this page-->
    <script src="../../js/sb-admin-datatables.min.js"></script>
    <script src="../../js/sb-admin-charts.min.js"></script>


    <script src="http://code.jquery.com/jquery-3.2.1.js"></script>
    <link href="../../css/jquery.gmaps.css" rel="stylesheet" />
    <script src="../../js/jquery.gmaps.js"></script>

    <style>
        .gmaps {
            height: 500px;
            width: 100%;
        }
    </style>
</head>
<body class="fixed-nav sticky-footer bg-dark" id="page-top">
    <form runat="server">
        <!-- Navigation-->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" id="mainNav">

            <a class="navbar-brand" href="../../Views/Index/Index.aspx">Conoce a: Colombia</a>



            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav navbar-sidenav" id="exampleAccordion">
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="LinkHistoria" runat="server" OnClick="LinkHistoria_Click">
                        <i class="fa fa-fw fa-book"></i>Historia
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="linkGeografia" runat="server" OnClick="linkGeografia_Click">
                        <i class="fa fa-fw fa-globe"></i>Geografia
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="LinkPersonajesPublicos" runat="server" OnClick="LinkPersonajesPublicos_Click">
                        <i class="fa fa-fw fa-male"></i>Personajes Publicos
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="LinkArte" runat="server" OnClick="LinkArte_Click">
                        <i class="fa fa-fw fa-paint-brush"></i>Arte
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="LinkGastronomia" runat="server" OnClick="LinkGastronomia_Click">
                        <i class="fa fa-fw fa-spoon"></i>Gastronomia
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="LinkMusica" runat="server" OnClick="LinkMusica_Click">
                        <i class="fa fa-fw fa-music"></i>Música
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="LinkDeportes" runat="server" OnClick="LinkDeportes_Click">
                        <i class="fa fa-fw fa-futbol-o"></i>Deportes
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="LinkFlora" runat="server" OnClick="LinkFlora_Click">
                        <i class="fa fa-fw fa-leaf"></i>Flora
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="LinkFauna" runat="server" OnClick="LinkFauna_Click">
                        <i class="fa fa-fw fa-paw"></i>Fauna
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="linkCulturas" runat="server" OnClick="linkCulturas_Click">
                        <i class="fa fa-fw fa-handshake-o"></i>Culturas
                        </asp:LinkButton>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Población">
                        <a class="nav-link" href="../../Views/MenuJuego/MenuJuego.aspx">
                            <i class="fa fa-fw fa-gamepad"></i>
                            <span class="nav-link-text">Mini Juego</span>
                        </a>
                    </li>
                    <li class="nav-item" data-toggle="tooltip" data-placement="right" title="Población">
                        <a class="nav-link" href="../../Views/Puntuacion/Puntuaciones.aspx">
                            <i class="fa fa-fw fa-trophy"></i>
                            <span class="nav-link-text">Maxima Puntuación</span>
                        </a>
                    </li>

                </ul>

                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <asp:Label runat="server" ID="lblUsuario" CssClass="btn btn-primary"></asp:Label>>
                             
                    </li>


                    <li class="nav-item">
                        <asp:LinkButton Class="nav-link" ID="lbSalir" Text="Salir" runat="server" OnClick="lbSalir_Click">
                             <i class="fa fa-fw fa-sign-out"></i>Salir
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="content-wrapper">
            <div class="container-fluid">

                <div data-key="AIzaSyAejsGgs4worFPCnl7j_Sxk3G-j826TFZw"
                    data-control-zoom="true"
                    data-control-type="false"
                    data-control-scale="true"
                    data-control-streetview="false"
                    data-control-rotate="false"
                    data-event-mousewheel="true"
                    data-zoom="14" role="map" class="gmaps" >

                    <!-- Geografia -->
                    <asp:Repeater ID="rpDepartamentos" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"depaCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"depaLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"depaLongitud") %>"  
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"depaCodigo")%>_tbDepartamento.jpg" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"depaNombre") %></h1>
                                    <p>Gobernador: <%# DataBinder.Eval(Container.DataItem,"depaGobernador") %></p>
                                    <p>Capital: <%# DataBinder.Eval(Container.DataItem,"depaCapital") %></p>
                                    <p>Municipios: <%# DataBinder.Eval(Container.DataItem,"depaMunicipios") %></p>
                                </div>
                                    
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>



                    <asp:Repeater ID="rpCiudadesPricipales" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"ciprCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"ciprLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"ciprLongitud") %>"
                                class="marker">
                                <div class="map-card">
                                    <h1><%# DataBinder.Eval(Container.DataItem,"ciprNombre") %></h1>
                                    <p>Departamento: <%# DataBinder.Eval(Container.DataItem,"depaNombre") %></p>
                                    <p>Reseña: <%# DataBinder.Eval(Container.DataItem,"ciprReseña") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                    <!-- Gastronomia -->

                    <asp:Repeater ID="rpGastronomia" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"gastCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"gastLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"gastLongitud") %>"
                                class="marker">
                                <div class="">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"gastCodigo")%>gastronomia.jpg" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"gastNombre") %></h1>
                                    <p>Tipo: <%# DataBinder.Eval(Container.DataItem,"tigaDescripcion") %></p>
                                    <p>Ciudad: <%# DataBinder.Eval(Container.DataItem,"gastCiudad") %></p>
                                    <p>Departamento: <%# DataBinder.Eval(Container.DataItem,"depaNombre") %></p>
                                    <p>Descripcion: <%# DataBinder.Eval(Container.DataItem,"gastDescripcion") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                    <!-- Musica -->

                    <asp:Repeater ID="rpMusica" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"musiCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"musiLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"musiLongitud") %>"
                                class="marker" >
                                
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"musiCodigo")%>musica.jpg" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"musiNombre") %></h1>
                                    <p>Zona donde mas se escucha: <%# DataBinder.Eval(Container.DataItem,"depaNombre") %></p>
                                    <p>Descripcion: <%# DataBinder.Eval(Container.DataItem,"musiDescripcion") %></p>

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>



                    <!-- Personajes Publicos -->

                    <asp:Repeater ID="rpPersonajesPublicos" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"artiCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"artiLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"artiLongitud") %>"
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"artiCodigo")%>_tbArtistas.jpg" width="400" height="300" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"artiNombre") %></h1>
                                    <p>Ciudad: <%# DataBinder.Eval(Container.DataItem,"artiCiudad") %></p>
                                    <p>Departamento: <%# DataBinder.Eval(Container.DataItem,"depaNombre") %></p>
                                    <p>Que es?: <%# DataBinder.Eval(Container.DataItem,"tiatGenero") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                    <!-- Deportes-->
                     <asp:Repeater ID="rpDeportes" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"lgCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"stLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"stLongitud") %>"
                                
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"lgCodigo")%>Deportes.png" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"stNombre") %></h1>
                                    <p>Presidente: <%# DataBinder.Eval(Container.DataItem,"stPresidente") %></p>
                                    <p>Fundacion: <%# DataBinder.Eval(Container.DataItem,"stFundacion") %></p>
                                    <p>Ciudad: <%# DataBinder.Eval(Container.DataItem,"stCiudad") %></p>
                                    <p>Descripción: <%# DataBinder.Eval(Container.DataItem,"stDescripcion") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                    <asp:Repeater ID="rpEstructurasDeportivas" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"arquCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"arquLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"arquLongitud") %>"
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"arquCodigo")%>Estructuras.jpg" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"arquNombre") %></h1>
                                    <p>Ciudad: <%# DataBinder.Eval(Container.DataItem,"arquCiudad") %></p>
                                    <p>Deporte: <%# DataBinder.Eval(Container.DataItem,"depaNombre") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                    <!-- Arte -->
                    <asp:Repeater ID="rpArquitectura" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"arquCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"arquLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"arquLongitud") %>"
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"arquCodigo")%>Arte.jpg" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"arquNombre") %></h1>
                                    <p>Ciudad: <%# DataBinder.Eval(Container.DataItem,"arquCiudad") %></p>
                                    <p>Deporte: <%# DataBinder.Eval(Container.DataItem,"depaNombre") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <!-- Historia-->
                    <asp:Repeater ID="rpHistoria" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"histCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"histLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"histLongitud") %>"
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"histCodigo")%>historia.jpg"/>
                                    <h1><%# DataBinder.Eval(Container.DataItem,"histNombre") %></h1>
                                    <p>Fecha Inicio: <%# DataBinder.Eval(Container.DataItem,"histFechaInicio") %></p>
                                    <p>Fecha Fin: <%# DataBinder.Eval(Container.DataItem,"histFechaFin") %></p>
                                    <p>Descripción: <%# DataBinder.Eval(Container.DataItem,"histDescripcion") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>



                    <asp:Repeater ID="rpPersonajesHistoricos" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"pehiCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"pehiLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"pehiLongitud") %>"
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"pehiCodigo")%>_tbPersonajesHistoricos.jpg"/>
                                    <h1><%# DataBinder.Eval(Container.DataItem,"pehiNombre") %></h1>
                                    <p>Descripción: <%# DataBinder.Eval(Container.DataItem,"pehiDescripcion") %></p>
                                    <p>Ciudad: <%# DataBinder.Eval(Container.DataItem,"pehiCiudad") %></p>
                                    <p>Fecha de Nacimiento: <%# DataBinder.Eval(Container.DataItem,"pehiNacimiento") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                    <!-- Flora-->
                <asp:Repeater ID="rpFlora" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"lgCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"stLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"stLongitud") %>"
                                
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"lgCodigo")%>Flora.jpg" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"stNombreNombre") %></h1>
                                    <p>Nombre Cientifico: <%# DataBinder.Eval(Container.DataItem,"stPresidente") %></p>
                                    <p>Descripción: <%# DataBinder.Eval(Container.DataItem,"stDescripcion") %></p>
                                    <p>Abundancia: <%# DataBinder.Eval(Container.DataItem,"stAbundancia") %></p>
                                    <p>Periodo de floración: <%# DataBinder.Eval(Container.DataItem,"stPeriodoFloracion") %></p>
                                    <p>Departamento Común: <%# DataBinder.Eval(Container.DataItem,"obclsDepartamentos.stNombre") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                <!-- Fauna -->

                <asp:Repeater ID="rpFauna" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"lgCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"stLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"stLongitud") %>"
                                
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"lgCodigo")%>Fauna.jpg" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"obclsFauna.stNombre") %></h1>
                                    <p>Descripción: <%# DataBinder.Eval(Container.DataItem,"stDescripcion") %></p>
                                    <p>Tipo Fauna: <%# DataBinder.Eval(Container.DataItem,"obclsFauna.obclsTipoFauna.stDescripcion") %></p>
                                    <p>Departamento: <%# DataBinder.Eval(Container.DataItem,"obclsDepartamentos.stNombre") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>



                <!-- Culturas -->

                <asp:Repeater ID="rpCulturas" runat="server">
                        <ItemTemplate>
                            <div
                                data-id="<%# DataBinder.Eval(Container.DataItem,"lgCodigo") %>"
                                data-lat="<%# DataBinder.Eval(Container.DataItem,"stLatitud") %>"
                                data-lng="<%# DataBinder.Eval(Container.DataItem,"stLongitud") %>"
                                
                                class="marker">
                                <div class="map-card">
                                    <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"lgCodigo")%>Culturas.jpg" />
                                    <h1><%# DataBinder.Eval(Container.DataItem,"stNombre") %></h1>
                                    <p>Descripción: <%# DataBinder.Eval(Container.DataItem,"stDescripcion") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                </div>
                

                


                <script>
                    $(document).ready(function () {
                        $('.gmaps').gmaps();
                    });

                </script>
            </div>
            <!-- /.container-fluid-->
            <!-- /.content-wrapper-->
            <footer class="sticky-footer">
                <div class="container">
                    <div class="text-center">
                        <small>Copyright ©Conoce a: Colombia 2018</small>
                    </div>
                </div>
            </footer>



        </div>
    </form>
</body>
</html>
