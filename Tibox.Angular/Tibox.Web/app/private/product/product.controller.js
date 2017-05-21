(function () {
    'use strict';
    angular.module('app')
    .controller('productController', productController);

    productController.$inject = ['dataService', 'configService', '$state'];

    function productController(dataService, configService, $state) {
        var apiUrl = configService.getApiUrl();
        var vm = this;

        //Propiedades:
        vm.product = {};
        vm.productList = [];
        vm.modalTitle = '';
        vm.modalButtonTitle = '';
        vm.readOnly = false;
        vm.isDelete = false;

        //Funciones:
        vm.create = create;
        vm.deleter = deleter;
        vm.edit = edit;
        vm.getProduct = getProduct;
        init();

        function init() {

        }

        function list() {

        }

        function closeModal() {
            angular.element('#modal-container').modal('hide');
        }

        function getProduct(id) {
            vm.product = null;
            dataService.getData(apiUrl + '/product/' + id)
            .then(
                    function (result) {
                        vm.product = result.data;
                    },
                    function (error) {
                        console.log(error);
                    }
                );
        }

        function edit() {
            vm.modalTitle = 'Editar Producto';
            vm.modalButtonTitle = 'Actualizar';
            vm.readOnly = false;
            vm.isDelete = false;
            vm.modalFunction = updateProduct;
        }

        function updateProduct(){
            if (!vm.product) return;
            dataService.putData(apiUrl + '/product/', vm.product)
            .then(
                     function (result) {
                         vm.product = {};
                         list();
                         closeModal();
                     },
                     function (error) {
                         console.log(error);
                     }
                 );
        }

        function deleter() {
            vm.modalTitle = 'Eliminar Producto';
            vm.modalButtonTitle = 'Eliminar';
            vm.readOnly = false;
            vm.isDelete = false;
            vm.modalFunction = deleterProduct;
        }

        function deleterProduct(id) {
            if (!vm.product) return;
            dataService.putData(apiUrl + '/product/' + id)
            .then(
                    function (result) {
                        list();
                        closeModal();
                    },
                    function (error) {
                        console.log(error);
                    }
            );
        }
    }
})();
