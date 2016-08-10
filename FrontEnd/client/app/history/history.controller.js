'use strict';
angular.module('frontEndApp')
  .controller('historyComponent', function($scope, api, ngNotify) {

    /*
    {
      "ID": 0,
      "Description": "string",
      "Barcode": "string"
    }
    */

    $scope.historyModel = {};
    $scope.historyForm = {};
    $scope.historyFields = [{
      'key': 'history',
      'type': 'input',
      'templateOptions': {
        'label': 'View the history of a box :',
        'placeholder': 'Type a description or scan a barcode',
        'required': true,
        'focus': true
      }
    }];


    $scope.search = function(data) {
      api.post('TrackAdmin/history', data).then(function(result) {
        if (result.status !== 'error') {
          $scope.searchResult = result;
          $scope.options.resetModel();

        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };


  });
