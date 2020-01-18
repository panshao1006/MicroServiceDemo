export default {
	install(Vue, options) {
		Vue.prototype.request = function(options) {
			if (!options || !options.method) {

				return;
			}
			var that = this;
			var axios = this.$axios;
			axios.defaults.headers.common["Token"] = this.$cookies.get('Token');
			axios.defaults.headers.post["Content-type"] = "application/json";

			var httpMethod = options.method.toLowerCase();

			switch (httpMethod) {
				case "post":
					axios.post(options.url, options.data)
						.then(function(response) {
							if (response.data || response.data.success) {
								if (options.success) {
									options.success(response.data);
								}
							} else {
								if (options.failed) {
									options.failed(response.data);
								}

							}
						})
						.catch(function(error) {
							if (options.error) {
								options.error(error);
							} else {
								that.$message({
									showClose: true,
									message: '无法连接服务器',
									type: 'error'
								});
							}
						});
					break;
				case "get":
					axios.get(options.url)
						.then(function(response) {
							if (response.data || response.data.success) {
								if (options.success) {
									options.success(response.data)
								}
							} else {
								if (options.failed) {
									options.failed(response.data);
								}

							}
						})
						.catch(function(error) {
							if (options.error) {
								options.error(error);
							}else {
								that.$message({
									showClose: true,
									message: '无法连接服务器',
									type: 'error'
								});
							}
						});
					break;
				case "put":
					axios.put(options.url, options.data)
						.then(function(response) {
							if (response.data || response.data.success) {
								if (options.success) {
									options.success(response.data);
								}
							} else {
								if (options.failed) {
									options.failed(response.data);
								}

							}
						})
						.catch(function(error) {
							if (options.error) {
								options.error(response.data);
							}else {
								that.$message({
									showClose: true,
									message: '无法连接服务器',
									type: 'error'
								});
							}
						});
					break;
				default:
					break;
			}
		}
	}
}
