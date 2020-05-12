import { ActionTree } from "vuex";
import { RootState } from "../../../state";
import { ProfileState } from "../state";
import { login } from "./login";
import { accountInfo } from "./accountInfo";
import { refreshToken } from "./refreshToken";
import { register } from "./register";

export const actions: ActionTree<ProfileState, RootState> = {
    login,
    accountInfo,
    refreshToken,
    register
};