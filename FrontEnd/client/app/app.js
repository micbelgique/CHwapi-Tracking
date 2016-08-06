'use strict';

angular.module('frontEndApp', ['frontEndApp.auth', 'frontEndApp.admin', 'frontEndApp.constants',
    'ngCookies', 'ngResource', 'ngSanitize', 'btford.socket-io', 'ui.router', 'ui.bootstrap', 'ui.select',
    'validation.match', 'ngNotify', 'pascalprecht.translate', 'formly', 'formlyBootstrap'
  ])
  .config(function($urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise('/');
    $locationProvider.html5Mode(true);
  })
  .config(function($httpProvider) {
    $httpProvider.defaults.timeout = 3000;
    //delete $httpProvider.defaults.headers.common['X-Requested-With'];
    //$httpProvider.defaults.headers.post['Accept'] = 'application/json, text/javascript';
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/json; charset=utf-8';
    //$httpProvider.defaults.headers.post['Access-Control-Max-Age'] = '1728000';
    //$httpProvider.defaults.headers.common['Access-Control-Max-Age'] = '1728000';
    //$httpProvider.defaults.headers.common['Accept'] = 'application/json, text/javascript';
    //$httpProvider.defaults.headers.common['Content-Type'] = 'application/json; charset=utf-8';
    //$httpProvider.defaults.useXDomain = true;
  });
