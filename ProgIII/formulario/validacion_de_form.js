$(document).ready(() => {
    $('#paises').prop('selectedIndex', -1);

    $('#formulario').validate({
        rules: {
            nombre: "required",
            contrasenia: {"required":true, "minlength": 8},
            'conf-contrasenia': {"required": true, "equalTo": '#contrasenia'},
            'rb-sexo': "required",
            paises: "required"
        },
        messages: {
            nombre: "Por favor ingrese un nombre",
            contrasenia: {
                "required": "Por favor ingrese una contraseña",
                "minlenght": "La contraseña debe tener como minimo 8 caracteres"},
            'conf-contrasenia': "Las contraseñas no coinciden",
            'rb-sexo': "Debe seleccionar un sexo",
            paises: "Debe seleccionar un pais"
            },
            errorClass: 'error-class',
            submitHandler: function(form) {
                form.submit();
            },
        }
    )
});