// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './store'
import apolloProvider from './apollo'

Vue.config.productionTip = false

//store.$apollo = apolloProvider

/* eslint-disable no-new */
new Vue({
  el: '#app',
  apolloProvider,
  router,
  store,
  template: '<App/>',
  components: { App }
})
