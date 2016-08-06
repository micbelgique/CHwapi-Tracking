'use strict';

angular.module('frontEndApp.auth', ['frontEndApp.constants', 'frontEndApp.util', 'ngCookies',
    'ui.router'
  ])
  .config(function($httpProvider) {
    $httpProvider.interceptors.push('authInterceptor');
  });
