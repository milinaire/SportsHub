import {
  SET_CATEGORIES,
  POST_CATEGORY,
  SET_CONFERENCES,
  SET_TEAMS,
  SET_IS_TEAMS_OPENED,
  SET_IS_CONFERENCES_OPENED,
  SET_HOVERED_CONFERENCE,
  SET_HOVERED_CATEGORY
} from "./navigationActions";

export const setCategories = (categories) => ({type: SET_CATEGORIES, categories})
export const setConferences = (conferences) => ({type: SET_CONFERENCES, conferences})
export const setTeams = (teams) => ({type: SET_TEAMS, teams})
export const setHoveredCategory = (id) => ({type: SET_HOVERED_CATEGORY, id})
export const setHoveredConference = (id) => ({type: SET_HOVERED_CONFERENCE, id})
export const setIsConferencesOpened = (isConferencesOpened) => ({type: SET_IS_CONFERENCES_OPENED, isConferencesOpened})
export const setIsTeamsOpened = (isTeamsOpened) => ({type: SET_IS_TEAMS_OPENED, isTeamsOpened})
export const addCategory = (category) => ({type: POST_CATEGORY, category})

