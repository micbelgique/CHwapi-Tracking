'use strict';

angular.module('frontEndApp')
  .config(function ($stateProvider) {
    $stateProvider
      .state('additeminabox', {
        url: '/additeminabox',
        template: '<additeminabox></additeminabox>'
      });
  });
