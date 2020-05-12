import { Action } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";
import { endpoints } from "../../../../axios/index";
import { TokenModel } from "../models/tokenModel";
import { RegisterModel } from '../models/registerModel';

export const register: Action<ProfileState, RootState> =
    ({ commit }, model: RegisterModel) => {
        return endpoints
            .account()
            .post("/Register", model)
            .then(response => {
                let payload: TokenModel = response && response.data;
                commit("token", payload.token);
                commit("tokenLastUpdated", Date.now());
            })
    }