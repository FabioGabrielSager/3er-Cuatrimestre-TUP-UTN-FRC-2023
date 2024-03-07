$(document).ready(function () {
    let zoos = [];
    $.ajax({
        type: "GET",
        url: "http://localhost:5144/obtenerZoos",
        dataType: "json",
        success: function (response) {
            if(response.ok){
                let zooNum = 0;
                response.zoos.forEach(z => {
                    $('#zoos').append(`<option value="${zooNum}">${z.nombre} (${z.pais} - ${z.ciudad})</option>`);
                    zoos.push(z);
                    zooNum++;
                });
            }
        }
    });

    $('#zoos').on('change', function () {
        $('#animales .row').empty();
        const zoo = zoos[$('#zoos').val()];
        const url = 
        `http://localhost:5144/api/Animales/ObtenerAnimalesDeZoo/${encodeURIComponent(zoo.nombre)}/ciudad/${encodeURIComponent(zoo.ciudad)}/pais/${encodeURIComponent(zoo.pais)}`;
        // $.ajax({
        //     type: "GET",
        //     url: url,
        //     dataType: "json",
        //     success: function (response) {
        //         if(response.ok){
        //             response.animales.forEach(a => {
        //                 const card = $('<div class="card me-lg-2 mt-3" style="width: 18rem;">');
        //                 const cardBody = $('<div class="card-body">');
        //                 const cardTitle = $(`<h5 class="card-title">Nombre: ${a.nombre}</h5>`);
        //                 const cardNombreCientifico = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Nombre cientifico: ${a.nombreCientifico}</h6>`);
        //                 const cardContinente = $(`<h6 class="card-subtitle mb-2 text-body-secondary">COntinente: ${a.continente}</h6>`);
        //                 const cardPais = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Pais: ${a.pais}</h6>`);
        //                 const cardSexo = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Sexo: ${a.sexo}</h6>`);
        //                 const cardFamilia = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Familia: ${a.familia}</h6>`);
        //                 const cardPeligroDeExtincion = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Peligro de extinción: ${a.peligoDeExtincion ? "No" : "Si"}</h6>`);
        //                 const cardAnioDeNacimiento = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Año de nacimiento: ${a.anioDeNacimiento}</h6>`);

        //                 $(cardBody).append(cardTitle, cardNombreCientifico, cardContinente, cardPais, cardSexo, cardFamilia, cardPeligroDeExtincion, cardAnioDeNacimiento);
        //                 $(card).append(cardBody);
        //                 $('#animales .row').append(card);
        //             });
        //         }
        //         else {
        //             console.log(response.mensajeInfo);
        //         }
        //     }
        // });

        fetch(url).then(respuesta => respuesta.json())
        .then(respuesta => {
            if(respuesta.ok){
                respuesta.animales.forEach(a => {
                    const card = $('<div class="card me-lg-2 mt-3" style="width: 18rem;">');
                    const cardBody = $('<div class="card-body">');
                    const cardTitle = $(`<h5 class="card-title">Nombre: ${a.nombre}</h5>`);
                    const cardNombreCientifico = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Nombre cientifico: ${a.nombreCientifico}</h6>`);
                    const cardContinente = $(`<h6 class="card-subtitle mb-2 text-body-secondary">COntinente: ${a.continente}</h6>`);
                    const cardPais = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Pais: ${a.pais}</h6>`);
                    const cardSexo = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Sexo: ${a.sexo}</h6>`);
                    const cardFamilia = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Familia: ${a.familia}</h6>`);
                    const cardPeligroDeExtincion = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Peligro de extinción: ${a.peligoDeExtincion ? "No" : "Si"}</h6>`);
                    const cardAnioDeNacimiento = $(`<h6 class="card-subtitle mb-2 text-body-secondary">Año de nacimiento: ${a.anioDeNacimiento}</h6>`);

                    $(cardBody).append(cardTitle, cardNombreCientifico, cardContinente, cardPais, cardSexo, cardFamilia, cardPeligroDeExtincion, cardAnioDeNacimiento);
                    $(card).append(cardBody);
                    $('#animales .row').append(card);
                });
            }
            else{
                throw new Error(respuesta.mensajeInfo);
            }
        }).catch(err => console.log(err))
    });
});