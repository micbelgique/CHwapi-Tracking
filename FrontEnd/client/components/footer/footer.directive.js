'use strict';

angular.module('frontEndApp')
  .directive('footer', function() {
    return {
      templateUrl: 'components/footer/footer.html',
      restrict: 'E',
      controller: function() {
        this.date = Date.now();
      },
      controllerAs: 'footer',
      link: function(scope, element) {
        element.addClass('footer');
      }
    };
  });
