import {
  CLEAR_BREAKDOWN,
  SET_BREAKDOWN
} from "./breakdownActions";

export const setBreakdown = (articles, name) => ({type: SET_BREAKDOWN, articles, name})
export const clearBreakdown = () => ({type: CLEAR_BREAKDOWN})



