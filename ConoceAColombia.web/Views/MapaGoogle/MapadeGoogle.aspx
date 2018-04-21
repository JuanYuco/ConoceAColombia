<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Template.Master" AutoEventWireup="true" CodeBehind="MapadeGoogle.aspx.cs" Inherits="ConoceAColombia.web.Views.MapaGoogle.MapadeGoogle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
     <style>
      #map {
        height: 500px;
        width: 100%;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenedor" runat="server">
    <h3>Conoce a colombia</h3>
    <div id="map"></div>
    <script>
        function initMap() {
            var uluru = { lat: 4.0000000, lng: -72.0000000};
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 5.3,
                center: uluru
            });
            var marker = new google.maps.Marker({
                position: uluru,
                map: map
            });
        }
    </script>
    <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCQpz91b0RSXRUi6tWYxRCYtYe4H3oYjgI&callback=initMap">
    </script>
</asp:Content>
