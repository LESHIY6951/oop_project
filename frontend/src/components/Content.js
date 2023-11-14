import React, { Component } from 'react'
import Catalog from './Catalog'
import { Navigate, Route, Routes } from 'react-router-dom'
import Cart from './Cart'
import Profile from './Profile'
import Contacts from './Contacts'
import Registration from './Registration'
import Login from './Login'
import Order from './Order'
import Forum from './Forum'
import OrderHistory from './OrderHistory'

export class Content extends Component {
  render() {
    return (
      <div className='content'>
      <Routes>
      <Route path='/catalog' element={<Catalog state={this.props.state}/>} />
      <Route path='/cart' element={<Cart state={this.props.state}/>} />
      <Route path='/profile' element={<Profile state={this.props.state} changeLoginStatus={this.props.changeLoginStatus}/>} />
      <Route path='/contacts' element={<Contacts/>} />
      <Route path='/registration' element={<Registration changeLoginStatus={this.props.changeLoginStatus} changeID={this.props.changeID}/>} />
      <Route path='/login' element={<Login changeLoginStatus={this.props.changeLoginStatus} changeID={this.props.changeID}/>} />
      <Route path='/order' element={<Order state={this.props.state}/>} />
      <Route path='/forum' element={<Forum state={this.props.state}/>}/>
      <Route path='/order-history' element={<OrderHistory state={this.props.state}/>}/>
      <Route path='*' element={<Navigate to='/catalog' replace/>}/>
      </Routes>
      </div>
    )
  }
}

export default Content