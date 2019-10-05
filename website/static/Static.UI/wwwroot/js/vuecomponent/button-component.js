Vue.component('button-yellow', {
    props:{
        buttonTitle:String,
        buttonColor:String,
        buttonId:String,
        romoteUrl:String,
        httpMethod:String,
        postData:Object,
        successed:Function,
        failed:Function
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
        buttonTitle: String,
        buttonId: String,
        remoteUrl: String,
        httpMethod: String,
        postData: Object,
        buttonClass: String,
        initPostData: Function,
        successCallback:Function,
        failCallback:Function
    }, 
    template: '<a href="javascript:void(0)" v-bind:id="buttonId" v-bind:class="buttonClass" v-on:click="clickEvent">{{buttonTitle}}</a>',
    data: function () {
        return {
            $remoteUrl: this.remoteUrl,
            $httpMethod: this.httpMethod,
            $postData: this.postData,
            $setData: this.initPostData,
            $successCallback: this.successCallback,
            $failCallback: this.failCallback
        };
    },
    methods: {
        clickEvent: function () {

            if (this.initPostData) {
                this.postData = this.initPostData();
            }

            var options = { url: this.remoteUrl, method: this.httpMethod, data: this.postData, onSuccessed: this.successCallback, onFailed: this.failCallback };
            this.$axios(options);
        }
    }
})