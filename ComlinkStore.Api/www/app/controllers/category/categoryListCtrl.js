(function () {
    'use strict';
    angular.module('ComLink').controller('categoryListCtrl', categoryListCtrl);

    categoryListCtrl.$inject = ['$http', 'SETTINGS'];

    function categoryListCtrl($http, SETTINGS) {
        var vm = this;
        vm.categories = [];

        activate();

        function activate() {
            load();
        }

        function load() {
            $http.get(SETTINGS.SERVICE_URL + 'v1/categories', null)
                .then(success).catch(fail);

            function success(result) {
                vm.categories = result.data;
            }
            function fail(result) {
                toastr.error(result.data.message, 'Ops, algo deu errado');
            }
        }
    }
})();