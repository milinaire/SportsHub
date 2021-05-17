import React, {Component, Fragment} from "react";
import Switch from "react-switch";

import { FaTrash } from "react-icons/fa";

import "./Footer.css";

class Footer extends Component {
  componentDidMount() {


  }

  state = {

    div1: true,
    div2: false,
    div3: false,
    check1: false,
    check2: false,
    check3: false,
    check4: false,
    check5: false,
    contcheck1: false,
    contcheck2: false,
    contcheck3: false,
    newcheck1: false,
    newcheck2: false,
    newcheck3: false,
    aboutSportsHub: true,
    contactUs: false,
    privacyPolicy: false,
  }

  constructor() {
    super();

    this.handleChange1 = this.handleChange1.bind(this);
    this.handleChange2 = this.handleChange2.bind(this);
    this.handleChange3 = this.handleChange3.bind(this);
    this.handleChange4 = this.handleChange4.bind(this);
    this.handleChange5 = this.handleChange5.bind(this);
    this.handleChange6 = this.handleChange6.bind(this);
    this.handleChange7 = this.handleChange7.bind(this);
    this.handleChange8 = this.handleChange8.bind(this);
    this.handleChange9 = this.handleChange9.bind(this);


  }
  handleChange1 (check1)  {
    this.setState({ check1 });
  };
  handleChange2 (check2)  {
    this.setState({ check2 });
  };
  handleChange3 (check3)  {
    this.setState({ check3 });
  };
  handleChange4 (check4)  {
    this.setState({ check4 });
  };
  handleChange5 (check5)  {
    this.setState({ check5 });
  };
  handleChange6 (contcheck1)  {
    this.setState({ contcheck1 });
  };
  handleChange7 (contcheck2)  {
    this.setState({ contcheck2 });
  };
  handleChange8 (contcheck3)  {
    this.setState({ contcheck3 });
  };
  handleChange9 (  newcheck1)  {
    this.setState({   newcheck1 });
  };



