Vue.component('list-combo', {
    props: {
        selectedId: String,
        textField: String,
        valueField:String,
        dataSource: Array,
        onChange: Function,
        customClass:String
    },
    data: function () {
        return {
            selectedName: null,
            finalTextField: null,
            finalValueField: null,
            panelStyle: {
                position:"fixed",
                display: "none",
                top: "0px",
                left: "0px",
                zIndex:"8888"
            }
        };
    },
    mounted: function () {
       
        this.finalTextField = this.textField ? this.textField : "id";
        this.finalValueField = this.valueField ? this.valueField : "text";
    },
    beforeUpdate: function () {
        this.init();
    },
    methods: {
        click_event: function (e) {
            //点击名称时做一次panel的计算
            var dom = e.target;
            var left = dom.offsetLeft;
            var top = dom.offsetTop;

            this.panelStyle.top = (top + 50) + "px";
            this.panelStyle.left = (left - 20) + "px";
            this.panelStyle.display = this.panelStyle.display == "none" ? "block" : "none";

        },
        change_event: function (id) {
            if (this.onChange) {
                this.onChange(id);
            }
        },
        init: function () {

            if (this.selectedName) {
                return;
            }

            if (this.dataSource == null || this.dataSource.length == 0) {
                return "";
            }

            for (var i = 0; i < this.dataSource.length; i++) {
                var currentData = this.dataSource[i];
                var id = currentData[this.finalValueField];

                if (id == this.selectedId) {
                    this.selectedName = currentData[this.finalTextField];
                }
            }
        }
    },
    template:
        '<div>'+
            '<div v-bind:class="customClass"><a href="javacript:void(0);" class="list-combo" v-bind:currentId="selectedId" v-on:click="click_event($event)">{{selectedName}}</a></div>' +
            '<div class="m-pop-box m-pop-menu" v-bind:style="panelStyle">' +
                '<b class="popup-arrow" style="left: 20px;"></b>' +
                '<div class="item-list" style="height: 304px;">' +
                    '<p v-for="data in dataSource"><a href="javascript:void(0);" v-on:click="change_event(data[finalValueField])">{{data[finalTextField]}}</a></p>' +
                '</div>' +
            '</div>' +
        '</div>'
});