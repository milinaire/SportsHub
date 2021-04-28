import React, { Component } from "react";
import "./AdminHeader.css";
import {NavLink} from "react-router-dom";
import ScrollMenu from 'react-horizontal-scrolling-menu';



const MenuItem = ({text, path, selected}) => {
  return <div
    className={`menu-item ${selected ? 'active' : ''}`}
    > <NavLink  to={`${path}`}> 
    {text}
  </NavLink></div>;
};


export const Menu = (list,  selected) =>
  list.map(el => {
    {console.log(el)}
    const {name, id} = el;
    return <MenuItem path={id} text={name} key={id} selected={selected} />;
  });


const Arrow = ({ text, className }) => {
  return (
    <div
      className={className}
    >{text}</div>
  );
};


const ArrowLeft = Arrow({ text: '<', className: 'arrow-prev' });
const ArrowRight = Arrow({ text: '>', className: 'arrow-next' });

const selected = 'item1';


export class AdminHeader extends Component {
  componentDidMount(){
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
  )}
  state = {
    selected,
    Categories: []
  }
  constructor(props) {
    super(props);
    this.menuItems = Menu(this.state.Categories, selected);
  }
  onSelect = key => {
    this.setState({ selected: key });
  }
  render() {
    const { selected } = this.state;
    // Create menu from items
    let menu = [] ;
    for (let i = 0; i < this.state.Categories.length; i++) {
      menu.push(<div
        className={`menu-item1 ${selected ? 'active' : ''}`}
        > <NavLink  to={`/admin/${this.state.Categories[i].id}`}> 
        {this.state.Categories[i].name}
      </NavLink></div>)
    }
    return (
     
        <div className="head-wrap">
             {console.log(this.state.Categories)}
             <div  className="head-title">
                 <div className="hdt"></div>
                 <div className="head-func"></div>
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
