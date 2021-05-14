import {combineReducers, createStore} from "redux";
import navigationReducer from "./reducers/navigationReducer";

let reducers = combineReducers(
  {
    navigationReducer
  }
)
let store = createStore(reducers);

export default store;