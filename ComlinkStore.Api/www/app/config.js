(function () {
    'use strict';
    angular.module('ComLink').constant('SETTINGS', {
        "SERVICE_URL": "http://localhost:53674/api/"
    });

    angular.module('ComLink').run(function ($rootScope, $location) {
        $rootScope.token = '';
        $rootScope.cart = [];

        var token = localStorage.getItem('token');
        if (token != '') {
            $rootScope.token = token;
        }
        
        var cart = localStorage.getItem('cart');
        if (cart != '') {
            $rootScope.cart = angular.fromJson(cart);
        }

        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (next.authorize && $rootScope.token == '') {
                $location.path("/login");
            }
        });
    });
})();