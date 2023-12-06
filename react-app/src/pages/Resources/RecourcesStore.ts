import * as recourceApi from "../../api/Resources"
import {  makeAutoObservable,runInAction } from "mobx";
import { IRecource } from "../../interfaces/ResourceInterface";

class ResourcesStore{

     resources: IRecource[] = [];
     totalPages: number = 0;
     currentPage: number = 1;
     isLoading: Boolean = false;

    constructor(){
        makeAutoObservable(this)
        runInAction(this.getRecource)
    }
        getRecource = async () => {
            try {
                this.isLoading = true;
                const res = await recourceApi.getResources(this.currentPage)
                this.resources = res.data;
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
            await this.getRecource();
        }

}
export default ResourcesStore;