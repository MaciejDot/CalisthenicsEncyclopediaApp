import ChooseWorkout from '.././components/workout/ChooseWorkout'
import MainPage from '.././components/MainPage'
import Login from '.././components/account/Login.vue'
import SuccessSignOut from '.././components/account/SuccessSignOut.vue'
import Register from '.././components/account/Register.vue'
import NotFound from '.././components/routing/NotFound.vue'
import WorkoutCreator from '.././components/workout/WorkoutCreator'
import WorkoutViewer from '.././components/workout/WorkoutViewer.vue'
import WorkoutExecution from '.././components/workout/WorkoutExecution.vue'
import Calendar from '.././components/workout/Calendar.vue'
import WorkoutExecutionViewer from '../components/workout/WorkoutExecutionViewer'

export default [{
        path: '',
        name: "Main Page",
        component: MainPage,
        meta: {
            title: 'Calisthenics Encyclopedia'
          }
    },
    {
        path: '/workout',
        component: ChooseWorkout,
        meta: {
            title: 'Calisthenics Encyclopedia - Workout Dashboard',
            onlyAuthenticated: true
          }
    },
    {
        path: '/Login',
        component: Login,
        meta: {
            title: 'Calisthenics Encyclopedia - Login',
            onlyAnonymous: true,
            reload: true
          }
    },
    {
        path: '/Register',
        component: Register,
        meta: {
            title: 'Calisthenics Encyclopedia - Register',
            onlyAnonymous: true,
            reload: true
          }
    },
    {
        path: '/SuccessSignOut',
        component: SuccessSignOut,
        meta: {
            title: 'Calisthenics Encyclopedia - Success Sign Out',
            onlyAnonymous: true
          }
    },
    {
        path: '/WorkoutCreator',
        component: WorkoutCreator,
        meta: {
            title: 'Calisthenics Encyclopedia - Workout Creator',
            onlyAuthenticated: true
          },
          props: () => ({username: undefined, externalId: undefined})
    },
    {
        path: '/WorkoutCreator/:username/:externalId',
        component: WorkoutCreator,
        meta: {
            title: 'Calisthenics Encyclopedia - Workout Creator',
            onlyAuthenticated: true,
          },
        props: (route) => ({username: route.params.username, externalId: route.params.externalId})
    },
    {
        path: '/WorkoutExecution',
        component: WorkoutExecution,
        meta: {
            title: 'Calisthenics Encyclopedia - Workout Execution'
          },
        props: () => ({username: undefined, externalId: undefined})
    },
    {
        path: '/WorkoutExecution/:username/:externalId',
        component: WorkoutExecution,
        meta: {
            title: 'Calisthenics Encyclopedia - Workout Execution'
          },
          props: (route) => ({username: route.params.username, externalId: route.params.externalId})
    },
    {
        path: '/Calendar',
        component: Calendar,
        meta: {
            title: 'Calisthenics Encyclopedia - Calendar',
            onlyAuthenticated: true,
          }

    },
    {
        path: '/WorkoutViewer/:username/:externalId',
        component: WorkoutViewer,
        meta: {
            title: 'Calisthenics Encyclopedia - Workout Viewer'
          },
          props: (route) => ({username: route.params.username, externalId: route.params.externalId})
    },
    {
        path: '/WorkoutExecutionViewer/:username/:externalId',
        component: WorkoutExecutionViewer,
        meta: {
            title: 'Calisthenics Encyclopedia - Workout Execution'
          },
          props: (route) => ({username: route.params.username, externalId: route.params.externalId})
    },
    {
        path: '*',
        component: NotFound,
        meta: {
            title: 'Calisthenics Encyclopedia - 404'
          }
    }
];