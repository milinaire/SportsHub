import {SET_LANGUAGES, SET_CURRENT_LANGUAGE} from './languageActions'

let initialState = {
  isLoading: false,
  currentLanguage: {id: 1, languageName: 'en'},
  languages: [
    {id: 1, languageName: 'en'},

  ]
}

const languageReducer = (state = initialState, action) => {

  switch (action.type) {
    case SET_CURRENT_LANGUAGE:
      return {
        ...state,
        currentLanguage: {id: action.id, languageName: state.languages.find(l => l.id === action.id).languageName}
      };
    case SET_LANGUAGES:
      return {...state, languages: action.languages};
    default:
      return state;
  }
}
export default languageReducer;