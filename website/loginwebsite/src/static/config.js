const config = {
	https: false,
	apiVersion: "v1",
	apigateway: "localhost:5000/api",
	gosite: "127.0.0.1:8081",
	cookieDomain:"megi",
	cookiePath:"./",
	//保存7天
	cookieExpire:60*60*24*7
}

export default {
	config
}
