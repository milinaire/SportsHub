import React, {Component, Fragment,} from "react";

import Select from 'react-select';
import {withRouter} from "react-router-dom";
import {Alert} from "react-bootstrap";
import Tabs from "./Tabs";
import axios from "axios";
import {GET_BANNERS} from "../../../redux/sideBar/sideBarActions";


class ArticleConstructor extends Component {
  state = {

    showAlert: false,
    AlertVariant: '',
    AlertHeader: '',
    AlertText: '',
    Conferences: [],
    Teams: [],
    AllTeams: [],
    Locations: [],
    SelectedTeam: {},
    SelectedConference: {},
    SelectedLocation: {},
    Localization: [{
      languageId: {value: 1, label: 'en'},
      Alt: '',
      HeadLine: '',
      Caption: '',
      Content: '',
    }], file: '', imagePreviewUrl: ''

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

    file?reader.readAsDataURL(file):this.setState({file:'', imagePreviewUrl:''})
  }

  componentDidMount() {
    this.props.setCurrentAdminButtonPanel(
      <Fragment>
        <button className="cancel-btn" onClick={this.props.showBox}><b>Cancel</b></button>
        <button form='new-article-form' className="save-btn" type="submit"><>Save</>
        </button>
      </Fragment>
    )
    // this.props.setBox(
    //   <Fragment>
    //     <div className="new-article-cancel-alert">
    //       <div className="new-article-cancel-alert-text">
    //         <b>Are you sure want to cancel?</b>
    //         <>If you cancel this page, all </>
    //         <>entered information will be missed!</>
    //       </div>
    //
    //       <div className="new-article-cancel-alert-btn">
    //         <button className="cancel-btn" onClick={this.props.cancelBox}>No</button>
    //         <Link to={`/admin/${this.props.match.params.category}`}>
    //           <button className="save-btn" >Yes</button>
    //         </Link>
    //       </div>
    //
    //     </div>
    //
    //   </Fragment>
    // )
    console.log(this.props.match)
    fetch("/category?languageId=1")
      .then(res => res.json())
      .then(
        (result) => {

          // this.setState({Categories: result})
          this.props.setSelectedAdminCategory(result.find(el => String(el.id) === this.props.match.params.category).name)
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
      showAlert: false
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
      showAlert: false
    })
  };

  handleInputChange = (event, index) => {
    const target = event.target;
    const value = target.value;
    const name = target.name;
    clearTimeout(this.timeout)
    this.setState({
      Localization: this.state.Localization.map((l, i) => {
        if (i === index) {
          return ({...this.state.Localization[i], [name]: value,})
        } else {
          return ({...this.state.Localization[i]})
        }
      })

    });
  }
  handleLanguageChange = (event, index, selectedOption) => {


    clearTimeout(this.timeout)
    console.log(selectedOption)
    this.setState({
      Localization: this.state.Localization.map((l, i) => {
        if (i === index) {
          return ({...this.state.Localization[i], languageId: selectedOption,})
        } else {
          return ({...this.state.Localization[i]})
        }
      })

    });
  }

