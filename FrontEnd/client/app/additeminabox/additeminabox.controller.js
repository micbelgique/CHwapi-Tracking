'use strict';

(function(){

class AdditeminaboxComponent {
  constructor() {
    this.message = 'Hello';
  }
}

angular.module('frontEndApp')
  .component('additeminabox', {
    templateUrl: 'app/additeminabox/additeminabox.html',
    controller: AdditeminaboxComponent,
    controllerAs: Additeminabox
  });

})();
