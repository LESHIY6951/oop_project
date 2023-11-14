import React from 'react'
import Header from './components/Header';
import Content from './components/Content';
import { BrowserRouter } from 'react-router-dom';



class App extends React.Component {
  constructor(props) {
    super(props)
    this.state={
      isLogin:false,
      userCart: [],
      id:''
    }
  }
  changeID = (status) => {
    this.setState({id: status});
  }

  changeLoginStatus = (status) => {
    this.setState({ isLogin: status });
  };
 
  render() {
    return (
      <BrowserRouter>
      <div className='wrapper'>
        <Header/>
        <Content state={this.state} changeLoginStatus={this.changeLoginStatus} changeID={this.changeID}/>
      </div>
      </BrowserRouter>
    )
  }
}



export default App;
