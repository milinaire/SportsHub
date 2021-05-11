import React, {Component, Fragment} from "react";
import {NavLink} from "react-router-dom";

export class AdminNavMenu extends Component {
  render() {
    return (
      <Fragment>
        <div className="admin-nav-menu">
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/surveys">
              <div className="admin-nav-menu-item">
                <b>Surveys</b>
              </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/banners">
            <div className="admin-nav-menu-item">
              <b>Banners</b>
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/languages">
            <div className="admin-nav-menu-item">
              <b>Languages</b>
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/footer">
            <div className="admin-nav-menu-item">
              <b>Footer</b>
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/social_networks">
            <div className="admin-nav-menu-item">
              <b>Social Networks</b>
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/users">
            <div className="admin-nav-menu-item">
              <b>Users</b>
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/information_architecture">
            <div className="admin-nav-menu-item">
              <b>IA</b>
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/teams">
            <div className="admin-nav-menu-item">
              <b>Teams</b>
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/news_partners">
            <div className="admin-nav-menu-item">
              <b>News Partners</b>
            </div>
          </NavLink>
          <NavLink className="admin-nav-menu-item-not-active" activeClassName="admin-nav-menu-item-active" to="/admin/advertising">
            <div className="admin-nav-menu-item">
              <b>Advertising</b>
            </div>
          </NavLink>
        </div>
      </Fragment>
    )
  }
}