import React, { Component } from 'react'
import axios from 'axios';

export class Item extends Component {
    baseUrl = 'https://localhost:7018/api/UserBasket';

    AddToCart() {
        if (this.props.state.isLogin) {
            console.log(this.props.item.id, this.props.state.id);
            console.log(parseInt(this.props.item.id), parseInt(this.props.state.id));
            axios.post(this.baseUrl + "/" + this.props.state.id + "," + this.props.item.id).then((response) => {
                console.log(response)
            });
        }
        if (!this.props.state.isLogin) {
            alert('Вы не вошли в профиль');
        }
    }

    render() {
        return (
            <div className='item'>
                <img alt={this.props.item.name} src={this.props.item.img} />
                <h2>{this.props.item.name}</h2>
                <p>{this.props.item.desc}</p>
                <b>{this.props.item.price}$</b>
                <div className='add-to-cart' onClick={() => this.AddToCart()}>+</div>
            </div>
        )
    }
}

export default Item