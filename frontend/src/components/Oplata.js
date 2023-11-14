import React, { Component } from 'react';
import axios from 'axios';

export class Oplata extends Component {
    baseUrl = 'https://localhost:7018/api/OrderControllers'
    baseUrl2 = 'https://localhost:7018/api/Order_Histori'

    constructor(props) {
        super(props);
        this.state = {
            user_id: this.props.state.id,
            card_num: '',
            CVV: '',
            card_name:'',
        };
    }

    handleSubmit = async (event) => {
        event.preventDefault();
        const lala = this.state;
        axios.post(this.baseUrl, lala);
        axios.post(this.baseUrl2+"/"+this.props.state.id)
    }
    render() {
        return (
            <div className='registration'>
                <div className='logo'>Оформление заказа</div>

                <form onSubmit={this.handleSubmit}>
                    <input placeholder='Номер карты...' onChange={data => this.setState({card_num: data.target.value})} />
                    <input placeholder='CVV-код...' onChange={data => this.setState({CVV: data.target.value})} />
                    <input placeholder='Имя владельца с карты...' onChange={data => this.setState({card_name: data.target.value})} />
                  
                    <button type='submit' onClick={this.handleSubmit}>Оплатить</button>
                </form>
            </div>
        );
    }


}

export default Oplata;
