import { GetterTree } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";

export const getters: GetterTree<ProfileState, RootState> = {
    loggedIn(state) : boolean { 
        return state.token !== undefined
    },
    username(state) : string | undefined {
        return state.username;
    },
    token(state) : string | undefined {
        return state.token
    }
};