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
        {this.state.isOpenSubcategory ? (
          <div className="hide-footer">
            <div className="modal-full" />{" "}
          </div>
        ) : null}
        <div
          className="category"
          onMouseEnter={() => {
            if (this.props.subcategories.length > 0) {
              this.setState({ isOpenSubcategory: true });
            }
          }}
          onMouseLeave={() => {
            this.setState({ isOpenSubcategory: false });
          }}
        >
          <NavLink
            className="not-active"
            to={`/nav/${this.props.url}`}
            activeClassName={"active"}
          >
            <li>{this.props.title}</li>
          </NavLink>
          {this.props.subcategories.length ? (
            <SubCategory
              url={this.props.url}
              subcategories={this.props.subcategories}
            />
          ) : null}
        </div>
      </Fragment>
    );
  }
}
