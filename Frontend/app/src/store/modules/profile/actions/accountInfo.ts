import { AccountInfoModel } from "../models/accountInfoModel";
import { Action } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";
import { endpoints } from "../../../../axios/index";

export const accountInfo : Action<ProfileState, RootState>= ({commit})=>{
    return endpoints
        .account()
        .get("/AccountInfo")
        .then(response => {
            let payload: AccountInfoModel = response && response.data;
            commit("username", payload.username);
            commit("usernameLastUpdated", Date.now());
        });
}