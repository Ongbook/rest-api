(function () {
	'use strict';
	angular
	.module('og.controllers')
	.controller('entidadeCtrl', entidadeCtrl);

	entidadeCtrl.$inject = ['entidadeServiceApi','toaster'];

	function entidadeCtrl(entidadeServiceApi,toaster) {
		
		var vm 			   = this;
		console.log('hahaha');
		vm.getEntidadesAll = getEntidadesAll;
		vm.result = 'hahaha';
		function getEntidadesAll() {
			console.log('Estamos aquiii');
			entidadeServiceApi.getEntidades()
				.then(function (result) {
					vm.result = result.data.response;
					console.log(result);
				});
		}
		
	}

})();