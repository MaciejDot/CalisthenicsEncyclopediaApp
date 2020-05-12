import { Action } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";
import { endpoints } from "../../../../axios/index";
import { TokenModel } from "../models/tokenModel";

export const refreshToken: Action<ProfileState, RootState> =
    ({ commit }) => {
        return endpoints
            .account()
            .get("/Token")
            .then(response => {
                let payload: TokenModel = response && response.data;
                commit("token", payload.token);
                commit("tokenLastUpdated", Date.now());
            })
    }