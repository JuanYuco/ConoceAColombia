<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="MapaPersonajesPublicos.aspx.cs" Inherits="ConoceAColombia.web.Views.MapaPersonajesPublicos.MapaPersonajesPublicos" %>

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
        <asp:repeater id="rpPersonajesPublicos" runat="server">
            <ItemTemplate>
                <div
                    data-id="<%# DataBinder.Eval(Container.DataItem,"artiCodigo") %>"
                    data-lat="<%# DataBinder.Eval(Container.DataItem,"artiLatitud") %>"
                    data-lng="<%# DataBinder.Eval(Container.DataItem,"artiLongitud") %>"
                    class="marker">
                    <div class="map-card">
                        <img src="../../Resources/Images/<%# DataBinder.Eval(Container.DataItem,"artiCodigo")%>personaje.jpg" width="400" height="300" />
                        <h1><%# DataBinder.Eval(Container.DataItem,"artiNombre") %></h1>
                        <p>Ciudad: <%# DataBinder.Eval(Container.DataItem,"artiCiudad") %></p>
                        <p>Departamento: <%# DataBinder.Eval(Container.DataItem,"depaNombre") %></p>
                        <p>Que es?: <%# DataBinder.Eval(Container.DataItem,"tiatGenero") %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:repeater>
        <!-- fin datos de ubicación -->
    </div>
     <script>
        $(document).ready(function () {
            $('.gmaps').gmaps();
        });
        
    </script>
</asp:Content>
