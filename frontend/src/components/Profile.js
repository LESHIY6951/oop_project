import React, { Component } from 'react'
import {AiFillCloseCircle} from 'react-icons/ai'
import { NavLink } from 'react-router-dom'
import axios from 'axios'


export class Profile extends Component {
baseUrl = 'https://localhost:7018/api/User'

constructor(props) {
  super(props);
  this.state = {
    user:{}
  }
  if (this.props.state.isLogin) {
    this.LoadUser();
  }
  }

  LoadUser() {
    axios.get(this.baseUrl + "/" + this.props.state.id)
    .then(response => {
      this.setState({ user: response.data });
    });
  }

  render() {
    if (!this.props.state.isLogin) {
      return (
        <div className='profile'>
          <div className='logo'>Ваш профиль</div>
          <NavLink to='/registration' className='Link'>Зарегистрироваться</NavLink>
          <NavLink to='/login' className='Link'>Войти в аккаунт</NavLink>
        </div>
      )
    }
    if (this.props.state.isLogin) {
      return (
        <div className='profile-loggedIn'>
          <img src='https://tambovcentr.ru/joomla/images/docs/icons2/unnamed.jpg'/>
          <div className='signature'>ВАШ ПРОФИЛЬ</div>
          <div className='profile-info'>
          <div className='name'>Имя: {this.state.user.name}</div>
          <div className='email'>e-mail: {this.state.user.email}</div>
          <div className='number'>Номер: {this.state.user.number}</div>
          <div className='address'>Адрес: {this.state.user.address}</div>
          </div>
          <AiFillCloseCircle className='logout' onClick={()=>this.props.changeLoginStatus(false)}/>
          <NavLink to='/forum' className='Link'>Форум</NavLink>
          <NavLink to='/order-history' className='otherLink'>История заказов</NavLink>
        </div>
      )
    }
  }
}

export default Profile