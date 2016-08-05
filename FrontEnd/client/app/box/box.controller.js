'use strict';

(function() {

  class BoxComponent {
    constructor() {      
      this.message = 'Hello';
    }
  }

  angular.module('frontEndApp')
    .component('box', {
      templateUrl: 'app/box/box.html',
      controller: BoxComponent,
      //controllerAs: Box
    });
})();
