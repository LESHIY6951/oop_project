import React, { Component } from 'react'
import axios from 'axios';

export class ForumPosts extends Component {
    UrlForLikes = 'https://localhost:7018/api/Forum';
    UrlForDislikes = 'https://localhost:7018/api/Forum/dislike';

putLike =() =>{
    axios.post(this.UrlForLikes + "/" + this.props.post.forum_id)
    this.props.LoadForum();
}

putDislike = () =>{
    axios.post(this.UrlForDislikes + "/" + this.props.post.forum_id);
    this.props.LoadForum();
}
    
    render() {
        return (
            <div className='post'>
                <img src='https://tambovcentr.ru/joomla/images/docs/icons2/unnamed.jpg'/>
                <div className='postName'>{this.props.post.name}</div>
                <div className='postText'>{this.props.post.text}</div>
                <button className='btLikes' onClick={() =>this.putLike()}>Лайк</button>
                <div className='postLikes'>{this.props.post.likes}</div>
                <button className='btDislikes' onClick={()=>this.putDislike()}>Дизлайк</button>
                <div className='postDislikes'>{this.props.post.dislikes}</div>
                <div className='postScore'>Рейтинг: {this.props.post.score}</div>
            </div>
        )
    }
}

export default ForumPosts