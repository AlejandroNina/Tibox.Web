(function () {
    'use strict';
    angular.module('app')
    .factory('authenticationService', authenticationService);

    autehnticationService.$inject = ['$http',' $state','localStorageService', 'configService'];

    function autehnticationService($http, $state, localStorageService,configService) {
        var service = {};
        service.login = login;
        service.logout = logout;

        return service;

        function login(user) {
            var url = configService.getApiUrl() + '/token';
            var data = "grant_type=password&userName=" + user.userName +
                "&password=" + user.password;
            $http.post(url,
                data,
                {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
            .then(function (result) {
                $http.defaults.headers.common.Authorization =
                    'Bearer ' + result.data.access_token;

                localStorageService.set('userToken',
                {
                    token: result.data.access_token,
                    userName: user.userName
                });

                configService.setLogin(true);
            })
        }

        function logout() {
            if (!configService.getLogin()) return $state.go('login');
            $http.defaults.headers.common.Authorization = '';
            localStorageService.remove('userToken');
            configService.setLogin(false);
            $state.go('home');
        }
    }

})();