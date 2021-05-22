import {
  SET_LANGUAGES, SET_CURRENT_LANGUAGE,
  SET_IS_LOADING, SET_IS_MODAL_OPEN, SET_NEW_LANGUAGES, SET_IS_INITIALIZING,
} from './languageActions'
import {supportedLngs} from "../../supportedLngs";

let initialState = {
  supportedLngs,
  languages: [],
  isLoading: false,
  currentLanguage: {},
  isModalOpen: false,
  isInitializing: true,
  newLanguages: null,
  changingLanguage: null,
}

const languageReducer = (state = initialState, action) => {

  switch (action.type) {
    case SET_LANGUAGES:
      return {
        ...state, languages: action.payload.map(language => ({
          id: language.id,
          value: language.languageName,
          label: state.supportedLngs.find(l => l.value === language.languageName).label
        }))
      };
    case SET_IS_LOADING:
      return {...state, isLoading: action.payload};
    case SET_IS_INITIALIZING:
      return {...state, isInitializing: action.payload};
    case SET_CURRENT_LANGUAGE:

      return {
        ...state,
        currentLanguage: state.languages.find(l => l.value === action.payload)
      };
    case SET_IS_MODAL_OPEN:
      return {...state, isModalOpen: action.payload};
    case SET_NEW_LANGUAGES:
      return {...state, newLanguages: action.payload};
    default:
      return state;
  }
}
export default languageReducer;