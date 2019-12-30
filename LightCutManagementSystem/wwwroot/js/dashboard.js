/**
 * File:
 * dashboard.js
 * 
 * Creation date:
 * 14/12/2019
 */

let vm = new Vue({
    el: '#dashboardApp',

    data: {
        numberOfPendingOrders: 0,
        numberOfPendingPayments: 0,
        _pendingOrdersTable: null,
        _pendingPaymentsTable: null
    },

    methods: {
        init: function () {
            this.getPendingOrdersData();
            this.getPendingPaymentsData();
        },

        getPendingOrdersData: function () {

        },

        getPendingPaymentsData: function () {

        },

        generatePendingOrdersTable: function () {

        },

        generatePendingPaymentsTable: function () {

        }
    }
});

vm.init();
