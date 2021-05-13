import React, {Component, Fragment} from "react";
import {NavLink, Row} from "reactstrap";
import {Link, withRouter} from "react-router-dom";
import "./Header.css";
import {Form, FormControl, NavDropdown, Image, Button} from "react-bootstrap";
import authService from "../../api-authorization/AuthorizeService";

class Header extends Component {
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

  componentDidMount() {
    this._subscription = authService.subscribe(() => this.authenticationChanged());
    this.populateAuthenticationState();
  }

  componentWillUnmount() {
    authService.unsubscribe(this._subscription);
  }

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      ready: false,
      user:null,
      authenticated: false,
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
      <Fragment>
        {this.state.user&&console.log(this.state.user)}
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
                    <i className="fa fa-search"/>
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
                    <i className="fa fa-facebook-f "/>
                  </button>
                  <button type="submit">
                    <i className="fa fa-twitter "/>
                  </button>
                  <button type="submit">
                    <i className="fa fa-google"/>
                  </button>
                </Row>
              </NavLink>
            </div>
            <div className="item4">
              <Row className="profile-section-row">
                {this.state.User.login === true ? (
                  <>
                    <div
                      style={{borderRadius: "100%", height: "50px", width: "50px", background: "red", color: "white"}}>
                      <Link to={`/admin`}>
                        <div style={{
                          borderRadius: "100%",
                          height: "50px",
                          width: "50px",
                          display: "flex",
                          justifyContent: "center",
                          alignItems: "center"
                        }}>
                          admin
                        </div>
                      </Link>
                    </div>

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
                        <NavDropdown.Item key={key} href={"#" + action + key}>
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
                        key={key}
                        className="dropdown-item disabled"
                        href={"#" + language + key}
                      >
                        {language}
                      </NavDropdown.Item>
                    ) : (
                      <NavDropdown.Item key={key} href={"#" + language + key}>
                        {language}
                      </NavDropdown.Item>
                    )
                  )}
                </NavDropdown>
              </Row>
            </div>
            {//<div className="item5"></div>
            }
          </div>
        </header>
      </Fragment>
    );
  }

  async populateAuthenticationState() {
    const authenticated = await authService.isAuthenticated();
    const user = await authService.getUser();
    console.log(authService.userManager.getUser(), authService.getAccessToken(), )
    this.setState({ready: true, user: user, authenticated});
  }

  async authenticationChanged() {
    this.setState({ready: false, authenticated: false});
    await this.populateAuthenticationState();
  }
}

export default withRouter(Header)