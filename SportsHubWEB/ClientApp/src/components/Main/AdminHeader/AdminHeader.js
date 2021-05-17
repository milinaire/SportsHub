import React, {Component} from "react";
import "./AdminHeader.css";
import {Link, NavLink, withRouter} from "react-router-dom";
import ScrollMenu from 'react-horizontal-scrolling-menu';
import {Row} from "reactstrap";
import {Image, NavDropdown} from "react-bootstrap";
import Header from "../../User/Header/Header";

const Arrow = ({text, className}) => <div className={className}>{text}</div>;
const ArrowLeft = Arrow({text: '<', className: 'arrow-prev'});
const ArrowRight = Arrow({text: '>', className: 'arrow-next'});

class AdminHeader extends Component {
  componentDidMount() {
    fetch(`/category?languageId=${this.props.language.currentLanguage.id}`)
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
    selected: '',
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

  }

  onSelect = key => {
    this.setState({selected: key});
  }

  render() {
    const {selected} = this.state;
    let menu = [];
    for (let i = 0; i < this.state.Categories.length; i++) {
      menu.push(
        <div className={`menu-item1 ${selected ? 'selected-category' : ''}`}>
          <NavLink activeClassName="selected-category" to={`/admin/${this.state.Categories[i].id}`}>
            <div className="link-box">
              <b style={{fontSize: "150%"}}>{this.state.Categories[i].name}</b>
            </div>
          </NavLink>
        </div>)
    }
    return (

      <div className="head-wrap">
        <Header language={this.props.language} setCurrentLanguage={this.props.setCurrentLanguage}/>
        <div className="head-title">
          <div className="hdt">
            <b style={{fontSize: "200%"}}>{this.props.currentSection}</b>
          </div>
          <div className="head-func">
            {this.props.buttonElem}
          </div>
        </div>
        <div style={{display:'flex', justifyContent:'space-around', alignItems:'center', height:'60px'}}>
          <span/>
          {this.state.Categories.map(c=>(
            <span key={c.id}> <Link style={{textDecoration:"none", color:'#666'}} to={`/admin/${c.id}`}>{c.name}</Link></span>
          ))}
          <span/>
        </div>
        {/*<ScrollMenu*/}
        {/*  className="head-list"*/}
        {/*  data={menu}*/}
        {/*  arrowLeft={ArrowLeft}*/}
        {/*  arrowRight={ArrowRight}*/}
        {/*  selected={selected}*/}
        {/*  onSelect={this.onSelect}*/}
        {/*/>*/}
      </div>

    );
  }
}

export default withRouter(AdminHeader)