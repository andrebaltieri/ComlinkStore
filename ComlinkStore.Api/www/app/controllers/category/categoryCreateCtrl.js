(function () {
    'use strict';
    angular.module('ComLink').controller('categoryCreateCtrl', categoryCreateCtrl);

    categoryCreateCtrl.$inject = ['$rootScope' ,'$http', '$location', 'SETTINGS'];

    function categoryCreateCtrl($rootScope, $http, $location, SETTINGS) {
        var vm = this;
        vm.name = '';
        vm.submit = save;
        
        activate();

        function activate() {
            
        }
        
        function save() {
            var data = { name: vm.name };
            var headers = { 
                headers: 
                    { 'Authorization': 'Bearer ' + $rootScope.token }
            };
            $http.post(SETTINGS.SERVICE_URL + 'v1/categories', data, headers)
                .then(success).catch(fail);
                
            function success(result) {
                toastr.success('Categoria salva com sucesso', 'Tudo certo!');
                $location.path('/categories');
            }
            function fail(result) {
                toastr.error(result.data.message, 'Ops, algo deu errado');
            }
        }
    }
})();