import React, {Component, Fragment, useState} from "react";
import "../../AdminPage.css";
import "../../../Main/home.css"
import Select from 'react-select';
import {Link, withRouter} from "react-router-dom";
import {Alert} from "react-bootstrap";


class ArticleConstructor extends Component {
  state = {

    showAlert: false,
    AlertVariant:'',
    AlertHeader:'',
    AlertText: '',
    Conferences: [],
    Teams: [],
    AllTeams: [],
    Locations: [],
    SelectedTeam: {},
    SelectedConference: {},
    SelectedLocation: {},
    Alt: '',
    HeadLine: '',
    Caption: '',
    Content: '',
  }

  componentDidMount() {
    this.props.setButtonElem(
      <Fragment>
        <button className="cancel-btn" onClick={this.props.showBox}><b>Cancel</b></button>
        <button form='new-article-form' className="save-btn" type="submit"><>Save</></button>
      </Fragment>
    )
    this.props.setBox(
      <Fragment>
        <div className="new-article-cancel-alert">
          <div className="new-article-cancel-alert-text">
            <b>Are you sure want to cancel?</b>
            <>If you cancel this page, all </>
            <>entered information will be missed!</>
          </div>

          <div className="new-article-cancel-alert-btn">
            <button className="cancel-btn" onClick={this.props.cancelBox}>No</button>
            <Link to={`/admin/${this.props.match.params.category}`}>
              <button className="save-btn" >Yes</button>
            </Link>
          </div>

        </div>

      </Fragment>
    )
    console.log(this.props.match)
    fetch("/category?languageId=1")
      .then(res => res.json())
      .then(
        (result) => {

          // this.setState({Categories: result})
          this.props.setCurrentSection(result.find(el => String(el.id) === this.props.match.params.category).name)
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
    fetch(`conference?languageId=1&categoryId=${this.props.match.params.category}`)
      .then(res => res.json())
      .then(
        (result) => {
          let options = []
          result.map(c => {
            {
              options.push({value: c.conferenceId, label: c.name})
            }
          })
          this.setState({Conferences: options})
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
    fetch(`/team?languageId=1&categoryId=${this.props.match.params.category}`)
      .then(res => res.json())
      .then(
        (result) => {
          let options = []
          result.map(t => {
            options.push({value: t.teamId, label: t.name})
          })
          this.setState({AllTeams: result, Teams: options})
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
  }

  componentWillUnmount() {
    clearTimeout(this.timeout)
  }

  conferenceChange = selectedOption => {
    let options = []
    this.state.AllTeams.map(t => {
      if (t.conferenceId === selectedOption.value) {
        options.push({value: t.teamId, label: t.name})
      }
    })
    clearTimeout(this.timeout)
    this.setState({
      SelectedConference: selectedOption,
      Teams: options,
      SelectedTeam: {},
      showAlert:false
    });
  };
  teamChange = selectedOption => {
    let option = {}
    let options = []
    this.state.AllTeams.map(t => {
      if (t.teamId === selectedOption.value) {
        option = this.state.Conferences.find(c => c.value == t.conferenceId)
      }
    })
    this.state.AllTeams.map(t => {
      if (t.conferenceId === option.value) {
        options.push({value: t.teamId, label: t.name})
      }
    })
    clearTimeout(this.timeout)
    this.setState({
      SelectedTeam: selectedOption,
      SelectedConference: option,
      Teams: options,
      showAlert:false
    })
  };

  handleInputChange = event => {
    const target = event.target;
    const value = target.value;
    const name = target.name;
    clearTimeout(this.timeout)
    this.setState({
      [name]: value,
      showAlert:false
    });
  }

  handleSubmit = event => {
    event.preventDefault();
    if (!this.state.SelectedConference.value) {
      console.log("alert")
      this.setState({showAlert: true, AlertHeader: "You got an error!", AlertText: "Make sure you correctly choose conference!", AlertVariant: "danger"})

      return;
    }
    if (!this.state.SelectedTeam.value) {
      console.log("alert")
      this.setState({showAlert: true, AlertHeader: "You got an error!", AlertText: "Make sure you correctly choose team!", AlertVariant: "danger"})
      return;
    }
    if (!this.state.Alt) {
      console.log("alert")
      this.setState({showAlert: true, AlertHeader: "You got an error!", AlertText: "Make sure you correctly print alt!", AlertVariant: "danger"})
      return;
    }
    if (!this.state.HeadLine) {
      console.log("alert")
      this.setState({showAlert: true, AlertHeader: "You got an error!", AlertText: "Make sure you correctly print headline!", AlertVariant: "danger"})
      return;
    }
    if (!this.state.Caption) {
      console.log("alert")
      this.setState({showAlert: true, AlertHeader: "You got an error!", AlertText: "Make sure you correctly print caption!", AlertVariant: "danger"})
      return;
    }
    if (!this.state.Content) {
      console.log("alert")
      this.setState({showAlert: true, AlertHeader: "You got an error!", AlertText: "Make sure you correctly print content!", AlertVariant: "danger"})
      return;
    }
    const sportArticle = {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({
        teamId: this.state.SelectedTeam.value,
        imageId: 11,
        categoryId: this.props.match.params.category,
        isPublished: true,
        datePublished: new Date().toISOString(),
        showComments: true
      })
    };

    fetch('/sportarticle', sportArticle)
      .then(response => response.json())
      .then(data => {
        const articleLocalization = {
          method: 'POST',
          headers: {'Content-Type': 'application/json'},
          body: JSON.stringify({
            articleId: data.ArticleId,
            languageId: 1,
            headline: this.state.HeadLine,
            text: this.state.Content,
            caption: this.state.Caption,
            alt: this.state.Alt
          })
        };
        fetch(`/article/${data.ArticleId}/localization`, articleLocalization)
          .then(response => response.json())
          .then(data => data.ArticleId && this.setState({
            showAlert: true,
            AlertHeader: "Success!",
            AlertText: "New article successfully added!",
            AlertVariant: "success",
            SelectedTeam:{},
            SelectedConference:{},
            Alt: '',
            HeadLine: '',
            Caption: '',
            Content: '',
          }));
      });

  }
  // constructor(props) {
  //   super(props);
  //   this.state = {file: '', imagePreviewUrl: ''};
  // }
  //
  // _handleSubmit(e) {
  //   e.preventDefault();
  //   // TODO: do something with -> this.state.file
  //   console.log('handle uploading-', this.state.file);
  // }
  //
  // _handleImageChange(e) {
  //   e.preventDefault();
  //
  //   let reader = new FileReader();
  //   let file = e.target.files[0];
  //
  //   reader.onloadend = () => {
  //     this.setState({
  //       file: file,
  //       imagePreviewUrl: reader.result
  //     });
  //   }
  //
  //   reader.readAsDataURL(file)
  // }

  render() {

    // let {imagePreviewUrl} = this.state;
    // let $imagePreview = null;
    // if (imagePreviewUrl) {
    //   $imagePreview = (<img alt="" className="imgPreview" src={imagePreviewUrl}/>);
    // } else {
    //   $imagePreview = (
    //     <div className="previewText"><p><span style={{color: "red"}}>+Add picture </span>or drop it right here</p><p>You
    //       can add next formats: png. jpg. jpeg. tif</p></div>);
    // }

    return (

      <Fragment>
        {this.state.showAlert ? (
            clearTimeout(this.timeout),
          this.timeout = setTimeout(() => {
            this.setState({showAlert: false})
          }, 10000),
            <div style={{position: "fixed", bottom: 0, right: 0}}>
              <Alert variant={this.state.AlertVariant} onClose={() =>{clearTimeout(this.timeout); this.setState({showAlert: false})}} dismissible>
                <Alert.Heading>{this.state.AlertHeader}</Alert.Heading>
                <p>
                  {this.state.AlertText}
                </p>
              </Alert>
            </div>
        ) : null}

        <div className="const-wrap">
          <div className="photo-of-the-day-const">
            {/*<p className="txt-const">PICTURE*</p>*/}
            {/*<div className="previewComponent">*/}
            {/*  <form className="previewComponent" onSubmit={(e) => this._handleSubmit(e)}>*/}
            {/*    <label className="customPhotoupload">*/}
            {/*      <div className="imgPreview">*/}
            {/*        {$imagePreview}*/}
            {/*      </div>*/}
            {/*      <input className="fileInput"*/}
            {/*             type="file"*/}
            {/*             onChange={(e) => this._handleImageChange(e)}/>*/}
            {/*    </label>*/}
            {/*    {//<button className="submitButton"*/}
            {/*      // type="submit"*/}
            {/*      // onClick={(e)=>this._handleSubmit(e)}>Upload Image</button>//*/}
            {/*    }*/}
            {/*  </form>*/}
            {/*</div>*/}
            <form id='new-article-form'  onSubmit={this.handleSubmit} className="textForm">
              <div className="small-select">
                <p className="txt-const">CONFERENCE</p>
                <Select
                  single
                  options={this.state.Conferences}
                  onChange={this.conferenceChange}
                  value={this.state.SelectedConference}
                />
              </div>
              <div className="small-select">
                <p className="txt-const">TEAM</p>
                <Select
                  single
                  options={this.state.Teams}
                  onChange={this.teamChange}
                  value={this.state.SelectedTeam}
                />
              </div>

              {/*<div className="small-select">*/}
              {/*  <p className="txt-const">LOCATION</p>*/}
              {/*  <Select*/}
              {/*    single*/}
              {/*    // options={options}*/}
              {/*    //onChange={(values) => this.onChange(values)}*/}
              {/*  />*/}
              {/*</div>*/}


              <label className="textLabel">
                <p className="txt-const">ALT*</p>
                <input
                  type="text"
                  name="Alt"
                  className="textInput"
                  value={this.state.Alt}
                  onChange={this.handleInputChange}/>
              </label>
              <label className="textLabel">
                <p className="txt-const">ARTICLE HEADLINE*</p>
                <input
                  type="text"
                  name="HeadLine"
                  className="textInput"
                  value={this.state.HeadLine}
                  onChange={this.handleInputChange}/>
              </label>
              <label className="textLabel">
                <p className="txt-const">CAPTION*</p>
                <input
                  type="text"
                  name="Caption"
                  className="textInput"
                  value={this.state.Caption}
                  onChange={this.handleInputChange}/>
              </label>
              <label className="textLabel">
                <p className="txt-const">CONTENT*</p>
                <input
                  type="text"
                  name="Content"
                  className="textInput"
                  value={this.state.Content}
                  onChange={this.handleInputChange}/>
              </label>
            </form>
          </div>
        </div>
      </Fragment>

    );
  }
}

export default withRouter(ArticleConstructor)