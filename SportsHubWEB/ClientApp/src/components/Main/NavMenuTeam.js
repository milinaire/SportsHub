import React, {Component, Fragment} from "react";
import {NavLink} from "react-router-dom";
import "./NavMenuCategory.css";

export class Team extends Component {
    state = {
        isOpenSubcategory: false,
    };

    render() {
        return (
            <div className="dropdown-content-team">
                <ul className="categories">
                    {this.props.teams.map((team) => (
                        <NavLink to={`/${team.url}`}>
                            <li className={"team"}>{team.title}</li>
                        </NavLink>
                    ))}
                </ul>
            </div>
        )
    }
}