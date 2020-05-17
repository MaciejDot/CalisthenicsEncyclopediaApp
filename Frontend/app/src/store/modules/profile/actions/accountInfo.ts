import { AccountInfoModel } from "../models/accountInfoModel";
import { endpoints } from "../../../../axios/index";
import { ActionImpl } from "direct-vuex";
import { ProfileState } from '../state';
import { moduleActionContext } from "../../../../store"
import { profileModule } from "../index";

export const accountInfo = (context : any): any =>{
    const { commit } = moduleActionContext(context, profileModule);
    return endpoints
        .account()
        .get("/AccountInfo")
        .then(response => {
            const payload: AccountInfoModel = response && response.data;
            commit.username( 
            { 
                payload : payload.username,
                lastUpdatedFromServer : Date.now(),
                expirationDate: Date.now() + 60 * 60 * 1000
            });
        });
}