import React, { Component } from 'react';
import Item from './Item';
import axios from 'axios';

export class Catalog extends Component {

  baseUrl='https://localhost:7018/api/Product'
  constructor(props) {
    super(props)
    this.state = {
      items:[]

    }
    this.LoadCatalog();

  }
  render() {
    return (
      <div className='catalog-wrapper'>
        <div className='catalog'>
        {this.state.items.map(el => <Item item={el} state={this.props.state}/>)}
        </div>
        <div className='news'>Тут будут новости</div>
      </div>
    )
  }
  LoadCatalog(){
    axios.get(this.baseUrl).then(res => {
      var itemDtos = [];
      res.data.forEach(element => {
        itemDtos.push({
          id: element.item_id,
          name: element.item_name,
          desc: element.item_description,
          img: element.item_img,
          price: element.item_cost
        })
      });

      this.setState({
        items: []
      }, () => this.setState({
          items: itemDtos
      }))
    })
  }
}

export default Catalog