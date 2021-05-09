import React, {Component, Fragment} from "react";

export class Languages extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Languages")
  }

  render() {
    return (
      <Fragment>
        Languages
      </Fragment>
    );
  }
}
