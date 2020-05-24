import { login } from "./login";
import { accountInfo } from "./accountInfo";
import { refreshToken } from "./refreshToken";
import { register } from "./register";
import { defineActions } from "direct-vuex";

export const actions = defineActions({
    accountInfo,
    login,
    register,
    refreshToken
});