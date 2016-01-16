(function () {
    'use strict';
    angular.module('ComLink').controller('loginCtrl', loginCtrl);

    loginCtrl.$inject = ['$rootScope', '$http', '$location', 'SETTINGS'];

    function loginCtrl($rootScope, $http, $location, SETTINGS) {
        var vm = this;
        vm.user = {};
        vm.submit = login;
        
        activate();

        function activate() {

        }
        
        function login(){
            var data = "grant_type=password&username=" + vm.user.username + "&password=" + vm.user.password;
            $http.post(SETTINGS.SERVICE_URL + 'token', data, { 
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(success).catch(fail);
            
            function success(result) {
                toastr.success('Login efetuado com sucesso!', 'Tudo certo!');
                
                $rootScope.token = result.data.access_token;
                localStorage.setItem('token', result.data.access_token);
                
                $location.path('#/');
            }
            function fail(result) {
                toastr.error(result.data.message, 'Ops, algo deu errado');
            }
        }
    }
})();