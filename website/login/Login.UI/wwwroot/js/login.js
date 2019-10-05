var login = new Vue({
    el: '.m-reg-box',
    data: {
        loginButtonTitle: "登录",
        loginButtonUrl: this.$gatewayHost + "/sessions",
        loginButtonId: "btnLogin",
        loginButtonData: null,
        loginButtonClass: "m-btn-blue",
        email: "",
        password: "",
        errorTips:""
    },
    methods: {
        loginSuccessd: function (response) {
            var token = response.data.token;
            window.location.href = this.$mySiteHost + "?token=" + token;
        },
        loginFailed: function (data) {
            this.errorTips = "账号或者密码错误!";
        },
        getLoginPostData: function () {
            return { "Email": this.email, "Password": this.password };
        }

    },
    mounted: function () {
        //await this.$confirgurationManager();

        new Promise((resolve, reject) => {
            this.$confirgurationManager()
                .then(response => {
                    this.loginButtonUrl = this.$gatewayHost + "/sessions";
                    resolve(response);
                })
                .catch(error => {
                    reject(error);
                });
        });


    }
});