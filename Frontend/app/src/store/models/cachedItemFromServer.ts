export interface CachedItemFromServer<T>{
    payload : T | undefined;
    lastUpdatedFromServer : number | undefined;
    expirationDate: number | undefined;
}