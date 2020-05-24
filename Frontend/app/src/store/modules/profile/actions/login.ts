import { Action } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";
import { endpoints } from "../../../../axios/index";
import { LoginModel } from "../models/loginModel";
import { TokenModel } from "../models/tokenModel";
import { moduleActionContext } from "../../../../store"
import { profileModule } from "../index";
import { ActionImpl } from 'direct-vuex';

export const login =
    (context: any, model: LoginModel) : any => {
        const { commit } = moduleActionContext(context, profileModule);
        return endpoints
            .account()
            .post("/Token", model)
            .then(response => {
                const payload: TokenModel = response && response.data;
                commit.putToken( 
                { 
                    payload : payload.token,
                    downloaded : Date.now(),
                    expires: Date.now() + 60 * 60 * 1000
                });
            })
    }