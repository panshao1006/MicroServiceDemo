Vue.component('button-yellow', {
    props:{
        button-title:String,
        button-color:String,
        button-id:String,
        romote-url:String,
        http-method:String,
        post-data:Object,
        successed:Function,
        failed:Function,
    }, 
    data: function () {
        return {
           
        }
    },
    method: {
        click_event: function () {
            var options = {url:romote-url , method:http-method , data:post-data , onSuccessed:successed , onFailed:failed}
            this.$axios(options);
        }
    },
    template: '<a href="javascript:void(0)" class="easyui-linkbutton-yellow l-btn l-btn-small" v-bind:on="click_event" group=""><span class="l-btn-left">{{button-title}}<span class="l-btn-text"></span></span></a>'
});

Vue.component('button-normal', {
    props:{
        button-title:String,
        button-class:String,
        button-id:String,
        romote-url:String,
        http-method:String,
        post-data:Object,
        successed:Function,
        failed:Function,
    }, 
    data: function () {
        return {
           
        }
    },
    method: {
        click_event: function () {
            var options = {url:romote-url , method:http-method , data:post-data , onSuccessed:successed , onFailed:failed}
            this.$axios(options);
        }
    },
    template: '<a href="javascript:void(0)" class="{{button-class}}" v-bind:on="click_event">{{button-title}}</a>'
})