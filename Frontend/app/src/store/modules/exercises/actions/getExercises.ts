import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../../../store"
import { isCachedItemFromServerExpired } from '@/store/functions/isCachedItemFromServerExpired';
import { exerciseModule } from '..';
import { ExerciseCacheModel } from '../models/ExerciseCacheModel';

export const getExercises = (context: any): Promise<Array<ExerciseCacheModel> | undefined> => {
    const { commit, state } = moduleActionContext(context, exerciseModule);
    if (isCachedItemFromServerExpired(state.exercises))
    {
        return endpoints
            .exercise()
            .get(
                `/Exercise`
            ).then(response => {
                const payload: Array<ExerciseCacheModel> = response && response.data;
                commit.putExercises({
                    payload: payload,
                    downloaded: Date.now(),
                    expires: Date.now() + 60 * 60 * 1000
                });
                return state.exercises?.payload;
            });
    }
    return Promise.resolve(state.exercises?.payload);
}