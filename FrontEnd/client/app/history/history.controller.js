'use strict';

(function(){

class HistoryComponent {
  constructor() {
    this.message = 'Hello';
  }
}

angular.module('frontEndApp')
  .component('history', {
    templateUrl: 'app/history/history.html',
    controller: HistoryComponent,
    controllerAs: History
  });

})();
