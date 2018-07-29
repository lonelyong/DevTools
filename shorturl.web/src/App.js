import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Route,
  Link
} from 'react-router-dom';
import Home from './pages/Home';
import Document from './pages/Document';
import About from './pages/About';
import Contact from './pages/Contact';
import './content/css/App.css';
import Apis from './content/js/Apis';
class App extends Component {
  render() {
    return (      
      <Router>
        <div id='router-root'>
          <div className="topper">
            <div className="left">
                <Link to='/'>首页</Link>
                <Link to='/docs/intro'>APIs</Link>
            </div>
            <div className="right">
                <a>分享</a>
                <Link to='/about'>关于</Link>
            </div>
          </div>
          <Route exact path="/" component={Home}/>
          <Route path="/about" component={About}/>
          <Route path="/docs" component={Document}/>
          <Route path="/contact" component={Contact}/>
          <div className="footer">
            <div className="line"></div>
            <div className="linkbar">
                <a href="http://pm.tianxia.ink" target="_blank">Spm</a>|
                <a href="http://jquery-utils.hicode.net" target="_blank">Jquery-utils</a>|
                <a href="http://github.com" target="_blank">Github</a>|
                <a href="http://google.com" target="_blank">谷歌</a>|
                <a href="http://bootcdn.com" target="_blank">BootCDN</a>
            </div>
            <div className="linkbar">
                <Link to='/contact'>联系</Link>
                <Link to='/about'>关于</Link>
            </div>
          </div>  
        </div>    
      </Router>
    )
  }
}

export default App;
