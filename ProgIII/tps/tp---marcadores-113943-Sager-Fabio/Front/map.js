function calculateZoomLevel(width) {
    // Puntos de corte para diferentes niveles de zoom
    var breakpoints = [
      { width: 576, zoom: 8 },
      { width: 768, zoom: 10 },
      { width: 992, zoom: 12 },
      { width: 1200, zoom: 14 },
      { width: 1600, zoom: 16 },
      { width: 1920, zoom: 18 }
    ];

    for (var i = breakpoints.length - 1; i >= 0; i--) {
        if (width >= breakpoints[i].width) {
            return breakpoints[i].zoom;
        }
    }
    return 10;
}

$('#generarMapa').on('click', function() {
  $.ajax({
    url: 'http://localhost:5257/GetMarcadores', 
    type: 'GET',
    dataType: 'json',
    success: function(response) {
      if (response.ok) {
        $('#generarMapa').hide();
        $('#generarMapaContainer').removeClass('d-flex align-items-center justify-content-center').hide();

        var markersData = response.litadoMarcadores;

        // Inicializar el mapa
        var platform = new H.service.Platform({
          apikey: 'MWnvqqnO6RmNOrmlA1UuoHiXIJO-sz33QBd1nX41IR8'
        });

        var defaultLayers = platform.createDefaultLayers();
        var map = new H.Map(
          document.getElementById('map'),
          defaultLayers.vector.normal.map,
          {
            center: { lat: markersData[0].latitud, lng: markersData[0].longitud },
            zoom: 15
          }
        );

        // Create the default UI:
        var ui = H.ui.UI.createDefault(map, defaultLayers);

        // Creo icono de locación personalizado
        var icon = new H.map.Icon('img/location.svg', {
            size: { w: 24, h: 24 },
            anchor: { x: 12, y: 24 }
        });


        // Agregar los marcadores al mapa
        markersData.forEach(function(markerData) {
          var marker = new H.map.Marker({
            lat: markerData.latitud,
            lng: markerData.longitud
          },  { icon: icon });

          map.addObject(marker);
        });

        // Control de tamaño del mapa según sea la resolución actual
        $(window).resize(function() {
            map.getViewPort().resize();
        });

        // Control del zoom del mapa según sea la resolución actual
        $(window).on('load resize', function() {
            var width = $(window).width();
            var zoom = calculateZoomLevel(width);

            map.setZoom(zoom);
        });

        $('#map').hide();
        $('#map').fadeIn(1500);
      } 
      else {
        console.error('Error al obtener los marcadores:', response.error);
      }
    },
    error: function(xhr, status, error) {
      console.error('Error en la solicitud AJAX:', error);
    }
  });
});