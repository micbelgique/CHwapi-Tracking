'use strict';
angular.module('frontEndApp')
  .config(function($stateProvider) {
    $stateProvider
      .state('history', {
        url: '/history',
        templateUrl: 'app/history/history.html',
        controller: 'historyComponent'
      });
  });
