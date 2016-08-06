'use strict';

angular.module('frontEndApp')
  .controller('GateComponent', function($scope, api) {

    /*
    {
      "ID": 0,
      "Description": "string"
    }
    */

    $scope.gateModel = {};
    $scope.gateForm = {};
    $scope.gateFields = [{
      'key': 'Description',
      'type': 'input',
      'templateOptions': {
        'label': 'Description of the gate :',
        'placeholder': 'Type the description',
        'required': true,
        'focus': true
      }
    }, {
      "key": "Type",
      "type": "select",
      "templateOptions": {
        "label": "Select the type of the gate",
        "options": [{
          "name": "Normal",
          "value": "normal"
        }, {
          "name": "End Point",
          "value": "endPoint"
        }],
        'required': true,
      }
    }, ];


    $scope.create = function(data) {
      api.post('gatees', data).then(function(result) {
        if (result.status !== 'error') {
          ngNotify.set('gate Added successfuly', 'success');
          $scope.options.resetModel()
        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };


  });
