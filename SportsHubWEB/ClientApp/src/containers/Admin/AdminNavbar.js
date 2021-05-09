import React, {Component, Fragment} from "react";
import {NavLink} from "react-router-dom";

export class AdminNavMenu extends Component {
  render() {
    return (
      <Fragment>
        <div className="admin-nav-menu">
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/surveys">
              <div className="admin-nav-menu-item">
                Surveys
              </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/banners">
            <div className="admin-nav-menu-item">
              Banners
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/languages">
            <div className="admin-nav-menu-item">
              Languages
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/footer">
            <div className="admin-nav-menu-item">
              Footer
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/social_networks">
            <div className="admin-nav-menu-item">
              Social Networks
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/users">
            <div className="admin-nav-menu-item">
              Users
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/information_architecture">
            <div className="admin-nav-menu-item">
              IA
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/teams">
            <div className="admin-nav-menu-item">
              Teams
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/news_partners">
            <div className="admin-nav-menu-item">
              News Partners
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/advertising">
            <div className="admin-nav-menu-item">
              Advertising
            </div>
          </NavLink>
        </div>
      </Fragment>
    )
  }
}