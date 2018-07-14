import React, {Component} from 'react';
import NoticeList from '../Notice/NoticeList';
import {Button} from 'react-bootstrap';
import NoticeEdit from '../Notice/NoticeEdit';


class Dashboard extends Component
{   
    constructor(props){
        super(props),
        this.state ={
            noticeId: 0                
        },
        this.showModal = this.showModal.bind(this);     
    };

    showModal() {
        this.setState({noticeId: 1});
        this.refs.modal.open();        
    }

    render()
    {
        return(
            <div>
                <div className="form-group">
                    <h3>List notice</h3>
                    <Button className="btn btn-primary" onClick={this.showModal}>Add</Button>
                </div>                
                <NoticeEdit onAdd={this.handleAddClick} ref="modal" NoticeId={this.state.noticeId}></NoticeEdit>
                <NoticeList></NoticeList>
            </div>
        );
    }
}

export default Dashboard;