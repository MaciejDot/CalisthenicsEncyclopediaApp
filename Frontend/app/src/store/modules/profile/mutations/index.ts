import { MutationTree } from "vuex";
import { ProfileState } from "../state";
import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
import { defineMutations } from 'direct-vuex';

export const mutations = defineMutations<ProfileState>()({
    token: (state, token : CachedItemFromServer<string>) => state.token = token,
    username: (state, username: CachedItemFromServer<string>) => state.username = username,
});