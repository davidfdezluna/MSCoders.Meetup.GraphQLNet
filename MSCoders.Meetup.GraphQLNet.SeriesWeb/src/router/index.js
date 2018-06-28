import Vue from 'vue'
import Router from 'vue-router'
import Home from '../containers/Home'

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/',
            Name: 'Home',
            component: Home
        }
    ]
})