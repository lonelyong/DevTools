import React from 'react';
import APIs from '../../../content/js/Apis';
import Configs from '../../../content/js/Configuration';
import RegexUtil from '../../../content/js/RegexUtil';
import css from "./SLink.css";
const dataTarget = 'data-target';
const tab = {
    zip:'zip',
    unzip:'unzip'
};
const setTitle = ()=> document.title = '短链接';
class Home extends React.Component{
    componentDidMount() {
        setTitle();
    }
    componentDidUpdate() {
        setTitle()
    }
    constructor(){
        super();
        this.state={
            tab:tab.zip,
            zipping:false,
            zipInput:'',
            zipOutput:'',
            zipOutputStatus:0,
            unzipping:false,
            unzipInput:'',
            unzipOutput:'',
            unzipOutputStatus:0,
        }
    }

    zip=(e)=>{
        if(this.state.zipping){
            this.setState({
                zipOutput:'正在缩短网址，请稍后。。。',
                zipOutputStatus:0
            });
            return;
        }
        var llink = this.refs.zipInput.value;
        if(!llink){
            this.setState({
                zipOutput:'请输入长网址',
                zipOutputStatus: 0
            });
            this.refs.zipInput.focus();
            return;
        }
        if(!RegexUtil.isUrl(llink)){
            this.setState({
                zipOutput:'输入的长网址不合法，请重新输入',
                zipOutputStatus: 0
            });
            this.refs.zipInput.focus();
            return;
        }
        APIs.zipUrl({llink: llink},
            ()=>{
                this.setState({
                    zipping:true
                });
                this.refs.zipInput.setAttribute('disabled', '');
            }, 
            (rep)=>{ 
                if(APIs.isOk(rep)){
                    this.setState({ 
                        zipOutput:rep.result,
                        zipOutputStatus:1
                    });
                }
                else{
                    this.setState({ 
                        zipOutput:rep.return_msg,
                        zipOutputStatus:0
                    });
                }
            },
            (err)=>{
                this.setState({ 
                    zipOutput:JSON.stringify(err),
                    zipOutputStatus:0
                });
            },
            ()=>{
                this.setState({
                    zipping:false
                });
                this.refs.zipInput.removeAttribute('disabled', '');
            }
        );
    }
    unzip=(e)=>{
        if(this.unzipping){
            this.setState({
                unzipOutput:'正在还原网址，请稍后。。。',
                unzipOutputStatus:0
            });
            return;
        }
        var slink = this.refs.unzipInput.value;
        if(!slink){
            this.setState({
                unzipOutput:'请输入短网址',
                unzipOutputStatus: 0
            });
            this.refs.unzipInput.focus();
            return;
        }
        if(!RegexUtil.isShortUrl(slink)){
            this.setState({
                unzipOutput:'输入的短网址不合法，请重新输入',
                unzipOutputStatus: 0
            });
            this.refs.unzipInput.focus();
            return;
        }
        APIs.unzipUrl({slink:slink}, 
            ()=>{
                this.setState({
                    unzipping:true
                });
                this.refs.unzipInput.setAttribute('disabled', '');
            }, 
            (rep)=>{ 
                if(APIs.isOk(rep)){
                    this.setState({ 
                        unzipOutput:rep.result,
                        unzipOutputStatus:1
                    });
                }
                else{
                    this.setState({ 
                        unzipOutput:rep.return_msg,
                        unzipOutputStatus:0
                    });
                }
            },
            (err)=>{
                this.setState({ 
                    unzipOutput:JSON.stringify(err),
                    unzipOutputStatus:0
                });
            },
            ()=>{
                this.setState({
                    unzipping:false
                });
                this.refs.unzipInput.removeAttribute('disabled', '');
            }
        );
    }

    zipInputChange=(e)=>{
        this.setState({
            zipOutput:'',
            zipOutputStatus:0,
            zipInput:e.target.value
        });
    }

    zipInputEnter=(e)=>{
        if (e.keyCode === 13) {
            this.zip(e);
        }
    }

    unzipInputChange=(e)=>{
        this.setState({
                unzipOutput:'',
                unzipOutputStatus:0,
                unzipInput:e.target.value.replace(/[^\w]/ig, '')
            }
        );
    }

    unzipInputEnter=(e)=>{
        if (e.keyCode === 13) {
            this.unzip(e);
        }
    }

    switchTab=(e)=>{
        let el = e.target;
        let tab = el.getAttribute(dataTarget);
        this.setState({tab:tab});
    }

    go=(e)=>{
        var text = e.target.innerHTML;
        if(RegexUtil.isUrl(text)){
            window.open(text);
        }
    }

    render(){
        let successClass = 'success';
        let errClass = 'error';
        return(
            <div className='d-flex flex-grow-1 justify-content-center align-items-center'>
                <div className="content-wrap d-flex flex-column align-content-stretch">
                    <ul className="nav nav-tabs border-bottom-0 flex-shrink-0">
                        <li className="nav-item flex-grow-1 text-center">
                            <span className="nav-link active" data-toggle="pill" href="#zip">正转</span>
                        </li>
                        <li className="nav-item flex-grow-1 text-center">
                            <span className="nav-link" data-toggle="pill" href="#unzip">逆转</span>
                        </li>
                    </ul>
                    <div className="tab-content mt-2 p-2 flex-grow-1 d-flex align-content-stretch">
                        <div id="zip" className="tab-pane active flex-grow-1">
                            <div className="d-flex flex-column h-100">
                                <div className="text-dark"><label>请输入要缩短的网址(最长1024字符)</label></div>
                                <div className="input-wrap w-100 d-flex flex-row align-items-center p-1">
                                    <input ref='zipInput' value={this.state.zipInput} type="text" name="long" id=" long" maxLength="1024" className="flex-grow-1"
                                        onKeyDown={this.zipInputEnter} 
                                        onChange={this.zipInputChange}/>
                                </div>
                                <div className={`${this.state.zipOutputStatus===0?errClass:successClass} flex-grow-1`} onClick={this.go}>{this.state.zipOutput}</div>
                                <div className="p-2 d-flex flex-row justify-content-end">
                                    <div className="btn btn-secondary" onClick={this.zip}>缩短网址</div>
                                </div>
                            </div>
                        </div>
                        <div id="unzip" className="tab-pane fade flex-grow-1">
                        <div className="d-flex flex-column h-100">
                            <div className="text-dark"><label>请输入短网址</label></div>
                                <div className="input-wrap w-100 d-flex flex-row align-items-center p-1">
                                    <label className="flex-shrink-0 m-0 text-info">{Configs.host}/</label>
                                    <input ref='unzipInput' value={this.state.unzipInput} type="text" name="short" id=" short" maxLength="8" className="flex-grow-1 text-success"
                                onKeyDown={this.unzipInputEnter} 
                                onChange={this.unzipInputChange}/>
                                </div>
                                <div className={`${this.state.unzipOutputStatus===0?errClass:successClass} flex-grow-1`} onClick={this.go} >{this.state.unzipOutput}</div>
                                <div className="p-2 d-flex flex-row justify-content-end">
                                    <div className="btn btn-secondary" onClick={this.unzip}>还原网址</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
export default Home;