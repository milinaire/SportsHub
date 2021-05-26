
// Auto-generated do not edit


/* eslint-disable import/no-extraneous-dependencies */
/* eslint-disable no-undef */
import React from 'react';
import renderer from 'react-test-renderer';
import {Contributors} from "./Contributors";




describe('Main\Footer\Contributors test', () => {
  it('Main\Footer\Contributors should match snapshot', () => {
    const component = renderer.create(<Contributors/>);
    const tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});