  async handleSubmit(event) {
    console.log("constructor")
    event.preventDefault();
    if (!this.state.file) {
      console.log("alert")
      this.setState({
        showAlert: true,
        AlertHeader: "You got an error!",
        AlertText: `Make sure you upload photo.`,
        AlertVariant: "danger"
      })
      return;
    }
    if (!this.state.SelectedConference.value) {
      console.log("alert")
      this.setState({
        showAlert: true,
        AlertHeader: "You got an error!",
        AlertText: "Make sure you correctly choose conference!",
        AlertVariant: "danger"
      })
      return;
    }
    if (!this.state.SelectedTeam.value) {
      console.log("alert")
      this.setState({
        showAlert: true,
        AlertHeader: "You got an error!",
        AlertText: "Make sure you correctly choose team!",
        AlertVariant: "danger"
      })
      return;
    }
    for (let i = 0; i < this.state.Localization.length; i++) {
      if (!this.state.Localization[i].Alt) {
        console.log("alert")
        this.setState({
          showAlert: true,
          AlertHeader: "You got an error!",
          AlertText: `Make sure you correctly print alt! (Localization ${i + 1})`,
          AlertVariant: "danger"
        })
        return;
      }
      if (!this.state.Localization[i].HeadLine) {
        console.log("alert")
        this.setState({
          showAlert: true,
          AlertHeader: "You got an error!",
          AlertText: `Make sure you correctly print headline! (Localization ${i + 1})`,
          AlertVariant: "danger"
        })
        return;
      }
      if (!this.state.Localization[i].Caption) {
        console.log("alert")
        this.setState({
          showAlert: true,
          AlertHeader: "You got an error!",
          AlertText: `Make sure you correctly print caption! (Localization ${i + 1})`,
          AlertVariant: "danger"
        })
        return;
      }
      if (!this.state.Localization[i].Content) {
        console.log("alert")
        this.setState({
          showAlert: true,
          AlertHeader: "You got an error!",
          AlertText: `Make sure you correctly print content! (Localization ${i + 1})`,
          AlertVariant: "danger"
        })
        return;
      }
    }
    let formData = new FormData();
    formData.append("file", this.state.file);
    let imgResponse
    const img = await axios.post("/image", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    }).then(response => imgResponse = response.data);
    console.log('img', imgResponse)
    const sportArticle = {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({
        teamId: this.state.SelectedTeam.value,
        imageId: imgResponse.ImageId,
        categoryId: this.props.match.params.category,
        isPublished: false,
        datePublished: new Date().toISOString(),
        showComments: true
      })
    };
    const response = await fetch('/sportarticle', sportArticle)
    const json = await response.json()
    const id = json.ArticleId
    for (let i = 0; i < this.state.Localization.length; i++) {
      const localization = {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({
          articleId: id,
          languageId: this.state.Localization[i].languageId.value,
          headline: this.state.Localization[i].HeadLine,
          text: this.state.Localization[i].Content,
          caption: this.state.Localization[i].Caption,
          alt: this.state.Localization[i].Alt
        })
      };
      const response = await fetch(`/article/${id}/localization`, localization)
      if(response.status === 200){
        this.setState({
          showAlert: true,
          AlertHeader: "Success!",
          AlertText: `New article was successfully added.`,
          AlertVariant: "success",
          SelectedTeam: {},
          SelectedConference: {},
          Localization: [{
            languageId: {value: 1, label: 'en'},
            Alt: '',
            HeadLine: '',
            Caption: '',
            Content: '',
          }], file: '', imagePreviewUrl: ''
        })
      }
    }
  }

  constructor(props) {
    super(props);
    this.handleSubmit = this.handleSubmit.bind(this)
  }

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
        {this.state.showAlert ? (
          clearTimeout(this.timeout),
            this.timeout = setTimeout(() => {
              this.setState({showAlert: false})
            }, 10000),
            <div style={{position: "fixed", bottom: 0, right: 0, background: this.state.AlertVariant==='danger'?'red':"green"}}>
              <Alert variant={this.state.AlertVariant} onClose={() => {
                clearTimeout(this.timeout);
                this.setState({showAlert: false})
              }} dismissible>
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
            <form id='new-article-form' onSubmit={this.handleSubmit} className="textForm">
              <p className="txt-const">PICTURE*</p>
              <div className='picture'>
                <label className="customPhotoupload">
                  <div className="imgPreview">
                    {$imagePreview}
                  </div>
                  <input className="fileInput"
                         type="file"
                         onChange={(e) => this._handleImageChange(e)}/>
                </label>
              </div>
              <div className={'formSelect'}>
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
              </div>


              {/*<div className="small-select">*/}
              {/*  <p className="txt-const">LOCATION</p>*/}
              {/*  <Select*/}
              {/*    single*/}
              {/*    // options={options}*/}
              {/*    //onChange={(values) => this.onChange(values)}*/}
              {/*  />*/}
              {/*</div>*/}
              <Tabs {...this.props} Localization={this.state.Localization}
                    addTab={() => this.setState({
                      Localization: [...this.state.Localization, {
                        languageId: 1,
                        Alt: '',
                        HeadLine: '',
                        Caption: '',
                        Content: '',
                      }]
                    })} deleteTab={(index) => this.setState(
                {Localization: [...this.state.Localization.slice(0, index), ...this.state.Localization.slice(index + 1)]})}>
                {this.state.Localization.map((localization, index) => (
                  <div key={localization.languageId} label={index}>
                    <div className="small-select">
                      <p className="txt-const">LANGUAGE</p>
                      <Select
                        isDisabled={!index}
                        single
                        name="languageId"
                        options={this.props.language.languages.map(l => ({value: l.id, label: l.languageName}))}
                        onChange={(selectedOption, e) => this.handleLanguageChange(e, index, selectedOption)}
                        value={
                          this.state.Localization[index].languageId
                        }
                      />
                    </div>
                    <label className="textLabel">
                      <p className="txt-const">ALT*</p>
                      <input
                        type="text"
                        name="Alt"
                        className="textInput"
                        value={this.state.Localization[index].Alt}
                        onChange={(e) => this.handleInputChange(e, index)}/>
                    </label>
                    <label className="textLabel">
                      <p className="txt-const">ARTICLE HEADLINE*</p>
                      <input
                        type="text"
                        name="HeadLine"
                        className="textInput"
                        value={this.state.Localization[index].HeadLine}
                        onChange={(e) => this.handleInputChange(e, index)}/>
                    </label>
                    <label className="textLabel">
                      <p className="txt-const">CAPTION*</p>
                      <input
                        type="text"
                        name="Caption"
                        className="textInput"
                        value={this.state.Localization[index].Caption}
                        onChange={(e) => this.handleInputChange(e, index)}/>
                    </label>
                    <label className="textLabel">
                      <p className="txt-const">CONTENT*</p>
                      <input
                        type="text"
                        name="Content"
                        className="textInput"
                        value={this.state.Localization[index].Content}
                        onChange={(e) => this.handleInputChange(e, index)}/>
                    </label>
                  </div>
                ))}
              </Tabs>


            </form>
          </div>
        </div>
      </Fragment>

    );
  }
}

export default withRouter(ArticleConstructor)