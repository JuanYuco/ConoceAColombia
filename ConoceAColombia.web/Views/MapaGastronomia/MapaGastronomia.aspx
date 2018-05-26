<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="MapaGastronomia.aspx.cs" Inherits="ConoceAColombia.web.Views.MapaGastronomia.MapaGastronomia" %>

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
        <asp:Repeater ID="rpGastronomia" runat="server">
            <ItemTemplate>
                <div
                    data-id="<%# DataBinder.Eval(Container.DataItem,"gastCodigo") %>"
                    data-lat="<%# DataBinder.Eval(Container.DataItem,"gastLatitud") %>"
                    data-lng="<%# DataBinder.Eval(Container.DataItem,"gastLongitud") %>"
                    class="marker">
                    <div class="map-card">
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
    </div>
    <script>
        $(document).ready(function () {
            $('.gmaps').gmaps();
        });
        
    </script>
</asp:Content>
