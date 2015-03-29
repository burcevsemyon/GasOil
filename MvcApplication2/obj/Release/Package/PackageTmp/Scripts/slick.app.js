$(document).ready(function(){
    /*$('#div-carousel').slick({
        infinite: true,
        speed: 700,
        fade: true,
        cssEase: 'linear',
        autoplay: true,
        autoplaySpeed: 2500
    });*/
    $('#div-carousel').slick({
        //centerMode: true,
        //centerPadding: '1px',
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 2000,
        arrows: false,
        infinite: true
    });
});