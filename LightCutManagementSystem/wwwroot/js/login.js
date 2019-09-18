/**
 * File:
 * login.js
 * 
 * Creation date:
 * 2019/04/10
 */

let vm = new Vue({
    el: '#loginApp',

    data: {
        username: null,
        password: null,
        error: {
            show: false,
            message: null
        }
    },

    methods: {
        init: function () {
            this.username = null;
            this.password = null;
            this.error = {
                show: false,
                message: null
            }
        },

        login: function () {
            axios.get('home/login', {
                username: this.username,
                password: this.password
            }).then((res) => {
                if (!res.error) {
                    window.open("dashboard/index", "_self");
                } else {
                    this.error.show = true;
                    this.error.message = res.message;
                }
            }).catch((err) => {
                alert(err.message);
            });
        }
    }
});

vm.init();