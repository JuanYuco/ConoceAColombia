<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ConoceAColombia.web.Views.Mapa.WebForm1" %>

<!DOCTYPE html>

<html>
  <head>
    <style>
      #map {
        height: 400px;
        width: 100%;
       }
    </style>
  </head>
  <body>
    <h3>Conoce a colombia</h3>
    <div id="map"></div>
    <script>
        function initMap() {
            var uluru = { lat: 4.428375671209252, lng: -73.52065110892448 };
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 4,
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
  </body>
</html>
