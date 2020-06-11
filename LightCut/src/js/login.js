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
                params: {
                    username: this.username,
                    password: this.password
                }
            }).then((res) => {

                let data = res.data;

                if (!data.error) {
                    window.open("home/dashboard", "_self");
                } else {
                    this.error.show = true;
                    this.error.message = data.message;
                }
            }).catch((err) => {
                alert(err.message);
            });
        }
    }
});

vm.init();