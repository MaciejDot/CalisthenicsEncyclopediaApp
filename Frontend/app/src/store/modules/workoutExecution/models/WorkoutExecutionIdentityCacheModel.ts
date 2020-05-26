import { WorkoutExecutionCacheModel } from './WorkoutExecutionCacheModel';
import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';

export interface WorkoutExecutionIdentityCacheModel{
    payload: CachedItemFromServer<WorkoutExecutionCacheModel>,
    externalId: string,
    username: string
}