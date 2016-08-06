'use strict';

describe('Component: AdditeminaboxComponent', function () {

  // load the controller's module
  beforeEach(module('frontEndApp'));

  var AdditeminaboxComponent;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($componentController) {
    AdditeminaboxComponent = $componentController('additeminabox', {});
  }));

  it('should ...', function () {
    expect(1).to.equal(1);
  });
});
