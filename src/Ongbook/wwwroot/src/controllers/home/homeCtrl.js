(function () {
	'use strict';
	angular
	.module('og.controllers')
	.controller('homeCtrl', homeCtrl);

	homeCtrl.$inject = ['entidadeServiceApi','toaster','$state'];

	function homeCtrl(entidadeServiceApi, toaster, $state) {
		var vm = this;
		vm.listDashboard = listDashboard;
		vm.entidades = {};


		function listDashboard() {
			console.log('here');

			$state.go('dashboard');
		}

		function teste() {
			entidadeServiceApi.getEntidades()
				.then(function (result) {
					console.log(result.data.response);
					vm.entidades = result.data.response;
				});
		}
		teste();
	}

})();