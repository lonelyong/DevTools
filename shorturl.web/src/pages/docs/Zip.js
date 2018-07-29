import React from 'react';
import Configs from '../../content/js/Configuration';
const setTitle = ()=> document.title = '文档-链接缩短';
class Zip extends React.Component{
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
                    <label>缩短URL</label>
                </div>
                <div className="section">
                    <div className="title">
                        <label>应用场景</label>
                    </div>
                    <div className="content">
                        需要将长连接转换为短链接，如生成二维码、分享给好友时调用此接口，将会返回短链接
                    </div>
                </div>
                <div className="section">
                    <div className="title">
                        <label>接口链接</label>
                    </div>
                    <div className="content">
                    <a target="_blank" href={Configs.apiHost}>{Configs.apiHost}/api/zip</a>
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
                                    <td>url</td>
                                    <td>String(1024)</td>
                                    <td>是</td>
                                    <td>要压缩的网址，必须是http或https开头，不支持其他协议的网址，网址最长为1024位字符，并且网址在格式上必须是合法的。此外，网址域名也不能是{Configs.apiHost}</td>
                                    <td>http://www.baidu.com<br />https://www.codezone.link</td>
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
                                    <td>{Configs.apiHost}/Ld8Dc</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        );
    }
}
export default Zip;