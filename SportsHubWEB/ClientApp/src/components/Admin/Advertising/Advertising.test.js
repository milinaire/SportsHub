import React from 'react';
import ReactDOM from 'react-dom';
import {MemoryRouter} from 'react-router-dom';

import renderer from 'react-test-renderer';
import Advertising from "./Advertising";


describe('my beverage', () => {
  const props = {
    mainArticles:{mainArticles:[]}
  }
  test('renders without crashing', async () => {
    const div = document.createElement('div');
    ReactDOM.render(
      <MemoryRouter>
        <Advertising {...props}/>
      </MemoryRouter>, div);

  })
  test('',()=>{
    const tree = renderer
      .create(<Advertising {...props}/>)
      .toJSON();
    expect(tree).toMatchSnapshot();
  })
})