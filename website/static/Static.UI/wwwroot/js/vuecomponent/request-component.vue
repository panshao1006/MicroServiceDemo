Vue.component('request-component', {
    props:{
        romote-url:String,
        http-method:String,
        post-data:Object,
        successed:Function,
        failed:Function,
		error:Function,
    }, 
    data: function () {
        return {
           
        }
    },
    method: {
        get: function () {
            if(!this.romote-url){
                return;
            }
            axios.get(this.romote-url)
                .then(function (response) {
                    if (response.data.success) {
                        this.successed(response.data);
                    } else {
                        this.failed(response.data);
                    }
                })
                .catch(function (error) {
                    this.error(error);
                });
        },
		post:function(){
            axios.post(this.romote-url , this.post-data)
                .then(function (response) {
                    if (response.data.success) {
                        this.successed(response.data);
                    } else {
                        this.failed(response.data);
                    }
                })
                .catch(function (error) {
                   this.error(error);
                });
		}
    }
})