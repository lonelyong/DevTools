import React from 'react';

class Intro extends React.Component{
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