(function () {
    'use strict';
    angular.module('ComLink').controller('cartCtrl', cartCtrl);

    cartCtrl.$inject = ['$rootScope'];

    function cartCtrl($rootScope) {
        var vm = this;
        vm.cart = [];
        vm.calculateTotal = calculateTotal;
        vm.total = 0;
        
        activate();

        function activate() {
            load();
            calculateTotal();
        }

        function load() {
            vm.cart = $rootScope.cart;
        }

        function calculateTotal() {
            var total = 0;
            angular.forEach(vm.cart, function (item) {
                var sub = (item.quantity * item.product.price);
                total += sub;
            });
            vm.total = total;
        }
    }
})();