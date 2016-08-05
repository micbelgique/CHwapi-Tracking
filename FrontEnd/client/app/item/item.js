'use strict';

angular.module('frontEndApp')
  .config(function ($stateProvider) {
    $stateProvider
      .state('item', {
        url: '/item',
        template: '<item></item>'
      });
  });
