export default {
	install(Vue, options) {
		Vue.prototype.getFullUrl = function(url) {
			//为空或者已经有前缀了,不进行处理
			if (!url || url.indexOf("http") == 0) {
				return url;
			}
			var config = this.$gloablConfig.config;

			if (config.https) {
				return "https://" + config.apigateway + "/" + config.apiVersion + url;
			}

			return "http://" + config.apigateway + "/" + config.apiVersion + url;;
		};
		Vue.prototype.navTo = function(url) {
			if (!url) {
				return;
			}

			if (!url.toLowerCase().indexOf("http") == 0) {
				url = this.getFullUrl(url)
			}

			this.$router.push(url);
		};
		Vue.prototype.redirectTo = function(url){
			
			window.location.href = this.$gloablConfig.config.https ? "https://"+ url:"http://"+url;
		};
		Vue.prototype.getQueryParam = function(key) {
			var query = window.location.hash;
			if (!query) {
				return "";
			}
			//问号第一次出现的位置
			var questionIndex = query.indexOf('?');
			//排除掉问号
			query = query.substring(questionIndex);
			query = query.substring(1);
			var vars = query.split("&");
			for (var i = 0; i < vars.length; i++) {
				var pair = vars[i].split("=");
				if (pair[0] == key) {
					return pair[1];
				}
			}
			return "";
		};
		
		Vue.prototype.setCookie = function(key ,value){
			this.$cookies.set(key , value , this.$gloablConfig.cookieExpire , this.$gloablConfig.cookieDomain,this.$gloablConfig.cookiePath)
		}
	}
}
