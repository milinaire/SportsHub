
// Auto-generated do not edit


/* eslint-disable import/no-extraneous-dependencies */
/* eslint-disable no-undef */
import React from 'react';
import renderer from 'react-test-renderer';
import {ContactUs} from "./ContactUs";



describe('Main\Footer\ContactUs test', () => {
  it('Main\Footer\ContactUs should match snapshot', () => {
    const component = renderer.create(<ContactUs/>);
    const tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});
