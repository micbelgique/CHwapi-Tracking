'use strict';
angular.module('frontEndApp')
  .controller('AddaddIteminaboxComponent', function($scope, api) {

    $scope.boxes = [];
    api.get('box')
      .then(function(response) {
        if (response !== undefined) {
          $scope.boxes = $scope.boxes.push(response);
        }
      });

    $scope.items = [];
    api.get('item')
      .then(function(response) {
        if (response !== undefined) {
          $scope.items = $scope.items.push(response);
        }
      });

    $scope.addItemModel = {};
    $scope.addItemForm = {};
    $scope.addItemFields = [{
      "key": "boxId",
      "type": "select",
      "templateOptions": {
        "label": "Select the box",
        "options": [{
          "name": "Box 1",
          "value": "box1"
        }, {
          "name": "Box 2",
          "value": "box2"
        }],
        'required': true,
      }
    }, {
      "key": "itemId",
      "type": "select",
      "templateOptions": {
        "label": "Select a item to add in a box",
        "options": [{
          "name": "Glucose",
          "value": "glucose"
        }, {
          "name": "Scalpel",
          "value": "scalpel"
        }],
        'required': true,
      }
    }, ];


    $scope.create = function(data) {
      api.post('addItems', data).then(function(result) {
        if (result.status !== 'error') {
          ngNotify.set('addItem Added successfuly', 'success');
          $scope.options.resetModel()
        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };


  });
