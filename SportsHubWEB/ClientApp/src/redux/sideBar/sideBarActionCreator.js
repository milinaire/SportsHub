import {
  SET_BANNERS,
  ADD_NEW_BANNER,
  UPDATE_NEW_BANNER, GET_BANNERS
} from "./sideBarActions";

export const setBanners = (banners) => ({type: SET_BANNERS, banners})
export const addNewBanner = (category, language) => ({type: ADD_NEW_BANNER, category, language})
export const updateNewBanner = (newBanner) => ({type: SET_BANNERS, newBanner})
export const getBanners = () => {
  return async dispatch=>{
    const response = await fetch('/banner')
    const json = await response.json()
    dispatch({type:GET_BANNERS, payload:json})
  }
}
export const publishBanner = (banner) => {
  return async dispatch=>{
    const publishBanner = {
      method: 'PUT',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({
        isPublished: true,
        isClosed: false
      })
    };

    await fetch(`/banner/${banner.bannerId}`, publishBanner)
    getBanners()
  }
}
export const closeBanner = (banner) => {
  return async dispatch=>{
    const closeBanner = {
      method: 'PUT',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({
        isClosed: true
      })
    };

    await fetch(`/banner/${banner.bannerId}`, closeBanner)
    getBanners()
  }
}
// export const addNewBanner = () => {
//   return async dispatch=>{
//     const closeBanner = {
//       method: 'POST',
//       headers: {'Content-Type': 'application/json'},
//       body: JSON.stringify({
//
//       })
//     };
//
//     await fetch(`/banner`, closeBanner)
//
//   }
// }


