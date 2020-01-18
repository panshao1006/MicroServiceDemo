import Vue from 'vue'
import App from './App.vue'

import router from './router/index.js'
//import $ from 'jquery'

import VueCookies from 'vue-cookies'
Vue.use(VueCookies)

import 'element-ui/lib/theme-chalk/index.css' //导入样式
import ElementUI from 'element-ui'
Vue.use(ElementUI)

import axios from "axios"
Vue.prototype.$axios = axios

//自定义
import './assets/css/site.css'

import gloablConfig from './static/config.js'
import utils from './assets/js/common.js'
import httpAjax from './assets/js/http.js'

Vue.prototype.$gloablConfig = gloablConfig
Vue.use(utils)
Vue.use(httpAjax)

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
