import {
  SET_LANGUAGES,
  SET_CURRENT_LANGUAGE,
  ADD_NEW_LANGUAGE,
  CHANGE_NEW_LANGUAGE,
  POST_NEW_LANGUAGE,
  DELETE_LANGUAGE,
  ADD_CHANGE_LANGUAGE,
  CHANGE_LANGUAGE,
  PUT_LANGUAGE,
  GET_LANGUAGES,
  DELETE_NEW_LANGUAGE,
} from './languageActions'

let initialState = {
  isLoading: false,
  currentLanguage: {id: 1, languageName: 'en'},
  languages: [
    {id: 1, languageName: 'en'},
  ],
  newLanguage: null,
  changingLanguage: null,
}

const languageReducer = (state = initialState, action) => {

  switch (action.type) {
    case SET_CURRENT_LANGUAGE:
      return {
        ...state,
        currentLanguage: {id: action.id, languageName: state.languages.find(l => l.id === action.id).languageName}
      };
    case ADD_NEW_LANGUAGE:
      return {
        ...state,
        newLanguage: {languageName: ''}
      };
    case CHANGE_NEW_LANGUAGE:
      return {
        ...state,
        newLanguage: {languageName: action.name}
      };
    case DELETE_NEW_LANGUAGE:
      return {
        ...state,
        newLanguage: null
      };
    case CHANGE_LANGUAGE:
      return {
        ...state,
        changingLanguage: {...state.changingLanguage, languageName: action.name}
      };
    case ADD_CHANGE_LANGUAGE:
      return {
        ...state,
        changingLanguage: {id: action.id, languageName: state.languages.find(l => l.id === action.id).languageName}
      };
    case POST_NEW_LANGUAGE:
      return {
        ...state,
        newLanguage: null
      };
    case SET_LANGUAGES:
      return {...state, languages: action.languages};
    case DELETE_LANGUAGE:
      return {...state, languages: action.payload};
    case PUT_LANGUAGE:
      return {...state, languages: action.payload, changingLanguage: null};
    case GET_LANGUAGES:
      return {...state, languages: action.payload};
    default:
      return state;
  }
}
export default languageReducer;