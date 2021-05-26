
// Auto-generated do not edit


/* eslint-disable import/no-extraneous-dependencies */
/* eslint-disable no-undef */
import React from 'react';
import renderer from 'react-test-renderer';
import {CompanyInfo} from "./CompanyInfo";



describe('Main\Footer\CompanyInfo test', () => {
  it('Main\Footer\CompanyInfo should match snapshot', () => {
    const component = renderer.create(<CompanyInfo
       />);
    const tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});
