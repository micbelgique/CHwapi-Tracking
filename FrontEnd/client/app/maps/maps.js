'use strict';

angular.module('frontEndApp')
  .config(function($stateProvider) {
    $stateProvider
      .state('maps', {
        url: '/maps',
        templateUrl: 'app/maps/maps.html',
      });
  });
