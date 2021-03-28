import React, {Component, Fragment} from 'react';

export class SubCategoryArticles extends Component {
    render() {
        return (
            <Fragment>
                <div style={{minHeight:"1000px"}}>
                {this.props.match.params.category}>
                    {this.props.match.params.subcategory}
                </div>
            </Fragment>

        )
    }
}