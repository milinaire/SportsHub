import {
  SET_CATEGORIES,
  POST_CATEGORY,
  SET_CONFERENCES,
  SET_TEAMS,
  SET_HOVERED_CONFERENCE,
  SET_HOVERED_CATEGORY
} from "./navigationActions";

export const setCategories = (categories) => ({type: SET_CATEGORIES, categories})
export const setConferences = (conferences) => ({type: SET_CONFERENCES, conferences})
export const setTeams = (teams) => ({type: SET_TEAMS, teams})
export const setHoveredCategory = (id) => ({type: SET_HOVERED_CATEGORY, id})
export const setHoveredConference = (id) => ({type: SET_HOVERED_CONFERENCE, id})
export const addCategory = (category) => ({type: POST_CATEGORY, category})

