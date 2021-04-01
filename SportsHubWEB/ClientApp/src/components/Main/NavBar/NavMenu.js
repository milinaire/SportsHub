import React, { Component } from "react";
import "./NavMenu.css";
import { Category } from "./NavMenuCategory";
import { NavLink } from "react-router-dom";

export class NavMenu extends Component {
  state = {
    isOpenSubcategory: false,
    Categories: [
      {
        title: "NBA",
        key: 1,
        show: true,
        url: "/NBA",
        subCategories: [
          {
            title: "NBA1",
            url: "1",
            teams: [
              { title: "1teamNBA1", url: "1" },
              { title: "2teamNBA1", url: "2" },
              { title: "3teamNBA1", url: "3" },
              { title: "4teamNBA1", url: "4" },
            ],
          },
          {
            title: "NBA2",
            url: "2",
            teams: [
              { title: "1teamNBA2", url: "1" },
              { title: "2teamNBA2", url: "2" },
              { title: "3teamNBA2", url: "3" },
              { title: "4teamNBA2", url: "4" },
            ],
          },
          {
            title: "NBA3",
            url: "3",
            teams: [
              { title: "1teamNBA3", url: "1" },
              { title: "2teamNBA3", url: "2" },
              { title: "3teamNBA3", url: "3" },
              { title: "4teamNBA3", url: "4" },
            ],
          },
          {
            title: "NBA4",
            url: "4",
            teams: [
              { title: "1teamNBA4", url: "1" },
              { title: "2teamNBA4", url: "2" },
              { title: "3teamNBA4", url: "3" },
              { title: "4teamNBA4", url: "4" },
            ],
          },
        ],
      },
      {
        title: "UFC",
        key: 2,
        show: true,
        url: "/UFC",
        subCategories: [
          {
            title: "UFC1",
            url: "1",
            teams: [
              { title: "1teamUFC1", url: "1" },
              { title: "2teamUFC1", url: "2" },
              { title: "3teamUFC1", url: "3" },
              { title: "4teamUFC1", url: "4" },
            ],
          },
          {
            title: "UFC2",
            url: "2",
            teams: [
              { title: "1teamUFC2", url: "1" },
              { title: "2teamUFC2", url: "2" },
              { title: "3teamUFC2", url: "3" },
              { title: "4teamUFC2", url: "4" },
            ],
          },
          {
            title: "UFC3",
            url: "3",
            teams: [
              { title: "1teamUFC3", url: "1" },
              { title: "2teamUFC3", url: "2" },
              { title: "3teamUFC3", url: "3" },
              { title: "4teamUFC3", url: "4" },
            ],
          },
          {
            title: "UFC4",
            url: "4",
            teams: [
              { title: "1teamUFC4", url: "1" },
              { title: "2teamUFC4", url: "2" },
              { title: "3teamUFC4", url: "3" },
              { title: "4teamUFC4", url: "4" },
            ],
          },
        ],
      },
      {
        title: "KPD",
        key: 3,
        show: true,
        url: "/KPD",
        subCategories: [{ title: "UFC1", url: "1", teams: [] }],
      },
    ],
    follow: [{ show: true }, { show: true }, { show: true }, { show: true }],
  };

  render() {
    return (
      <div className={"left-panel-wrapper"}>
        <div className="scrollbar" id="style-1">
          <ul className="categories">
            <NavLink
              className="not-active"
              exact
              to={""}
              activeClassName={"active"}
            >
              <li className="category">HOME</li>
            </NavLink>
            {this.state.Categories.map((category) => (
              <Category
                title={category.title}
                show={category.show}
                url={category.url}
                subcategories={category.subCategories}
              />
            ))}
          </ul>
        </div>
        <div className="follow">
          <p>Follow</p>
          <button type="submit">
            <i className="fa fa-facebook-f " />
          </button>
          <button type="submit">
            <i className="fa fa-twitter " />
          </button>
          <br />
          <button type="submit">
            <i className="fa fa-google" />
          </button>
          <button type="submit">
            <i className="fa fa-youtube-play " />
          </button>
        </div>
      </div>
    );
  }
}
