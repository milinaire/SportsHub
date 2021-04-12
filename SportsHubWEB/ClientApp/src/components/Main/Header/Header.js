import React, { Component } from "react";
import { NavLink, Row } from "reactstrap";
import { Link } from "react-router-dom";
import "./Header.css";
import { Form, FormControl, NavDropdown, Image, Button } from "react-bootstrap";

export class Header extends Component {
  static displayName = Header.name;

  server = {
    User: {
      login: true,
      name: "Ivan",
      surname: "Baloh",
      role: "admin",
      image_url:
        "https://widgetwhats.com/app/uploads/2019/11/free-profile-photo-whatsapp-4.png",
      user_actions: [
        "Action",
        "Another action",
        "Something",
        "Another something",
      ],
    },
    Languages: {
      current_lang: ["En", 0],
      available_lang: ["English", "Ukrainian", "French", "German"],
    },
  };
  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
      ...this.server,
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    return (
      <>
        <header className="sticky-top">
          <link
            rel="stylesheet"
            href="https://www.w3schools.com/w3css/4/w3.css"
          />
          <link
            rel="stylesheet"
            href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"
          />

          <div className="grid-container">
            <div className="item1">
              <Link to="/" className="brand-card">
                {" "}
                <Row className="brand-text">
                  <p>Sports Hub</p>
                </Row>
              </Link>
            </div>
            <div className="item2">
              <Form className="search-card" inline>
                <Row className="pl-lg-5">
                  <button type="submit">
                    <i className="fa fa-search" />
                  </button>
                  <FormControl
                    type="text"
                    placeholder="Search By"
                    className="search-card from-width-fix"
                  />
                </Row>
              </Form>
            </div>
            <div className="item3">
              <NavLink className="share-card">
                <Row className="pl-lg-5">
                  <h5>Share</h5>
                  <button type="submit">
                    <i className="fa fa-facebook-f " />
                  </button>
                  <button type="submit">
                    <i className="fa fa-twitter " />
                  </button>
                  <button type="submit">
                    <i className="fa fa-google" />
                  </button>
                </Row>
              </NavLink>
            </div>
            <div className="item4">
              <Row className="profile-section-row">
                {this.state.User.login === true ? (
                  <>
                    <Image
                      className="profile-section avatar-img"
                      src={this.state.User.image_url}
                    />
                    <NavDropdown
                      className="dropdown-header "
                      title={
                        this.state.User.name + " " + this.state.User.surname
                      }
                      id="dropdownMenu1"
                    >
                      {this.state.User.user_actions.map((action, key) => (
                        <NavDropdown.Item href={"#" + action + key}>
                          {action}
                        </NavDropdown.Item>
                      ))}
                    </NavDropdown>
                  </>
                ) : (
                  <div className="pt-2">
                    <Button className="login-button btn-danger mr-2">
                      Sign up
                    </Button>
                    <Button className="signin-button btn-danger">Log in</Button>
                  </div>
                )}
                <NavDropdown
                  className="ml-lg-2 dropdown-header"
                  title={this.state.Languages.current_lang[0]}
                  id="dropdownMenu2"
                >
                  {this.state.Languages.available_lang.map((language, key) =>
                    key === this.state.Languages.current_lang[1] ? (
                      <NavDropdown.Item
                        className="dropdown-item disabled"
                        href={"#" + language + key}
                      >
                        {language}
                      </NavDropdown.Item>
                    ) : (
                      <NavDropdown.Item href={"#" + language + key}>
                        {language}
                      </NavDropdown.Item>
                    )
                  )}
                </NavDropdown>
              </Row>
            </div>
            <div className="item5"></div>
          </div>
        </header>
      </>
    );
  }
}
