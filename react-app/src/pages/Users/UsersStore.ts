import * as userApi from "../../api/Users"
import { makeAutoObservable, runInAction } from "mobx";
import {IUser} from "../../interfaces/UserInterface"

class UsersStore{

     users: IUser[] = [];
     totalPages: number = 0;
     currentPage: number = 1;
     isLoading: Boolean = false;

    constructor(){
        makeAutoObservable(this)
        runInAction(this.getUser)
    }
        getUser = async () => {
            try {
                this.isLoading = true;
                const res = await userApi.getUsers(this.currentPage)
                this.users = res.data;
                this.totalPages = res.total_pages;
            } catch (e) {
                if (e instanceof Error) {
                    console.error(e.message)
                }
            }
            this.isLoading = false;
        }
        
        async changePage(page: number) {
            this.currentPage = page;
            await this.getUser();
        }

}
export default UsersStore;