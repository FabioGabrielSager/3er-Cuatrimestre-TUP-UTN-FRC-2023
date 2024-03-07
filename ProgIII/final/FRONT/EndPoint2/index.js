$(document).ready(function () {
    $('#divExisteUnArg').hide();
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/obtenerDepositos",
        dataType: "json",
        success: function (response) {
            if(response.ok){
                let depoNum = 0;
                let cantDeposArgentinos = 0;
                response.depositos.forEach(e => {
                    const row = `            
                    <tr>
                        <th scope="row">${depoNum}</th>
                        <td>${e.nombre}</td>
                        <td>${e.metrosCuadrados}</td>
                        <td>${e.calle}</td>
                        <td>${e.numero}</td>
                        <td>${e.barrio}</td>
                        <td>${e.ciudad}</td>
                        <td>${e.pais}</td>
                    </tr>`
                    $('#listado tbody').append(row);
                    depoNum++;
                    if(e.pais == "Argentina"){
                        cantDeposArgentinos++;
                    }
                });
                if(cantDeposArgentinos > 3){
                    alert("Hay mas de 3 depositos Argentinos")
                }

                if(cantDeposArgentinos == 1){
                    $('#divExisteUnArg').show();
                    $('#divExisteUnArg').addClass('d-flex justify-content-center');
                }
            }
            else{
                alert("Hubo un error:", response.mensajeInfo)
            }
            },
            Error: function (statusText) { alert(statusText) }
    });
});