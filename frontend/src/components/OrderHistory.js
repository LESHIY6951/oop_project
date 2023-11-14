import React, { Component } from 'react'
import axios from 'axios';
import OrderHistoryItem from './OrderHistoryItem';


export class OrderHistory extends Component {
  baseUrl = 'https://localhost:7018/api/Order_Histori';
  constructor(props) {
    super(props);
    this.state = {
      history: []
    }
    this.LoadHistory();
  }
  LoadHistory() {
    axios.get(this.baseUrl + "/" + this.props.state.id)
    .then(response => {
      this.setState({ history: response.data });
    });
  }

  render() {
      return (
        <div className='orderHistory'>
            <div className='orderHistory-logo'>История заказов</div>
            {this.state.history.length == 0 && (
            <div className='emptyHistory'>Вы пока ничего не заказывали</div>
          )}
            {this.state.history.length > 0 && (
            
            <div className='orderItems'>
                 {this.state.history.map(el => <OrderHistoryItem item={el}/>)}
            </div>
          )}
        </div>
      )
    }
}
export default OrderHistory