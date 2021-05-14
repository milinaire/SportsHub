import React, {Component, Fragment} from "react";
import axios from "axios";


export class Advertising extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Advertising")
  }
  
  constructor(props) {
    super(props);
    this.state = {file: '', imagePreviewUrl: ''};
  }

  _handleSubmit(e) {
    e.preventDefault();
    // TODO: do something with -> this.state.file
      let formData = new FormData();

      formData.append("file", this.state.file);

      axios.post("/image", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      }).then(response => console.log(response.data));
    
    /*const formData = new FormData()
    formData.append('myFile', this.state.file)
    const image = {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: formData
    }
    fetch('/image', image)
        .then(response => response.json())
        .then(data => {
          console.log(data);
        });
    console.log('handle uploading-', this.state.file);*/
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
      $imagePreview = (<img alt="" className="imgPreview" src={imagePreviewUrl}/>);
    } else {
      $imagePreview = (
        <div className="previewText"><p><span style={{color: "red"}}>+Add picture </span>or drop it right here</p><p>You
          can add next formats: png. jpg. jpeg. tif</p></div>);
    }
    return (
      <Fragment>
        <p className="txt-const">PICTURE*</p>
        <div className="previewComponent">
          <form className="previewComponent" onSubmit={(e) => this._handleSubmit(e)}>
            <label className="customPhotoupload">
              <div className="imgPreview">
                {$imagePreview}
              </div>
              <input className="fileInput"
                     type="file"
                     onChange={(e) => this._handleImageChange(e)}/>
            </label>
            <button className="submitButton"
               type="submit"
                onClick={(e)=>this._handleSubmit(e)}>Upload Image
            </button>
            
          </form>
        </div>
      </Fragment>
    );
  }
}
