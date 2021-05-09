import React, {Component} from "react";
import "./AdminHeader.css";
import {Link, NavLink, withRouter} from "react-router-dom";
import ScrollMenu from 'react-horizontal-scrolling-menu';
import {Row} from "reactstrap";
import {Image, NavDropdown} from "react-bootstrap";


const MenuItem = ({text, path, selected}) => {
  return <div
    className={`menu-item ${selected ? 'active' : ''}`}
  ><NavLink to={`${path}`}>
    {text}
  </NavLink></div>;
};


export const Menu = (list, selected) =>
  list.map(el => {
    const {name, id} = el;
    return <MenuItem path={id} text={name} key={id} selected={selected}/>;
  });


const Arrow = ({text, className}) => {
  return (
    <div
      className={className}
    >{text}</div>
  );
};


const ArrowLeft = Arrow({text: '<', className: 'arrow-prev'});
const ArrowRight = Arrow({text: '>', className: 'arrow-next'});

const selected = 'item1';


class AdminHeader extends Component {
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
  }

  state = {

    selected,
    Categories: [],
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
  }

  constructor(props) {
    super(props);
    this.menuItems = Menu(this.state.Categories, selected);
  }

  onSelect = key => {
    this.setState({selected: key});
  }

  render() {
    const {selected} = this.state;
    // Create menu from items
    let menu = [];
    for (let i = 0; i < this.state.Categories.length; i++) {
      menu.push(<div
        className={`menu-item1 ${selected ? 'active' : ''}`}
      ><NavLink to={`/admin/${this.state.Categories[i].id}`}>
        {this.state.Categories[i].name}
      </NavLink></div>)
    }
    return (

      <div className="head-wrap">
        <div className="head-default">
          <div className="admin-logo">
            <Link to="/" className="brand-card">
              {" "}
              <Row className="brand-text">
                <p>Sports Hub</p>
              </Row>
            </Link>
          </div>
          <div className="admin-user">
            <div style={{borderRadius: "100%", height: "50px", width: "50px", background: "red", color: "white"}}>
              <Link to={String(this.props.location.pathname).replace("/admin", "")}>
                <div style={{
                  borderRadius: "100%",
                  height: "50px",
                  width: "50px",
                  display: "flex",
                  justifyContent: "center",
                  alignItems: "center"
                }}>
                  <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                       className="bi bi-arrow-left-right" viewBox="0 0 16 16">
                    <path fill-rule="evenodd"
                          d="M1 11.5a.5.5 0 0 0 .5.5h11.793l-3.147 3.146a.5.5 0 0 0 .708.708l4-4a.5.5 0 0 0 0-.708l-4-4a.5.5 0 0 0-.708.708L13.293 11H1.5a.5.5 0 0 0-.5.5zm14-7a.5.5 0 0 1-.5.5H2.707l3.147 3.146a.5.5 0 1 1-.708.708l-4-4a.5.5 0 0 1 0-.708l4-4a.5.5 0 1 1 .708.708L2.707 4H14.5a.5.5 0 0 1 .5.5z"/>
                  </svg>
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
          </div>
        </div>
        <div className="head-title">
          <div className="hdt">
            <b style={{fontSize:"200%"}}>{this.props.currentSection}</b>
          </div>
          <div className="head-func">

          </div>
        </div>
        <ScrollMenu
          className="head-list"
          data={menu}
          arrowLeft={ArrowLeft}
          arrowRight={ArrowRight}
          selected={selected}
          onSelect={this.onSelect}
        />
      </div>

    );
  }
}

export default withRouter(AdminHeader)