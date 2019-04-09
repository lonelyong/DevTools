import React from 'react';
import '../../content/css/home/Login.css';
import AccountInfo from '../../content/js/AccountInfo';
import Apis from '../../content/js/Apis';
const setTitle = ()=> document.title = '登录';
class Login extends React.Component{
    
    componentDidMount() {
        setTitle();
    }
    componentDidUpdate() {
        setTitle();
    }
    login=()=>{
        AccountInfo.login(
            {username:this.refs.usernameInput.value, password:this.refs.passwordInput.value},
            ()=>{
                
            }, 
            (rep)=>{  
                if(Apis.isOk(rep)){
                  this.props.history.push("/home/index");
                }
            },
            (err)=>{
               
            },
            ()=>{
               
            });
    };
    render(){
        return(
            <div id='Login' className='container body-content'>
                <div className="title">
                    <label>登录</label>
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
                        <button onClick={this.login}>登录</button>
                        <button>清空</button>
                    </div>
                </div>
            </div>
        );
    }
}
export default Login;