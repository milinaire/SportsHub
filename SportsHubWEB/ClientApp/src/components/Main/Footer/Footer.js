import React, { Component } from "react";
import "./Footer.css";
import { NavLink, Row } from "reactstrap";

export class Footer extends Component {
  state = {
    showCompanyInfo: true,
    showContybutors: true,
    showNewsLetter: true,
    CompanyInfoSections:[
      {HeadLine:"About SportHub", show:true, url:"about"},
      {HeadLine:"headline", show:true, url:"1"},
      {HeadLine:"headline", show:true, url:"2"},
      {HeadLine:"headline", show:true, url:"3"},
      {HeadLine:"Contact Us", show:true, url:"contact"},
      
    ]
  };
  render() {
    return (
      <footer>
        <div className={"footer-categiries"}>
          {this.state.showCompanyInfo ? (
            <div className="footer-categiry">
              <h3>
                <b>COMPANY INFO</b>
              </h3>
              {this.state.CompanyInfoSections.map(section=>
              section.show?
              <a href={`/companyinfo/${section.url}`}><p>{section.HeadLine}</p></a>
              
              :null
                )}
            </div>
          ) : null}
          {this.state.showContybutors ? (
            <div className="footer-categiry">
              <h3>
                <b>CONTRIBUTORS</b>
              </h3>
            </div>
          ) : null}
          {this.state.showNewsLetter ? (
            <div className="footer-categiry">
              <h3>
                <b>NEWSLETTER</b>
              </h3>
            </div>
          ) : null}
        </div>
        <div className={"footer-info"}>
          <div className="logo">
            <a href="/">
              <div className="footer-link">
                <div className="logo-text">
                  <a href="/">
                    <p>Sports Hub</p>
                  </a>
                </div>
              </div>
            </a>
          </div>
          <div className="copirating">
            <p>Copirating c 2019 SportHub</p>
            <a href="/privacy">Privacy</a>/<a href="/terms">Terms</a>
          </div>
        </div>
      </footer>
    );
  }
}
