import React, { Component } from 'react';
import { Container, Navbar, NavLink, Row} from 'reactstrap';
import { Link } from 'react-router-dom';
import './Header.css';

export class Header extends Component {
  static displayName = Header.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Container>
          <Row>
            <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
            
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom mb-3 " light>
              <div className="brand-card">
                <NavLink className=" brand-text" href={Link} to="/">Sports Hub</NavLink>
              </div>
              <div className="borders-card">
                <NavLink className="search-card">
                  <form className="header-form">
                    <button type="submit"><i className="fa fa-search"/></button>
                    <input type="text" placeholder="Search By" name="search"/>
                  </form>
                </NavLink>
              </div>
              
              <div className="borders-card">
                <NavLink className="share-card">
                  <form className="header-form">
                    <Row>
                      <h5>Share</h5>
                      <button className="ml-2 mr-1" type="submit"><i className="fa fa-facebook-f "/></button>
                      <button className="mr-1" type="submit"><i className="fa fa-twitter "/></button>
                      <button className="mr-1" type="submit"><i className="fa fa-google-plus"/></button>
                    </Row>
                  </form>
                </NavLink>
              </div>
              
              <div className="borders-card">
                <NavLink className="search-card">
                  <form className="header-form">
                    <button type="submit"><i className="fa fa-search"/></button>
                    <input type="text" placeholder="Search By" name="search"/>
                  </form>
                </NavLink>
              </div>
            </Navbar>
            {/*<Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom mb-3 borders-card" light>
            <Row>
              <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
              <Collapse className="d-sm-inline-flex flex-sm-row-reverse " isOpen={!this.state.collapsed} navbar>
                <ul className="navbar-nav flex-grow">
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                  </NavItem>
                  <LoginMenu>
                  </LoginMenu>
                </ul>
              </Collapse>
            </Row>
        </Navbar>*/}

          </Row>
        </Container>
        
        
      </header>
    );
  }
}