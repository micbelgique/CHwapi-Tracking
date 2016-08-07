'use strict';

angular.module('frontEndApp')
  .controller('boxComponent', function($scope, api, ngNotify) {

    /*
    {
      "ID": 0,
      "Description": "string",
      "Barcode": "string"
    }
    */

    $scope.boxModel = {};
    $scope.boxForm = {};
    $scope.boxFields = [{
      'key': 'Barcode',
      'type': 'input',
      'templateOptions': {
        'label': 'Barcode :',
        'placeholder': 'Scan the barcode',
        'required': true,
        'focus': true
      }
    }, {
      'key': 'Description',
      'type': 'input',
      'templateOptions': {
        'label': 'Box description :',
        'placeholder': 'Enter the description of the box',
        'required': true
      }
    }];


    $scope.create = function(data) {
      api.post('box', data).then(function(result) {
        if (result.status !== 'error') {
          ngNotify.set('Box added successfuly', 'success');
          $scope.options.resetModel()
        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };


  });
