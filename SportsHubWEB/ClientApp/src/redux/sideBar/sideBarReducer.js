import {
  SET_BANNERS,
  ADD_NEW_BANNER,
  UPDATE_NEW_BANNER, GET_BANNERS
} from './sideBarActions'

let initialState = {
  banners:[],
  newBanner:null
}
const sideBarReducer = (state = initialState, action) => {

  switch (action.type) {

    case SET_BANNERS:
      return {...state, banners: action.banners};
    case GET_BANNERS:
      return {...state, banners: action.payload};
    case ADD_NEW_BANNER:
      return {...state, newBanner: {categoryId: action.category, isPublished:false, isClosed:false,
          localization:[{languageId:action.language, headline:'New Banner Name'},] }};
    case UPDATE_NEW_BANNER:
      return {...state, newBanner: action.newBanner};
    default:
      return state;
  }
}
export default sideBarReducer;