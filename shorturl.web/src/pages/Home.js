import React from 'react';
import '../content/css/Home.css';
import APIs from '../content/js/Apis';
import Configs from '../content/js/Configuration';
import RegexUtil from '../content/js/RegexUtil';
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
        let iszip = this.state.tab===tab.zip;
        let isunzip = this.state.tab===tab.unzip;
        let activatedClass = 'active';
        let tabHeaderClass = 'tab-header';
        let tabBodyClass = 'tab-body';
        let successClass = 'success';
        let errClass = 'error';
        let resultClass = 'result';
        return(
            <div id='Home' className='container body-content'>
                <div className="box">
                    <div className="tab-banner">
                        <div className={iszip ? `${activatedClass} ${tabHeaderClass}` : tabHeaderClass} data-target={tab.zip} onClick={this.switchTab}>正转</div>
                        <div className={isunzip ? `${activatedClass} ${tabHeaderClass}` : tabHeaderClass} data-target={tab.unzip} onClick={this.switchTab}>逆转</div>
                    </div>
                    <div className={iszip ? `${tab.zip} ${tabBodyClass} ${activatedClass}` : `${tab.zip} ${tabBodyClass}`}>
                        <div className="title"><label>请输入要缩短的网址(最长1024字符)</label></div>
                        <div className="input-container">
                            <input ref='zipInput' value={this.state.zipInput} type="text" name="long" id=" long" maxLength="1024" onKeyDown={this.zipInputEnter} onChange={this.zipInputChange}/>
                        </div>
                        <div className={`${resultClass} ${this.state.zipOutputStatus===0?errClass:successClass}`} onClick={this.go}>{this.state.zipOutput}</div>
                        <div className="submit">
                            <div className="button">
                                <label onClick={this.zip}>缩短网址</label>
                            </div>
                        </div>
                    </div>
                    <div className={isunzip ? `${tab.unzip} ${tabBodyClass} ${activatedClass}` : `${tab.unzip} ${tabBodyClass}`}>
                        <div className="title"><label>请输入短网址</label></div>
                        <div className="input-container">
                            <div className="host"><label>{Configs.host}/</label></div>
                            <input ref='unzipInput' value={this.state.unzipInput} type="text" name="short" id=" short" maxLength="8" onKeyDown={this.unzipInputEnter} onChange={this.unzipInputChange}/>
                        </div>
                        <div className={`${resultClass} ${this.state.unzipOutputStatus===0?errClass:successClass}`} onClick={this.go} >{this.state.unzipOutput}</div>
                        <div className="submit">
                            <div className="button">
                                <label onClick={this.unzip}>还原网址</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
export default Home;