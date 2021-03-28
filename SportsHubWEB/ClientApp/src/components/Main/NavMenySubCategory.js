import React, {Component, Fragment} from "react";
import {NavLink} from "react-router-dom";
import "./NavMenuCategory.css";
import {Team} from "./NavMenuTeam";

export class SubCategory extends Component {
    state = {
        isOpenSubcategory: false,
    };

    render() {
        return (
            <div className="dropdown-content">
                <ul className="categories">
                    {this.props.subcategories.map((category) => (
                        <NavLink to={`${this.props.url}/${category.url}`}>
                            <li className={"subcategory"}>
                                <Team teams={category.teams}/>
                                {category.title}</li>
                        </NavLink>
                    ))}
                </ul>
            </div>
        )
    }
}