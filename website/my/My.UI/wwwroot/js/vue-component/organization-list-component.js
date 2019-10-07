Vue.component('organization-list', {
    props: {
        organization: Object
    },
    data: function () {
        return {
            versionName: this.organization.versionId === 1 ? "标准版" : "记账版",
            roleName: "管理员"

        };
    },
    methods: {
        click_event: function () {
            var options = {
                url: "http://127.0.0.1:5000/api/v1/sessions",
                method: "put",
                data: { organizationId: this.organization.id },
                onSuccessed: function (response) {
                    var data = response.data;

                    if (data.WizardStep < 15) {
                        //走向导的逻辑
                        window.location.href = "http://127.0.0.1:7002?token=" + this.$cookies.get('token');
                    } else {
                        //跳转到go页面
                        window.top.location.href = "http://127.0.0.1:7002?token=" + this.$cookies.get('token');
                    }
                },
                onFailed: function (response) {
                    var data = response.data;
                    if (data.message) {
                        alert(data.message);
                    }
                }
            };
            this.$axios(options);
        },
        relation_event: function () {

        },
        delete_event: function () {

        }
    },
    template:
        '<div class="m-bank-try item" status="2" version="0">' +
            '<div class="title" >' +
                '<a href="javascript:void(0);" class="name" style="color:#048fc2" title="点击进入组织" v-on:click="click_event">{{ organization.displayName }}</a >' +
            '</div> ' +
            '<div class="info">' +
                '<span class="info1" style="color:#e23f2a;font-weight:bold"><label>您正在使用</label>{{ versionName }}</span>' +
                '<span class="info3"><label style="">您的角色：</label>{{ roleName }}</span>' +
                '<span class="info3"><label>创建日期:</label>2018-12-26</span>' +
                '<span class="info4"><label>关联事务所:</label><a class="m-changetype" href="javascript:void(0)" v-on:click="relation_event">—</a></span>' +
            '</div>' +
            '<div class="info">' +
                '<span class="info1 version">试用期</span>' +
                '<span class="info3"><label>最后访问日期：</label>2019-04-16</span>' +
                '<span class="info3"><label>到期日期:</label>2029-01-23</span>' +
                '<span class="info4">' +
                    '<a href="javascript:void(0)" class="easyui-linkbutton l-btn l-btn-small" id="aDelete" v-on:click="delete_event">' +
                        '<span class="l-btn-left"><span class="l-btn-text">删除</span></span>' +
                    '</a>' +
                '</span>' +
            '</div>' +
        '</div > '
});
