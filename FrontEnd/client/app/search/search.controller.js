'use strict';
angular.module('frontEndApp')
  .controller('searchComponent', function($scope, api, ngNotify) {

    $scope.searchModel = {};
    $scope.searchForm = {};
    $scope.searchFields = [{
      'key': 'search',
      'type': 'input',
      'templateOptions': {
        'label': 'Search a box or a item :',
        'placeholder': 'Search a description or a barcode',
        'required': true,
        'focus': true
      }
    }];


    $scope.search = function(data) {
      api.post('TrackAdmin/search', data).then(function(result) {
        if (result.status !== 'error') {
          $scope.searchResult = result;
          //TO DO

        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };


  });
