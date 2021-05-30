import React from 'react';
import ReactDOM from 'react-dom';
import {MemoryRouter} from 'react-router-dom';

import renderer from 'react-test-renderer';
import MainArticle from "./MainArticle";

describe('my beverage', () => {
  const Props = {
    categories: [],
    article: {imageUri:'1'},
    setCurrentArticle: () => {
    }
  }
  test('renders without crashing', async () => {
    const div = document.createElement('div');
    ReactDOM.render(
      <MemoryRouter>
        <MainArticle   {...Props}/>
      </MemoryRouter>, div);

  })
  test('', () => {
    const tree = renderer
      .create(<MainArticle  {...Props}/>)
      .toJSON();
    expect(tree).toMatchSnapshot();
  })
})