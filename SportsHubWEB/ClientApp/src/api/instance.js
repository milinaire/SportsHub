import axios from "axios";

export const instance = axios.create({
  //headers: {Authorization: `Bearer ${JSON.parse(localStorage.getItem('SportsHubWEBuser:https://localhost:5001:SportsHubWEB')).access_token}`}
})
