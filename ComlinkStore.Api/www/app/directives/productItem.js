(function () {
    'use strict';
    angular.module('ComLink').directive('productItem', productItem);

    function productItem() {
        return {
            templateUrl: 'pages/shared/product-item.html',
            scope: {
                product: '='
            }
        }
    }
})();