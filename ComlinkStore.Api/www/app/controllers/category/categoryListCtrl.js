(function () {
    'use strict';
    angular.module('ComLink').controller('categoryListCtrl', categoryListCtrl);

    categoryListCtrl.$inject = ['$rootScope','$http', 'SETTINGS'];

    function categoryListCtrl($rootScope, $http, SETTINGS) {
        var vm = this;
        vm.categories = [];
        vm.remove = remove;

        activate();

        function activate() {
            load();
        }

        function load() {
            $http.get(SETTINGS.SERVICE_URL + 'v1/categories')
                .then(success).catch(fail);

            function success(result) {
                vm.categories = result.data;
            }
            function fail(result) {
                toastr.error(result.data.message, 'Ops, algo deu errado');
            }
        }
        
        function remove(id, index) {
            var headers = { headers: { 'Authorization': 'Bearer ' + $rootScope.token }};
            $http.delete(SETTINGS.SERVICE_URL + 'v1/categories/' + id, headers)
                .then(success).catch(fail);

            function success(result) {
                toastr.success('Categoria removida com sucesso!', 'Tudo Certo!');                
                vm.categories.splice(index, 1);
            }
            function fail(result) {
                toastr.error(result.data.message, 'Ops, algo deu errado');
            }
        }
    }
})();