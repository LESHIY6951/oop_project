import React, { Component } from 'react'

import axios from 'axios'
import ForumPosts from './ForumPosts'


export class Forum extends Component {
    baseUrl = 'https://localhost:7018/api/Forum'

    constructor(props) {
        super(props)
        this.state = {
            Posts: [],
            message:'',
            user: {}
        }
        this.LoadForum();
    }

    LoadForum = () => {
        axios.get(this.baseUrl).then(res => {
            var loadingNotes = [];
            res.data.forEach(element => {
                loadingNotes.push({
                    forum_id: element.forum_id,
                    cert_id: element.cert_id,
                    name: element.name,
                    score: element.score,
                    text: element.text,
                    likes: element.likes,
                    dislikes: element.dislikes
                })
            });

            this.setState({
                Posts: []
            }, () => this.setState({
                Posts: loadingNotes
            }))
        })
    }
    AddMessage = () => {
        axios.post(this.baseUrl+"/"+this.props.state.id,this.state.message)
        .then(()=>this.LoadForum());
    }

    render() {
        return (
            <div className='forum'>
                <div className='signature'>ФОРУМ</div>
                <div className='addPost'>
                <input placeholder='Введите сообщение...' onChange={data => this.setState({message: data.target.value})} />
                <button onClick={() => this.AddMessage()}> Отправить</button>
                </div>
                <div className='posts'>
                    {this.state.Posts.map(el => <ForumPosts post={el} state={this.props.state} LoadForum={this.LoadForum} />)}
                </div>
            </div>
        )
    }
}

export default Forum