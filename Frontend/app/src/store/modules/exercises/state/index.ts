import { CachedItemFromServer } from '@/store/models/cachedItemFromServer';
import { ExerciseCacheModel } from '../models/ExerciseCacheModel';

export interface ExerciseState{
    exercises? : CachedItemFromServer<Array<ExerciseCacheModel>>
}