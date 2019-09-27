Vue.prototype.$axios = function (options) {
    if (!options || !options.method) {
        
        return;
    }

    axios.defaults.headers.common["token"] = this.$cookies.get('token');
    axios.defaults.headers.post["Content-type"] = "application/json";

    var httpMethod = options.method.toLowerCase();

    switch (httpMethod) {
        case "post":
            axios.post(options.url, options.data)
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
            break;
        case "get":
             axios.get(options.url)
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
            break;
        default:
            break;
    }
}