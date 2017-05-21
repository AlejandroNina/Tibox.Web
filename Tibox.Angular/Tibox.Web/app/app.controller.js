(function () {
    'use-strict';
    angular.module('app')
    .controller('applicationController', applicationController);

    applicationController.$inject = ['$scope', 'configService', 'authenticationService'];

    function applicationController($scope, configService, authenticationService) {
        var vm = this;
        vm.validate = validate();
        vm.logout = logout;

        //Con esto no necesito estar cambiando la URL en toda la aplicación:
        $scope.init = function (url) {
            configService.setApiUrl(url);
        }

        function validate() {
            return configService.getLogin();
        }

        function logout() {
            authenticationService.logout();
        }
    }
})();