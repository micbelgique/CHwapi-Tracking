angular.module('frontEndApp')
  .config(function($stateProvider) {
    $stateProvider
      .state('additeminabox', {
        url: '/additeminabox',
        templateUrl: 'app/additeminabox/additeminabox.html',
        controller: 'AddaddIteminaboxComponent'
      });
  });
