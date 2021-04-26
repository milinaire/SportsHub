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
        id: 1,
        show: true,
        url: "NBA",
        subCategories: [
          {
            title: "NBA1",
            id: 1,
            teams: [
              { title: "1teamNBA1", id: 1 },
              { title: "2teamNBA1", id: 2 },
              { title: "3teamNBA1", id: 3 },
              { title: "4teamNBA1", id: 4 },
            ],
          },
          {
            title: "NBA2",
            id: 2,
            teams: [
              { title: "1teamNBA2", id: 1 },
              { title: "2teamNBA2", id: 2 },
              { title: "3teamNBA2", id: 3 },
              { title: "4teamNBA2", id: 4 },
            ],
          },
          {
            title: "NBA3",
            id: 3,
            teams: [
              { title: "1teamNBA3", id: 1 },
              { title: "2teamNBA3", id: 2 },
              { title: "3teamNBA3", id: 3 },
              { title: "4teamNBA3", id: 4 },
            ],
          },
          {
            title: "NBA4",
            id: 4,
            teams: [
              { title: "1teamNBA4", id: 1 },
              { title: "2teamNBA4", id: 2 },
              { title: "3teamNBA4", id: 3 },
              { title: "4teamNBA4", id: 4 },
            ],
          },
        ],
      },
      {
        title: "UFC",
        id: 2,
        show: true,
        url: "UFC",
        subCategories: [
          {
            title: "UFC1",
            id: 1,
            teams: [
              { title: "1teamUFC1", id: 1 },
              { title: "2teamUFC1", id: 2 },
              { title: "3teamUFC1", id: 3 },
              { title: "4teamUFC1", id: 4 },
            ],
          },
          {
            title: "UFC2",
            id: 2,
            teams: [
              { title: "1teamUFC2", id: 1 },
              { title: "2teamUFC2", id: 2 },
              { title: "3teamUFC2", id: 3 },
              { title: "4teamUFC2", id: 4 },
            ],
          },
          {
            title: "UFC3",
            id: 3,
            teams: [
              { title: "1teamUFC3", id: 1 },
              { title: "2teamUFC3", id: 2 },
              { title: "3teamUFC3", id: 3 },
              { title: "4teamUFC3", id: 4 },
            ],
          },
          {
            title: "UFC4",
            id: 4,
            teams: [
              { title: "1teamUFC4", id: 1 },
              { title: "2teamUFC4", id: 2 },
              { title: "3teamUFC4", id: 3 },
              { title: "4teamUFC4", id: 4 },
            ],
          },
        ],
      },
      {
        title: "KPD",
        id: 3,
        show: true,
        url: "KPD",
        subCategories: [{ title: "UFC1", id: 1, teams: [] }],
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
                key={category.id}
                title={category.title}
                show={category.show}
                url={category.id}
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
