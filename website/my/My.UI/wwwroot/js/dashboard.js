var welcomDiv = new Vue({
    el: '#span-welcom-tips',
    data: {
        welcomInfo: "",
    },
    mounted: function () {
        var token = this.$cookies.get('token');

        var requestUri = "http://localhost:5000/api/v1/users?token=" + token;
        axios.get(requestUri, data, {
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(function (response) {
            if (response.data.success) {
                var name = response.data.data.mname;
                welcomInfo = name; 
            } else {
                alert("登录失败");
            }
        }).catch(function (error) {
            alert("登录失败");
        });
    }
});