var login = new Vue({
    el: '.m-reg-box',
    data: {
        loginButtonTitle:"登录",
        loginButtonUrl: this.$gatewayHost+"/sessions",
        loginButtonId : "btnLogin",
        loginButtonData: null,
        loginButtonClass: "m-btn-blue",
        email: "",
        password:""
    },
    methods: {
        loginSuccessd: function (data) {
            var token = data.token;
            window.location.href = this.$mySiteHost+"?token=" + token;
        },
        loginFailed: function (data) {
            alert("账号或者密码错误!")
        },
        getLoginPostData: function () {
            return { "Email": this.email, "Password": this.password };
        }

    },
    created: function () {
        this.$gatewayHost;
    }
});