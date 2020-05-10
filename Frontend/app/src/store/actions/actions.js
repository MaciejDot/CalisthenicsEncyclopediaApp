//reducers ensure all have implementations and none action is implemented without reducer ts 
export const actions = {
    updateAccountInfo: function ({
        commit,
        state,
        dispatch
    }) {
        if (state.jwtToken !== undefined) {
            return this._vm
                .$axios
                .account()
                .get('/AccountInfo')
                .then(r => {
                    commit('lastUpdatedAccountInfo', Date.now());
                    commit('username', r.data.username);
                    commit('roles', r.data.roles);
                    return Promise;
                })
                .catch(() => {
                    dispatch('logOut')
                });
        } else {
            return dispatch('logOut')
        }
    },
    getBackLog: function ({
        state,
        commit
    }) {
        if (state.backLog == undefined ||
            state.lastUpdatedBackLog == undefined ||
            state.lastUpdatedBackLog < Date.now() - 180 * 60 * 1000) {
            return this._vm
                .$axios
                .workoutExecution()
                .get('/Workout')
                .then(x => {
                    commit('backLog', x.data);
                    commit('lastUpdatedBackLog', Date.now())
                    return state.backLog;
                })
        } else {
            return Promise.resolve(state.backLog);
        }
    },
    addToBackLog: function ({
        state,
        commit
    }, {
        externalId,
        name,
        description,
        created,
        executed,
        mood,
        fatigue
    }) {
        if (state.backLog !== undefined) {
            let backLog = state.backLog;
            backLog.push({
                externalId,
                name,
                description,
                created,
                executed,
                mood,
                fatigue
            });
            return Promise.resolve(commit('backLog', backLog))
        }
        return new Promise();
    },
    updateEntityBackLog: function ({
        state,
        commit
    }, {
        externalId,
        name,
        description,
        created,
        executed,
        mood,
        fatigue
    }) {
        if (state.backLog != undefined) {
            let backLog = state.backLog.filter(x => x.externalId != externalId);
            backLog.push({
                externalId,
                name,
                description,
                created,
                executed,
                mood,
                fatigue
            });
            commit('backLog', backLog);
        }
        return Promise.resolve();
    },
    getScheduledWorkouts: function ({
        state,
        commit
    }) {
        if (state.scheduledWorkouts == undefined ||
            state.lastUpdatedScheduledWorkouts == undefined ||
            state.lastUpdatedScheduledWorkouts < Date.now() - 180 * 60 * 1000) {
            return this._vm
                .$axios
                .workoutPlan()
                .get('/WorkoutSchedule')
                .then(x => {
                    commit('scheduledWorkouts', x.data);
                    commit('lastUpdatedScheduledWorkouts', Date.now());
                    return state.scheduledWorkouts;
                })
        }
        return Promise.resolve(state.scheduledWorkouts);
    },
    removeWorkoutSchedule({
        commit,
        state
    }, {
        externalId
    }) {
        if (state.scheduledWorkouts !== undefined) {
            commit('scheduledWorkouts', state.scheduledWorkouts.filter(x => x.externalId === externalId));
        }
    },
    updateToken: function ({
        commit,
        state,
        dispatch
    }, ) {
        if (state.jwtToken !== undefined) {
            this._vm.$axios.account()
                .get("/Token")
                .then(t => {
                    commit('lastUpdatedToken', Date.now());
                    commit('jwtToken', t.data.token);
                })
                .catch(() =>
                    dispatch('logOut')
                );
        } else {
            dispatch('logOut')
        }
    },
    logOut: ({
        commit
    }) => {
        commit('jwtToken', undefined);
        commit('username', undefined);
        commit('roles', undefined);
        commit('workoutPlans', undefined);
        commit('workoutPlansLastUpdate', undefined);
        commit('workoutPlans', undefined);
        commit('lastUpdatedToken', undefined);
        commit('lastUpdatedAccountInfo', undefined);
        commit('lastUpdatedScheduledWorkouts', undefined);
        commit('scheduledWorkouts', undefined);
        commit('backLog', undefined);
        commit('lastUpdatedBackLog', undefined);
        commit('workoutPlanView', undefined);
        commit('workoutPlanViewUpdate', undefined);
    },
    getExercises: function ({
        state,
        commit
    }) {
        if (state.exercisesLastUpdated === undefined ||
            state.exercisesLastUpdated < Date.now() - 8 * 60 * 60 * 1000 ||
            state.exercises === undefined) {
            return this._vm.$axios
                .exercise()
                .get("/Exercise")
                .then(
                    x => {
                        commit('exercisesLastUpdated', Date.now());
                        commit('exercises', x.data.map(y => {
                            return {
                                value: y.id,
                                label: y.name
                            };

                        }));
                        return state.exercises;
                    });
        }
        return Promise.resolve(state.exercises);
    },
    getMoods: function ({
        state,
        commit
    }) {
        if (state.moods === undefined ||
            state.lastUpdatedMoods === undefined ||
            state.lastUpdatedMoods < Date.now() - 8 * 60 * 60 * 1000) {
            return this._vm.$axios
                .mood()
                .get("/Mood")
                .then(x => {
                    commit('moods', x.data.map(y => {
                        return {
                            value: y.id,
                            label: y.name
                        };
                    }));
                    commit('lastUpdatedMoods', Date.now())
                    return state.moods;
                });
        }
        return Promise.resolve(state.moods);
    },
    getFatigues: function ({
        state,
        commit
    }) {
        if (state.fatigues === undefined ||
            state.lastUpdatedFatigues === undefined ||
            state.lastUpdatedFatigues < Date.now() - 8 * 60 * 60 * 1000) {
            return this._vm.$axios
                .fatigue()
                .get("/Fatigue")
                .then(x => {
                    commit('fatigues', x.data.map(y => {
                        return {
                            value: y.id,
                            label: y.name
                        };
                    }));
                    commit('lastUpdatedFatigues', Date.now())
                    return state.fatigues;
                });
        }
        return Promise.resolve(state.fatigues);
    },
    removeWorkoutPlan: function ({
        state,
        commit,
        dispatch
    }, entity) {
        dispatch('updateWorkoutPlanViewState', {
            username: state.username,
            externalId: entity.externalId,
            data: undefined
        })
        if (state.workoutPlans != undefined)
        {
            state.workoutPlans = state.workoutPlans.filter(element => element.externalId != `${entity.externalId}`);
            commit('workoutPlans', state.workoutPlans)
        }
        return Promise.resolve();
    },
    updateWorkoutPlans: function ({
        state,
        commit
    }, entity) {
        if (state.workoutPlans != undefined){
            state.workoutPlans.push(entity);
            commit('workoutPlans', state.workoutPlans);
        }
        return Promise.resolve();
    },
    getWorkoutPlans: function ({
        state,
        commit
    }) {
        if (state.workoutPlansLastUpdate == undefined ||
            state.workoutPlansLastUpdate < Date.now() - 2 * 60 * 60 * 1000 ||
            state.workoutPlans == undefined) {
            return this._vm.$axios
                .workoutPlan()
                .get("/WorkoutPlan")
                .then(x => {
                    commit('workoutPlans', x.data);
                    commit('workoutPlansLastUpdate', Date.now());
                    return state.workoutPlans;
                });
        }
        return Promise.resolve(state.workoutPlans)
    },
    postWorkoutPlan: function ({
        dispatch,
        state
    }, data) {
        return this._vm.$axios
            .workoutPlan()
            .post(`/WorkoutPlan`, data)
            .then(r => {
                return Promise.all([dispatch('updateWorkoutPlans', {
                        name: data.name,
                        externalId: r.data.externalId,
                        description: data.description
                    }),
                    dispatch('updateWorkoutPlanViewState', {
                        username: state.username,
                        externalId: r.data.externalId,
                        data: { ...data, externalId:r.data.externalId }
                    })
                ]);
            });

    },
    patchWorkoutPlan: function ({
        state,
        dispatch
    }, data) {
        this._vm.$axios
            .workoutPlan()
            .patch(`/WorkoutPlan/${data.externalId}`, data)
            .then(() => {
                return dispatch("updateWorkoutPlanViewState", {
                    username: state.username,
                    externalId: data.externalId,
                    data: data
                });
            });
    },
    postWorkoutExecution: function ({
        state,
        dispatch
    }, data) {
        return this._vm.$axios
            .workoutExecution()
            .post(`/Workout`, data)
            .then(r => Promise.all([
                dispatch('updateWorkoutExecutionViewState', {
                    username: state.username,
                    externalId: r.data.externalId,
                    workoutName: data.name,
                   data: { ...data, externalId: r.data.externalId }
                }),
                dispatch('updateEntityBackLog', {
                    externalId: r.data.externalId,
                    name: data.name,
                    description: data.description,
                    executed: data.dateOfWorkout,
                    created: new Date(),
                    mood: data.mood,
                    fatigue: data.fatigue
                })
            ]));
    },
    patchWorkoutExecution: function ({
        dispatch,
        state
    }, data) {
        return this._vm.$axios
            .workoutExecution()
            .patch(`/Workout/${data.name}`,
                data)
            .then(() => Promise.all([
                dispatch('updateWorkoutExecutionViewState', {
                    username: state.username,
                    workoutName: data.name,
                    externalId: data.externalId,
                    data: data
                }),
                dispatch('updateEntityBackLog', {
                    name: data.name,
                    externalId: data.externalId,
                    description: data.description,
                    executed: data.dateOfWorkout,
                    created: new Date(),
                    mood: data.mood,
                    fatigue: data.fatigue
                })
            ]));
    },
    updateWorkoutPlanViewState: function ({
        commit,
        state
    }, {
        username,
        data,
        externalId
    }) {

        let workoutPlanView = state.workoutPlanView || {};
        workoutPlanView[username] = workoutPlanView[username] || {};
        let workoutPlanViewUpdate = state.workoutPlanViewUpdate || {};
        workoutPlanViewUpdate[username] = workoutPlanViewUpdate[username] || {};
        workoutPlanView[username][externalId] = data;
        workoutPlanViewUpdate[username][externalId] = Date.now();
        commit('workoutPlanView', workoutPlanView)
        commit('workoutPlanViewUpdate', workoutPlanViewUpdate)
    },
    getWorkoutPlanView: function ({
        state,
        dispatch
    }, {
        username,
        externalId
    }) {
        if (state.workoutPlanViewUpdate == undefined ||
            state.workoutPlanViewUpdate[username] == undefined ||
            state.workoutPlanViewUpdate[username][externalId] == undefined ||
            state.workoutPlanViewUpdate[username][externalId] < Date.now() - 30 * 60 * 1000 ||
            state.workoutPlanView == undefined ||
            state.workoutPlanView[username] == undefined ||
            state.workoutPlanView[username][externalId] == undefined ||
            state.username != username) {
            return this._vm.$axios
                .workoutPlan()
                .get(
                    `/WorkoutPlan/${username}/${externalId}`
                ).then(x => {
                    dispatch('updateWorkoutPlanViewState', {
                        username: username,
                        externalId: externalId,
                        data: x.data
                    })
                    return state.workoutPlanView[username][externalId];
                });
        }
        return Promise.resolve(state.workoutPlanView[username][externalId]);
    },
    updateWorkoutExecutionViewState: function ({
        commit,
        state
    }, {
        username,
        externalId,
        data
    }) {

        let workoutExecutionView = state.workoutExecutionView || {};
        workoutExecutionView[username] = workoutExecutionView[username] || {};
        let workoutExecutionViewUpdate = state.workoutExecutionViewUpdate || {};
        workoutExecutionViewUpdate[username] = workoutExecutionViewUpdate[username] || {};
        workoutExecutionView[username][externalId] = data;
        workoutExecutionViewUpdate[username][externalId] = Date.now();
        commit('workoutExecutionView', workoutExecutionView)
        commit('workoutExecutionViewUpdate', workoutExecutionViewUpdate)
        return Promise.resolve();
    },
    getWorkoutExecutionView: function ({
        state,
        dispatch
    }, {
        username,
        externalId
    }) {
        if (state.workoutExecutionViewUpdate == undefined ||
            state.workoutExecutionViewUpdate[username] == undefined ||
            state.workoutExecutionViewUpdate[username][externalId] == undefined ||
            state.workoutExecutionViewUpdate[username][externalId] < Date.now() - 30 * 60 * 1000 ||
            state.workoutExecutionView == undefined ||
            state.workoutExecutionView[username] == undefined ||
            state.workoutExecutionView[username][externalId] == undefined ||
            state.username != username) {
            return this._vm.$axios
                .workoutExecution()
                .get(
                    `/Workout/${username}/${externalId}`
                ).then(x => {
                    dispatch('updateWorkoutExecutionViewState', {
                        username: username,
                        workoutName: externalId,
                        data: x.data
                    })
                    return state.workoutExecutionView[username][externalId];
                });
        }
        return Promise.resolve(state.workoutExecutionView[username][externalId]);
    },
    deleteWorkoutPlanView: function ({
        dispatch
    }, {
        externalId
    }) {
        return this._vm.$axios
            .workoutPlan()
            .delete(`/WorkoutPlan/${externalId}`)
            .then(() => {
                return dispatch("removeWorkoutPlan", {
                    externalId: externalId
                });
            });
    },
    deleteWorkoutExecutionView: function ({
        state,
        dispatch
    }, {
        externalId
    }) {
        return this._vm.$axios
            .workoutExecution()
            .delete(`/Workout/${externalId}`)
            .then(() => Promise.all([
                dispatch('updateWorkoutExecutionViewState', state.username, externalId),
                dispatch('deleteFromStateBackLog', externalId)
            ]));
    },
    deleteFromStateBackLog:({state, commit}, externalId)=>{
        if (state.backLog != undefined) {
            let backLog = state.backLog.filter(x=>x.externalId != externalId);
            commit('backLog', backLog)
        }
        return Promise.resolve()
    },
    userIsInRole: ({
            state
        }, role) => state.roles != undefined ?
        state.roles.some(x => x == role) : false
}