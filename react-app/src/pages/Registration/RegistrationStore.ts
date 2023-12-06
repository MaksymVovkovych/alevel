import {
    action,
    makeObservable,
    observable,
} from "mobx";
import MainStore from "../../MainStore"




class RegistrationStorage{

    private _mainStore: MainStore;

    email: string = '';
    password: string = '';
    error: string = '';
    isLoading: Boolean = false;

    constructor(store: MainStore){
        this._mainStore = store;
        makeObservable(this,{
            email: observable,
            password: observable,
            error: observable,
            isLoading: observable,
            changeEmail: action,
            changePassword: action,
            registration: action
        });
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

    async registration() {
        try {
            this.isLoading = true;
           await this._mainStore.register(this.email, this.password);
        }
        catch (e) {
            if (e instanceof Error) {
                this.error = e.message;
            }
        }
        this.isLoading = false;
    } 
}

export default RegistrationStorage