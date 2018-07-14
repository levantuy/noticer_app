import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import axios from 'axios';
import { getToken } from '../../helpers';

class NoticeItem extends Component {
    constructor(props) {
        super(props);
        this.state = {

        };
        // this.handleDelete = this.handleDelete.bind(this);
        this.clickHandler = this.clickHandler.bind(this);
    }

    handleChildDelete() {
        getToken();
        var config = {
            headers: { "Authorization": 'Bearer ' + localStorage.getItem('token') }
        };
        axios.delete(localStorage.getItem('urlApi') + 'Notice/delete?noticeId=' + this.props.NoticeId, config)
            .then((response) => {
                this.setState({ showModal: false });
            })
            .catch(function (error) {
                // console.log(error);
            })
            .then(function () {
                // always executed
            });    
    };

    clickHandler(){
        if (typeof this.props.onDeleteClick === 'function') {
            this.props.onDeleteClick(this.props.NoticeId);
        }
    }

    render() {
        return (
            <div>
                <input type="hidden" value={this.props.NoticeId} />
                <h4>{this.props.Title}</h4>
                <p>{this.props.Content}</p>
                <a href={this.props.Url}>website</a>
                <br />
                <div className="form-group">
                    <span><Button className="btn btn-primary">Edit</Button> </span>
                    <Button className="btn btn-primary" onClick={this.clickHandler}>Delete</Button>
                </div>
            </div>
        )
    }
}

export default NoticeItem;