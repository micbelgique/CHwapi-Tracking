'use strict';

describe('Component: GateComponent', function () {

  // load the controller's module
  beforeEach(module('frontEndApp'));

  var GateComponent;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($componentController) {
    GateComponent = $componentController('gate', {});
  }));

  it('should ...', function () {
    expect(1).to.equal(1);
  });
});
