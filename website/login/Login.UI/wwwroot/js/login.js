var login = new Vue({
    el: '.m-reg-box',
    data: {
        loginButtonTitle:"登录",
        loginButtonUrl : "http://127.0.0.1:5000/api/v1/sessions",
        loginButtonId : "btnLogin",
        loginButtonData: null,
        loginButtonClass: "button-class",
        loginSuccessd: function (data) {

        },
    },
    methods: {
        login: function () {
            
        }
    },
    created: function () {
        
    }
});