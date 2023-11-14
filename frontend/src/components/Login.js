import React, { Component } from 'react';
import axios from 'axios';


export class Login extends Component {
    baseUrl = 'https://localhost:7018/api/User'

    constructor(props) {
        super(props);
        this.state = {
            login: '',
            password: '',
        };
        this.users = [];
      }
    
      handleSubmit = () => {
        axios.get(this.baseUrl).then((response) => {
          this.users = response.data;
        });
    
        const authenticatedUser = this.users.find(
          (u) => u.login === this.state.login && u.password === this.state.password
        );
    
        if (authenticatedUser) {
          this.props.changeID(authenticatedUser.id);
          this.props.changeLoginStatus(true);
        } else {
          alert('Incorrect username or password');
        }
      };
    
      render() {
        return (
            <div className='login'>
                <div className='logo'>Авторизация</div>

                <input placeholder='Логин...' onChange={data => { this.setState({ login: data.target.value }); console.log(this.state) }} />
                <input placeholder='Пароль...' onChange={data => { this.setState({ password: data.target.value }); console.log(this.state) }} />

                <button type='submit' onClick={()=>this.handleSubmit()}>Войти</button>

            </div>
        );
    }
}

export default Login;
