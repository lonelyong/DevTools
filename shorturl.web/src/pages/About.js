import React from 'react';
import '../content/css/About.css';
const setTitle = ()=> document.title = '关于';
class About extends React.Component{
    
    componentDidMount() {
        setTitle();
    }
    componentDidUpdate() {
        setTitle()
    }
    render(){
        return(
            <div id='About' className='container body-content'>
                <div className="title">
                    <label>ABOUT</label>
                </div>
                <div className="section">
                    <div className="title">
                        <label>IMPORTANT!</label>
                    </div>
                    <div className="content">
                        <label>本网站所有功能免费使用，请勿用于生产环境，使用本网站所造成的一切损失自负。</label>
                    </div>
                </div>
            </div>
        );
    }
}
export default About;