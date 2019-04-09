import React from 'react';
import {
    BrowserRouter as Router,
    Route,
    Link,
    NavLink,
    Redirect,
    Switch
  } from 'react-router-dom';
  import '../content/css/Document.css';
  import Err404 from './errs/Err404.js';
  import Intro from './docs/Intro.js';
  import Rule from './docs/Rule.js';
  import Zip from './docs/Zip.js';
  import Unzip from './docs/Unzip.js';
class Document extends React.Component{
    render(){
        return(
            <div id='Document' className='container body-content'>
                <div className="nav">
                    <div className="group" data-id="rules">
                        <div className="title">
                            <i className="fa fa-caret-down">&nbsp;</i>
                            <label>细则</label>
                        </div>
                        <NavLink to='/docs/intro' activeClassName="active">
                            <div>接口说明</div>
                        </NavLink>
                        <NavLink to='/docs/rule' activeClassName="active">                        
                            <div>接口规则</div>
                        </NavLink>
                    </div>
                    <div className="group" data-id="api">
                        <div className="title">
                            <i className="fa fa-caret-down">&nbsp;</i>
                            <label>Api列表</label>
                        </div>
                        <NavLink to='/docs/zip' activeClassName="active">
                            <div>链接缩短</div>
                        </NavLink>
                        <NavLink to='/docs/unzip' activeClassName="active">
                            <div>链接还原</div>
                        </NavLink>
                    </div>
                </div>
                <Switch>
                    <Route path="/docs/intro" component={Intro}/>
                    <Route path="/docs/rule" component={Rule}/>
                    <Route path="/docs/zip" component={Zip}/>
                    <Route path="/docs/unzip" component={Unzip}/>
                    <Redirect exact from='/docs' to={{pathname:'/docs/intro'}}/>
                    <Route path="/docs/*" component={Err404}/>
                </Switch>
            </div>           
        );
    }
}
export default Document;