'use strict';
angular.module('frontEndApp')
  .config(function($stateProvider) {
    $stateProvider
      .state('gate', {
        url: '/gate',
        templateUrl: 'app/gate/gate.html',
        controller: 'GateComponent'
      });
  });
