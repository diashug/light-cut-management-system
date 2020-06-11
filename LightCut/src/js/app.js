window._ = require('lodash');

try {
    window.Popper = require('popper.js').default;
    window.$ = window.jQuery = require('jquery');
    require('bootstrap');
    window.Vue = require('vue');
    window.Vuex = require('vuex');
    window.axios = require('axios');
} catch (e) {
    console.log(e);
}

window.axios.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';


// Add dropdown submenu
$('.dropdown-menu a.dropdown-toggle').on('click', function (e) {

    if (!$(this).next().hasClass('show')) {
        $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
    }

    let $subMenu = $(this).next(".dropdown-menu");
    $subMenu.toggleClass('show');

    $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
        $('.dropdown-submenu .show').removeClass("show");
    });

    return false;
});
