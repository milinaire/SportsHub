import React, {Component, Fragment} from "react";

export class Advertising extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Advertising")
  }

  render() {
    return (
      <Fragment>
        Advertising
      </Fragment>
    );
  }
}
