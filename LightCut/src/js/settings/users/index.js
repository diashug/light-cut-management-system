/**
 * File:
 * js/administration/users/index.js
 *
 * Creation date:
 * 2019/10/19
 */

let vm = new Vue({
    el: '#usersApp',

    data: {
        user: {
            name: null,
            username: null,
            password: null,
            roleId: null,
            observations: null
        }
    },

    methods: {
        init: function () {
            this.user = {
                name: null,
                username: null,
                password: null,
                roleId: null,
                observations: null
            }
        },

        create: function () {

        },

        edit: function () {

        },

        remove: function () {

        }
    }
});

vm.init();