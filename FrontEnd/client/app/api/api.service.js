'use strict';

function apiService() {
  // AngularJS will instantiate a singleton by calling "new" on this function
}

angular.module('frontEndApp')
  .service('api', function($http, $q, $location, ngNotify, $translate) {
    var serviceBase = 'http://192.168.241.133:54321/ApiTracking/';
    var obj = {};

    obj.get = function(q) {
      return $http.get(serviceBase + q).then(function(results) {
        return results.data;
      }, function(results) {
        //ngNotify.set($translate.instant('app.components.api.UNABLETOCONNECT'), 'error');
      });
    };

    obj.post = function(q, object) {
      //object = JSON.stringify(object);
      return $http.post(serviceBase + q, object).then(function(results) {
        return results.data;
      }, function(results) {
        //ngNotify.set($translate.instant('app.components.api.UNABLETOCONNECT'), 'error');

      });
    };
    obj.put = function(q, object) {
      object = JSON.stringify(object);
      return $http.put(serviceBase + q, object).then(function(results) {
        return results.data;
      }, function(results) {
        //ngNotify.set($translate.instant('app.components.api.UNABLETOCONNECT'), 'error');
      });
    };
    obj.delete = function(q) {

      return $http.delete(serviceBase + q).then(function(results) {
        return results.data;
      }, function(results) {
        //ngNotify.set($translate.instant('app.components.api.UNABLETOCONNECT'), 'error');

      });
    };
    return obj;


  });
