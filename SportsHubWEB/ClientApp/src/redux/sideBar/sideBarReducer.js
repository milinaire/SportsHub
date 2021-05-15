import {
SET_BANNERS
} from './sideBarActions'

let initialState = {
  banners:[],

}
const sideBarReducer = (state = initialState, action) => {

  switch (action.type) {

    case SET_BANNERS:
      return {...state, banners: action.banners};
    default:
      return state;
  }
}
export default sideBarReducer;