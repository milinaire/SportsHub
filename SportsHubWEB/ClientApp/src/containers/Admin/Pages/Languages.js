import React, {Component, Fragment} from "react";
import Switch from "react-switch";
import { FaTrash } from "react-icons/fa";
import "./Languages.css"

export class Languages extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Languages")
  }

  constructor() {
    super();
    this.state = { checked: false };
    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(checked) {
    this.setState({ checked });
  }

  render() {
    return (
      <Fragment>
        <div className="laguages-block">
            <div className="language-head">
              <div className="sub-language-head"><p>LANGUAGES</p></div>
              <div className="sub-language-head"><p>STATUS</p></div>
            </div>
            <div className="sub-language-block">
              <div className="sub-sub-language-block"><p>English</p></div>
              <div className="sub-sub-language-block">
                <div className="switch-icon-language-block">  
                  <label >
                    <Switch  className="custom-switch" 
                    onChange={this.handleChange} 
                    checked={this.state.checked} 
                    height={20} width={40}  
                    handleDiameter={15} 
                    boxShadow='0 0 8px 0 rgba(0, 0, 0, 0.3)' 
                    uncheckedIcon={false}
                    checkedIcon={false} 
                    offColor='grey' 
                    onColor='grey' 
                    offHandleColor='#F0F0F0' 
                    onHandleColor='#FF0000'/>
                  </label>
               
                <FaTrash/>
                </div>
              </div>
            </div>
            <div className="sub-language-block">
              <div className="sub-sub-language-block"><p>German</p></div>
                <div className="sub-sub-language-block">
                <div className="switch-icon-language-block">  
                  <label>
                  <Switch  className="custom-switch" 
                    onChange={this.handleChange} 
                    checked={this.state.checked} 
                    height={20} width={40}  
                    handleDiameter={15} 
                    boxShadow='0 0 8px 0 rgba(0, 0, 0, 0.3)' 
                    uncheckedIcon={false}
                    checkedIcon={false} 
                    offColor='grey' 
                    onColor='grey' 
                    offHandleColor='#F0F0F0' 
                    onHandleColor='#FF0000'/>
                  </label>
                  <FaTrash/>
                  </div>
                </div>
            </div>
            <div className="sub-language-block">
              <div className="sub-sub-language-block"><p>Spanish</p></div>
                <div className="sub-sub-language-block">
                <div className="switch-icon-language-block">  
                  <label>
                  <Switch  className="custom-switch" 
                    onChange={this.handleChange} 
                    checked={this.state.checked} 
                    height={20} width={40}  
                    handleDiameter={15} 
                    boxShadow='0 0 8px 0 rgba(0, 0, 0, 0.3)' 
                    uncheckedIcon={false}
                    checkedIcon={false} 
                    offColor='grey' 
                    onColor='grey' 
                    offHandleColor='#F0F0F0' 
                    onHandleColor='#FF0000'/>
                  </label>
                  <FaTrash/>
                  </div>
                </div>
            </div>
            <div className="sub-language-block">
            <div className="sub-sub-language-block"><p>French</p></div>
              <div className="sub-sub-language-block">
              <div className="switch-icon-language-block">  
                <label>
                <Switch  className="custom-switch" 
                    onChange={this.handleChange} 
                    checked={this.state.checked} 
                    height={20} width={40}  
                    handleDiameter={15} 
                    boxShadow='0 0 8px 0 rgba(0, 0, 0, 0.3)' 
                    uncheckedIcon={false}
                    checkedIcon={false} 
                    offColor='grey' 
                    onColor='grey' 
                    offHandleColor='#F0F0F0' 
                    onHandleColor='#FF0000'/>
                </label>
                <FaTrash/>
                </div>
              </div>
            </div>
        </div>
      </Fragment>
    );
  }
}
