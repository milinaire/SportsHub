import React, {Component} from "react";
import {Link} from "react-router-dom";
// import "./Footer.css";

export class DownFooterPart extends Component {
  state = {
    ContactUs: {HeadLine: "Contact Us", show: true, url: "contact"},
    AboutSportHub: {HeadLine: "About SportHub", show: true, url: "about"},
    CompanyInfo: {
      title: "COMPANY INFO",
      show: true,
      sections: [
        {HeadLine: "headline", show: true, url: "1"},
        {HeadLine: "headline", show: true, url: "2"},
        {HeadLine: "headline", show: true, url: "3"},
      ],
    },
    Contributors: {
      title: "CONTRIBUTORS",
      show: true,
      contributors: [
        {HeadLine: "headline", show: true, url: "1"},
        {HeadLine: "headline", show: true, url: "2"},
        {HeadLine: "headline", show: true, url: "3"},
      ],
    },
    NewsLetter: {
      title: "NEWSLETTER",
      show: true,
      showDescription: true,
    },
  };

  render() {
    return (
      <footer>
        <div className="footer-info">
          <div className="logo">
            <Link to="/">
              <div className="footer-link">
                <div className="logo-text">
                  <p>Sports Hub</p>
                </div>
              </div>
            </Link>
          </div>
          <div className="copirating">
            <p>Copirating c 2019 SportHub</p>
            <Link to="/privacy">Privacy</Link>/<Link to="/terms">Terms</Link>
          </div>
        </div>
      </footer>
    );
  }
}
