import React, {Component, Fragment} from "react";
import Tabs from "./Tabs";

export class Banners extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Banners")
  }
  state ={
    tabs: [<div label="Gator">
      See ya later, <em>Alligator</em>!
    </div>]
  }

  addTab=(label)=>
  {
    const joined = this.state.tabs.concat([<div label={label}>yyy</div>])
    this.setState({ tabs: joined })
  }
  render() {
    return (
      <Fragment>
        Banners
        <Tabs addTab={this.addTab}>

          {this.state.tabs}
        </Tabs>
      </Fragment>
    );
  }
}
