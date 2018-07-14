import React, {Component} from 'react';
import {Button} from 'react-bootstrap';

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
                <br/>
                <div className="form-group">
                    <span><Button className="btn btn-primary">Edit</Button> </span>                    
                    <Button className="btn btn-primary">Delete</Button>
                </div>
            </div>
        )
    }
}

export default NoticeItem;