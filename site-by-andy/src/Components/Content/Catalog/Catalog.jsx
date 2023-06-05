import React from 'react';
import './Catalog.css';

const Catalog = () => {
    return (
        <div className='catalog'>
            <Products />
            <News/>
        </div>
    )
}

const Products = () => {
    return (
        <div className='products'>
            <div>Сам каталог</div>
        </div>
    )
}
const News = () => {
    return (
        <div className='news'>
            <div>Новости</div>
        </div>
    )
}

export default Catalog;