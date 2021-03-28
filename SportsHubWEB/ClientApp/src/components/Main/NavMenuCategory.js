import React, { Component, Fragment } from "react";
import { NavLink } from "react-router-dom";
import "./NavMenuCategory.css";
import { SubCategory } from "./NavMenySubCategory";

export class Category extends Component {
  state = {
    isOpenSubcategory: false,
  };

  render() {
    return (
      <Fragment>
        {this.state.isOpenSubcategory ? <div className="modal-full" /> : null}
        <NavLink
          className="not-active"
          to={`${this.props.url}`}
          activeClassName={"active"}
        >
          <li
            onMouseEnter={() => {
              if (this.props.subcategories.length > 0) {
                this.setState({ isOpenSubcategory: true });
              }
            }}
            onMouseLeave={() => {
              this.setState({ isOpenSubcategory: false });
            }}
            className="category"
          >
            {this.props.title}
            {this.props.subcategories.length ? (
              <SubCategory
                url={this.props.url}
                subcategories={this.props.subcategories}
              />
            ) : null}
          </li>
        </NavLink>
      </Fragment>
    );
  }
}
