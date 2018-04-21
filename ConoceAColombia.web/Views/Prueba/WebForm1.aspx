
  <html>
  <head>
    <style>
      #map {
        height: 400px;
        width: 100%;
       }
    </style>
  </head>


<%--    <label runat="server">Latitud</label>
    <input runat="server" name="latitud" id="txtlatitud" type="text" />
    <br />
    <label runat="server">Longitud</label>
    <input runat="server" name="longitud" id="txtlongitud" type="text" />
    <div id="map"></div>
    <input type="button" value="Mostrar mapa" onclick="initMap()" />--%>

   <div id="map"></div>
    <input type="button" value="Mostrar Mapa" onClick="initMap()"/>
    <script>
        function initMap() {
            var uluru = { lat: -25.363, lng: 131.044 };
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
