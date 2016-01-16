(function(){
    'use strict';
    angular.module('ComLink').config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'homeCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/home/index.html'
            })
            .when('/login', {
                controller: 'loginCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/account/login.html'
            })
            .when('/categories', {
                controller: 'categoryListCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/category/list.html'
            })
            .when('/categories/create', {
                controller: 'categoryCreateCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/category/create.html',
                authorize: true
            })
            .otherwise({
                controller: 'homeCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/home/404.html'
            });
    });
})();