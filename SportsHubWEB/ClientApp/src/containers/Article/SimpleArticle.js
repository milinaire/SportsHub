import React, {Component, Fragment} from "react";
import {PageLayout} from "../../components/Main/Layout/PageLayout";

export class Article extends Component {
 constructor(props) {
   super(props);
   this.state = {Article:{}}
 }

  componentDidMount() {

    fetch(`/article`)
      .then(res => res.json())
      .then(
        (result) => {

          this.setState({
            Article: result.find(a=>String(a.articleId) === String(this.props.match.params.article))
          });

        },
        (error) => {
          this.setState({
            error
          });
        }
      )
  }



  render() {
    return (
      <Fragment>

        <PageLayout MainArticles={this.state.Article !== {} &&[this.state.Article]}>
          <div style={{padding: '50px'}}>
            <div className="text-a">
              <h3 className="text-lg-left">{this.state.Article.text}</h3>
            </div>
            <hr/>
          </div>
        </PageLayout>
      </Fragment>
    )
  }
}