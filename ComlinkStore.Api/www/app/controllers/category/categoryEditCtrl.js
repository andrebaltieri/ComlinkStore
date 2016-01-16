(function () {
    'use strict';
    angular.module('ComLink').controller('categoryEditCtrl', categoryEditCtrl);

    categoryEditCtrl.$inject = ['$rootScope','$http', '$routeParams', '$location', 'SETTINGS'];

    function categoryEditCtrl($rootScope, $http, $routeParams, $location, SETTINGS) {
        var vm = this;
        vm.category = {};
        vm.submit = save;
         
        activate();

        function activate() {
            load();
        }
        
        
        function load() {
            $http.get(SETTINGS.SERVICE_URL + 'v1/categories/' + $routeParams.id)
                .then(success).catch(fail);

            function success(result) {
                vm.category = result.data;
            }
            function fail(result) {
                toastr.error(result.data.message, 'Ops, algo deu errado');
            }
        }
        
        function save() {
            var headers = { headers: { 'Authorization': 'Bearer ' + $rootScope.token }};
            $http.put(SETTINGS.SERVICE_URL + 'v1/categories/' + $routeParams.id, vm.category, headers)
                .then(success).catch(fail);
                
            function success(result) {
                toastr.success('Categoria alterada com sucesso', 'Tudo certo!');
                $location.path('/categories');
            }
            function fail(result) {
                toastr.error(result.data.message, 'Ops, algo deu errado');
            }
        }
    }
})();