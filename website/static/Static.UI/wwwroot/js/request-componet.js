Vue.prototype.$axios = function (options) {
    axios.defaults.headers.common["token"] = this.$cookies.set('token', token);
    axios.defaults.headers.post["Content-type"] = "application/json";
    axios.defaults.baseURL = "https://127.0.0.1:5000";

    if (!options) {
        return;
    }

    var httpMethod = options.method;

    if (httpMethod.toLower() == "post") {
        axios.post(options.url, data)
            .then(function (response) {
                if (response.data.success) {
                    if (options.onSuccessed) {
                        options.onSuccessed(response.data)
                    }
                } else {
                    if (options.onFialed) {
                        options.onFialed(response.data);
                    }

                }
            })
            .catch(function (error) {
                if (options.onError) {
                    options.onError(response.data);
                }
            });
    } else if (httpMethod.toLower() == "get") {
        axios.post(options.url)
            .then(function (response) {
                if (response.data.success) {
                    if (options.onSuccessed) {
                        options.onSuccessed(response.data)
                    }
                } else {
                    if (options.onFialed) {
                        options.onFialed(response.data);
                    }

                }
            })
            .catch(function (error) {
                if (options.onError) {
                    options.onError(response.data);
                }
            });
    }
}