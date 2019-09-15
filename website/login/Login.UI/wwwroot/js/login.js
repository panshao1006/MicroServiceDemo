var loginButton = new Vue({
    el: '#btnLogin',
    methods: {
        login: function () {
            var self = this;
            this.isViewReady = false;

            var requestUri = "http://localhost:5000/api/v1/sessions";
            let data = {"Email":"591387160@qq.com","Password":"megi#123"};

            axios.post(requestUri , data)
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