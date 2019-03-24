
'esversion: 6'
import Apis from './Apis';
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
			for (const callback of this.loginedCallbacks) {
				callback();
			}
		}, error, complete);
	};
	loginedCallbacks = [];
}

export default new AccountInfo()