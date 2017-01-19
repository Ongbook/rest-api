(function () {
	'use strict';	
	angular.module('og.controllers',[]);
	angular.module('og.services',[]);
	angular.module('og.directives',[]);
	angular.module('og.interceptors',[]);
	angular.module('og.components',[]);

	angular.module('ongbook',[
		'ngRoute',
		'ui.router',
		'toaster',		
		'ngAnimate',
		'ui.bootstrap',
		'ngFileUpload',
		'og.controllers',
		'og.services',
		'og.directives',
		'og.interceptors',
		'og.components'
		])
	.config(['$routeProvider', '$locationProvider','$urlRouterProvider', '$stateProvider',function($routeProvider, $locationProvider, $urlRouterProvider, $stateProvider){
		$locationProvider.html5Mode(true); 		
		$stateProvider
            .state('home', {
                url: '/',
                templateUrl: '../templates/dashboard/index.html',
                controller: 'homeCtrl',
                controllerAs: 'vm'
            })
            .state('dashboard', {
                url: '/dashboard',
                templateUrl: '../templates/dashboard/home.html',
                controller: 'homeCtrl',
                controllerAs: 'vm'
            })
            ;
		$urlRouterProvider.otherwise('/');
	}])

})();