var welcomeDiv = new Vue({
    el: '#span-welcom-tips',
    data: {
        welcomeInfo: "您好，"
    },
    created: function () {
        var token = this.$cookies.get('token');

        var requestUri = "http://localhost:5000/api/v1/users/" + token;

        var options = {};
        options.url = requestUri;
        options.method = "get";

        options.onSuccessed = async function (response) {

            if (!response || !response.success || !response.data) {
                return;
            }

            var data = response.data;

            var name = data.name;
            welcomeDiv.$data.welcomeInfo += name;
        };

        this.$axios(options);
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
            //var topContentDiv = top.$(".m-tab-content[data-index='1']");

            //topContentDiv.css("display", "block");

            //topContentDiv.find("iframe").src = "/initialization/index";
        }
    }
});

var main = new Vue({
    el: '.m-imain',
    data: {
        organizations:[]
    },
    mounted: function () {
        
        var requestUri = "http://localhost:5000/api/v1/organizations";
        var options = { url: requestUri, method: "get", onSuccessed: this.successCallback, onFailed: this.failCallback };
        this.$axios(options);
    },
    methods: {
        successCallback: function (response) {
            this.organizations = response.data;
        },
        failCallback: function (data) {

        }
    }
});