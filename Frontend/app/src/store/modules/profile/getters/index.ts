import { GetterTree } from "vuex";
import { ProfileState } from "../state";
import { isCachedItemFromServerExpired } from "@/store/functions/isCachedItemFromServerExpired";
import { defineGetters } from 'direct-vuex';

export const getters = defineGetters<ProfileState>()({
    loggedIn(state) : boolean {
        return !isCachedItemFromServerExpired(state.token);
    },
    username(state) : string | undefined {
        return state.username?.payload;
    },
    token(state) : string | undefined {
        return state.token?.payload;
    }
});