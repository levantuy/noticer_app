import moment from 'moment';
import axios from 'axios';

export function getToken(callback) {    
    var expirationDate = localStorage.getItem('expirationDate');        
    if (expirationDate == 'undefined' || expirationDate == null || expirationDate == '' || moment().isAfter(expirationDate, 'second')) {
        // Optionally the request above could also be done as
        axios.get(localStorage.getItem('urlApi') + 'Token', {
            params: {
                username: 'admin',
                password: '123456'
            }
        })
            .then((response) => {
                localStorage.setItem("token", response.data.Token);
                localStorage.setItem("expirationDate", response.data.Expiration);
                callback();
            })
            .catch(function (error) {
                // console.log(error);
            })
            .then(function () {
                // always executed
            });            
    }
  }