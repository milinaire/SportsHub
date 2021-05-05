import React, {Component, Fragment} from "react";
import {AdminLayout} from "../../components/Main/Layout/AdminLayout";
import "./AdminPage.css";
import  "../../containers/Main/home.css"
import Select from 'react-dropdown-select';

export class ArticleConstructor extends Component {

    constructor(props) {
      super(props);
      this.state = {file: '',imagePreviewUrl: ''};
    }

    _handleSubmit(e) {
      e.preventDefault();
      // TODO: do something with -> this.state.file
      console.log('handle uploading-', this.state.file);
    }

    _handleImageChange(e) {
      e.preventDefault();

      let reader = new FileReader();
      let file = e.target.files[0];

      reader.onloadend = () => {
        this.setState({
          file: file,
          imagePreviewUrl: reader.result
        });
      }

      reader.readAsDataURL(file)
    }

    render() {
      
      let {imagePreviewUrl} = this.state;
      let $imagePreview = null;
      if (imagePreviewUrl) {
        $imagePreview = (<img className="imgPreview" src={imagePreviewUrl} />);
      } else {
        $imagePreview = (<div className="previewText"><p><span style={{color: "red"}}>+Add picture </span>or drop it right here</p><p>You can add next formats: png. jpg. jpeg. tif</p></div>);
      }
  
      return (
  
        <Fragment>
         
          <AdminLayout>
           
          <div className="const-wrap">
              
            
              <div className="photo-of-the-day-const">
                  
                  <p className="txt-const">PICTURE*</p>
                  <div className="previewComponent">
                      
                      <form  className="previewComponent" onSubmit={(e)=>this._handleSubmit(e)}>
                          <label className="customPhotoupload">
                          <div className="imgPreview">
                            {$imagePreview}
                          </div>
                            <input className="fileInput" 
                            type="file" 
                            onChange={(e)=>this._handleImageChange(e)} />
                          </label>
                          
                        {//<button className="submitButton" 
                         // type="submit" 
                         // onClick={(e)=>this._handleSubmit(e)}>Upload Image</button>//
                        }
                        
                      </form>
                     
                    
                   </div>
                   <form className="textForm">
                        <div className="small-select">
                            <p className="txt-const">CONFERENCE</p>
                                <Select
                                    multi
                                    // options={options}
                                    onChange={(values) => this.onChange(values)}
                                    />
                            </div>
                            <div className="small-select">
                            <p className="txt-const">TEAM</p>
                            <Select
                                    multi
                                    // options={options}
                                    onChange={(values) => this.onChange(values)}
                                    />
                            </div>
                            <div className="small-select">
                            <p className="txt-const">LOCATION</p>
                            <Select
                                    multi
                                    // options={options}
                                    onChange={(values) => this.onChange(values)}
                                    />
                            </div>
                            
                        <label className="textLabel">
                        <p className="txt-const">ALT*</p>
                          <input type="text" name="name" className="textInput" />
                        </label>
                        <label className="textLabel">
                        <p className="txt-const">ARTICLE HEADLINE*</p>
                          <input type="text" name="name" className="textInput" />
                        </label>
                        <label className="textLabel">
                        <p className="txt-const">CAPTION*</p>
                          <input type="text" name="name" className="textInput" />
                        </label>
                        <label className="textLabel">
                        <p className="txt-const">AUTHOR*</p>
                          <input type="text" name="name" className="textInput" />
                        </label>
                    </form>

              </div>
            
              
               

            </div>
          </AdminLayout>
          
           
          
        </Fragment>
  
      );
    }
}