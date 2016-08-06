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
        'placeholder': 'Type a description or scan a barcode',
        'required': true,
        'focus': true
      }
    }];


    $scope.boxes = [];
    api.get('boxes')
      .then(function(response) {
        if (response !== undefined) {
          $scope.boxes = $scope.boxes.push(response);
        }
      });


  });
