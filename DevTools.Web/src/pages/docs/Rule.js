import React from 'react';
const setTitle = ()=> document.title = '文档-接口规则';
class Rule extends React.Component{
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
                    <label>接口规则</label>
                </div>
                <div className="section">
                    <div className="title"><label>规则列表</label></div>
                    <div className="content">
                        <table>
                            <thead>
                                <tr>
                                    <td>名称</td>
                                    <td>描述</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>传输规则</td>
                                    <td>当前支持HTTP，HTTPS传输，未来可能只支持HTTPS传输</td>
                                </tr>
                                <tr>
                                    <td>提交方式</td>
                                    <td>POST提交，支持AJAX</td>
                                </tr>
                                <tr>
                                    <td>数据格式</td>
                                    <td>JSON</td>
                                </tr>
                                <tr>
                                    <td>字符编码</td>
                                    <td>UTF-8</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        );
    }
}
export default Rule;