'use strict';

angular.module('frontEndApp')
  .config(function ($stateProvider) {
    $stateProvider
      .state('search', {
        url: '/search',
        template: '<search></search>'
      });
  });
