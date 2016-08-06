  'use strict';

  angular.module('frontEndApp')
    .config(function($stateProvider) {
      $stateProvider
        .state('search', {
          url: '/search',
          templateUrl: 'app/search/search.html',
          controller: 'searchComponent',
          //authenticate: true
        });
    });
