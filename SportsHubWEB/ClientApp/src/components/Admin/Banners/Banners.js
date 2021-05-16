import React from "react";
import {addNewBanner} from "../../../redux/sideBar/sideBarActionCreator";


let Banners = (props) => {
  return (
    <div>
      Banners
      {console.log(props)}
      <button onClick={()=>props.addNewBanner(props.categories[0].id, props.language.currentLanguage.id)}>add</button>
      {props.banners.banners.map(banner=>(
        <div>
          <button onClick={()=>props.publishBanner(banner)}>publish</button>
          <button onClick={()=>props.closeBanner(banner)}>close</button>
        </div>
      ))}
    </div>
  )
}


export default Banners;