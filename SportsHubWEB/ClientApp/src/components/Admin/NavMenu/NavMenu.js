import React, {Fragment} from "react";
import {NavLink} from "react-router-dom";
import {RiChatCheckLine} from "react-icons/ri";
import {MdLanguage} from "react-icons/md";
import {RiLayoutBottomLine} from "react-icons/ri";
import {MdShare} from "react-icons/md";
import {FaUserFriends} from "react-icons/fa";
import {CgMenuBoxed} from "react-icons/cg";
import {RiDashboardLine} from "react-icons/ri";
import {RiTeamLine} from "react-icons/ri";
import {BiBriefcase} from "react-icons/bi";
import {RiAdvertisementLine} from "react-icons/ri";

import "./AdminNavbar.css";

const NavMenu = () => {

  return (
    <Fragment>
      <div className="admin-nav-menu">
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/surveys">
          <div className="admin-nav-menu-item">
            <RiChatCheckLine className="navIcon"/>
          </div>
        </NavLink>
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/banners">
          <div className="admin-nav-menu-item">
            <CgMenuBoxed className="navIcon"/>
          </div>
        </NavLink>
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/languages">
          <div className="admin-nav-menu-item">
            <MdLanguage className="navIcon"/>
          </div>
        </NavLink>
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/footer">
          <div className="admin-nav-menu-item">
            <RiLayoutBottomLine className="navIcon"/>
          </div>
        </NavLink>
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/social_networks">
          <div className="admin-nav-menu-item">
            <MdShare className="navIcon"/>
          </div>
        </NavLink>
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/users">
          <div className="admin-nav-menu-item">
            <FaUserFriends className="navIcon"/>
          </div>
        </NavLink>
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/information_architecture">
          <div className="admin-nav-menu-item">
            <RiDashboardLine className="navIcon"/>
          </div>
        </NavLink>
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/teams">
          <div className="admin-nav-menu-item">
            <RiTeamLine className="navIcon"/>
          </div>
        </NavLink>
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/news_partners">
          <div className="admin-nav-menu-item">
            <BiBriefcase className="navIcon"/>
          </div>
        </NavLink>
        <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active"
                 to="/admin/advertising">
          <div className="admin-nav-menu-item">
            <RiAdvertisementLine className="navIcon"/>
          </div>
        </NavLink>
      </div>
    </Fragment>
  )
}
export default NavMenu