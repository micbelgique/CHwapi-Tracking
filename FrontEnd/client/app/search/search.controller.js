'use strict';
angular.module('frontEndApp')
  .controller('searchComponent', function($scope, api) {

    /*
    {
      "ID": 0,
      "Description": "string",
      "Barcode": "string"
    }
    */

    $scope.searchModel = {};
    $scope.searchForm = {};
    $scope.searchFields = [{
      'key': 'Description',
      'type': 'input',
      'templateOptions': {
        'label': 'Search a box or a item :',
        'placeholder': 'Search a description or a barcode',
        'required': true,
        'focus': true
      }
    }];


    $scope.search = function(data) {
      api.get('searches', data).then(function(result) {
        if (result.status !== 'error') {
          ngNotify.set('search Added successfuly', 'success');
          $scope.options.resetModel()
        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };


  });
