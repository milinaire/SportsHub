import {SET_CURRENT_LANGUAGE, SET_LANGUAGES} from "./languageActions";

export const setCurrentLanguage = (id) => ({type: SET_CURRENT_LANGUAGE, id})
export const setLanguages = (languages) => ({type: SET_LANGUAGES, languages})
