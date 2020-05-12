import { Action } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";
import { endpoints } from "../../../../axios/index";
import { LoginModel } from "../models/loginModel";
import { TokenModel } from "../models/tokenModel";

export const login: Action<ProfileState, RootState> =
    ({ commit }, model: LoginModel) => {
        return endpoints
            .account()
            .post("/Token", model)
            .then(response => {
                const payload: TokenModel = response && response.data;
                commit("token", payload.token);
                commit("tokenLastUpdated", Date.now());
            })
    }