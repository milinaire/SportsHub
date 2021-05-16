import React, {Fragment} from 'react'
import {Link} from "react-router-dom";
import {FormControl, NavDropdown} from "react-bootstrap";
import style from './Header.module.css'
import {FaTwitter, FaGoogle, FaFacebookF} from "react-icons/fa"
import {AiOutlineSwap} from 'react-icons/ai'
import Select from "react-select";
import {withRouter} from "react-router";

const Header = (props) => {
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
            placeholder="Search By"
            className={style.searchField}
          />
        </div>
        <div className={style.share}>
          <p className={style.shareText}>Share</p>
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
            <Link className={style.navbarAdminButton} to={props.match.url==='/'?`/admin`:'/'}>
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
              <p className={style.navbarUserInfoRole}>Administrator</p>
            </div>
            <div className={style.navbarUserDropdown}>
              <NavDropdown id="userDropdown" title={''}>
                <div className={style.navbarUserDropdownInfo}>
                  <p className={style.navbarUserDropdownInfoName}>Ivan Baloh</p>
                  <p className={style.navbarUserDropdownInfoEmail}>ivanbaloh@gmail.com</p>
                </div>
                <NavDropdown.Item href="#action3">Action</NavDropdown.Item>
                <NavDropdown.Item href="#action4">Another action</NavDropdown.Item>
                <NavDropdown.Item href="#action3">Action</NavDropdown.Item>
                <NavDropdown.Item href="#action4">Another action</NavDropdown.Item>
                <NavDropdown.Divider/>
                <NavDropdown.Item href="#action5">Something else here</NavDropdown.Item>
              </NavDropdown>
            </div>
          </div>
          <div className={style.navbarLanguage}>
            <Select
              styles={{width:'100%'}}
              single
              options={props.language.languages.map(language => ({value: language.id, label: language.languageName}))}
              onChange={(language) => props.setCurrentLanguage(language.value)}
              value={{value: props.language.currentLanguage.id, label: props.language.currentLanguage.languageName}}
            />
          </div>
        </div>
      </header>
    </Fragment>
  )
}
export default withRouter(Header);