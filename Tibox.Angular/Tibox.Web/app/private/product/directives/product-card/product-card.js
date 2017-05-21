(function () {
    'use-strict';

    angular.module('app')
    .directive('productCard', productCard);

    function productCard() {
        return {
            //Si quiero que sea de tipo Element: 'E'.
            //Si quiero que sea de tipo Attribute: 'A'.
            // '@' Significa que lo pintará de tipo texto.
            // '=' Significa que lo traerá tal cual es.
            //transclude: Significa que esa directiva puede recibir más elementos.
            restrict: 'E',
            transclude: true,
            scope: {
                id: '@', 
                productName: '@',
                supplierId: '@',
                unitPrice: '@',
                package: '@',
                isDiscontinued: '='
            },
            templateUrl: 'app/private/product/directives/product-card.html'
        };
    }
})();