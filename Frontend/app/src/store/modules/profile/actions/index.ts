import { ActionTree } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";
import { login } from "./login";


export const actions: ActionTree<ProfileState, RootState> = {
    login
};