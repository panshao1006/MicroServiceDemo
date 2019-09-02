import _global from '~/js/globalvariable.vue'
Vue.prototype.global = _global;


Vue.prototype.requestUrl = function (controller, method) {
    var fullURL = this.global.baseURL + controller + "/" + method;

    return fullURL;
};