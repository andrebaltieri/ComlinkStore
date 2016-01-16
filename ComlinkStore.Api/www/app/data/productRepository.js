(function () {
    'use strict';
    angular.module('ComLink').factory('productRepository', productRepository);

    productRepository.$inject = ['$http', 'SETTINGS'];

    function productRepository($http, SETTINGS) {
        return {
            getByCategory: getProductsByCategory,
            getCategories: getCategories
        };

        function getProductsByCategory(category) {
            return $http.get(SETTINGS.SERVICE_URL + 'v1/products/category/' + category);
        }
        
        function getCategories() {
            return $http.get(SETTINGS.SERVICE_URL + 'v1/categories');
        }
    }
})();