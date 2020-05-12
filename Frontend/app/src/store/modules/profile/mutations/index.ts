import { MutationTree } from "vuex";
import { ProfileState } from "../state";

export const mutations: MutationTree<ProfileState> = {
    token: (state, token : string | undefined) => state.token = token,
    username: (state, username: string | undefined) => state.username = username,
    usernameLastUpdated: (state, usernameLastUpdated: number | undefined) => state.usernameLastUpdated = usernameLastUpdated,
    tokenLastUpdated: (state, tokenLastUpdated: number | undefined) => state.tokenLastUpdated = tokenLastUpdated
};