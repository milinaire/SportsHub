import React, { Component } from 'react';
import PropTypes from 'prop-types';
import "./Tab.css";
import Tab from './Tab';
class Tabs extends Component {
  static propTypes = {
    children: PropTypes.instanceOf(Array).isRequired,
  }

  constructor(props) {
    super(props);
    this.state = {
      activeTab: this.props.children[0].props.label,
    };
  }

  onClickTabItem = (tab) => {
    this.setState({ activeTab: tab });
  }
  render() {
    const {
      onClickTabItem,
      props: {
        children,
      },
      state: {
        activeTab,
      }
    } = this;

    return (
      <div className="tabs">
        <ol className="tab-list">
          {children.map((child) => {
            if(child){
              const { label } = child.props;
              return (
                <Tab
                  deleteTab={this.props.deleteTab}
                  activeTab={activeTab}
                  resetActiveTab={()=>this.setState({ activeTab: this.props.children[0].props.label })}
                  key={label}
                  label={label}
                  onClick={onClickTabItem}
                />);
            }
          })}

          { this.props.language.languages.length > this.props.Localization.length?
            <button onClick={(e)=>{e.preventDefault();this.props.addTab()}}>
            +
            </button>:null}
        </ol>
        <div className="tab-content" style={{height:'200px'}}>
          {children.map((child) => {
            if (child){
              if (child.props.label !== activeTab) return undefined;
              return child.props.children;
            }

          })}
        </div>
      </div>
    );
  }
}

export default Tabs;