'use strict';

angular.module('frontEndApp')
  .config(function($stateProvider) {
    $stateProvider
      .state('item', {
        url: '/item',
        templateUrl: 'app/item/item.html',
        controller: 'itemComponent'
      });
  });
