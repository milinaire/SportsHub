
// Auto-generated do not edit


/* eslint-disable import/no-extraneous-dependencies */
/* eslint-disable no-undef */
import React from 'react';
import renderer from 'react-test-renderer';
import {Privacy} from "./Privacy";



describe('Main\Footer\Privacy test', () => {
  it('Main\Footer\Privacy should match snapshot', () => {
    const component = renderer.create(<Privacy/>);
    const tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});
