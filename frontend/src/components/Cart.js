import React, { Component } from 'react'
import { NavLink } from 'react-router-dom'
import axios from 'axios';
import CartItem from './CartItem';
import { BsTrash } from 'react-icons/bs';


export class Cart extends Component {
  baseUrl = 'https://localhost:7018/api/UserBasket';
  userUrl = 'https://localhost:7018/api/User';
  constructor(props) {
    super(props);
    this.state = {
      cart: [],
      user: {},
      summa: 0
    }

    if (this.props.state.isLogin) {
      this.LoadUser();
      this.LoadCart();
    }
    this.LoadCart = this.LoadCart.bind(this);
  }
  LoadUser() {
    axios.get(this.userUrl + "/" + this.props.state.id)
    .then(response => {
      this.setState({ user: response.data });
    });
  }
  DelettingAllItems() {
    axios.delete(this.baseUrl + "/Clear/" + this.props.state.id)
    .then(()=> {
      this.LoadCart();
    });
  }

  LoadCart() {
    axios.get(this.baseUrl + "/" + this.props.state.id).then(res => {
      var cartLoad = [];
      let totalSumm = 0;
      res.data.forEach(element => {
        cartLoad.push({
          id: element.item_id,
          name: element.item_name,
          img: element.item_img,
          price: element.item_cost,
          col: element.col
        });
        totalSumm+=element.item_cost*element.col;
      });
      this.setState({
        cart:cartLoad,
        summa: totalSumm
      });
    });
  }

  render() {
    if (!this.props.state.isLogin) {
      return (
        <div className='cart'>
          <div className='cart-message'>Вы не вошли в свой аккаунт</div>
          <NavLink to='/profile' className='Link'>Перейти в профиль</NavLink>
        </div>
      )
    }
    if (this.props.state.isLogin) {
      return (
        <div className='cart-loggedIn'>
          <div className='cart-loggedIn-message'>Здравствуйте, {this.state.user.name}</div>
          {this.state.cart.length == 0 && (
            <div className='emptyCart'>Ваша корзина пуста</div>
          )}
         {this.state.cart.length > 0 && (
            <>
              <div className='CartItems'>
              {this.state.cart.map(el => <CartItem item={el} state={this.props.state} LoadCart={this.LoadCart}/>)}
              </div>
              <BsTrash className='trashingAllItems' onClick={() => this.DelettingAllItems()}></BsTrash>
              <NavLink to='/order' className='Link'>Перейти к оформлению заказа</NavLink>
              <div className='totalSumm'>Сумма: {this.state.summa}</div>
            </>
          )}
        </div>
      )
    }
  }
}
export default Cart