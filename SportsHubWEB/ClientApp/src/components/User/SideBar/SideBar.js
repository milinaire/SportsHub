import React, {Fragment} from "react";
import style from './SideBar.module.css'
import Banner from "./Banner";

const SideBar = (props) => {
  return (
    <Fragment>
      <div className={style.sideBarWrapper}>
      {props.banners.banners&&props.banners.banners.map(banner=>(
        banner.isPublished?<Banner headline={banner.headline}
                category={''}
                image={banner.imageUri} key={banner.bannerId}/>:null
        )
      )}
    </div>
    </Fragment>
  );
}
export default SideBar;

