/*
=========================================================================
Template Name: "Elegant - Personal/Html5 Template"
Template URI: http://www.ramand-novin.ir/theme/elegant
Description: "Personal - Html5 Template"
Author: Masoud Ramandian
Author URI: http://www.ramand-novin.ir
Author Email: ramand.novin@gmail.com
Version: 1.0
=========================================================================
*/

/* ================================
            Active Menu
================================ */
$(document).ready(function () {
    $(".menu-bars").on("click", function () {
        $('.navigation').toggleClass('active');
        $(this).toggleClass('active');
        return false
    });
    $(".navigation li a").on('click', function () {
        $(".navigation").removeClass("active");
        $(".menu-bars").removeClass("active");
    });
});

/* ================================
        Smooth Scroll Effect
================================ */
$(document).ready(function () {
    $('li.smooth-scroll a').bind('click', function (event) {
        var $anchor = $(this);
        var headerHeight = '0';
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top - headerHeight + "px"
        }, 1200, 'easeInOutExpo');
        event.preventDefault();
    });
});

/* ================================
        Smooth Scroll Effect
================================ */
$('body').scrollspy({
    target: '.navigation-inner',
    offset: 0
});

/* ================================
            Progress Bar
================================ */
$('.skill-area').waypoint(function () {
    $('.progress-bar').addClass('slideInLeft');
}, {
    triggerOnce: true,
    offset: '70%'
});

/* ================================
          Experiences Slider
================================ */
$(".experiences-sllides").owlCarousel({
    rtl: true,
    items: 3,
    margin: 30,
    loop: true,
    autoplay: true,
    smartSpeed: 1000,
    dots: false,
    nav: false,
    responsiveClass: true,
    responsive: {
        0: {
            items: 1,
            center: false
        },
        600: {
            items: 2,
            center: false
        },
        769: {
            items: 3,
            center: false
        }
    }
});

/* ================================
            Counter
================================ */
$('.counter-item').counterUp({
    delay: 10,
    time: 2000
});

/* ================================
            Isotope
================================ */
$(document).ready(function () {
    $(".portfolio-navigation li").on('click', function () {
        // Active class add & remove
        $(".portfolio-navigation li").removeClass("active");
        $(this).addClass("active");
        var selector = $(this).attr('data-filter');
        $(".portfolio-list").isotope({
            filter: selector
        });
    });
});

/* ================================
    Magnific Portfolio Popup
================================ */
$('.portfolio-view').magnificPopup({
    type: 'image',
    removalDelay: 300,
    mainClass: 'mfp-fade',
    gallery: {
        enabled: true
    }
});

/* ================================
    Testimonial Slides activation
================================ */
$(".testimonial-slides").owlCarousel({
    rtl: true,
    items: 3,
    margin: 30,
    loop: true,
    autoplay: true,
    smartSpeed: 1000,
    dots: true,
    nav: false,
    center: true,
    responsive: {
        0: {
            items: 1,
            dots: false
        },
        767: {
            items: 3
        }
    }
});

/* ================================
           Brand Activation
================================ */
$(".brand-slides").owlCarousel({
    rtl: true,
    items: 5,
    margin: 10,
    loop: true,
    autoplay: true,
    smartSpeed: 1000,
    responsive: {
        0: {
            items: 1,
            center: true,
            margin: 0
        },
        600: {
            items: 2
        },
        800: {
            items: 3
        },
        1024: {
            items: 4
        },
        1100: {
            items: 4
        },
        1200: {
            items: 4
        }
    }
});

/* ================================
   Scroll To top Function apply
================================ */
$(window).scroll(function () {
    var ScrollToTop = $(window).scrollTop();
    //ScrollToTop Function
    if (ScrollToTop > 500) {
        $(".ScrollToTop").fadeIn();
    }
    else {
        $(".ScrollToTop").fadeOut();
    }
});

/* ================================
   Scroll To top With animate
================================ */
$(".ScrollToTop").on('click', function () {
    $("body, html").animate({'scrollTop': 0}, 1000, 'easeInOutExpo');
    return false
});

/* ================================
               WOW JS
================================ */
$(document).ready(function () {
    new WOW().init();
});

/* ================================
            Pre-loader
================================ */
$(document).ready(function () {
    $(".portfolio-list").isotope();
    $(".elegant-preeloader").fadeOut(2200);
});