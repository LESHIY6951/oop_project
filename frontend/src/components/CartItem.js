import React, { Component } from 'react';
import {BsTrash} from 'react-icons/bs';
import axios from 'axios';


export class CartItem extends Component {
    baseUrl = 'https://localhost:7018/api/UserBasket';
    DelettingItem(){
        axios.delete(this.baseUrl + "/" + this.props.item.id + "," + this.props.state.id)
        .then(()=> {
            this.props.LoadCart();
        });
    }
    render() {
        return (
            <div className='CartItem'>
                <img alt={this.props.item.name} src={this.props.item.img}/>
                <h2>{this.props.item.name}</h2>
                <p className='itemDesc'>описание</p>
                {/* <p>{this.props.item.desc}</p> */}
                <p className='itemCol'>Количество: {this.props.item.col}</p>
                <b>Цена: {this.props.item.price}$</b>
                <BsTrash className='trashingItem' onClick={() => this.DelettingItem()}/>
            </div>
        )
    }
}

export default CartItem