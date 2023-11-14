import React, { Component } from 'react'
import { NavLink } from 'react-router-dom'

export class Header extends Component {
  render() {
    return (
      <header>
        <div>
          <span className='logo'>Охотничья бездна</span>
          <div className='navbar'>
            <NavLink to='/catalog' className='Link' >Каталог</NavLink>
            <NavLink to='/cart' className='Link' >Корзина</NavLink>
            <NavLink to='/profile' className='Link' >Профиль</NavLink>
            <NavLink to='/contacts' className='Link' >Контакты</NavLink>
          </div>
        </div>
      </header>
    )
  }
}

export default Header