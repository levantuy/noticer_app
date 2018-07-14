import React, { Component } from 'react';
import NoticeItem from './NoticeItem';
import {getToken} from '../../helpers';
import axios from 'axios';

class NoticeList extends Component {
    constructor(props) {
        super(props);
        this.state = {        
            result:{
                data:[],
                success: 'true',
                message:'success'
            }    
        };
        this.reloadData = this.reloadData.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);
    }
    
    componentDidMount() {
        this.reloadData();
    }

    reloadData(){
        getToken();
        // Optionally the request above could also be done as
        axios.get(localStorage.getItem('urlApi') + 'Notice/index', {
            params: {
            },
            headers: {
                "Authorization" : 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then((response) => {
                this.setState({ result: response.data });
            })
            .catch(function (error) {
                // console.log(error);
            })
            .then(function () {
                // always executed
            });
    }

    handleDelete(noticeId){
        getToken();
        var config = {
            headers: { "Authorization": 'Bearer ' + localStorage.getItem('token') }
        };
        axios.delete(localStorage.getItem('urlApi') + 'Notice/delete?noticeId=' + noticeId, config)
            .then((response) => {
                this.setState({ showModal: false });
                this.reloadData();
            })
            .catch(function (error) {
                // console.log(error);
            })
            .then(function () {
                // always executed
            });                    
    };

    handleEdit(item){
        if (typeof this.props.onEditClick === 'function') {
            this.props.onEditClick(item);
        }
    };

    render() {
       
        const noticeComponent = this.state.result.data.map((notice) => (
            <NoticeItem onDeleteClick={this.handleDelete} onEditClick={this.handleEdit} key={notice.NoticeId}
                NoticeId={notice.NoticeId}
                Title={notice.Title}
                Content={notice.Content}
                Url={notice.Url}
            />
        ));

        return (
            <div>
                {noticeComponent}
            </div>
        )
    }
}

export default NoticeList;