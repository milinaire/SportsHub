import React, { Component } from "react";
import "./AdminHeader.css";
import {NavLink} from "react-router-dom";
import ScrollMenu from 'react-horizontal-scrolling-menu';


const list =  [
  {
    title: "HOME",
    url: "HOME",
    path:"./admin"
},
    {
        title: "NBA",
        url: "NBA",
        path:"./admin"
    },
    {
        title: "UFC",
        url: "UFC",
        path:"./admin"
    },
    {
        title: "KPD",
        url: "KPD",
        path:"./admin"
    },
    {
      title: "UFC",
      url: "UFC",
      path:"./admin"
    },
    {
        title: "UFC",
        url: "UFC",
        path:"./admin"
    },
    {
      title: "UFC",
      url: "UFC",
      path:"./admin"
    },
    {
      title: "UFC",
      url: "UFC",
      path:"./admin"
    },
    {
      title: "UFC",
      url: "UFC",
      path:"./admin"
    },
    {
      title: "UFC",
      url: "UFC",
      path:"./admin"
    },
    {
      title: "UFC",
      url: "UFC",
      path:"./admin"
    }
]

const MenuItem = ({text, path, selected}) => {
  return <div
    className={`menu-item ${selected ? 'active' : ''}`}
    > <NavLink  to={`path`}> 
    {text}
  </NavLink></div>;
};


export const Menu = (list,  selected) =>
  list.map(el => {
    const {title} = el;
    return <MenuItem text={title} key={title} selected={selected} />;
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
  
  state = {
    selected,
    Categories: [
      {
        title: "HOME",
        url: "HOME",
        path:"./admin"
    },
        {
            title: "NBA",
            url: "NBA",
            path:"./admin"
        },
        {
            title: "UFC",
            url: "UFC",
            path:"./admin"
        },
        {
            title: "KPD",
            url: "KPD",
            path:"./admin"
        },
        {
          title: "UFC",
          url: "UFC",
          path:"./admin"
        },
        {
            title: "UFC",
            url: "UFC",
            path:"./admin"
        },
        {
          title: "UFC",
          url: "UFC",
          path:"./admin"
        },
        {
          title: "UFC",
          url: "UFC",
          path:"./admin"
        },
        {
          title: "UFC",
          url: "UFC",
          path:"./admin"
        },
        {
          title: "UFC",
          url: "UFC",
          path:"./admin"
        },
        {
          title: "UFC",
          url: "UFC",
          path:"./admin"
        }
    ]
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
    const menu = this.menuItems;
    return (
        <div className="head-wrap">
             <div  className="head-title">
                 <div className="hdt"></div>
                 <div className="head-func"></div>
             </div>
           
             <ScrollMenu
             className="hdt-a"
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
