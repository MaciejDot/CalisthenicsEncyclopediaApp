export interface CachedItemFromServer<T>{
    payload : T | undefined;
    downloaded : number | undefined;
    expires: number | undefined;
}