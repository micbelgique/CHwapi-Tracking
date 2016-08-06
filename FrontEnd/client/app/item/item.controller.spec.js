'use strict';

describe('Component: ItemComponent', function () {

  // load the controller's module
  beforeEach(module('frontEndApp'));

  var ItemComponent;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($componentController) {
    ItemComponent = $componentController('item', {});
  }));

  it('should ...', function () {
    expect(1).to.equal(1);
  });
});
