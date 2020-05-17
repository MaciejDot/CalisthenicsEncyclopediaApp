import { CachedItemFromServer } from "../models/cachedItemFromServer";

export const isCachedItemFromServerExpired = function<T>(cachedItemFromServer : CachedItemFromServer<T> | undefined) {
    return !(cachedItemFromServer !== undefined &&
        cachedItemFromServer.expirationDate !== undefined &&
        cachedItemFromServer.payload !== undefined &&
        cachedItemFromServer.lastUpdatedFromServer !== undefined &&
        cachedItemFromServer.expirationDate > Date.now());
}