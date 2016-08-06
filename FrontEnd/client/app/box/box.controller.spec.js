'use strict';

describe('Component: BoxComponent', function () {

  // load the controller's module
  beforeEach(module('frontEndApp'));

  var BoxComponent;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($componentController) {
    BoxComponent = $componentController('box', {});
  }));

  it('should ...', function () {
    expect(1).to.equal(1);
  });
});
