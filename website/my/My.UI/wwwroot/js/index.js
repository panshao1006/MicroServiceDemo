var home = new Vue({
    el: ".my-org",
    mounted: function () {
        let token = null;

        var reg = new RegExp('(^|&)token=([^&]*)(&|$)', 'i');
        var r = window.location.search.substr(1).match(reg);
        if (r != null) {
            token = unescape(r[2]);
        }

        if (token) {
            this.$cookies.set('token', token)
        }
    },
    methods: {
        
    }
});