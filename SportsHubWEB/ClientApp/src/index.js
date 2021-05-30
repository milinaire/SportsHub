import React, {Suspense} from 'react';
import ReactDOM from 'react-dom';
import {BrowserRouter} from 'react-router-dom';
import store from './redux/store';
import {Provider} from "react-redux";
import App from "./App";
import './style.css'
import './i18n.js';
import CustomAlertProvider from "./CustomAlerts/Alert";
import Loader from "./CustomLoader/Loader";
//import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

// TODO add custom loader
ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <Provider store={store}>
      <Suspense fallback={<Loader/>}>
        <CustomAlertProvider>
          <App/>
        </CustomAlertProvider>
      </Suspense>
    </Provider>
  </BrowserRouter>,
  rootElement);


// Uncomment the line above that imports the registerServiceWorker function
// and the line below to register the generated service worker.
// By default create-react-app includes a service worker to improve the
// performance of the application by caching static assets. This service
// worker can interfere with the Identity UI, so it is
// disabled by default when Identity is being used.
//
//registerServiceWorker();

