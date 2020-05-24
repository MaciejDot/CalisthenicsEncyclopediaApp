import { CachedItemFromServer } from "../models/cachedItemFromServer";

export const isCachedItemFromServerExpired = function<T>(cachedItemFromServer : CachedItemFromServer<T> | undefined) {
    return !(cachedItemFromServer !== undefined &&
        cachedItemFromServer.expires !== undefined &&
        cachedItemFromServer.payload !== undefined &&
        cachedItemFromServer.downloaded !== undefined &&
        cachedItemFromServer.expires > Date.now());
}