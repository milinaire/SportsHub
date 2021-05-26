import React from 'react';
import ReactDOM from 'react-dom';
import {MemoryRouter} from 'react-router-dom';

import renderer from 'react-test-renderer';
import Article from "./Article";


describe('my beverage', () => {
  const props = {
    mainArticles:{mainArticles:[]}
  }
  test('renders without crashing', async () => {
    const div = document.createElement('div');
    ReactDOM.render(
      <MemoryRouter>
        <Article {...props}/>
      </MemoryRouter>, div);

  })
  test('',()=>{
    const tree = renderer
      .create(<Article {...props}/>)
      .toJSON();
    expect(tree).toMatchSnapshot();
  })
})