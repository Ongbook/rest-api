(function () {
	'use strict';
	angular
		.module('og.directives')
		.directive('home', 
			function () {
				return{
					templateUrl: '../../../templates/dashboard/index.html'
				}
			});
})();