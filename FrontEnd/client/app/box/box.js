'use strict';

angular.module('frontEndApp')
  .config(function ($stateProvider) {
    $stateProvider
      .state('box', {
        url: '/box',
        template: '<box></box>'
      });
  });
