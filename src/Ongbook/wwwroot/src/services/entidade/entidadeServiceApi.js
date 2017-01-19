(function () {
	'use strict';
	angular
		.module('og.services')
		.factory('entidadeServiceApi',entidadeServiceApi);

		entidadeServiceApi.$inject = ['$http','config'];

		function entidadeServiceApi($http,config) {

			var _getEntidades = function () {
				return $http.get(config.baseApiUrl+'entidades');
			}

			var _setEntidades = function (objParam) {
				return $http.post(config.baseApiUrl+'entidades',objParam);
			}

			return {
				getEntidades:_getEntidades,
				setEntidades:_setEntidades

			}
		}
})();