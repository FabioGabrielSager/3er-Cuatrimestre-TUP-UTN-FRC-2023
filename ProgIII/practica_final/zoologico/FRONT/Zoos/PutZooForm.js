function HabilitarCamposForm(isEnabled) {
    const form = document.getElementsByTagName('form')[0];

    for (let i = 0; i < form.elements.length; i++) {
        const e = form.elements[i];
        if (e.tagName === 'INPUT' || e.tagName === 'SELECT' && e.id !== 'zoo') {
            e.disabled = !isEnabled; 
        }
    }
}

document.addEventListener("DOMContentLoaded", function() {
    HabilitarCamposForm(false);
    let zoos = [];

    // Cargar select de zoos
    fetch("http://localhost:5144/obtenerZoos").then(r => r.json())
    .then(r => {
        if(r.ok){
            r.zoos.forEach(z => {
                const option = document.createElement('option');
                option.value = z.id;
                option.textContent = z.nombre + ` (${z.pais} - ${z.ciudad})`;
                document.getElementById('zoo').appendChild(option);
                zoos.push(z);
            });
        }

    }).catch(err => console.log(err));

    // Cargar select de ciudad
    fetch("http://localhost:5144/obtenerCiudades").then(r => r.json())
    .then(r => {
        r.forEach(c => {
            const option = document.createElement('option');
            option.value = c.id;
            option.textContent = c.nombre;
            document.getElementById('ciudad').appendChild(option);
        });
    }).catch(err => console.log(err));

    // Cargar select de pais
    fetch("http://localhost:5144/obtenerPaises").then(r => r.json())
    .then(r => {
        r.forEach(p => {
            const option = document.createElement('option');
            option.value = p.id;
            option.textContent = p.nombre;
            document.getElementById('pais').appendChild(option);
        });
    }).catch(err => console.log(err));

    const selectZoos = document.getElementById('zoo');
    selectZoos.addEventListener("change", function(){
        HabilitarCamposForm(true);
        const zoo = zoos[selectZoos.selectedIndex - 1];
        document.getElementById('nombre').value = zoo.nombre;
        document.getElementById('presupuesto').value = zoo.presupuestoAnual;
        document.getElementById('tamanio').value = zoo.tamanioEnM2;

        const selectCiudad = document.getElementById('ciudad');
        for (let i = 0; i < selectCiudad.options.length; i++) {
            const option = selectCiudad.options[i];
            if(option.text == zoo.ciudad){
                selectCiudad.selectedIndex = i;
                break;
            }
        }

        const selectPais = document.getElementById('pais');
        for (let i = 0; i < selectPais.options.length; i++) {
            const option = selectPais.options[i];
            if(option.text == zoo.pais){
                selectPais.selectedIndex = i;
                break;
            }
        }
    });

    
    const form = document.getElementsByTagName('form')[0];
    form.addEventListener('submit', function (e) {
        e.preventDefault();
        const zoo = zoos[selectZoos.selectedIndex - 1];
        const selectPais = document.getElementById('pais');
        const selectCiudad = document.getElementById('ciudad');
        const request = {
            "idZoo": zoo.id,
            "ciudadId": selectCiudad.options[selectCiudad.selectedIndex].value,
            "paisId": selectPais.options[selectPais.selectedIndex].value,
            "nombre": document.getElementById('nombre').value,
            "presupuestoAnual": document.getElementById('presupuesto').value,
            "tamanioEnM2": document.getElementById('tamanio').value
        }

        fetch("http://localhost:5144/actualizarZoo", {
            method: "PUT",
            body: JSON.stringify(request),
            headers: {
                "Content-type": "application/json"
            }
        }).then(r => r.json()).then(r => {if(r.ok){ alert("Actualizado"); }else{ throw new Error("Hubo un error") }})
        .catch(err => console.log(err));
     })

});
