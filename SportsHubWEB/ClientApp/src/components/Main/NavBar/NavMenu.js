import React, {Component, Fragment} from "react";
import "./NavMenu.css";
import {NavLink} from "react-router-dom";

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
              {title: "1teamNBA1", id: 1},
              {title: "2teamNBA1", id: 2},
              {title: "3teamNBA1", id: 3},
              {title: "4teamNBA1", id: 4},
            ],
          },
          {
            title: "NBA2",
            id: 2,
            teams: [
              {title: "1teamNBA2", id: 1},
              {title: "2teamNBA2", id: 2},
              {title: "3teamNBA2", id: 3},
              {title: "4teamNBA2", id: 4},
            ],
          },
          {
            title: "NBA3",
            id: 3,
            teams: [
              {title: "1teamNBA3", id: 1},
              {title: "2teamNBA3", id: 2},
              {title: "3teamNBA3", id: 3},
              {title: "4teamNBA3", id: 4},
            ],
          },
          {
            title: "NBA4",
            id: 4,
            teams: [
              {title: "1teamNBA4", id: 1},
              {title: "2teamNBA4", id: 2},
              {title: "3teamNBA4", id: 3},
              {title: "4teamNBA4", id: 4},
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
              {title: "1teamUFC1", id: 1},
              {title: "2teamUFC1", id: 2},
              {title: "3teamUFC1", id: 3},
              {title: "4teamUFC1", id: 4},
            ],
          },
          {
            title: "UFC2",
            id: 2,
            teams: [
              {title: "1teamUFC2", id: 1},
              {title: "2teamUFC2", id: 2},
              {title: "3teamUFC2", id: 3},
              {title: "4teamUFC2", id: 4},
            ],
          },
          {
            title: "UFC3",
            id: 3,
            teams: [
              {title: "1teamUFC3", id: 1},
              {title: "2teamUFC3", id: 2},
              {title: "3teamUFC3", id: 3},
              {title: "4teamUFC3", id: 4},
            ],
          },
          {
            title: "UFC4",
            id: 4,
            teams: [
              {title: "1teamUFC4", id: 1},
              {title: "2teamUFC4", id: 2},
              {title: "3teamUFC4", id: 3},
              {title: "4teamUFC4", id: 4},
            ],
          },
        ],
      },
      {
        title: "KPD",
        id: 3,
        show: true,
        url: "KPD",
        subCategories: [
          {title: "UFC1", id: 1, teams: []}
        ],
      },
    ],
    follow: [{show: true}, {show: true}, {show: true}, {show: true}],
    NavSubCategories: {
      sub: [],
      cat: undefined
    },
    NavTeams: {
      teams: [],
      sub: undefined,
      cat: undefined,
    },
  };

  setHovered = (id, left, categoryId, subcategoryId) => {
    for (let i = 0; i < id.length; i++) {
      document.getElementById(id[i]).style.marginLeft = `${left[i]}px`;
    }
    clearTimeout(this.timeout)

    if (categoryId) {
      this.setState({
        NavSubCategories: {
          sub: this.state.Categories.find(category => category.id === categoryId).subCategories,
          cat: categoryId
        }
      })
    }
    if (subcategoryId) {
      this.setState({
        NavTeams: {
          teams: this.state.NavSubCategories.sub.find(category => category.id === subcategoryId).teams,
          cat: this.state.NavSubCategories.cat,
          sub: subcategoryId
        }
      })
    }
    document.getElementById("1").style.height = "calc(100vh - 100px)";
    document.getElementById("2").style.height = "calc(100vh - 100px)";
    document.getElementById("3").style.height = "calc(100vh - 100px)";
    document.getElementById("box").style.zIndex = "5";
    document.getElementById("box").style.backgroundColor = "rgba(0, 0, 0, 0.8)";
  }
  unsetHovered = (id, left, flag) => {
    for (let i = 0; i < id.length; i++) {
      document.getElementById(id[i]).style.marginLeft = `${left[i]}px`;
    }
    if (flag) {
      document.getElementById("1").style.height = "calc(100vh - 200px)";
      document.getElementById("2").style.height = "calc(100vh - 200px)";
      document.getElementById("3").style.height = "calc(100vh - 200px)";
      document.getElementById("box").style.backgroundColor = "rgba(0, 0, 0, 0.0)";
      this.timeout = setTimeout(() => document.getElementById("box").style.zIndex = "-1", 400)
    }

  }

  render() {
    return (
      <Fragment>
        <div id="box" className="gray-box">

        </div>
        <div id="1" className={`custom-nav `}
             onMouseEnter={() => this.setHovered([1, 2], [600, 300])}
             onMouseLeave={() => this.unsetHovered([1, 2], [0, 0], true)}
        >
          <div className="dropdown-content">
            <ul className="subcategories">
              {this.state.NavTeams.teams.map((category) => (
                <NavLink
                  key={category.id}
                  className="not-active"
                  activeClassName={"active-subcategory"}
                  to={`/nav/${this.state.NavTeams.cat}/${this.state.NavTeams.sub}/${category.id}`}
                >
                  <li className={"subcategory"}>
                    {category.title}
                  </li>
                </NavLink>
              ))}
            </ul>
          </div>
        </div>
        <div id="2" className={`custom-nav `}
             onMouseEnter={() => this.setHovered([1, 2], [300, 300])}
             onMouseLeave={() => this.unsetHovered([1, 2], [0, 0], true)}
        >
          <div className="dropdown-content">
            <ul className="subcategories">
              {this.state.NavSubCategories.sub.map((category) => (
                <NavLink
                  onMouseEnter={() => {
                    if (category.teams.length) {
                      this.setHovered([1, 2], [600, 300], undefined, category.id)
                    }
                  }}
                  onMouseLeave={() => this.unsetHovered([1, 2], [300, 300], false)}
                  key={category.id}
                  className="not-active"
                  activeClassName={"active-subcategory"}
                  to={`/nav/${this.state.NavSubCategories.cat}/${category.id}`}
                >
                  <li className={"subcategory"}>
                    {category.title}
                  </li>
                </NavLink>
              ))}
            </ul>
          </div>
        </div>
        <div id="3" className={`custom-nav `}>
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
                <NavLink
                  onMouseEnter={() => {
                    if (category.subCategories.length) {
                      this.setHovered([1, 2], [300, 300], category.id)
                    }
                  }}
                  onMouseLeave={() => this.unsetHovered([1, 2], [0, 0], true)}
                  key={category.id}
                  className="not-active"
                  
                  to={`/nav/${category.id}`}
                  activeClassName={"active"}
                >
                  <li className="category">{category.title}</li>
                </NavLink>
              ))}
            </ul>
          </div>
        </div>
      </Fragment>
    );
  }
}
