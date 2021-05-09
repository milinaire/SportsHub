import React, {Component, Fragment} from "react";
import "./NavMenu.css";
import {NavLink} from "react-router-dom";

export class NavMenu extends Component {


  state = {
    isOpenSubcategory: false,
    Categories: [],
    follow: [{show: true}, {show: true}, {show: true}, {show: true}],
    SubCategories:[],
    Teams:[],
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

  componentDidMount() {
    fetch("/category?languageId=1")
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({Categories: result})
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
    fetch("/conference?languageId=1")
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({SubCategories: result})
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
    fetch("/team")
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({Teams: result})
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
  }

  setHovered = (id, left, categoryId, subcategoryId) => {
    let flagc = true
    let flags = true
    if (categoryId) {
      this.setState({
        NavSubCategories: {
          sub: this.state.SubCategories.filter(category => category.categoryId === categoryId),
          cat: categoryId
        }
      })
      if(!this.state.SubCategories.filter(category => category.categoryId === categoryId).length){
        flagc = false
      }
    }

    if (subcategoryId) {
      this.setState({
        NavTeams: {
          teams: this.state.Teams.filter(category => category.conferenceId === subcategoryId),
          cat: this.state.NavSubCategories.cat,
          sub: subcategoryId
        }
      })
      if(!this.state.Teams.filter(category => category.conferenceId === subcategoryId).length){
        flags = false
      }
    }


    if(flagc && flags){
      document.getElementById(id[1]).style.marginLeft = `${left[1]}px`;
    }
    if(flagc && flags){
      document.getElementById(id[0]).style.marginLeft = `${left[0]}px`;
    }

    if(flagc){
      clearTimeout(this.timeout)
      document.getElementById("1").style.height = "calc(100vh - 100px)";
      document.getElementById("2").style.height = "calc(100vh - 100px)";
      document.getElementById("3").style.height = "calc(100vh - 100px)";
      document.getElementById("box").style.zIndex = "5";
      document.getElementById("box").style.backgroundColor = "rgba(0, 0, 0, 0.8)";
    }

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
             onMouseLeave={() => this.unsetHovered([1, 2], [0, 0], true)}>
          <div className="dropdown-content">
            <ul className="subcategories">
              {this.state.NavTeams.teams.map((category) => (
                <NavLink
                  key={category.teamId}
                  className="not-active"
                  activeClassName={"active-subcategory"}
                  to={`/nav/${this.state.NavTeams.cat}/${this.state.NavTeams.sub}/${category.teamId}`}>
                  <li className={"subcategory"}>
                    {category.name}
                  </li>
                </NavLink>
              ))}
            </ul>
          </div>
        </div>
        <div id="2" className={`custom-nav `}
             onMouseEnter={() => this.setHovered([1, 2], [300, 300])}
             onMouseLeave={() => this.unsetHovered([1, 2], [0, 0], true)}>
          <div className="dropdown-content">
            <ul className="subcategories">
              {this.state.NavSubCategories.sub.map((category) => (
                <NavLink
                  onMouseEnter={() => {

                      this.setHovered([1, 2], [600, 300], undefined, category.conferenceId)

                  }}
                  onMouseLeave={() => this.unsetHovered([1, 2], [300, 300], false)}
                  key={category.conferenceId}
                  className="not-active"
                  activeClassName={"active-subcategory"}
                  to={`/nav/${this.state.NavSubCategories.cat}/${category.conferenceId}`}>
                  <li className={"subcategory"}>
                    {category.name}
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
                activeClassName={"active"}>
                <li className="category">HOME</li>
              </NavLink>
              {this.state.Categories.map((category) => (
                <NavLink
                  onMouseEnter={() => {
                    this.setHovered([1, 2], [300, 300], category.id)
                  }}
                  onMouseLeave={() => this.unsetHovered([1, 2], [0, 0], true)}
                  key={category.id}
                  className="not-active"
                  to={`/nav/${category.id}`}
                  activeClassName={"active"}>
                  <li className="category">{category.name}</li>
                </NavLink>
              ))}
            </ul>
          </div>
        </div>
      </Fragment>
    );
  }
}
