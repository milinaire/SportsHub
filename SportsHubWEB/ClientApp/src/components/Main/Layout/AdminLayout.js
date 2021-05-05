import React, {Component, Fragment} from "react";
import "./AdminLayout.css";
import {Route, Switch} from "react-router-dom";
import { ArticleConstructor } from "../../../containers/Admin/ArticleConstructor";
import { AdminPage } from "../../../containers/Admin/AdminPage";
import { AdminHeader } from "../AdminHeader/AdminHeader";
import ScrollToTop from "./ScrollToTop";

export class AdminLayout extends Component {

  render() {
    return (
      <Fragment>
      <AdminHeader/>
      <div className="wrap-shit">
          <Switch>
            <Route path="/admin/home">
              
               
               <AdminPage/>
            </Route>
            <Route path="/admin/article">
           
                <ArticleConstructor/>
             
            </Route>
            
          </Switch>
       </div>
      
      </Fragment>
    );
  }
}
