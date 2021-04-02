import React, { Component } from "react";
import "./Footer.css";
import { NavLink, Row } from "reactstrap";

export class Footer extends Component {
  state = {
    ContactUs:{ HeadLine: "Contact Us", show: true, url: "contact" },
    AboutSportHub:{ HeadLine: "About SportHub", show: true, url: "about" },
    CompanyInfo: {
      title: "COMPANY INFO",
      show: true,
      sections: [
        
        { HeadLine: "headline", show: true, url: "1" },
        { HeadLine: "headline", show: true, url: "2" },
        { HeadLine: "headline", show: true, url: "3" },
        
      ],
    },
    Contributors: {
      title: "CONTRIBUTORS",
      show: true,
      contributors: [
        { HeadLine: "headline", show: true, url: "1" },
        { HeadLine: "headline", show: true, url: "2" },
        { HeadLine: "headline", show: true, url: "3" },
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
        <div className={"footer-categiries"}>
          {this.state.CompanyInfo.show? (
            <div className="footer-categiry">
              <h3>
                <b>{this.state.CompanyInfo.title}</b>
              </h3>

              { this.state.AboutSportHub.show ? (
                      <a href={`/${this.state.AboutSportHub.url}`}>
                        <p>{this.state.AboutSportHub.HeadLine}</p>
                      </a>
                    ) 
                  : null}
                { this.state.CompanyInfo.sections.map((section) =>
                    section.show ? (
                      <a href={`/companyinfo/${section.url}`}>
                        <p>{section.HeadLine}</p>
                      </a>
                    ) 
                  : null)}
                  { this.state.ContactUs.show ? (
                      <a href={`/${this.state.ContactUs.url}`}>
                        <p>{this.state.ContactUs.HeadLine}</p>
                      </a>
                    ) 
                  : null}
            </div>
            
          ) : null}
          {this.state.Contributors.show ? (
            <div className="footer-categiry">
              <h3>
                <b>{this.state.Contributors.title}</b>
              </h3>
              {this.state.Contributors.contributors.map((contributor) =>
                contributor.show ? (
                  <a href={`/contributors/${contributor.url}`}>
                    <p>{contributor.HeadLine}</p>
                  </a>
                ) : null
              )}
            </div>
          ) : null}
          {this.state.NewsLetter.show ? (
            <div className="footer-categiry">
              <h3>
                <b>{this.state.NewsLetter.title}</b>
              </h3>
              {this.state.NewsLetter.showDescription ? (
                <h6>Sign up to receive the latest sport news</h6>
              ) : null}
              <form>
                <input
                  className="input-email"
                  type="email"
                  name="email"
                  placeholder="Your email address"
                />
                <input
                  className="submit-email"
                  type="submit"
                  value="Subscribe"
                />
              </form>
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
