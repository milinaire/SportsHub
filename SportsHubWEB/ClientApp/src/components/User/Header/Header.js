import React, {Fragment} from 'react'
import {Link} from "react-router-dom";
import {FormControl, NavDropdown} from "react-bootstrap";
import style from './Header.module.css'
import {FaTwitter, FaGoogle, FaFacebookF} from "react-icons/fa"
import {AiOutlineSwap} from 'react-icons/ai'
import Select from "react-select";
import {withRouter} from "react-router";
import '../../../i18n.js'
import {withAlert} from 'react-alert'
import {useTranslation} from "react-i18next";

const Header = (props) => {
  const {t} = useTranslation();
  return (
    <Fragment>
      <header className={style.stickyTopHeader}>
        <div className={style.logo}>
          <Link to="/" className={style.logoLink}>
            <p className={style.logoLinkText}>Sports Hub</p>
          </Link>
        </div>
        <div className={style.search}>
          <FormControl
            type="text"
            placeholder={t("Header/Search")}
            className={style.searchField}
          />
        </div>
        <div className={style.share}>
          <p className={style.shareText}>{t("Header/Share")}</p>
          <button>
            <FaFacebookF/>
          </button>
          <button>
            <FaTwitter/>
          </button>
          <button>
            <FaGoogle/>
          </button>
        </div>
        <div className={style.navbar}>
          <div className={style.navbarAdmin}>
            <Link className={style.navbarAdminButton} to={props.match.url === '/' ? `/admin` : '/'}>
              <AiOutlineSwap/>
            </Link>
          </div>
          <div className={style.navbarUser}>
            <div className={style.navbarUserAvatar}>
              <img className={style.navbarUserAvatarImg}
                   src="https://widgetwhats.com/app/uploads/2019/11/free-profile-photo-whatsapp-4.png" alt="avatar"/>
            </div>
            <div className={style.navbarUserInfo}>
              <p className={style.navbarUserInfoName}>Ivan Baloh</p>
              <p className={style.navbarUserInfoRole}>{t("Header/Administrator")}</p>
            </div>
          </div>
          <div className={style.navbarLanguage}>
            {props.languageReducer.isLoading
              ? 'Loading...'
              : <Select
                styles={{width: '100%'}}
                single
                options={props.languageReducer.languages}
                onChange={({value}) => props.setCurrentLanguage(value)}
                value={props.languageReducer.currentLanguage}
              />}
          </div>
        </div>
      </header>
    </Fragment>
  )
}
export default withAlert()(withRouter(Header));