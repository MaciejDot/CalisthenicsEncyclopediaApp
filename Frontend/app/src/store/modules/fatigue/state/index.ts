import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import { FatigueCacheModel } from '../models/FatigueCacheModel';

export interface FatigueState{
    fatigues? : CachedItemFromServer<Array<FatigueCacheModel>>
}