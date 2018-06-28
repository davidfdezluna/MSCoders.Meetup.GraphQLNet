import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const state = { data: [] }

const mutations = {}

//TODO: PENDIENTE HACER LAS ACCIONES ASYNC (AXIOS?)
const actions = {
    SEARCH_SERIES({ commit }, name) {
        console.log("Vuex SEARCH_SERIES: " + name)
        //var s = this.$apollo;
    }
}

const getters = {
    series: state => {
        return state.data
    }
}

const store = new Vuex.Store({
    state, mutations, actions, getters
})

export default store