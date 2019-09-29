Vue.prototype.$confirgurationManager = async function () {

    var configurationUrl = "http://127.0.0.1:8000/api/v1/configurations?environment=DEV&appid=Login.UI";

    var options = {};
    options.url = configurationUrl;
    options.method = "get";

    options.onSuccessed = async function (response) {

        if (!response || !response.success || !response.data) {
            return;
        }

        var data = response.data;

        for (var i = 0; i < data.length; i++) {
            var keyValue = data[i];

            switch (keyValue.key) {
                case "GatewayHost":
                    Vue.prototype.$gatewayHost = keyValue.value;
                    break;
                case "MySiteHost":
                    Vue.prototype.$mySiteHost = keyValue.value;
                    break;
            }
        }
    };

    await this.$axiosAsync(options);
};
