import React, {Component, Fragment} from "react";

export class NewsPartners extends Component {
  componentDidMount() {
    this.props.setCurrentSection("News Partners")
  }

  render() {
    return (
      <Fragment>
        NewsPartners
      </Fragment>
    );
  }
}
