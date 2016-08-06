'use strict';
angular.module('frontEndApp')
  .controller('historyComponent', function($scope, api) {

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
      'key': 'Description',
      'type': 'input',
      'templateOptions': {
        'label': 'View the history of a box :',
        'placeholder': 'Type a description or a barcode',
        'required': true,
        'focus': true
      }
    }];


    $scope.history = function(data) {
      api.get('historyes', data).then(function(result) {
        if (result.status !== 'error') {
          ngNotify.set('history Added successfuly', 'success');
          $scope.options.resetModel()
        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };


  });
