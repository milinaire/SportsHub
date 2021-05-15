import React from "react";
import style from './SideBar.module.css'

const Banner = (props) => {
  return (
    <div className={style.bannerWrapper}>
      <div className={style.bannerBackground} style={{backgroundImage: `url(${props.image})`}}>
        {props.category && <div className={style.bannerCategory}>
          {props.category}
        </div>}
        {props.headline && <div className={style.bannerHeadline}>
          {props.headline}
        </div>}
      </div>

    </div>
  )
}
export default Banner;