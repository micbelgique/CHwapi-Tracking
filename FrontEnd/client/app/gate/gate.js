'use strict';

angular.module('frontEndApp')
  .config(function ($stateProvider) {
    $stateProvider
      .state('gate', {
        url: '/gate',
        template: '<gate></gate>'
      });
  });
