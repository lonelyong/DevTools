import React from 'react';
import '../content/css/Contact.css';
class Contact extends React.Component{
    render(){
        return(
            <div id='Contact' className='container body-content'>
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