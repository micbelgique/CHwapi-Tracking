'use strict';
angular.module('frontEndApp')
  .controller('AddaddIteminaboxComponent', function($scope, api, ngNotify) {

    $scope.searchItemModel = {};
    $scope.searchItemForm = {};

    $scope.addItemModel = {
      'idBox': '',
      'itemsID': [],
      'gateID': ''
    };
    $scope.addItemForm = {};

    $scope.searchItemFields = [{
      'key': 'search',
      'type': 'input',
      'templateOptions': {
        'label': 'Search a box or a item :',
        'placeholder': 'Scan the bar code',
        'required': true,
        'focus': true
      }
    }];

    function getJsonGate() {
      return api.get('gate');
    }

    $scope.addItemFields = [{
      'key': 'gateID',
      'type': 'select',
      'templateOptions': {
        'label': 'Choice the destination of the box :',
        'labelProp': 'Description',
        'valueProp': 'ID',
        'placeholder': 'Type or select the destination',
        'required': true,
        'options': [],
      },
      controller: /* @ngInject */ function($scope) {
        $scope.to.loading = getJsonGate().then(function(response) {
          $scope.to.options = response;
          // note, the line above is shorthand for:
          // $scope.options.templateOptions.options = data;
          return response;
        });
      }
    }];


    $scope.search = function(data) {
      api.post('TrackAdmin/search', data).then(function(result) {
        var encodedState = {};

        if (result.status !== 'error') {

          $scope.searchResult = result;
          if (encodedState.boxIsAssigned === true) {
            ngNotify.set('Box already assigned, please scan a item or reset', 'error');
          }
          if (encodedState === undefined || encodedState.boxIsAssigned === false) {
            if ($scope.searchResult.boxes.length > 0) {
              $scope.addItemModel.idBox = $scope.searchResult.boxes[0].ID;
              ngNotify.set('Box assigned, scan item', 'info');
              encodedState.boxIsAssigned = true;
              $scope.options.resetModel()
            } else {
              ngNotify.set('Scan a box before item', 'error');
            }

          } else {
            if ($scope.searchResult.items.length > 0) {
              $scope.addItemModel.itemsID.push($scope.searchResult.items[0].ID);
              ngNotify.set('item assigned, scan another item or close the box', 'info');
            } else {
              ngNotify.set('Oops, something went wrong', 'error');
            }
          }
        }
      })
    };

    $scope.create = function(data) {
      api.post('TrackAdmin/affectbox', data).then(function(result) {
        if (result.status !== 'error') {
          //TO DO
        } else {
          ngNotify.set('Oops, something went wrong', 'error');
        }
      });

    };
  });
