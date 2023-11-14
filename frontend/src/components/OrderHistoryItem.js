import React, { Component } from 'react';
import {BsTrash} from 'react-icons/bs';
import axios from 'axios';


export class OrderHistoryItem extends Component {
    render() {
        return (
            <div className='HistoryItem'>
                <img alt={this.props.item.item_name} src={this.props.item.item_img}/>
                <h2>{this.props.item.item_name}</h2>
                {/* <p>{this.props.item.desc}</p> */}
                <p className='itemCol'>Количество: {this.props.item.col}</p>
                <b>Цена: {this.props.item.item_cost}$</b>
                <b>Дата заказа: {this.props.item.date}</b>
            </div>
        )
    }
}

export default OrderHistoryItem