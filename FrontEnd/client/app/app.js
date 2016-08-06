'use strict';

angular.module('frontEndApp', ['frontEndApp.auth', 'frontEndApp.admin', 'frontEndApp.constants',
    'ngCookies', 'ngResource', 'ngSanitize', 'btford.socket-io', 'ui.router', 'ui.bootstrap',
    'validation.match', 'ngNotify', 'pascalprecht.translate', 'formly', 'formlyBootstrap'
  ])
  .config(function($urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise('/');
    $locationProvider.html5Mode(true);
  });
