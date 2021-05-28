import React from 'react';
import ReactDOM from 'react-dom';
import {MemoryRouter} from 'react-router-dom';
import Banner from "./Banner";
import renderer from 'react-test-renderer';

describe('my beverage', () => {
  test('renders without crashing', async () => {
    const div = document.createElement('div');
    ReactDOM.render(
      <MemoryRouter>
        <Banner/>
      </MemoryRouter>, div);

  })
  test('',()=>{
    const tree = renderer
      .create(<Banner/>)
      .toJSON();
    expect(tree).toMatchSnapshot();
  })
})