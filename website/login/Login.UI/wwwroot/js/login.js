var loginButton = new Vue({
    el: '#btnLogin',
    methods: {
        login: function () {
            var requestUri = "http://localhost:5000/api/v1/sessions";
            let data = {"Email":"591387160@qq.com","Password":"megi#123"};

            axios.post(requestUri , data)
                .then(function (response) {
                    if (response.data.success) {
                        var token = response.data.data.token;
                        window.location.href = "http://localhost:7001?token=" + token;
                    } else {
                        alert("登录失败");
                    }
                })
                .catch(function (error) {
                    alert("登录失败");
                });
        }
    },
    created: function () {
        
    }
});