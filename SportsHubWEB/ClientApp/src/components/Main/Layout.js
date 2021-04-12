import React, { Component, Fragment } from "react";
import { Header } from "./Header/Header";
import "./Layout.css";
import { NavMenu } from "./NavBar/NavMenu";
import { Sidebar } from "./SideBar/Sidebar";
import { Footer } from "./Footer/Footer";

export class Layout extends Component {
  static displayName = Layout.name;
  render() {
    return (
      <Fragment>
        {console.log(this.props.match)}
        <div>
          <Header />
          <div className={"page-wrapper"}>
            <NavMenu />
            <div className="content-wrapper">
              <div className={"content"}>{this.props.children}</div>
            </div>
            <Sidebar category={this.props.category}/>
          </div>
          <Footer />
        </div>
      </Fragment>
    );
  }
}
