import React, { Component } from "react";
import { Link } from "react-router-dom";
import "./Footer.css";

export class UpFooterPart extends Component {
  state = {
    ContactUs: { HeadLine: "Contact Us", show: true, url: "contact" },
    AboutSportHub: { HeadLine: "About SportHub", show: true, url: "about" },
    CompanyInfo: {

      title: "COMPANY INFO",
      show: true,
      sections: [
        { HeadLine: "headline", show: true, url: "1", id:1 },
        { HeadLine: "headline", show: true, url: "2", id:2 },
        { HeadLine: "headline", show: true, url: "3", id:3 },
      ],
    },
    Contributors: {
      title: "CONTRIBUTORS",
      show: true,
      contributors: [
        { HeadLine: "headline", show: true, url: "1", id:1 },
        { HeadLine: "headline", show: true, url: "2", id:2 },
        { HeadLine: "headline", show: true, url: "3", id:3 },
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
          {this.state.CompanyInfo.show ? (
            <div className="footer-categiry">
              <h4>
                <b>{this.state.CompanyInfo.title}</b>
              </h4>
              {this.state.AboutSportHub.show ? (
                <Link to={`/${this.state.AboutSportHub.url}`}>
                  <p>{this.state.AboutSportHub.HeadLine}</p>
                </Link>
              ) : null}
              {this.state.CompanyInfo.sections.map((section) =>
                section.show ? (
                  <Link key={section.id} to={`/company-info/${section.url}`}>
                    <p>{section.HeadLine}</p>
                  </Link>
                ) : null
              )}
              {this.state.ContactUs.show ? (
                <Link to={`/${this.state.ContactUs.url}`}>
                  <p>{this.state.ContactUs.HeadLine}</p>
                </Link>
              ) : null}
            </div>
          ) : null}
          {this.state.Contributors.show ? (
            <div className="footer-categiry">
              <h4>
                <b>{this.state.Contributors.title}</b>
              </h4>
              {this.state.Contributors.contributors.map((contributor) =>
                contributor.show ? (
                  <Link key={contributor.id} to={`/contributors/${contributor.url}`}>
                    <p>{contributor.HeadLine}</p>
                  </Link>
                ) : null
              )}
            </div>
          ) : null}
          {this.state.NewsLetter.show ? (
            <div className="footer-categiry">
              <h4>
                <b>{this.state.NewsLetter.title}</b>
              </h4>
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
                  type="button"
                  value="Subscribe"
                />
              </form>
            </div>
          ) : null}
        </div>

      </footer>
    );
  }
}
