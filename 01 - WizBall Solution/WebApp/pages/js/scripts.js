//jQuery code
jQuery(function($) {
    "use strict";

    //Select Navigation on Mobile Devices
    $('.mobilemenu select').change(function() {
        var url = $(this).val();
        if (url) {
            window.location = url;
        }
        return false;
    });

    ///// Masonry
    if ($.isFunction($.fn.isotope)) {
        $(window).load(function() {
            var $container = $('.gallery-item');
            // init
            $container.isotope({
                // options
                itemSelector: '.gal',
                layoutMode: 'masonry'
            });
        });
    }

    //// Pretty Photo
    if ($.isFunction($.fn.prettyPhoto)) {
        $(document).ready(function() {
            $("a[rel^='prettyPhoto']").prettyPhoto({
                theme: 'dark_rounded',
                /* light_rounded / dark_rounded / light_square / dark_square / facebook */
                social_tools: false,
                show_title: true,
                /* true/false */
            });
        });
    }

});
$(function() {
    var pull = $('#pull');
    menu = $('#top-menu ul.clearfix');
    menuHeight = menu.height();

    $(pull).on('click', function(e) {
        e.preventDefault();
        menu.slideToggle();
    });

    $(window).resize(function() {
        var w = $(window).width();
        if (w > 320 && menu.is(':hidden')) {
            menu.removeAttr('style');
        }
    });
});
$(function() {
    var pullb = $('#pull-blog');
    menub = $('.b-menu ul');
    menuHeight = menub.height();

    $(pullb).on('click', function(e) {
        e.preventDefault();
        menub.slideToggle();
    });

    $(window).resize(function() {
        var w = $(window).width();
        if (w > 320 && menub.is(':hidden')) {
            menub.removeAttr('style');
        }
    });
});
$(window).load(function() {
    $('.flexslider').flexslider();

});
$(function() {
    $("#v-tabs, #tab").tabs();
});
$(document).ready(function() {
    $('.slider1').bxSlider({
        slideWidth: 157,
        minSlides: 2,
        maxSlides: 4,
        pager: false,
        slideMargin: 0
    });
});
$(document).ready(function() {
    $('.slider2').bxSlider({
        //slideWidth: 156,
        minSlides: 1,
        maxSlides: 4,
        pager: false,
        slideMargin: 0
    });
});