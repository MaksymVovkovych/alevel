import {
    action,
    makeObservable,
    observable
} from "mobx";
import MainStore from "../../MainStore";




class LoginStore{

    private _mainStore: MainStore;

    email: string = '';
    password: string = '';
    error: string = '';
    isLoading: Boolean = false;
    

    constructor(mainStrore: MainStore){
        this._mainStore = mainStrore
        makeObservable(this,{
            email: observable,
            password: observable,
            error: observable,
            isLoading: observable,
            changeEmail: action,
            changePassword: action 
        })
    }

    changeEmail(email: string) {
        this.email = email;
        if (!!this.error) {
            this.error = '';
        }
    }

    changePassword(password: string) {
        this.password = password;
        if (!!this.error) {
            this.error = '';
        }
    }

    async login() {
        try {
            this.isLoading = true;
           await this._mainStore.login(this.email, this.password);
        }
        catch (e) {
            if (e instanceof Error) {
                this.error = e.message;
            }
        }
        this.isLoading = false;
    } 
    async logout(){
        try {
            this.isLoading = true;
           await this._mainStore.logout();
        }
        catch (e) {
            if (e instanceof Error) {
                this.error = e.message;
            }
        }
        this.isLoading = false;
    }
}

export default LoginStore