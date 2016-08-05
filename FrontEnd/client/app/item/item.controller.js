'use strict';

(function(){

class ItemComponent {
  constructor() {
    this.message = 'Hello';
  }
}

angular.module('frontEndApp')
  .component('item', {
    templateUrl: 'app/item/item.html',
    controller: ItemComponent,
    //controllerAs: Item
  });

})();
