import React from 'react';
import ReactDOM from 'react-dom';
import {MemoryRouter} from 'react-router-dom';

import renderer from 'react-test-renderer';
import Surveys from "./Surveys";


describe('my beverage', () => {
  const props = {
    mainArticles:{mainArticles:[]}
  }
  test('renders without crashing', async () => {
    const div = document.createElement('div');
    ReactDOM.render(
      <MemoryRouter>
        <Surveys {...props}/>
      </MemoryRouter>, div);

  })
  test('',()=>{
    const tree = renderer
      .create(<Surveys {...props}/>)
      .toJSON();
    expect(tree).toMatchSnapshot();
  })
})