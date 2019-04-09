import React from 'react';
const setTitle = ()=> document.title = '404';
import '../../content/css/Error.css';
class Err404 extends React.Component{
    
    componentDidMount() {
        setTitle();
    }
    componentDidUpdate() {
        setTitle()
    }
    render(){
        return(
            <div className="err-container">
                <label className="err-404">对不起，您访问的页面不存在</label>
            </div>
        );
    }
}
export default Err404;