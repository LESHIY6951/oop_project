import React, { Component } from 'react';
import axios from 'axios';

export class Registration extends Component {
    baseUrl = 'https://localhost:7018/api/User'

    constructor(props) {
        super(props);
        this.state = {
            login: '',
            password: '',
            name: '',
            cert_id: '',
            email: '',
            number: '',
            address: ''
        };
    }

    
    handleSubmit = async (event) => {
        event.preventDefault();
        const lala = this.state;
        axios.post(this.baseUrl, lala)
        .then((response) => {
            if(response.data === 'login zan'){
                alert('Данный логин занят');
            }
            else if(response.data === 'sert zan') {
                alert('Данный сертификат занят');
            }
            else {
                alert('Вы успешно зарегались');
                this.props.changeID(response.data.id);
                this.props.changeLoginStatus(true);
            }
          })
          .catch((error) => console.log(error))
        
      };

    
      render() {
    

        return (
            <div className='registration'>
                <div className='logo'>Регистрация</div>
                <form onSubmit={this.handleSubmit}>
                    <input placeholder='Логин...' onChange={data => this.setState({login: data.target.value})} />
                    <input placeholder='Пароль...' onChange={data => this.setState({password: data.target.value})} />
                    <input placeholder='ФИО...' onChange={data => this.setState({name: data.target.value})} />
                    <input placeholder='Номер сертификата...' onChange={data => this.setState({cert_id: data.target.value})} />
                    <input placeholder='e-mail...' onChange={data => this.setState({email: data.target.value})} />
                    <input placeholder='Номер телефона...' onChange={data => this.setState({number: data.target.value})} />
                    <input placeholder='Адрес...' onChange={data => this.setState({address: data.target.value})} />
                    <button type='submit' onClick={this.handleSubmit}>Зарегистрироваться</button>
                </form>
            </div>
        );
    }


}

export default Registration;
