import React, {Component, Fragment} from "react";

export class Surveys extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Surveys")
  }

  render() {
    return (
      <Fragment>
        Surveys
      </Fragment>
    );
  }
}
