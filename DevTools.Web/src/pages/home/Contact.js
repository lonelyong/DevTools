import React from 'react';
const setTitle = ()=> document.title = '联系';
class Contact extends React.Component{
    componentDidMount() {
        setTitle();
    }
    componentDidUpdate() {
        setTitle()
    }
    render(){
        return(
            <div id='Contact' className='page-content'>
                <address>
                    <strong>Phone</strong> <a href="tel:010-000000">010-000000</a><br />
                </address>
                <br />
                <address>
                    <strong>Support</strong> <a href="mailto:yong-zh@qq.com">yong-zh@qq.com</a><br />
                </address>
            </div>
        );
    }
}
export default Contact;