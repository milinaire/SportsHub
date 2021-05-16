import React, {Component} from 'react';
import PropTypes from 'prop-types';
import "./Tab.css";

class Tab extends Component {
  static propTypes = {
    activeTab: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    onClick: PropTypes.func.isRequired,
  };

  onClick = () => {
    const {label, onClick} = this.props;
    onClick(label);
  }

  render() {
    const {
      onClick,
      props: {
        activeTab,
        label,
      },
    } = this;

    let className = 'tab-list-item';

    if (activeTab === label) {
      className += ' tab-list-active';
    }
console.log(this.props.label)
    return (
      <li
        className={className}
        onClick={onClick}
      >
        Local-{label + 1}
        <button onClick={() => {
          if (label) {

            this.props.deleteBannerLocalization(label)
            this.props.onClickTabItem(0)
          }
        }
        } style={{border: "none",}}>{label?<>&#10006;</>:''}</button>
      </li>
    );
  }
}

export default Tab;