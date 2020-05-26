import { endpoints } from "../../../../axios/index";
import { moduleActionContext, rootActionContext } from "../../.."
import { isCachedItemFromServerExpired } from '@/store/functions/isCachedItemFromServerExpired';
import { fatigueModule } from '..';
import { FatigueCacheModel } from '../models/FatigueCacheModel';

export const getFatigues = (context: any): Promise<Array<FatigueCacheModel> | undefined> => {
    const { commit, state } = moduleActionContext(context, fatigueModule);
    if (isCachedItemFromServerExpired(state.fatigues))
    {
        return endpoints
            .fatigue()
            .get(
                `/Fatigue`
            ).then(response => {
                const payload: Array<FatigueCacheModel> = response && response.data;
                commit.putFatigues({
                    payload: payload,
                    downloaded: Date.now(),
                    expires: Date.now() + 60 * 60 * 1000
                });
                return state.fatigues?.payload;
            });
    }
    return Promise.resolve(state.fatigues?.payload);
}