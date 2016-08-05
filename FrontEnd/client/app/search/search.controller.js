'use strict';

(function(){

class SearchComponent {
  constructor() {
    this.message = 'Hello';
  }
}

angular.module('frontEndApp')
  .component('search', {
    templateUrl: 'app/search/search.html',
    controller: SearchComponent,
    controllerAs: Search
  });

})();
