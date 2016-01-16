(function () {
    'use strict';
    angular.module('ComLink').controller('productListCtrl', productListCtrl);

    productListCtrl.$inject = ['$rootScope', '$http', 'SETTINGS'];

    function productListCtrl($rootScope, $http, SETTINGS) {
        var vm = this;
        vm.categories = [];
        vm.products = [];
        vm.loadProducts = loadProductsByCategory;
        vm.categoryId = 0;
        vm.addToCart = addToCart;
        
        activate();

        function activate() {
            loadCategories();
        }
        
        function loadProductsByCategory(category) {
            vm.categoryId = category;
            $http.get(SETTINGS.SERVICE_URL + 'v1/products/category/' + category)
                .then(success).catch(fail);

            function success(result) {
                vm.products = result.data;
            }
            function fail(result) {
                toastr.error(result.data.message, 'Ops, algo deu errado');
            }
        }
        
        function loadCategories() {
            $http.get(SETTINGS.SERVICE_URL + 'v1/categories')
                .then(success).catch(fail);

            function success(result) {
                vm.categories = result.data;
                loadProductsByCategory(vm.categories[0].id);
            }
            function fail(result) {
                toastr.error(result.data.message, 'Ops, algo deu errado');
            }
        }
        
        function addToCart(product){
            var data = {
                product : product,
                quantity: 1
            };
            $rootScope.cart.push(data);
            localStorage.setItem('cart', angular.toJson($rootScope.cart));
        }
    }
})();