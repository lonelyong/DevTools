import React from 'react';
import AccountInfo from '../../content/js/AccountInfo';
import Apis from '../../content/js/Apis';
const setTitle = ()=> document.title = '注册';
class Login extends React.Component{
    
    componentDidMount() {
        setTitle();
    }
    componentDidUpdate() {
        setTitle();
    }
    signin=()=>{
        AccountInfo.signup(
            {
                username:this.refs.usernameInput.value, 
                password:this.refs.passwordInput.value,
                email:this.refs.emailInput.value,
                nickname:this.refs.nicknameInput.value
            },
            ()=>{
                
            }, 
            (rep)=>{  
                if(Apis.isOk(rep)){
                  this.props.history.push("/home/login");
                }
            },
            (err)=>{
               
            },
            ()=>{
               
            });
    };
    render(){
        return(
            <div id='Login' className='body-content'>
                <div className="title">
                    <label>注册</label>
                </div>
                <div className="section">
                    <div className="title">
                        <label>用户</label>
                        <input ref='usernameInput' type='text' defaultValue='onlyong' />
                    </div>
                    <div className="title">
                        <label>密码</label>
                        <input ref='passwordInput' type='text' defaultValue='123456' />
                    </div>
                    <div className="title">
                        <label>邮箱</label>
                        <input ref='emailInput' type='text' defaultValue='admin@google.com' />
                    </div>
                    <div className="title">
                        <label>昵称</label>
                        <input ref='nicknameInput' type='text' defaultValue='Tom' />
                    </div>
                    <div className="title">
                        <button onClick={this.signin}>注册</button>
                        <button>清空</button>
                    </div>
                </div>
            </div>
        );
    }
}
export default Login;