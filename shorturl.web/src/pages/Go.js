import React from 'react';
import '../content/css/Go.css';
import APIs from '../content/js/Apis';
import RegexUtil from '../content/js/RegexUtil';
const setTitle = ()=> document.title = '正在跳转...';
class Go extends React.Component{
    constructor(){
        super();
        this.state={
            message:'跳转中...'
        };
    }
    componentDidMount() {
        setTitle();
        APIs.unzipUrl({slink:this.props.match.params[0]},
            ()=>{},
            (rep)=>{
                if(APIs.isOk(rep)){
                    window.location.href=rep.result;
                }else{
                    this.setState({
                        message:rep.return_msg
                    });
                }
            },
            (err)=>{
                this.setState({
                    message:'访问出错'
                });
            },
            ()=>{}
        );
    }
    componentDidUpdate() {
        setTitle()
    }
    render(){
        return(
            <div className="go-container">
                <label className="go-title">{this.state.message}</label>
            </div>
        );
    }
}
export default Go;