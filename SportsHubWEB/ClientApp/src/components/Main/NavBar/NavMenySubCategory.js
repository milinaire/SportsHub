import React, { Component } from "react";
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
              key={category.id}
              className="not-active"
              activeClassName={"active-subcategory"}
              to={`/nav/${this.props.url}/${category.id}`}
            >
              <li className={"subcategory"}>
                {category.teams.length ? (
                  <Team
                    curl={this.props.url}
                    surl={category.id}
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
