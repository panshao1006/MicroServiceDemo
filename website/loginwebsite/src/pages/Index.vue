<template>
	<div class="m-reg-box">
		<div id="loginBox" class="m-login-box">
			<div class="container form-login-content">
				<div class="megi-logo">

				</div>
				<div class="lang-bar">
					切换语言 中文简体
				</div>

				<div class="main login">
					<p class="item-wrap">
						<el-input id="txtEmail" v-model="email" placeholder="请输入邮箱"></el-input>
					</p>
					<p class="item-wrap">
						<el-input type="password" v-model="password" placeholder="请输入密码"></el-input>
					</p>
					<div>
						<el-link type="primary" v-on:click="navToForgot()">忘记密码</el-link>
					</div>
					<p id="divCode" style="width:260px;display:none">
						<input type="text" id="tbxCode" class="easyui-validatebox textbox" hint="验证码" style="width: 60px; height: 26px; line-height:26px; padding-left: 2px;background-image:none;" />
						<span id="divCodeImage" style="display:none">
							<label id="isCorrent" href="javascript:void(0);" code="false" style="width: 16px; height: 16px; padding: 1px 5px;margin:0 auto;">&nbsp;&nbsp;</label>

							<a href="javascript:void(0);" id="btnChangeImage">看不清</a>
						</span>
					</p>
					<div id="lblError" class="error-msg">
						{{errorTips}}
					</div>
					<div class="m-action">
						<el-button type="primary" style="width: 380px;" v-on:click="loginEvent()">登录</el-button>
					</div>
					<div class="m-reg-wrap">
						<span style="color:red"></span>
						<br />
						<span>没有账号</span>
					</div>
					<div class="m-trial-wrap">
						<el-button type="warning" plain style="width: 200px;" v-on:click="navToRegister()">免费试用</el-button>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	export default {
		data() {
			return {
				email: '',
				password: '',
				errorTips: "",
				loginRequestUrl:this.getFullUrl("/sessions")
			}
		},
		methods: {
			loginEvent: function() {
				
				this.errorTips = "";
				if (!this.email || !this.password) {
					this.errorTips = "请输入邮箱和密码";
					return;
				}
				var that = this;
				this.request({
					url:this.loginRequestUrl,
					method:"post",
					data:{EmailAddress:this.email , Password:this.password},
					success:function(response){
						that.loginSuccessEvent(response , that);
					},
					failed:function(){
						that.loginFailEvent(response , that)
					}
					
				})
			},
			loginSuccessEvent:function(response , that){
				
				if(response && response.success && response.data){
					var data = response.data;
					//保存token
					that.setCookie("Token", data.tokenId);
					that.setCookie("LangId" , data.langId);
					
					var gosite = that.$gloablConfig.config.gosite;
					
					that.redirectTo(gosite);
				}else{
					var message = response && response.message ? response.message :"登录失败";
					that.errorTips = message;
				}
			},
			loginFailEvent:function(response , that){
				var message = response.message;
				that.errorTips = message;
			},
			navToRegister: function() {
				this.$router.push('/register');
			},
			navToForgot: function() {
				this.$router.push('/forgot');
			}
		}
	}
</script>

<style>
	.m-login-box {
		width: 380px;
		height: 400px;
		position: absolute;
		top: 0;
		left: 0;
		right: 0;
		bottom: 0;
		margin: auto;
	}

	.lang-bar {
		text-align: right;
		margin-top: 20px;
		font-size: 13px;
	}

	.m-trial-wrap,
	.m-reg-wrap {
		text-align: center;
	}

	.m-trial-wrap span {
		font-size: 16px;
	}

	.error-msg {
		color: red;
	}
</style>
