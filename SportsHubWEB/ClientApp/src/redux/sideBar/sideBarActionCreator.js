import {
  SET_BANNERS,
  ADD_NEW_BANNER,
  UPDATE_NEW_BANNER, GET_BANNERS, ADD_NEW_BANNER_IMG
} from "./sideBarActions";
import axios from "axios";

export const setBanners = (banners) => ({type: SET_BANNERS, banners})
export const addNewBanner = (category, language) => ({type: ADD_NEW_BANNER, category, language})
export const addNewBannerImg = (file, imagePreviewUrl) => ({type: ADD_NEW_BANNER_IMG, file, imagePreviewUrl})
export const updateNewBanner = (newBanner) => ({type: SET_BANNERS, newBanner})
export const getBanners = () => {
  return async dispatch => {
    const response = await fetch('/banner')
    const json = await response.json()
    dispatch({type: GET_BANNERS, payload: json})
  }
}
export const publishBanner = (banner) => {
  return async dispatch => {
    const publishBanner = {
      method: 'PUT',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({
        isPublished: true,
        isClosed: false
      })
    };

    await fetch(`/banner/${banner.bannerId}`, publishBanner)
    const response = await fetch('/banner')
    const json = await response.json()
    dispatch({type: GET_BANNERS, payload: json})
  }
}
export const closeBanner = (banner) => {
  return async dispatch => {
    const closeBanner = {
      method: 'PUT',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({
        isClosed: true
      })
    };

    await fetch(`/banner/${banner.bannerId}`, closeBanner)
    const response = await fetch('/banner')
    const json = await response.json()
    dispatch({type: GET_BANNERS, payload: json})
  }
}
export const postNewBanner = (newBanner) => {
  return async dispatch => {
    let formData = new FormData();
    formData.append("file", newBanner.file);

    let imgResponse
    const img = await axios.post("/image", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    }).then(response => imgResponse = response.data);

    console.log('img', imgResponse)


    const postBanner = {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({
        isPublished: newBanner.isPublished,
        isClosed: newBanner.isClosed,
        categoryId: newBanner.categoryId,
        imageId: imgResponse.ImageId
      })
    };
    console.log('postBanner', postBanner)
    const response = await fetch(`/banner`, postBanner)
    const json = await response.json()
    console.log(json.bannerId)

    const id = json.bannerId

    for (let i = 0; i < newBanner.localization.length; i++) {

      const localizationBanner = {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({
          bannerId: id,
          languageId: newBanner.localization[i].languageId,
          headline: newBanner.localization[i].headline,
        })
      };
      await fetch(`/banner/localization`, localizationBanner)

      const response = await fetch('/banner')
      const json = await response.json()
      dispatch({type: GET_BANNERS, payload: json})
    }
  }
}


