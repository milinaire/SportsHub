import React from 'react';
import ReactDOM from 'react-dom';
import {MemoryRouter} from 'react-router-dom';

import renderer from 'react-test-renderer';
import {UpFooterPart} from "./UpFooterPart";


describe('my beverage', () => {

  test('renders without crashing', async () => {
    const div = document.createElement('div');
    ReactDOM.render(
      <MemoryRouter>
        <UpFooterPart  />
      </MemoryRouter>, div);

  })

})