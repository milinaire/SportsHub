import React, {Component, Fragment} from "react";

export class InformationArchitecture extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Information Architecture")
  }
  render() {
    return (
      <Fragment>
        InformationArchitecture
      </Fragment>
    );
  }
}
