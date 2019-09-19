var welcomDiv = new Vue({
    el: '#span-welcom-tips',
    data: {
        welcomInfo: "您好，",
    },
    mounted: function () {
        var token = this.$cookies.get('token');

        var requestUri = "http://localhost:5000/api/v1/users/" + token;
        axios.get(requestUri, {
            headers: {
                'Content-Type': 'application/json',
                'token': token
            }
        }).then(function (response) {
            if (response.data.success) {
                var name = response.data.data.mName;
                this.welcomInfo += name;
            } else {
                alert("登录失败");
            }
        }).catch(function (error) {
            alert("登录失败");
        });
    },
    methods: {
        initName: function (name) {
            this.welcomInfo += name;
        }
    }
});

var btnAddOrganization = new Vue({
    el: '#btnAddOrganization',
    methods: {
        click: function () {

        }
    }
});

var organizationList = new Vue({
    el: '#span-welcom-tips',
    data: {
        welcomInfo: "您好，",
    },
    mounted: function () {
        var token = this.$cookies.get('token');

        var requestUri = "http://localhost:5000/api/v1/users/" + token;
        axios.get(requestUri, {
            headers: {
                'Content-Type': 'application/json',
                'token': token
            }
        }).then(function (response) {
            if (response.data.success) {
                var name = response.data.data.mName;
                this.welcomInfo += name;
            } else {
                alert("登录失败");
            }
        }).catch(function (error) {
            alert("登录失败");
        });
    },
    methods: {
        initName: function (name) {
            this.welcomInfo += name;
        }
    }
});