import React, {Component} from 'react';
import NoticeList from '../Notice/NoticeList';
import {Button} from 'react-bootstrap';
import NoticeEdit from '../Notice/NoticeEdit';
import axios from 'axios';
import { getToken } from '../../helpers';

class Dashboard extends Component
{   
    constructor(props){
        super(props),
        this.state ={
            noticeId: 0                
        },
        this.showModal = this.showModal.bind(this);
        this.handleSaveNotice = this.handleSaveNotice.bind(this);    
        this.handleEdit = this.handleEdit.bind(this); 
    };

    showModal() {
        this.setState({noticeId: 0});
        this.refs.modal.setState({
            value: '',
            content: '',
            url: ''
        });
        this.refs.modal.open();     
    }

    componentDidMount() {
        var a = this.props.searchText;
    }

    handleSaveNotice(item){
        getToken(function(){
            const notice = {
                NoticeId: item.NoticeId,
                Title: item.Title,
                Content: item.Content,
                Url: item.Url
            };
            var config = {
                headers: { "Authorization": 'Bearer ' + localStorage.getItem('token') }
            };
            axios.post(
                localStorage.getItem('urlApi') + 'Notice/add',
                notice,
                config
            )
                .then((response) => {
                    this.refs.modal.close();
                    this.refs.noticeList.reloadData();
                })
                .catch(function (error) {
                    // console.log(error);
                })
                .then(function () {
                    // always executed
                });
        });        
    }

    handleEdit(item){
        this.setState({noticeId: item.NoticeId});
        this.refs.modal.setState({
            value: item.Title,
            content: item.Content,
            url: item.Url
        });
        this.refs.modal.open();   
    };

    render(){

        return(
            <div>
                <div className="form-group">
                    <h3>List notice</h3>
                    <Button className="btn btn-primary" onClick={this.showModal}>Add</Button>
                </div>                
                <NoticeEdit onAdd={this.handleSaveNotice} ref="modal" NoticeId={this.state.noticeId}></NoticeEdit>
                <NoticeList ref="noticeList" onEditClick={this.handleEdit}></NoticeList>
            </div>
        );
    }
}

export default Dashboard;