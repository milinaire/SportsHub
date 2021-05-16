import {
  SET_BANNERS,
  ADD_NEW_BANNER,
  UPDATE_NEW_BANNER,
  GET_BANNERS,
  ADD_NEW_BANNER_IMG,
  SELECT_BANNER,
  UPDATE_BANNER_LOCALIZATION,
  ADD_BANNER_LOCALIZATION,
  UPDATE_BANNER_LOCALIZATION_HEADLINE,
  SET_BANNERS_STATUS,
  CLOSE_NEW_BANNER,
  SET_NEW_BANNER_CATEGORY,
  DELETE_BANNER_LOCALIZATION
} from './sideBarActions'

let initialState = {
  banners: [],
  newBanner: null,
  selectedBanner: null,
  isOpened: true
}
const sideBarReducer = (state = initialState, action) => {

  switch (action.type) {

    case SET_BANNERS:
      return {...state, banners: action.banners};
    case CLOSE_NEW_BANNER:
      return {...state, newBanner: null};
    case SET_NEW_BANNER_CATEGORY:
      return {...state, newBanner:{...state.newBanner, categoryId:action.category}};
    case SET_BANNERS_STATUS:
      return {...state, isOpened: action.status};
    case SELECT_BANNER:
      return {...state, selectedBanner: !state.newBanner?action.banner:null};
    case GET_BANNERS:

      return {...state, banners: action.payload, selectedBanner: null, newBanner: null};
    case ADD_NEW_BANNER:
      return {
        ...state, selectedBanner: null, isOpened: true, newBanner: {
          categoryId: action.category, isPublished: false,
          isClosed: false, imageId: 6, file: '', imagePreviewUrl: '',
          localization: [{languageId: action.language, headline: 'New Banner Name'},]
        }
      };
    case DELETE_BANNER_LOCALIZATION:
console.log([...state.newBanner.localization.slice(0,action.index), ...state.newBanner.localization.slice(action.index+1)])
      return {

        ...state, newBanner: {
          ...state.newBanner, localization: [...state.newBanner.localization.slice(0,action.index), ...state.newBanner.localization.slice(action.index+1)]

        }
      };
    case UPDATE_BANNER_LOCALIZATION:

      return {

        ...state, newBanner: {
          ...state.newBanner, localization: state.newBanner.localization.map((l, index) => {
            if (index === action.index) {
              return {languageId: action.languageId, headline: l.headline}
            } else {
              return l
            }
          })
        }
      };
    case UPDATE_BANNER_LOCALIZATION_HEADLINE:

      return {

        ...state, newBanner: {
          ...state.newBanner, localization: state.newBanner.localization.map((l, index) => {
            if (index === action.index) {
              return {languageId: l.languageId, headline: action.headline}
            } else {
              return l
            }
          })
        }
      };
    case ADD_BANNER_LOCALIZATION:

      return {

        ...state, newBanner: {
          ...state.newBanner,
          localization: [...state.newBanner.localization, {languageId:action.id, headline: 'New Banner Name'}]
        }
      };
    case ADD_NEW_BANNER_IMG:
      return {
        ...state, newBanner: {...state.newBanner, file: action.file, imagePreviewUrl: action.imagePreviewUrl}
      };
    case UPDATE_NEW_BANNER:
      return {...state, newBanner: action.newBanner};
    default:
      return state;
  }
}
export default sideBarReducer;