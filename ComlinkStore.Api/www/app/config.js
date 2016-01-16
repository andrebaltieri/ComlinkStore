(function () {
    'use strict';
    angular.module('ComLink').constant('SETTINGS', {
        "SERVICE_URL": "http://localhost:53674/api/"
    });

    angular.module('ComLink').run(function ($rootScope, $location) {
        $rootScope.token = '';

        var token = localStorage.getItem('token');
        if (token != '') {
            $rootScope.token = token;
        }

        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (next.authorize && $rootScope.token == '') {
                $location.path("/login");
            }
        });
    });
})();