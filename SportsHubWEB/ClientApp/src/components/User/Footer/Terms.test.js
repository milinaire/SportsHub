
// Auto-generated do not edit


/* eslint-disable import/no-extraneous-dependencies */
/* eslint-disable no-undef */
import React from 'react';
import renderer from 'react-test-renderer';
import {Terms} from "./Terms";


describe('Main\Footer\Terms test', () => {
  it('Main\Footer\Terms should match snapshot', () => {
    const component = renderer.create(<Terms/>);
    const tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});
