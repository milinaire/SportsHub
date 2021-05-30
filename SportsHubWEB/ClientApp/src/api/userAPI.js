import {instance} from "./instance";
export const userAPI = {
  getUser() {
    return instance.get(`/connect/userinfo`)
  }
}