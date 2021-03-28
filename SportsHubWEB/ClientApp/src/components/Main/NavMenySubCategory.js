import React, { Component, Fragment } from "react";
import { NavLink } from "react-router-dom";
import "./NavMenuCategory.css";
import { Team } from "./NavMenuTeam";

export class SubCategory extends Component {
  state = {
    isOpenSubcategory: false,
  };

  render() {
    return (
      <div className="dropdown-content">
        <ul className="subcategories">
          {this.props.subcategories.map((category) => (
            <NavLink
              className="not-active"
              activeClassName={"active-subcategory"}
              to={`${this.props.url}/${category.url}`}
            >
              <li className={"subcategory"}>
                {category.teams.length ? (
                  <Team
                    curl={this.props.url}
                    surl={category.url}
                    teams={category.teams}
                  />
                ) : null}
                {category.title}
              </li>
            </NavLink>
          ))}
        </ul>
      </div>
    );
  }
}
