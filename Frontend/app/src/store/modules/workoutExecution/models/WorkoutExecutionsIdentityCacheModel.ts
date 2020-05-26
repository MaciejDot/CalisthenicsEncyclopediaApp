import { WorkoutExecutionCacheModel } from './WorkoutExecutionCacheModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';

export interface WorkoutExecutionsIdentityCacheModel{
    payload: Array<CachedItemFromServer<WorkoutExecutionCacheModel>>,
    username: string
}