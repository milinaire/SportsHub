import React, {Component, Fragment} from "react";

export class Banners extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Banners")
  }

  render() {
    return (
      <Fragment>
        Banners
      </Fragment>
    );
  }
}
