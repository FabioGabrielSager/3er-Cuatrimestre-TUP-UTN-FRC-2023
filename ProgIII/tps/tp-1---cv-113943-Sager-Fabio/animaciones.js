$(document).ready(function() {
    $('#presentacion').hide();
    $('#proyectos').hide();
    $('#habilidades').hide();
    $('#formacion').hide();
    $('#presentacion').fadeIn(1500);

    $('#proyectos-nav-btn').on('click',function() {
        $('#habilidades').hide();
        $('#formacion').hide();
        $('#proyectos').fadeIn(1500);
        $('body').css('overflow-y', 'visible');
    })

    $('#habilidades-nav-btn').on('click', function(){
        $('#proyectos').hide();
        $('#formacion').hide();
        $('#habilidades').fadeIn(1500);
        $('body').css('overflow-y', 'visible');
    });

    $('#formacion-nav-btn').on('click', function () {
        $('#proyectos').hide();
        $('#habilidades').hide();
        $('#formacion').fadeIn();
        $('body').css('overflow-y', 'visible');
    });

    $('#LCII-title').on('click', function(){
        $('#LCII-body').slideToggle("slow");
        $('#PIITPI-body').hide();
        $('#PIITPIG-body').hide();
        $('html, body').animate({
            scrollTop: $('#LCII-title').offset().top-$('#nav-principal').outerHeight()-5}, 800);
    });

    $('#PIITPI-title').on('click', function () {
        $('#LCII-body').hide();
        $('#PIITPI-body').slideToggle("slow");
        $('#PIITPIG-body').hide();
        $('html, body').animate({
            scrollTop: $('#PIITPI-title').offset().top-$('#nav-principal').outerHeight()-5}, 800);
    });

    $('#project-mencionado').on('click', function () {
        $('#PIITPI-body').slideToggle("slow");
        $('html, body').animate({
            scrollTop: $('#PIITPI-title').offset().top-$('#nav-principal').outerHeight()-5}, 800);
    });

    $('#PIITPIG-title').on('click', function () {
        $('#LCII-body').hide();
        $('#PIITPI-body').hide();
        $('#PIITPIG-body').slideToggle("slow");
        $('html, body').animate({
            scrollTop: $('#PIITPIG-title').offset().top-$('#nav-principal').outerHeight()-5}, 800);
    });
});
