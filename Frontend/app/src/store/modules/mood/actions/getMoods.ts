import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../.."
import { isCachedItemFromServerExpired } from '@/store/functions/isCachedItemFromServerExpired';
import { moodModule } from '..';
import { MoodsCacheModel } from '../models/MoodCacheModel';

export const getMoods = (context: any): Promise<Array<MoodsCacheModel> | undefined> => {
    const { commit, state } = moduleActionContext(context, moodModule);
    if (isCachedItemFromServerExpired(state.moods))
    {
        return endpoints
            .mood()
            .get(
                `/Mood`
            ).then(response => {
                const payload: Array<MoodsCacheModel> = response && response.data;
                commit.putMoods({
                    payload: payload,
                    downloaded: Date.now(),
                    expires: Date.now() + 60 * 60 * 1000
                });
                return state.moods?.payload;
            });
    }
    return Promise.resolve(state.moods?.payload);
}