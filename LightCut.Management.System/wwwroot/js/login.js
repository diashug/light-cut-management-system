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
        password: null
    },

    methods: {
        init: function () {

        },

        login: function () {
            axios.post('/home/login/', {
                username: this.username,
                password: this.password
            }).then((res) => {
                console.log(res);
            }).catch((err) => {
                alert(err.message);
            });
        }
    }
});

vm.init();