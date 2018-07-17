import React, {Component} from 'react';
import {Button} from 'react-bootstrap';
import {getToken} from '../../helpers';

class User extends Component
{



    handleGetToken(){
        getToken(function(){
            alert("success");
        });
    };

    render()
    {
        return(
            <div>
                <Button onClick={this.handleGetToken}>Get token</Button>
            </div>
        );
    }
}

export default User;