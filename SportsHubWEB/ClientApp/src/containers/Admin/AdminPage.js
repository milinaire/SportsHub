import React, {Component, Fragment} from "react";
import {AdminLayout} from "../../components/Main/Layout/AdminLayout";
import "./AdminPage.css"

export class AdminPage extends Component {
   
    render() {
      
  
  
      return (
  
        <Fragment>
         
          <AdminLayout>
           
          <div className="const-wrap">
              <div className="main-a-const"></div>
              <div className="breakdown-const"></div>
              <div className="photo-of-the-day-const"></div>
              <div className="mots-sec-const"></div>
            </div>
          </AdminLayout>
          
           
          
        </Fragment>
  
      );
    }
}