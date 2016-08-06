'use strict';
angular.module('frontEndApp')
  .config(function($stateProvider) {
    $stateProvider
      .state('box', {
        url: '/box',
        templateUrl: 'app/box/box.html',
        controller: 'boxComponent'
      });
  });
