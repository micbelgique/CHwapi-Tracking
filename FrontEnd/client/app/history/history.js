'use strict';

angular.module('frontEndApp')
  .config(function ($stateProvider) {
    $stateProvider
      .state('history', {
        url: '/history',
        template: '<history></history>'
      });
  });
