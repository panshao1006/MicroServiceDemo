var indexVM = new Vue({
    el:".m-wrapper",
    data: {
        organizationId: "",
        userId: "",
        token:"",
        modules:[]
    },
    mounted: function () {
        let token = null;

        var reg = new RegExp('(^|&)token=([^&]*)(&|$)', 'i');
        var r = window.location.search.substr(1).match(reg);
        if (r != null) {
            token = unescape(r[2]);
        }

        if (token) {
            this.$cookies.set('token', token)
        }

        this.init();
    },
    methods: {
        init: function () {
            //获取token对应的组织信息
            new Promise((resolve, reject) => {
                this.initTokenInfo()
                    .then(response => {
                        this.initModule();
                        resolve(response);
                    })
                    .catch(error => {
                        reject(error);
                    });
            });
        },
        initTokenInfo: async function () {
            await this.$axiosAsync({
                url: "http://127.0.0.1:5000/api/v1/sessions?token=" + this.$cookies.get("token"),
                method: "get",
                onSuccessed: function (response) {
                    indexVM.userId = response.data.userId;
                    indexVM.organizationId = response.data.organizationId;
                },
                onFailed: function () {
                    alert("数据加载失败");
                }
            });
        },
        initModule: function () {
            this.$axios({
                url: "http://127.0.0.1:5000/api/v1/menus?userId=" + indexVM.userId + "&organizationId=" + indexVM.organizationId,
                method: "get",
                onSuccessed: function (response) {
                    let tempModules = response.data;

                    if (tempModules && tempModules.length > 0) {
                        for (var i = 0; i < tempModules.length; i++) {
                            var module = tempModules[i];
                            module.navStyle = "item-link m-nav-" + module.index;
                        }
                    }

                    indexVM.modules = tempModules;

                },
                onFailed: function () {
                    alert("模块数据加载失败");
                }
            });
        }
    }
});