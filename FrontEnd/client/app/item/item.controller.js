'use strict';

angular.module('frontEndApp')
  .controller('itemComponent', function($scope, api, ngNotify) {

    /*
    {
      "ID": 0,
      "Description": "string",
      "Barcode": "string"
    }
    */

    $scope.itemModel = {};
    $scope.itemForm = {};
    $scope.itemFields = [{
      'key': 'Barcode',
      'type': 'input',
      'templateOptions': {
        'label': 'Scan the barcode :',
        'placeholder': 'Scan the barcode',
        'required': true,
        'focus': true
      }
    }, {
      'key': 'Description',
      'type': 'input',
      'templateOptions': {
        'label': 'Item description :',
        'placeholder': 'Enter the description of the item',
        'required': true
      }
    }, ];


    $scope.create = function(data) {
      api.post('item', data).then(function(result) {
        if (result.status !== 'error') {
          ngNotify.set('item Added successfuly', 'success');
          $scope.options.resetModel();
        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };


  });
