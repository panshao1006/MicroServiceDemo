(function(t){function e(e){for(var i,r,o=e[0],l=e[1],c=e[2],p=0,d=[];p<o.length;p++)r=o[p],s[r]&&d.push(s[r][0]),s[r]=0;for(i in l)Object.prototype.hasOwnProperty.call(l,i)&&(t[i]=l[i]);u&&u(e);while(d.length)d.shift()();return n.push.apply(n,c||[]),a()}function a(){for(var t,e=0;e<n.length;e++){for(var a=n[e],i=!0,o=1;o<a.length;o++){var l=a[o];0!==s[l]&&(i=!1)}i&&(n.splice(e--,1),t=r(r.s=a[0]))}return t}var i={},s={app:0},n=[];function r(e){if(i[e])return i[e].exports;var a=i[e]={i:e,l:!1,exports:{}};return t[e].call(a.exports,a,a.exports,r),a.l=!0,a.exports}r.m=t,r.c=i,r.d=function(t,e,a){r.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:a})},r.r=function(t){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},r.t=function(t,e){if(1&e&&(t=r(t)),8&e)return t;if(4&e&&"object"===typeof t&&t&&t.__esModule)return t;var a=Object.create(null);if(r.r(a),Object.defineProperty(a,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var i in t)r.d(a,i,function(e){return t[e]}.bind(null,i));return a},r.n=function(t){var e=t&&t.__esModule?function(){return t["default"]}:function(){return t};return r.d(e,"a",e),e},r.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},r.p="/";var o=window["webpackJsonp"]=window["webpackJsonp"]||[],l=o.push.bind(o);o.push=e,o=o.slice();for(var c=0;c<o.length;c++)e(o[c]);var u=l;n.push([0,"chunk-vendors"]),a()})({0:function(t,e,a){t.exports=a("56d7")},"13ee":function(t,e,a){},"3c3a":function(t,e,a){},"56d7":function(t,e,a){"use strict";a.r(e);a("cadf"),a("551c"),a("f751"),a("097d");var i=a("2b0e"),s=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("router-view")},n=[],r={data:function(){return{}}},o=r,l=a("2877"),c=Object(l["a"])(o,s,n,!1,null,null,null),u=c.exports,p=a("8c4f"),d=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"m-reg-box"},[a("div",{staticClass:"m-login-box",attrs:{id:"loginBox"}},[a("div",{staticClass:"container form-login-content"},[a("div",{staticClass:"megi-logo"}),a("div",{staticClass:"lang-bar"},[t._v("\n\t\t\t\t切换语言 中文简体\n\t\t\t")]),a("div",{staticClass:"main login"},[a("p",{staticClass:"item-wrap"},[a("el-input",{attrs:{id:"txtEmail",placeholder:"请输入邮箱"},model:{value:t.email,callback:function(e){t.email=e},expression:"email"}})],1),a("p",{staticClass:"item-wrap"},[a("el-input",{attrs:{type:"password",placeholder:"请输入密码"},model:{value:t.password,callback:function(e){t.password=e},expression:"password"}})],1),a("div",[a("el-link",{attrs:{type:"primary"},on:{click:function(e){return t.navToForgot()}}},[t._v("忘记密码")])],1),t._m(0),a("div",{staticClass:"error-msg",attrs:{id:"lblError"}},[t._v("\n\t\t\t\t\t"+t._s(t.errorTips)+"\n\t\t\t\t")]),a("div",{staticClass:"m-action"},[a("el-button",{staticStyle:{width:"380px"},attrs:{type:"primary"},on:{click:function(e){return t.loginEvent()}}},[t._v("登录")])],1),t._m(1),a("div",{staticClass:"m-trial-wrap"},[a("el-button",{staticStyle:{width:"200px"},attrs:{type:"warning",plain:""},on:{click:function(e){return t.navToRegister()}}},[t._v("免费试用")])],1)])])])])},f=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("p",{staticStyle:{width:"260px",display:"none"},attrs:{id:"divCode"}},[a("input",{staticClass:"easyui-validatebox textbox",staticStyle:{width:"60px",height:"26px","line-height":"26px","padding-left":"2px","background-image":"none"},attrs:{type:"text",id:"tbxCode",hint:"验证码"}}),a("span",{staticStyle:{display:"none"},attrs:{id:"divCodeImage"}},[a("label",{staticStyle:{width:"16px",height:"16px",padding:"1px 5px",margin:"0 auto"},attrs:{id:"isCorrent",href:"javascript:void(0);",code:"false"}},[t._v("  ")]),a("a",{attrs:{href:"javascript:void(0);",id:"btnChangeImage"}},[t._v("看不清")])])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"m-reg-wrap"},[a("span",{staticStyle:{color:"red"}}),a("br"),a("span",[t._v("没有账号")])])}],v={data:function(){return{email:"",password:"",errorTips:"",loginRequestUrl:this.getFullUrl("/sessions")}},methods:{loginEvent:function(){this.errorTips="",this.email&&this.password||(this.errorTips="请输入邮箱和密码");this.request({url:this.loginRequestUrl,type:"post",data:{emailAddress:this.email,password:this.password},success:this.loginSuccessEvent})},loginSuccessEvent:function(t){if(t&&t.Success&&t.Data){var e=t.Data;this.$cookie.set("Token",e.TokenId),this.$cookie.set("LangId",e.langId);var a=this.$gloablConfig.gosite;this.$utils.navTo(a)}else{var i=t&&t.Message?t.Message:"登录失败";this.errorTips=i}},navToRegister:function(){this.$router.push("/register")},navToForgot:function(){this.$router.push("/forgot")}}},h=v,m=(a("8041"),Object(l["a"])(h,d,f,!1,null,null,null)),g=m.exports,_=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"m-reg-box"},[a("div",{staticClass:"container form-login-content reg",attrs:{id:"register"}},[a("div",{staticClass:"megi-logo"}),a("div",{staticClass:"lang-bar",staticStyle:{"margin-top":"10px"}},[t._v("\n            切换语言 : English\n        ")]),a("div",{staticClass:"main",attrs:{id:"divUserRegister"}},[a("el-row",{staticClass:"item-wrap",attrs:{gutter:10}},[a("el-col",{attrs:{span:12}},[a("el-input",{attrs:{placeholder:"请输入名"},model:{value:t.firstName,callback:function(e){t.firstName=e},expression:"firstName"}})],1),a("el-col",{attrs:{span:12}},[a("el-input",{attrs:{placeholder:"请输入姓"},model:{value:t.lastName,callback:function(e){t.lastName=e},expression:"lastName"}})],1)],1),a("div",{staticClass:"item-wrap"},[a("el-input",{attrs:{placeholder:"请输入邮箱"},model:{value:t.email,callback:function(e){t.email=e},expression:"email"}})],1),a("div",{staticClass:"item-wrap"},[a("el-input",{attrs:{placeholder:"请输入手机号码"},model:{value:t.phone,callback:function(e){t.phone=e},expression:"phone"}})],1),a("div",{staticClass:"text-agree-term"},[a("el-checkbox",{model:{value:t.checked,callback:function(e){t.checked=e},expression:"checked"}}),t._m(0),a("span",{staticClass:"reg-error-image"},[t._v(" ")])],1),a("div",{staticClass:"error-msg"},[t._v("\n\t\t\t\t"+t._s(t.errorTips)+"\n            ")]),a("div",{staticClass:"m-action"},[a("el-button",{staticStyle:{width:"385px"},attrs:{type:"primary"},on:{click:function(e){return t.registerEvent()}}},[t._v("注册")])],1),a("div",{staticClass:"m-signIn-wrap"},[t._m(1),t._m(2),a("div",{staticClass:"wrap-btn"},[a("el-link",{attrs:{type:"primary"},on:{click:function(e){return t.navToLogin()}}},[t._v("点击此处登录")])],1)])],1)])])},b=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("span",[t._v("\n                    我已阅读和确认\n                    "),a("a",{staticClass:"line",attrs:{href:"Https://static.megichina.com/Content/MEGI_Standard_Terms_of_Use.pdf",target:"_blank"}},[t._v("使用条款")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"wrap-problem"},[t._v("有问题请"),a("a",{attrs:{id:"megiFeedback",href:"https://www.megichina.com/contact/",target:"_Blank"}},[t._v("联系我们")]),t._v("，我们将竭诚为您服务。 ")])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"wrap-have-account"},[a("span",[t._v("已经拥有账号？")])])}],y=a("bd86"),w={data:function(){var t;return t={firstName:"",lastName:"",phone:"",email:""},Object(y["a"])(t,"phone",""),Object(y["a"])(t,"checked",!1),Object(y["a"])(t,"errorTips",""),t},methods:{registerEvent:function(){this.errorTips="",this.checked?this.firstName&&this.lastName?this.email?this.phone||(this.errorTips="请填写手机号码"):this.errorTips="请填写邮箱":this.errorTips="请填写姓和名":this.errorTips="请先同意使用条款"},navToLogin:function(){this.$router.push("./")}}},C=w,x=(a("ac59"),Object(l["a"])(C,_,b,!1,null,null,null)),k=x.exports,T=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"m-reg-box"},[a("div",{staticClass:"container form-login-content m-find-pwd"},[a("div",{staticClass:"forgot-logo"}),a("div",{staticClass:"forgot-title"},[t._v("忘记密码?")]),a("div",{staticClass:"forgot-tip"},[t._v("重设密码，请先输入Email地址。")]),a("div",{staticClass:"main reg",attrs:{id:"divSendlink"}},[a("div",{staticClass:"item-wrap"},[a("el-input",{attrs:{placeholder:"请输入注册时的邮箱"},model:{value:t.email,callback:function(e){t.email=e},expression:"email"}})],1),a("div",{staticClass:"error-message"},[t._v("\n\t\t\t\t"+t._s(t.errorMessage)+"\n\t\t\t")]),a("div",{staticClass:"m-action"},[a("el-button",{staticStyle:{width:"100%"},attrs:{type:"primary"},on:{click:function(e){return t.sendLink()}}},[t._v("发送验证链接")])],1),a("div",{staticClass:"m-signIn-wrap"},[t._m(0),t._m(1),a("div",{staticClass:"wrap-btn"},[a("el-link",{attrs:{type:"primary"},on:{click:function(e){return t.navToLogin()}}},[t._v("点击此处登录")])],1)])])])])},E=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"wrap-problem"},[t._v("有问题请"),a("a",{attrs:{id:"megiFeedback",href:"javascript:void(0);"}},[t._v("联系我们")]),t._v("，我们将竭诚为您服务。 ")])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"wrap-have-account"},[a("span",[t._v("已经拥有账号？")])])}],j={data:function(){return{email:"",errorMessage:""}},methods:{sendLink:function(){this.errorMessage="",this.email||(this.errorMessage="请输入注册时的邮箱")},navToLogin:function(){this.$router.push("/")}}},S=j,O=(a("c9d4"),Object(l["a"])(S,T,E,!1,null,null,null)),M=O.exports;i["default"].use(p["a"]);var N=[{path:"/",component:g},{path:"/register",component:k},{path:"/forgot",component:M},{path:"",redirect:"Index"}],I=new p["a"]({routes:N}),F=I,L=(a("1157"),a("2b27")),U=a.n(L),P=(a("0fae"),a("5c96")),R=a.n(P),q=(a("13ee"),{https:!1,apiVersion:"v1",apigateway:"127.0.0.1:5000",gosite:"127.0.0.1:8081"}),J={config:q},V=(a("57e7"),{install:function(t,e){t.prototype.getFullUrl=function(t){if(!t||0==t.indexOf("http"))return t;var e=this.$gloablConfig.config;return e.https?"https://"+e.apigateway+"/"+e.apiVersion+"/"+t:"http://"+ +e.apigateway+"/"+e.apiVersion+"/"+t},t.prototype.navTo=function(t){t&&(0==!t.toLowerCase().indexOf("http")&&(t=this.getFullUrl(t)),this.$router.push(t))}}}),B={install:function(t,e){t.prototype.request=function(t){$.ajax({type:t.type,accepts:"application/json",contentType:"application/json",url:t.url,data:JSON.stringify(t.data),success:function(e){t.success&&$.isFunction(t.success)&&t.success(e)},error:function(t){console.log(t.status),console.log(t.responseText)}})}}};i["default"].use(U.a),i["default"].use(R.a),i["default"].prototype.$gloablConfig=J,i["default"].use(V),i["default"].use(B),i["default"].config.productionTip=!1,new i["default"]({router:F,render:function(t){return t(u)}}).$mount("#app")},"64a7":function(t,e,a){},8041:function(t,e,a){"use strict";var i=a("64a7"),s=a.n(i);s.a},ac59:function(t,e,a){"use strict";var i=a("c95a"),s=a.n(i);s.a},c95a:function(t,e,a){},c9d4:function(t,e,a){"use strict";var i=a("3c3a"),s=a.n(i);s.a}});
//# sourceMappingURL=app.9c1ef83d.js.map