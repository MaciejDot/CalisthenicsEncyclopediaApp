import { Action } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";
import { endpoints } from "../../../../axios/index";
import { TokenModel } from "../models/tokenModel";
import { RegisterModel } from '../models/registerModel';
import { ActionImpl } from 'direct-vuex';
import { moduleActionContext } from '@/store';
import { profileModule } from '..';

export const register: ActionImpl =
    (context, model: RegisterModel) => {
        const { commit } = moduleActionContext(context, profileModule);
        return endpoints
            .account()
            .post("/Register", model)
            .then(response => {
                const payload: TokenModel = response && response.data;
                commit.token( 
                { 
                    payload : payload.token,
                    lastUpdatedFromServer : Date.now(),
                    expirationDate: Date.now() + 60 * 60 * 1000
                });
            })
    }