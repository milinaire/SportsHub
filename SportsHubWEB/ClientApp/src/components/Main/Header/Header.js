import React, { Component } from 'react';
import { Container, NavLink, Row} from 'reactstrap';
import { Link } from 'react-router-dom';
import './Header.css';
import {Navbar, Button, Form, FormControl, Nav, NavDropdown, Image, Dropdown} from "react-bootstrap";

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
       <>
           <header className="sticky-top" >
               <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
               <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
               <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"/>
               <div className="grid-container ">
                   <div className="item1">
                       <Row className="brand-text"> <p>Sports Hub</p></Row>
                   </div>
                   <div className="item2">
                       <Form className="search-card" inline>
                           <Row className="pl-lg-5">
                               <button type="submit">
                                   <i className="fa fa-search"/>
                               </button>
                               <FormControl type="text" placeholder="Search By" className="mr-sm-2 search-card" />
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
                           <Image className="profile-section avatar-img" src="https://widgetwhats.com/app/uploads/2019/11/free-profile-photo-whatsapp-4.png"/>
                           <NavDropdown className="dropdown-header " title="Ivan Baloh" id="collasible-nav-dropdown">
                               <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                               <NavDropdown.Item href="#action/3.2">Another action</NavDropdown.Item>
                               <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                               <NavDropdown.Divider />
                               <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
                           </NavDropdown>
                           <NavDropdown className="ml-lg-2 dropdown-header" title="En" id="basic-nav-dropdown">
                               <NavDropdown.Item href="#action/3.1">English</NavDropdown.Item>
                               <NavDropdown.Item href="#action/3.3">Ukrainian</NavDropdown.Item>
                               <NavDropdown.Item href="#action/3.2">German</NavDropdown.Item>
                               <NavDropdown.Item href="#action/3.3">French</NavDropdown.Item>
                           </NavDropdown>
                       </Row>
                       
                   </div>
               </div>
           </header>
           
       </>
    );
  }
}