import HttpMethod from './HttpMethod';
import Configs from './Configuration';
import AccountInfo from './AccountInfo';
const successCode = 'SUCCESS';
const headers = new Headers({
    'Content-Type': 'application/json',
    'Accept': 'application/json',
    'Access-Control-Allow-Origin':'*',
    'Access-Control-Allow-Methods': 'POST, GET, OPTIONS, PUT, DELETE'});


const sendRequest=(url, method, params, before, success, error, complete)=>{
    params = params || {};
    url = `${Configs.apiHost}${url}`;
    let req = null;
    headers.delete("Authorization");
    headers.append("Authorization",`Bearer ${AccountInfo.accessToken()}`);
    if(method === HttpMethod.GET){
        url += "?";
        Object.keys(params).forEach(e => {
            url+=`${e}=${params[e]}&`;
        });
        req = new Request(url, {
            method:method,
            mode:'cors',
            headers:headers,
        });     
    }
    else {
        req = new Request(url, {
            method:method,
            mode:'cors',
            headers:headers,
            body:JSON.stringify(params)
        });     
    }
    if(typeof before === typeof Object){
        before();
    }
    fetch(req).then(
        function(rep){
            if(rep.ok){
                return rep.json();
            }
            else{
                throw new Error(rep);
            }
        }
    )
    .then(function (data) {
        if(typeof success === typeof Object){    
            try {
                success(data);
            } catch (error) {
                
            }
        }
        if(typeof complete === typeof Object){
            complete();
        }
    })
    .catch(function(err){
        if(typeof error === typeof Object){
            try {
                error(err);
            } catch (error) {
                
            }
        }
        else{
            alert(JSON.stringify(err));
        }
        if(typeof complete === typeof Object){
            complete();
        }
    });
};

class ApiCollection{
     zipUrl = (params, before, success, error, complete)=>sendRequest("/url/zip", HttpMethod.POST, params, before, success, error, complete);
     unzipUrl =(params, before, success, error, complete)=>sendRequest("/url/unzip", HttpMethod.GET, params, before, success, error, complete);
     login =(params, before, success, error, complete)=>sendRequest("/account/login", HttpMethod.POST, params, before, success, error, complete);
     isOk(rep){
        if(rep){
            return rep.return_code===successCode;
        }
        return false;
     }
}
const Apis = new ApiCollection();
export default Apis;