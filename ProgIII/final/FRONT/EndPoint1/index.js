$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/obtenerDepositosArgentinos",
        dataType: "json",
        success: function (response) {
            if(response.ok){
                let depoNum = 0;
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
                });
            }
            else{
                alert("Hubo un error:", response.mensajeInfo)
            }
        },
        Error: function (statusText) { alert(statusText) }
    });
});