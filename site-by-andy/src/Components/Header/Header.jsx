import React from 'react';
import './Header.css';
import { NavLink } from 'react-router-dom';

const Header = () => {
    return (
        <div className='header'>
            <NavLink to='/catalog' className='Link'>Каталог</NavLink>
            <NavLink to='/cart' className='Link'>Корзина</NavLink>
            <NavLink to='/dialog' className='Link'>Онлайн-чат</NavLink>
            <NavLink to='/profile' className='Link'>Профиль</NavLink>
            <NavLink to='/contacts' className='Link'>Контакты</NavLink>
        </div>
    )
}

export default Header;