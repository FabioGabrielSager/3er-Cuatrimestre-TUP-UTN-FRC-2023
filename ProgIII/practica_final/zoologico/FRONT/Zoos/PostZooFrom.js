$(document).ready(function () {


    $.ajax({
        type: "get",
        url: "http://localhost:5144/obtenerCiudades",
        dataType: "json",
        success: function (response) {
          response.forEach(c => {
            $('#Ciudad').append(`<option value="${c.nombre}">${c.nombre}</option>`);
          });
        }
      });

    $.ajax({
      type: "get",
      url: "http://localhost:5144/obtenerPaises",
      dataType: "json",
      success: function (response) {
        response.forEach(c => {
          $('#Pais').append(`<option value="${c.nombre}">${c.nombre}</option>`);
        });
      }
    });


    $('form').submit(function (e) { 
      e.preventDefault();

      const request = {
        "ciudad": $('#Ciudad').val(),
        "pais": $('#Pais').val(),
        "nombre": $('#nombre').val(),
        "presupuestoAnual": $('#presupuesto').val(),
        "tamanioEnM2": $('#tamanio').val()
      }

    //   $.ajax({
    //   type: "POST",
    //   url: "http://localhost:5144/agregarZoo",
    //   data: JSON.stringify(request),
    //   contentType: "application/json",
    //   success: function (response) {
    //     if(response.ok){
    //       alert("Se cargo la wea");
    //     }
    //     else{
    //         console.log(response.mensajeInfo);
    //     }
    //   }
    // });

    fetch("http://localhost:5144/agregarZoo", {
      method: 'post',
      body: JSON.stringify(request),
      headers: {
        "Content-type": "application/json"
      }
    }).then(respuesta => respuesta.json())
    .then(respuesta => {
      if(respuesta.ok){
        alert("Se cargo la wea");
      }
      else{
        throw new Error("Hubo un error")
      }
    }).catch(err => console.log(err));
      
    });
  });