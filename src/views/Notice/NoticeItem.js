import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import axios from 'axios';
import { getToken } from '../../helpers';
import ConfirmMesage from '../Message/ConfirmMessage';

class NoticeItem extends Component {
    constructor(props) {
        super(props);
        this.state = {

        };
        this.btnEditClick = this.btnEditClick.bind(this);
        this.clickHandler = this.clickHandler.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
        this.handleAccept = this.handleAccept.bind(this);
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
        this.refs.confirmMessage.open('Xác nhận xóa dữ liệu!', 'Bạn có chắc chắn muốn xóa');     
    }

    btnEditClick(){
        if (typeof this.props.onEditClick === 'function') {
            this.props.onEditClick({
                NoticeId: this.props.NoticeId,
                Title: this.props.Title,
                Content: this.props.Content,
                Url: this.props.Url
            });
        }
    }    

    handleAccept(){
        if (typeof this.props.onDeleteClick === 'function') {
            this.props.onDeleteClick(this.props.NoticeId);
        };

        this.refs.confirmMessage.setState({
            showModal: false
        });
    };

    handleCancel(){
        this.refs.confirmMessage.setState({
            showModal: false
        });
    };

    render() {

        return (            
            <div>
                <ConfirmMesage onAccept={this.handleAccept} onCancel={this.handleCancel} ref="confirmMessage"></ConfirmMesage>
                <input type="hidden" value={this.props.NoticeId} />
                <h4>{this.props.Title}</h4>
                <p>{this.props.Content}</p>
                <a href={this.props.Url} className="pull-right">go to link</a>
                <br />
                <div className="form-group">
                    <span><Button className="btn btn-primary" onClick={this.btnEditClick}>Edit</Button> </span>
                    <Button className="btn btn-primary" onClick={this.clickHandler}>Delete</Button>
                </div>
            </div>
        )
    }
}

export default NoticeItem;