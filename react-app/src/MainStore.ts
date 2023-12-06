import * as authApi from './api/auth&ident'
import {
    action,
    makeObservable,
    observable
} from "mobx";

class mainStore{

    id = 0;
    token = "";

    constructor(){
         makeObservable(this, {
            id: observable,
            token: observable,
            login: action,
            register: action,
            logout: action
         });
    }

    async login(email: string, password: string){
        const result = await authApi.login({email, password});
        this.token = result.token;
    }

    async register(email: string, password: string){
        const result = await authApi.register({email, password});
        this.id = result.id;
        this.token = result.token;
    }

    async logout(){
        await authApi.logout();
        this.token = '';
    }
}

export default mainStore