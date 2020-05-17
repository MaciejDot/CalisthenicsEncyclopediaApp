import { Action } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";
import { endpoints } from "../../../../axios/index";
import { TokenModel } from "../models/tokenModel";
import { profileModule } from '..';
import { moduleActionContext } from '@/store';
import { ActionImpl } from 'direct-vuex';

export const refreshToken =
    (context: any) : any => {
        const { commit, getters, state } = moduleActionContext(context, profileModule);
        if (getters.loggedIn &&
            state.token !== undefined &&
            state.token.lastUpdatedFromServer !== undefined &&
            state.token.expirationDate !== undefined &&
            Date.now() - state.token.lastUpdatedFromServer >
            (state.token.expirationDate - state.token.lastUpdatedFromServer) / 2) {
            return endpoints
                .account()
                .get("/Token")
                .then(response => {
                    const payload: TokenModel = response && response.data;
                    commit.token(
                        {
                            payload: payload.token,
                            lastUpdatedFromServer: Date.now(),
                            expirationDate: Date.now() + 60 * 60 * 1000
                        });
                })
        }
        return Promise.resolve();
    }