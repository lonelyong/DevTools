import React from 'react';
import Configs from '../../content/js/Configuration';
const setTitle = ()=> document.title = '文档-还原链接';
class Unzip extends React.Component{
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
                    <label>还原URL</label>
                </div>
                <div className="section">
                    <div className="title">
                        <label>应用场景</label>
                    </div>
                    <div className="content">
                        需要将短链接转换为长链接时
                    </div>
                </div>
                <div className="section">
                    <div className="title">
                        <label>接口链接</label>
                    </div>
                    <div className="content">
                        <a target="_blank" href={Configs.apiHost}>{Configs.apiHost}/api/unzip</a>
                    </div>
                </div>
                <div className="section">
                    <div className="title">
                        <label>参数列表</label>
                    </div>
                    <div className="content">
                        <table>
                            <thead>
                                <tr>
                                    <td>参数名</td>
                                    <td>类型</td>
                                    <td>是否必须</td>
                                    <td>描述</td>
                                    <td>示例</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>surl</td>
                                    <td>String(32)</td>
                                    <td>是</td>
                                    <td>要解压的短网址，必须是 {Configs.apiHost} 开头，不支持其他协议的网址，并且网址在格式上必须是合法的。</td>
                                    <td>{Configs.apiHost}/srtgn<br />{Configs.apiHost}/Duoyh</td>
                                </tr>
                                <tr>
                                    <td>accesskey</td>
                                    <td>String(128)</td>
                                    <td>否</td>
                                    <td>此key用于身份认证以提供异于匿名用户的功能，但不是必须的，如果传入key则必须保证此key是有效的，否则将会调用api失败</td>
                                    <td>key的长度为128位字符</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div className="section">
                    <div className="title">
                        <label>参数列表</label>
                    </div>
                    <div className="content">
                        <table>
                            <thead>
                                <tr>
                                    <td>参数名</td>
                                    <td>类型</td>
                                    <td>是否必返回</td>
                                    <td>描述</td>
                                    <td>示例</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Return_Code</td>
                                    <td>String(16)</td>
                                    <td>是</td>
                                    <td>返回SUCCESS，则api调用成功，返回FAIL调用失败</td>
                                    <td>SUCCESS<br />FAIL</td>
                                </tr>
                                <tr>
                                    <td>Return_Msg</td>
                                    <td>String(128)</td>
                                    <td>是</td>
                                    <td>若Return_Code为SUCCESS，则返回OK，若Return_Code为Fail则返回错误描述</td>
                                    <td>OK<br />URL不是有效的</td>
                                </tr>
                                <tr>
                                    <td>Result</td>
                                    <td>String(32)</td>
                                    <td>是</td>
                                    <td>若Return_Code为SUCCESS，则返回压缩后的结果，若Return_Code为Fail则返回空字符串</td>
                                    <td>{Configs.apiHost}/1</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        );
    }
}
export default Unzip;