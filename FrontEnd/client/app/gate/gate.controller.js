'use strict';

angular.module('frontEndApp')
  .controller('GateComponent', function($scope, api, ngNotify) {

    $scope.gateModel = {};
    $scope.gateForm = {};
    $scope.gateFields = [{
      'key': 'Description',
      'type': 'input',
      'templateOptions': {
        'label': 'Gate description :',
        'placeholder': 'Enter the description of the gate',
        'required': true,
        'focus': true
      }
    }, {
      'key': 'X',
      'type': 'input',
      'templateOptions': {
        'label': 'Gate X position :',
        'placeholder': 'Enter the position X',
        'required': true,

      }
    }, {
      'key': 'Y',
      'type': 'input',
      'templateOptions': {
        'label': 'Gate Y position :',
        'placeholder': 'Enter the position Y',
        'required': true,

      }
    }, {
      'key': 'Z',
      'type': 'input',
      'templateOptions': {
        'label': 'Gate Z position :',
        'placeholder': 'Enter the position Z',
        'required': true,

      }
    }];


    $scope.create = function(data) {
      api.post('gate', data).then(function(result) {
        if (result.status !== 'error') {
          ngNotify.set('Gate added successfuly', 'success');
          $scope.options.resetModel()
        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };


  });
