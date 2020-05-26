import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import { MoodsCacheModel } from '../models/MoodCacheModel';

export interface MoodState{
    moods? : CachedItemFromServer<Array<MoodsCacheModel>>
}