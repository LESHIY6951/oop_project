import React from 'react';
import './App.css';
import Header from './Components/Header/Header';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Catalog from './Components/Content/Catalog/Catalog';
import Cart from './Components/Content/Cart/Cart';
import Dialog from './Components/Content/Dialog/Dialog';
import Profile from './Components/Content/Profile/Profile';
import Contacts from './Components/Content/Contacts/Contacts';

const App = () => {
  return (
    <BrowserRouter>
      <div className='app-wrapper'>
        <Header />
      </div>
      <div className='content'>
        <Routes>
          <Route path='/catalog' element={<Catalog />} />
          <Route path='/cart' element={<Cart />} />
          <Route path='/dialog' element={<Dialog />} />
          <Route path='/profile' element={<Profile />} />
          <Route path='/contacts' element={<Contacts />} />
          <Route path='/*' element={<Catalog />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}
export default App;
