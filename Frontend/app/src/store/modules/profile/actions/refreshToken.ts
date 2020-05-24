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
            state.token.downloaded !== undefined &&
            state.token.expires !== undefined &&
            Date.now() - state.token.downloaded >
            (state.token.expires - state.token.downloaded) / 2) {
            return endpoints
                .account()
                .get("/Token")
                .then(response => {
                    const payload: TokenModel = response && response.data;
                    commit.putToken(
                        {
                            payload: payload.token,
                            downloaded: Date.now(),
                            expires: Date.now() + 60 * 60 * 1000
                        });
                })
        }
        return Promise.resolve();
    }