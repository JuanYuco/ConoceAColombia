<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ConoceAColombia.web.Views.Prueba.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script 
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCQpz91b0RSXRUi6tWYxRCYtYe4H3oYjgI">
    </script>
</head>
<body onload="initMap()"><form>
     <div id="map"></div>
    <input type="button" value="Mostrar Mapa" onclick="initMap()"/>
    <script type="text/javascript">
        function initMap()
        alert('holamundo');
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
    </script></form>
</body>
</html>
