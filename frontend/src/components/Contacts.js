import React, { Component } from 'react';

export class Contacts extends Component {
  render() {
    return (
      <div className='contacts'>
      
        <iframe
          src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2243.2647838775974!2d37.596851!3d55.78864!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x46b54a0333918eb9:0xe156a25d2a9b59b8!2z0JLQsNC00LrQvtCy0YHQutC40Lkg0L_QtdGALiwgMTgg0YHRgtGA0L7QtdC90LjQtSAxLCDQnNC-0YHQutCy0LAsIDEyNzA1NQ!5e0!3m2!1sru!2sru!4v1684064759045!5m2!1sru!2sru"
          title="gg"
        ></iframe>
      
      <div className='information'>
       <div className='location'>
        г. Москва, Вадковский пер.,<br/>18 строение 1
       </div>
       <div className='number'>
        Как с нами связаться:<br/>
        +7(800)752-32-23
       </div>
       <div className='workdays'>
        График работы:<br/>
        ПН:10.00 - 21.00<br/>
        ВТ:10.00 - 21.00<br/>
        СР:10.00 - 21.00<br/>
        ЧТ:10.00 - 21.00<br/>
        ПТ:10.00 - 21.00<br/>
        СБ:10.00 - 18.00<br/>
        ВС: выходной
       </div>
      </div>
      </div>
    )
  }
}

export default Contacts;