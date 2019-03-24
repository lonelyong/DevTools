import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Route,
  Link,
  Redirect,
  Switch
} from 'react-router-dom';
import Index from './pages/home/Index';
import Document from './pages/Document';
import About from './pages/home/About';
import Contact from './pages/home/Contact';
import Login from './pages/home/Login';
import './content/css/App.css';
import Err404 from './pages/errs/Err404';
import Go from './pages/Go';
import AccountInfo from './content/js/AccountInfo';
class App extends Component {

  constructor(){
    super();
    this.updateSelf.bind(this);
    AccountInfo.loginedCallbacks.push(this.updateSelf);
  }

  logout = ()=>{
    AccountInfo.logout();
    this.forceUpdate();
  }

  updateSelf = ()=>{
    this.forceUpdate();
  };

  render() {
    return (      
      <Router>
        <div id='router-root'>
          <div className="topper">
            <div className="left">
                <Link to='/home/index'>首页</Link>
                <Link to='/docs'>APIs</Link>
            </div>
            <div className="right">
                {
                  AccountInfo.isLogined() ?
                  (<a onClick={this.logout}>注销（{AccountInfo.username()}）</a>):
                  (<Link to='/home/login'>登录</Link>)
                }
                <a>分享</a>
                <Link to='/home/about'>关于</Link>
            </div>
          </div>
          <Switch>
            <Route path="/home/index" component={Index}/>
            <Route path="/home/about" component={About}/>
            <Route path="/home/contact" component={Contact}/>
            <Route path="/home/login" component={Login}/>
            <Route path="/docs" component={Document}/>
            <Redirect exact from='' to={{pathname:'/home/index'}}/>
            <Redirect exact from='/' to={{pathname:'/home/index'}}/>
            <Redirect exact from='/home' to={{pathname:'/home/index'}}/>
            <Route from='/*/*' component={Err404}/>
            <Route exact path='/*' component={Go}/>
          </Switch>
          <div className="footer">
            <div className="line"></div>
            <div className="linkbar">
                <a href="http://pm.tianxia.ink" target="_blank">Spm</a>|
                <a href="http://jsutils.hicode.net" target="_blank">jsutils</a>|
                <a href="http://github.com" target="_blank">Github</a>|
                <a href="http://google.com" target="_blank">谷歌</a>|
                <a href="http://bootcdn.com" target="_blank">BootCDN</a>
            </div>
            <div className="linkbar">
                <Link to='/home/contact'>联系</Link>
                <Link to='/home/about'>关于</Link>
            </div>
          </div>  
        </div>    
      </Router>
    )
  }
}

export default App;
