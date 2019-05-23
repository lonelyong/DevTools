import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Route,
  Link,
  Redirect,
  Switch
} from 'react-router-dom';
import SLink from './pages/tabs/url/SLink';
import SLinkGo from './pages/tabs/url/SLinkGo';
import About from './pages/home/About';
import Contact from './pages/home/Contact';
import Login from './pages/account/Login';
import Signup from './pages/account/Signup';
import Err404 from './pages/errs/Err404';
import AccountInfo from './content/js/AccountInfo';
class App extends Component {

  constructor(){
    super();
    this.updateSelf.bind(this);
    AccountInfo.regesterLogined(this.updateSelf);
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
        <div id='router-root' className='d-flex flex-column align-content-stretch flex-grow-1'>
          <div className="topper">
            <div className="container d-flex flex-row justify-content-between align-content-center pt-2 pb-2 flex-shrink-0">
              <div className="left">
                  <Link to='/slink'>首页</Link>
                  <a href="https://api.link.hicode.net">APIs</a>
              </div>
              <div className="right">
                  {
                    AccountInfo.isLogined() ?
                    (<a onClick={this.logout}>注销（{AccountInfo.username()}）</a>):
                    (<Link to='/account/login'>登录</Link>)
                  }
                  {
                    !AccountInfo.isLogined() && <Link to='/account/signup'>注册</Link>
                  }
                  <a>分享</a>
                  <Link to='/home/about'>关于</Link>
              </div>
            </div>
          </div>
          <div className="container d-flex flex-column flex-grow-1" id="body-content-wrap">
            <Switch>
                <Route path="/slink" component={SLink}/>
                <Route path="/home/about" component={About}/>
                <Route path="/home/contact" component={Contact}/>
                <Route path="/account/login" component={Login}/>
                <Route path="/account/signup" component={Signup}/>
                <Redirect exact from='' to={{pathname:'/slink'}}/>
                <Redirect exact from='/' to={{pathname:'/slink'}}/>
                <Redirect exact from='/home' to={{pathname:'/slink'}}/>
                <Route from='/*/*' component={Err404}/>
                <Route exact path='/*' component={SLinkGo}/>
              </Switch>
          </div>
          <div className="container footer pt-2 pb-2">
            <hr className="hr-line-dashed"></hr>
            <div className="d-flex justify-content-center">
                <a href="http://pm.tianxia.ink" target="_blank">Spm</a>|
                <a href="http://jsutils.hicode.net" target="_blank">jsutils</a>|
                <a href="http://github.com" target="_blank">Github</a>|
                <a href="http://google.com" target="_blank">谷歌</a>|
                <a href="http://bootcdn.com" target="_blank">BootCDN</a>
            </div>
            <div className="d-flex justify-content-center">
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
