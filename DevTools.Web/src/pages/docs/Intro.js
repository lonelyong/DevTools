import React from 'react';
const setTitle = ()=> document.title = '文档-接口说明';
class Intro extends React.Component{
    componentDidMount() {
        setTitle();
    }
    componentDidUpdate() {
        setTitle()
    }
    render(){
        return(
            <div className='doc-body'>
                <div className="doc-title">
                    <label>文档说明</label>
                </div>
                <div className="section">
                    <div className="title"><label>开心一下</label></div>
                    <div className="content">懂得前端开发的开发者可在几分钟内读完并掌握api调用</div>
                </div>
            </div>
        );
    }
}
export default Intro;