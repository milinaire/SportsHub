import React, {Component, Fragment} from "react";
import "./Layout.css";
import {UpFooterPart} from "../Footer/UpFooterPart";
import {Link, Route, Switch, withRouter} from "react-router-dom";
import PageLayout from "./PageLayout";
import {NotFound} from "./NotFound";
class BaseLayout extends Component {

  render() {
    return (
      <Fragment>
        {/*{console.log(this.props.match)}*/}
        {/*<Link to={`${this.props.match.path}`}>link</Link>*/}
        <div className="main-part">
          <div className="main-content">
            <div className="content">
              <Switch>
                <Route>
                  <NotFound/>
                </Route>
              </Switch>
            </div>
          </div>
          <UpFooterPart/>
        </div>
      </Fragment>
    );
  }
}
export default withRouter(BaseLayout)