$(document).ready(()=>{
    $('#formulario').validate({
        rules:{
            nombre: "required",
            deportes: "required",
            calle: "required",
            barrio: "required",
            apellido: "required",
            sexo: "required",
            numero: {"required": true, "digits": true},
            cp: {"required": true, "digits": true}
        },
        messages:{
            nombre: "El nombre es requerido",
            deportes: "Debe seleccionar un deporte",
            calle: "La calle es requerida",
            barrio: "El barrio es requerido",
            apellido: "El apellido es requerido",
            sexo: "Debe seleccionar un sexo",
            numero: {"required": "El numero es requerido",
        "digits": "Debe ingresar un numero valido"},
            cp: {"required": "El numero es requerido",
        "digits": "Debe ingresar un numero valido"},
        },
        errorClass: "error-class",
        submitHandler: function(form) {
            alert("El formulario se envió correctamente.");
            form.submit();
        },
        invalidHandler: function(form) {
            alert("Hay errores, por favor corrijalos");
        }
    })
});
