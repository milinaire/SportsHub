import React from "react";
import {addNewBanner} from "../../../redux/sideBar/sideBarActionCreator";


let Banners = (props) => {
  let _handleImageChange = (e) => {
    e.preventDefault();
    console.log('handle work')
    let reader = new FileReader();
    if(!e.target.files){
      return
    }
    let file = e.target.files[e.target.files.length-1];

    reader.onloadend = () => {
      props.addNewBannerImg(
        file,
        reader.result
      );
    }

    reader.readAsDataURL(file)
  }
  let imagePreviewUrl = props.banners.newBanner ? props.banners.newBanner.imagePreviewUrl : null;
  let $imagePreview = null;
  if (imagePreviewUrl) {
    $imagePreview = (<img alt="" className="imgPreview" src={imagePreviewUrl}/>);
  } else {
    $imagePreview = (
      <div className="previewText"><p><span style={{color: "red"}}>+Add picture </span>or drop it right here</p><p>You
        can add next formats: png. jpg. jpeg. tif</p></div>);
  }
  return (
    <div>
      Banners

      <label className="customPhotoupload">
        <div className="imgPreview">
          {$imagePreview}
        </div>
        <input className="fileInput"
               type="file"
               onLoad={_handleImageChange}
               onChange={_handleImageChange}/>
      </label>


      {console.log(props)}
      <button onClick={() => props.addNewBanner(props.categories[0].id, props.language.currentLanguage.id)}>add</button>
      <button onClick={() => props.postNewBanner(props.banners.newBanner)}>post</button>
      {props.banners.banners.map(banner => (
        <div>
          <button onClick={() => props.publishBanner(banner)}>publish</button>
          <button onClick={() => props.closeBanner(banner)}>close</button>
        </div>
      ))}
      <select value={"грейпфрут"} onChange={() => {
      }}>
        <option value="грейпфрут">Грейпфрут</option>
        <option value="лайм">Лайм</option>
        <option value="кокос">Кокос</option>
        <option value="манго">Манго</option>
      </select>
    </div>
  )
}


export default Banners;