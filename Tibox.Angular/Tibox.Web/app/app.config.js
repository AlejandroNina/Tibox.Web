(function () {
    'use-strict';

    angular, module('app')
    config(config).run(run);

    config.$inject = ['$compilerProvider'];
   
    //Encargado de compilar toda la aplicación:
    function config($compilerProvider) {
        $compilerProvider.debugInfoEnabled(false);
    }

    run.$inject = ['$http', '$state', 'localStorageService', 'configService'];

    function run($http, $state, localStorageService,configService) {
        var user = localStorageService.get('userToken');
        if (user && user.token)
        {
            $http.defaults.headers.common.Authorization =
                'Bearer ' + user.token;
            configService.setLogin(true);
            //Redireccionar a otra página:
            $state.go('home');
        }
       else $state.go('login');
    }
})();