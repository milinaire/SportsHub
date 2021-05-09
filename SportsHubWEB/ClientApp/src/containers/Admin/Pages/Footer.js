import React, {Component, Fragment} from "react";

export class Footer extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Footer")
  }

  render() {
    return (
      <Fragment>
        Footer
      </Fragment>
    );
  }
}
