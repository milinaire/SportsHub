import React, {Component, Fragment} from "react";
import {Link, withRouter} from "react-router-dom";
import Select from "react-select";
import AdminArticlesList from "../../../containers/Admin/Pages/Category/AdminArticlesList";


class Category extends Component {
  state = {
    Categories: [],
    Conferences: [{value: 0, label: "All Conferences"}],
    Articles: [],
    SelectedConference: {value: 0, label: "All Conferences"},
    AllTeams: [],
    Teams: [{value: 0, label: "All Teams"}],
    SelectedTeam: {value: 0, label: "All Teams"},
    PublishedOptions: [
      {value: '0', label: 'All'},
      {value: '1', label: 'Published'},
      {value: '2', label: 'Unpublished'},
    ],
    SelectedPublishedOption: {value: '0', label: 'All'},
  }
  categoryOptions = [];

  componentDidMount() {

    this.props.setCurrentAdminButtonPanel(
      <Link to={`/admin/${this.props.match.params.category}/new_article`}>
        <div style={{
          background: '#d72130',
          width: '150px',
          height: '40px',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          paddingBottom: '2px'
        }}>
          + NewArticle
        </div>
      </Link>
    )
    fetch("/category?languageId=1")
      .then(res => res.json())
      .then(
        (result) => {
          result.map(category => {
            this.categoryOptions.push({value: category.id, label: category.name.toUpperCase()})
          })
          this.setState({Categories: result})
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
          this.setState({Conferences: [{value: 0, label: "All Conferences"}].concat(options)})
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
          this.setState({AllTeams: result, Teams: [{value: 0, label: "All Teams"}].concat(options)})
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
  }

  componentWillUnmount() {
    this.props.setCurrentAdminButtonPanel(null)
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.match.params.category !== this.props.match.params.category) {
      this.props.setCurrentAdminButtonPanel(
        <Link to={`/admin/${this.props.match.params.category}/new_article`}>
          <div style={{
            background: '#d72130',
            width: '150px',
            height: '40px',
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            paddingBottom: '2px'
          }}>
            + NewArticle
          </div>
        </Link>
      )
      this.props.setSelectedAdminCategory(this.state.Categories.find(el => String(el.id) === this.props.match.params.category).name)
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

            this.setState({
              Conferences: [{value: 0, label: "All Conferences"}].concat(options),
              SelectedConference: {value: 0, label: "All Conferences"},
              SelectedPublishedOption: {value: '0', label: 'All'}
            })
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
            this.setState({
              AllTeams: result,
              Teams: [{value: 0, label: "All Teams"}].concat(options),
              SelectedTeam: {value: 0, label: "All Teams"}
            })
          },
          (error) => {
            this.setState({
              error
            });
          }
        )
    }
  }


  conferenceChange = selectedOption => {
    let options = []
    this.state.AllTeams.map(t => {
      if (t.conferenceId === selectedOption.value || selectedOption.value === 0) {
        options.push({value: t.teamId, label: t.name})
      }
    })
    this.setState({
      SelectedConference: selectedOption,
      Teams: [{value: 0, label: "All Teams"}].concat(options),
      SelectedTeam: {value: 0, label: "All Teams"}
    });

  };
  publishedOptionChange = selectedOption => {
    this.setState({SelectedPublishedOption: selectedOption});
  };
  teamChange = selectedOption => {
    let option = {}
    let options = []
    this.state.AllTeams.map(t => {
      if (t.teamId === selectedOption.value) {
        option = this.state.Conferences.find(c => c.value == t.conferenceId)
      }
    })


    if (option.value) {
      this.state.AllTeams.map(t => {
        if (t.conferenceId === option.value) {
          options.push({value: t.teamId, label: t.name})
        }
      })
      this.setState({
        SelectedTeam: selectedOption,
        SelectedConference: option,
        Teams: [{value: 0, label: "All Teams"}].concat(options)
      })
    } else {
      this.setState({SelectedTeam: selectedOption});
    }

  };

  render() {
    return (
      <Fragment>
        <div className="category-filters">
          <div className="category-filter-items">
            <Select
              single
              options={this.state.Conferences}
              value={this.state.SelectedConference}
              onChange={this.conferenceChange}
            />
          </div>
          <div className="category-filter-items">
            <Select
              single
              options={this.state.Teams}
              value={this.state.SelectedTeam}
              onChange={this.teamChange}
            />
          </div>
          <div className="category-filter-items">
            <Select
              single
              options={this.state.PublishedOptions}
              value={this.state.SelectedPublishedOption}
              onChange={this.publishedOptionChange}
            />
          </div>
        </div>
        <div>
          <AdminArticlesList category={this.props.match.params.category}
                             conference={this.state.SelectedConference.value} team={this.state.SelectedTeam.value}
                             published={this.state.SelectedPublishedOption.value}/>
        </div>
      </Fragment>
    );
  }
}

export default withRouter(Category)