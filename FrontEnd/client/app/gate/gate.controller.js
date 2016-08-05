'use strict';

(function() {

  class GateComponent {
    constructor() {
      this.message = 'Hello';
    }
  }

  angular.module('frontEndApp')
    .component('gate', {
      templateUrl: 'app/gate/gate.html',
      controller: GateComponent,
      controllerAs: Gate
    });

})();
