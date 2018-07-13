import React, {Component} from 'react';
import NoticeList from '../Notice/NoticeList';

class Dashboard extends Component
{
    render()
    {
        return(
            <div>
                <h3>List notice</h3>
                <NoticeList></NoticeList>
            </div>
        );
    }
}

export default Dashboard;