import { CachedItemFromServer } from "../../../models/cachedItemFromServer";
export interface ProfileState{
    token : CachedItemFromServer<string> | undefined,
    username : CachedItemFromServer<string> | undefined
}