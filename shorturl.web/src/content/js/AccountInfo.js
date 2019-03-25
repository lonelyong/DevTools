
'esversion: 6'
import Apis from './Apis';

const onLogined = [];
class AccountInfo {
	accessToken = () => {
		return localStorage.access_token;
	};
	username = () => {
		return localStorage.username;
	};
	nickname=()=>{
		return localStorage.nickname;
	};
	isLogined = () => {
		return !!localStorage.access_token;
	};
	logout = ()=>{
		localStorage.removeItem('access_token');
		localStorage.removeItem('username');
		localStorage.removeItem('nickname');
	};
	login=(params, before, success, error, complete )=>{
		Apis.login(params, before, (rep)=>{
			if(Apis.isOk(rep)){
				localStorage.access_token = rep.result.accesstoken;
				localStorage.username = rep.result.username;
				localStorage.nickname = rep.result.nickname;
			}
			if(typeof success === typeof Object){
				success(rep);
			}
			for (const callback of onLogined) {
				callback();
			}
		}, error, complete);
	};
	signup = (params, before, success, error, complete)=>{
		Apis.signup(params, before, success, error, complete);
	};
	regesterLogined = (callback) =>{
		onLogined.push(callback);
	};
	unregesterLogined = (callback)=>{
		var index = onLogined.indexOf(callback);
		if(index >= 0){
			onLogined.splice(index, 1);
		}
	};
}

export default new AccountInfo()