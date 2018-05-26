<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="MapaGeografia.aspx.cs" Inherits="ConoceAColombia.web.Views.MapaEsteSi.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <script src="http://code.jquery.com/jquery-3.2.1.js"></script>
    <link href="../../css/jquery.gmaps.css" rel="stylesheet" />
    <script src="../../js/jquery.gmaps.js"></script>

    <style>
        .gmaps {
            height: 500px;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">


    <div data-key="AIzaSyCQpz91b0RSXRUi6tWYxRCYtYe4H3oYjgI"
        data-control-zoom="true"
        data-control-type="true"
        data-control-scale="true"
        data-control-streetview="true"
        data-control-rotate="true"
        data-event-mousewheel="true"
        data-zoom="14" role="map" class="gmaps">

        <!-- items de ubicaciones -->
        <asp:Repeater ID="rpDepartamentos" runat="server">
            <ItemTemplate>
                <div
                    data-id="<%# DataBinder.Eval(Container.DataItem,"depaCodigo") %>"
                    data-lat="<%# DataBinder.Eval(Container.DataItem,"depaLatitud") %>"
                    data-lng="<%# DataBinder.Eval(Container.DataItem,"depaLongitud") %>"
                    class="marker">
                    <div class="map-card">
                        <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"depaCodigo")%>departamento.jpg" />
                        <h1><%# DataBinder.Eval(Container.DataItem,"depaNombre") %></h1>
                        <p>Gobernador: <%# DataBinder.Eval(Container.DataItem,"depaGobernador") %></p>
                        <p>Capital: <%# DataBinder.Eval(Container.DataItem,"depaCapital") %></p>
                        <p>Municipios: <%# DataBinder.Eval(Container.DataItem,"depaMunicipios") %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <!-- fin datos de ubicación -->

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
    </div>


    <script>
        $(document).ready(function () {
            $('.gmaps').gmaps();
        });
        
    </script>
</asp:Content>
