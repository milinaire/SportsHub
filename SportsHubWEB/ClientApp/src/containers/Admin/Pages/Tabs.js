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
                  deleteBannerLocalization={this.props.deleteBannerLocalization}
                  activeTab={activeTab}
                  onClickTabItem={onClickTabItem}
                  key={label}
                  label={label}
                  onClick={onClickTabItem}
                />);
            }


          })}

          { this.props.language.languages.length > this.props.banners.newBanner.localization.length?<button onClick={()=>{
            if(this.props.language.languages.length > this.props.banners.newBanner.localization.length)
            {return this.props.addBannerLocalization(this.props.language.languages.find(l=> {
                for (let i = 0; i < this.props.banners.newBanner.localization.length; i++) {
                  if(this.props.banners.newBanner.localization[i].languageId === l.id)
                  {return false}
                }
                return true
              }

            ).id)
            }
          }}>
            +</button>:null}
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