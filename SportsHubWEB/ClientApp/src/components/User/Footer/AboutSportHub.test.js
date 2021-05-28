
// Auto-generated do not edit


/* eslint-disable import/no-extraneous-dependencies */
/* eslint-disable no-undef */
import React from 'react';
import renderer from 'react-test-renderer';
import {AboutSportHub} from "./AboutSportHub";




describe('Main\Footer\AboutSportHub test', () => {
  it('Main\Footer\AboutSportHub should match snapshot', () => {
    const component = renderer.create(<AboutSportHub/>);
    const tree = component.toJSON();
    expect(tree).toMatchSnapshot();
  });
});