  render() {
    const {div1, div2, div3, contactUs, aboutSportsHub,privacyPolicy} = this.state;


    return (

      <Fragment>

        <div className="admin-footer">
          <div className="admin-footer-header">
            <a  onClick={()=>this.setState({div1: true, div2: false, div3: false })} >   COMPANY INFO </a>
            <a  onClick={()=>this.setState({div1: false, div2: true, div3: false })}>  CONTRIBUTORS </a>
            <a onClick={()=>this.setState({div1: false, div2: false, div3: true })}>  NEWSLETTER </a>
          </div>

          {div1 && <div className="footer-wrapper">
            <div className="footer-block">
              <div className="footer-head">
                <div className="sub-footer-head1"><p>FOOTER MENU NAMES</p></div>
                <div className="center-wrapper"><div className="sub-footer-head2"><p>HIDE/SHOW</p></div>
                  <div className="sub-footer-head3"><p>ACTIONS</p></div></div>

              </div>
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"  onClick={()=>this.setState({contactUs:false, aboutSportsHub:true , privacyPolicy: false})}><p>ABOUT SPORTS HUB</p></div>

                <div className="switch-icon-footer-block">
                  <label >
                    <Switch  className="custom-switch"
                             onChange={this.handleChange1}
                             checked={this.state.check1}
                             name = 'check1'
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
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"><p>News / In the Press</p></div>

                <div className="switch-icon-footer-block">
                  <label>
                    <Switch  className="custom-switch"
                             onChange={this.handleChange2}
                             checked={this.state.check2}
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
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"><p>Advertising / Sports Blogger Ad Network</p></div>

                <div className="switch-icon-footer-block">
                  <label>
                    <Switch  className="custom-switch"
                             onChange={this.handleChange3}
                             checked={this.state.check3}
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
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"><p>Events</p></div>

                <div className="switch-icon-footer-block">
                  <label>
                    <Switch  className="custom-switch"
                             onChange={this.handleChange4}
                             checked={this.state.check4}
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
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"  onClick={()=>this.setState({contactUs:true, aboutSportsHub:false, privacyPolicy:false})}><p>Contact Us</p></div>

                <div className="switch-icon-footer-block">
                  <label>
                    <Switch  className="custom-switch"
                             onChange={this.handleChange5}
                             checked={this.state.check5}
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
            {aboutSportsHub &&
            <div className="contact-us-a">
              <div className="footer-head">
                <div className="sub-footer-head1"><p>ABOUT SPORTS HUB</p></div>
                <div className="center-wrapper"><div className="sub-footer-head2"><p></p></div>
                  <div className="sub-footer-head3"><p></p></div></div>

              </div>
              <div className="input-wrapper-a">
                <label className="textLabelfoot">
                  <p className="txt-const">HEADLINE</p>
                  <input
                    type="text"
                    name="HeadLine"
                    className="textInput"
                    value={this.state.HeadLine}
                    onChange={this.handleInputChange}/>
                </label>
              </div>

            </div>
            }
            {contactUs &&
            <div className="contact-us">
              <div className="footer-head">
                <div className="sub-footer-head1"><p>CONTACT US</p></div>
                <div className="center-wrapper"><div className="sub-footer-head2"><p></p></div>
                  <div className="sub-footer-head3"><p></p></div></div>

              </div>
              <div className="input-wrapper">
                <label className="textLabelfoot">
                  <p className="txt-const">ADRESS</p>
                  <input
                    type="text"
                    name="HeadLine"
                    className="textInput"
                    value={this.state.HeadLine}
                    onChange={this.handleInputChange}/>
                </label>
                <label className="textLabelfoot">
                  <p className="txt-const">TEL.</p>
                  <input
                    type="text"
                    name="HeadLine"
                    className="textInput"
                    value={this.state.HeadLine}
                    onChange={this.handleInputChange}/>
                </label>
                <label className="textLabelfoot">
                  <p className="txt-const">E-MAIL</p>
                  <input
                    type="text"
                    name="HeadLine"
                    className="textInput"
                    value={this.state.HeadLine}
                    onChange={this.handleInputChange}/>
                </label>
              </div>
            </div>}
            {privacyPolicy &&
            <div className="contact-us-a">
              <div className="footer-head">
                <div className="sub-footer-head1"><p>PRIVACY AND TERMS</p></div>
                <div className="center-wrapper"><div className="sub-footer-head2"><p></p></div>
                  <div className="sub-footer-head3"><p></p></div></div>

              </div>
              <div className="input-wrapper-a">
                <label className="textLabelfoot">
                  <p className="txt-const">HEADLINE</p>
                  <input
                    type="text"
                    name="HeadLine"
                    className="textInput"
                    value={this.state.HeadLine}
                    onChange={this.handleInputChange}/>
                </label>
              </div>

            </div>
            }
            <div className="footer-block1">
              <div className="footer-head">
                <div className="sub-footer-head1"><p>PRIVACY AND TERMS</p></div>
                <div className="center-wrapper"><div className="sub-footer-head2"><p></p></div>
                  <div className="sub-footer-head3"><p></p></div></div>

              </div>
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"  onClick={()=>this.setState({contactUs:false, aboutSportsHub:false, privacyPolicy:true})}><p>Privacy policy</p></div>
              </div>
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"><p>Terms and contidions</p></div>
              </div>
            </div>

          </div>
          }
          {div2  &&
          <div className="footer-wrapper">
            <div className="footer-block">
              <div className="footer-head">
                <div className="sub-footer-head1"><p>FOOTER MENU NAMES</p></div>
                <div className="center-wrapper"><div className="sub-footer-head2"><p>HIDE/SHOW</p></div>
                  <div className="sub-footer-head3"><p>ACTIONS</p></div></div>

              </div>
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"><p>Featured Writers Program</p></div>

                <div className="switch-icon-footer-block">
                  <label >
                    <Switch  className="custom-switch"
                             onChange={this.handleChange6}
                             checked={this.state.contcheck1}
                             name = 'check1'
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
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"><p>Featured Team Writers Program</p></div>

                <div className="switch-icon-footer-block">
                  <label>
                    <Switch  className="custom-switch"
                             onChange={this.handleChange7}
                             checked={this.state.contcheck2}
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
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"><p>Internship Program</p></div>

                <div className="switch-icon-footer-block">
                  <label>
                    <Switch  className="custom-switch"
                             onChange={this.handleChange8}
                             checked={this.state.contcheck3}
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
          }
          {div3  &&
          <div className="footer-wrapper">
            <div className="footer-block">
              <div className="footer-head">
                <div className="sub-footer-head1"><p>FOOTER MENU NAMES</p></div>
                <div className="center-wrapper"><div className="sub-footer-head2"><p>HIDE/SHOW</p></div>
                  <div className="sub-footer-head3"></div></div>

              </div>
              <div className="sub-language-block">
                <div className="sub-sub-footer-block"><p>Sign up to resive latest sport news</p></div>

                <div className="switch-icon-footer-block">
                  <label >
                    <Switch  className="custom-switch"
                             onChange={this.handleChange9}
                             checked={this.state.newcheck1}
                             name = 'check1'
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

          }


        </div>

      </Fragment>
    );
  }

}
export default Footer;