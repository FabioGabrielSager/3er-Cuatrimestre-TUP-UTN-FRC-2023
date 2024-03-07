$(document).ready(function () {
    $('#form-enviar-mensaje').validate({
        rules:{
            'recipient-name': "required",
            'message-text': "required"
        },
        submitHandler: function(form){
            form.submit();
        },
        invalidHandler: function(form){
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!'
              })
        },
        errorClass: 'error-class'
    });
});