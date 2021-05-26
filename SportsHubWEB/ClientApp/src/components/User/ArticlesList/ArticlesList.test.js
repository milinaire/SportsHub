import React from 'react';
import ReactDOM from 'react-dom';
import {MemoryRouter} from 'react-router-dom';
import renderer from 'react-test-renderer';
import ArticlesList from "./ArticlesList";

describe('my beverage', () => {
  const props={
    articles:[]
  }
  test('renders without crashing', async () => {
    const div = document.createElement('div');
    ReactDOM.render(
      <MemoryRouter>
        <ArticlesList {...props}/>
      </MemoryRouter>, div);

  })
  test('',()=>{
    const tree = renderer
      .create(<ArticlesList{...props}/>)
      .toJSON();
    expect(tree).toMatchSnapshot();
  })
})