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
    }

    componentDidMount() {
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

    render() {
       
        const noticeComponent = this.state.result.data.map((notice) => (
            <NoticeItem key={notice.NoticeId}
                NoticeId={'product-' + notice.NoticeId}
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