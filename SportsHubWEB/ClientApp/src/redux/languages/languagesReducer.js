import {
  SET_LANGUAGES, SET_CURRENT_LANGUAGE,
  SET_IS_LOADING, SET_IS_MODAL_OPEN, SET_NEW_LANGUAGES,
} from './languageActions'
import {supportedLngs} from "../../supportedLngs";

let initialState = {
  supportedLngs,
  languages: [],
  isLoading: false,
  currentLanguage: {id: 1, value: 'en', label: 'English'},
  isModalOpen: false,

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