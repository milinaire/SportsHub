import React from "react";
import {addNewBanner, selectBanner} from "../../../redux/sideBar/sideBarActionCreator";
import style from "./Banner.module.css"
import Tabs from "../../../containers/Admin/Pages/Tabs";

const OpenedBanner = (props) => {
  return (
    <div onClick={() => props.selectBanner(props.banner)} className={style.eachBanner}>
      <div className={style.bannerName}>
        {props.banner.headline}
      </div>
      <div className={style.bannerStatus}>
        <select onChange={(e) => {
          if (e.target.value === 'publish') {
            props.publishBanner(props.banner, props.language.currentLanguage.id)
          } else {
            props.closeBanner(props.banner, props.language.currentLanguage.id)
          }
        }} value={props.banner.isPublished ? 2 : 1}>
          <option style={{display: 'none'}} value={1}>Not published</option>

          <option style={{display: 'none'}} value={2}>Published</option>
          <option style={{display: props.banner.isPublished ? 'none' : ''}} value={'publish'}>Publish</option>
          <option style={{display: !props.banner.isPublished ? 'none' : ''}} value={'close'}>Close</option>
        </select>
      </div>
      <div className={style.bannerCategory}>
        <select
          onChange={e => props.changeBannerCategory(props.banner, props.language.currentLanguage.id, e.target.value)}
          value={props.banner.categoryId}>
          {props.categories.map(c => (
            <option value={c.id}>{c.name}</option>
          ))}
        </select>
      </div>
    </div>
  )
}
const ClosedBanner = (props) => {
  return (
    <div onClick={() => props.selectBanner(props.banner)} className={style.eachBanner}>
      <div className={style.bannerName}>
        {props.banner.headline}
      </div>
      <div className={style.bannerStatus}>
        CLOSED
      </div>
      <div className={style.bannerCategory}>
        {props.categories.find(c => c.id === props.banner.categoryId).name}
        <button onClick={()=>props.deleteBanner(props.banner, props.language.currentLanguage.id)}>delete</button>
      </div>
    </div>
  )
}
let Banners = (props) => {
  props.setCurrentAdminButtonPanel(
    (!props.banners.newBanner
      ?
      <button className={style.addBTN}
        onClick={() => props.addNewBanner(props.categories[0].id, props.language.currentLanguage.id)}>
        Add
        new banner
      </button>
      : <><button className={style.closeBTN} onClick={()=>props.closeNewBanner()}><b>Close</b></button> <button className={style.addBTN}
        onClick={() => props.postNewBanner(props.banners.newBanner, props.language.currentLanguage.id)}>Save
      </button></>)
  )
  let _handleImageChange = (e) => {
    e.preventDefault();
    console.log('handle work')
    let reader = new FileReader();
    if (!e.target.files) {
      return
    }
    let file = e.target.files[e.target.files.length - 1];
    reader.onloadend = () => {
      props.addNewBannerImg(
        file,
        reader.result
      );
    }
    reader.readAsDataURL(file)
  }
  return (
    <div className={style.bannerWrapper}>
      <div className={style.bannerBanners}>
        <div>
          <button className={props.banners.isOpened ? style.activeStatusBTN : style.statusBTN}
                  onClick={() => props.setBannersStatus(true)}>
            OPEN ({props.banners.banners.filter(b => !b.isClosed).length})
          </button>
          <button className={!props.banners.isOpened ? style.activeStatusBTN : style.statusBTN}
                  onClick={() => props.setBannersStatus(false)}>
            CLOSED ({props.banners.banners.filter(b => b.isClosed).length})
          </button>
        </div>
        <div className={style.bannersHead}>
          <div className={style.bannerName}>
            <b>BANNER NAME</b>
          </div>
          <div className={style.bannerStatus}>
            <b>STATUS</b>
          </div>
          <div className={style.bannerCategory}>
            <b>PUBLISHED IN</b>
          </div>
        </div>
        {props.banners.isOpened ? <div>{props.banners.newBanner ? <div onClick={() => props.selectBanner(props.banners.newBanner)} className={style.eachBanner}>
            <div className={style.bannerName}>
              {props.banners.newBanner.localization.map((l, idx)=><span>{l.headline}{props.banners.newBanner.localization.length-1>idx?' / ':''}  </span>)}
            </div>
            <div className={style.bannerStatus}>
              CREATING...
            </div>
            <div className={style.bannerCategory}>
              {/*{props.categories.find(c => c.id === props.banner.categoryId).name}*/}
              <select
                onChange={e => props.setNewBannerCategory(e.target.value)}
                value={props.banners.newBanner.categoryId}>
                {props.categories.map(c => (
                  <option value={c.id}>{c.name}</option>
                ))}
              </select>
              {/* TODO <button onClick={()=>props.closeNewBanner()}>delete</button>*/}
            </div>
          </div> : null}
          {props.banners.banners.map(banner => (
            !banner.isClosed && <OpenedBanner key={banner.bannerId} {...props} banner={banner}/>
          ))}</div>
          : <div>
          {
             props.banners.banners.map(banner => banner.isClosed && <ClosedBanner key={banner.bannerId} {...props} banner={banner}/>
             )
          }</div>}
      </div>
      <div className={style.bannerPre}>
        {props.banners.selectedBanner
          ? <div className={style.selectedBanner}>
            <div className={style.selectedBannerHeadline}>
              {props.banners.selectedBanner.headline}
            </div>
            <img className={style.selectedBannerImg} src={props.banners.selectedBanner.imageUri}/>
          </div>
          : <div>Select banner from list</div>}
        {props.banners.newBanner
          ? <div>{props.banners.newBanner && props.banners.newBanner.imagePreviewUrl ?
            <div style={{height: "200px", width: "200px"}}>
              <img alt="" style={{height: "200px", width: "200px"}}
                   src={props.banners.newBanner.imagePreviewUrl}/>
            </div> :
            (<div>
              <input style={{
                height: "200px",
                width: "200px",
                position: 'absolute',
                top: 'calc(260px + 10%)',
                left: 'calc(75%)'
              }}
                     type="file"
                     onLoad={_handleImageChange}
                     onChange={_handleImageChange}/>
              <div style={{height: "200px", width: "200px"}} className="previewText">
                <p><span style={{color: "red"}}>+Add picture </span>or drop it right here</p>
                <p>You can add next formats: png. jpg. jpeg. tif</p>
              </div>
            </div>)
          }
            <div>
              <Tabs {...props} addTab={props.addBannerLocalization}>
                {props.banners.newBanner.localization.map((localization, index) => (
                  <div label={index}>
                    <div className={style.bannerLocal}>
                      <select value={!index?1:props.banners.newBanner.localization[index].languageId} disabled={!index}
                              onChange={(e) => props.updateBannerLocalization(index, Number(e.target.value))
                              }>
                        {props.language.languages.map(language => (
                          <option style={{display:props.banners.newBanner.localization.find(l=>l.languageId===language.id)?'none':''}} value={language.id}>{language.languageName}</option>
                        ))}
                      </select>
                      <input type="text" value={localization.headline} onChange={(e) => {
                        props.updateBannerLocalizationHeadline(index, e.target.value)
                      }}/>
                    </div>
                  </div>
                ))}
              </Tabs>
            </div>
          </div>
          : null}
      </div>
    </div>


  )
}



export default Banners;