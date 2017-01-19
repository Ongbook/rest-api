(function () {
	'use strict';
	angular
		.module('og.directives')
		.directive('entidade', 
			function () {
				return{
					templateUrl: '../../../templates/entidade/entidade.html'
				}
			});
})();