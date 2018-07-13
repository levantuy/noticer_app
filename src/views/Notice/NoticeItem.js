import React, {Component} from 'react';

class NoticeItem extends Component{
    constructor(props) {
        super(props);
        this.state = {

        }
    }

    render()
    {
        return(
            <div>
                <h4>{this.props.NoticeId}</h4>
                <p>{this.props.Title}</p>
                <p>{this.props.Content}</p>
                <a href={this.props.Url}>website</a>
            </div>
        )
    }
}

export default NoticeItem;