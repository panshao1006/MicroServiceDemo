
//import _global from "~/js/globalvariable.vue"  
//Vue.prototype.global = _global;  

var loginButton = new Vue({
    el: '#aLogin',
    methods: {
        login: function () {
            var self = this;
            this.isViewReady = false;

            var requestUri = "http://localhost:5000/api/v1/user/login";

            //UPDATED TO GET DATA FROM WEB API
            axios.get(requestUri)
                .then(function (response) {
                    self.subscribers = response.data;
                    self.isViewReady = true;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }
    },
    created: function () {
        
    }
});