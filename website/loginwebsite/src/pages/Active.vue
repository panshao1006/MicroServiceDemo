<template>
	<div class="m-reg-box">
		<div class="container form-login-content main-reg">
			<div class="link-expire" v-bind:style="{display:validateFailStyle}">
				<div class="active-fail-logo"></div>
				<div>
					<div class="active-fail-title">激活连接已过期</div>
					<div class="active-fail-tip">您可以重新打开注册页面，重新进行注册</div>

				</div>
			</div>
			<div class="link-success" v-bind:style="{display:validateSuccessStyle}">
				<div class="active-success-logo"></div>
				<div>
					<div class="active-success-title">请输入密码完成激活</div>
					<div class="active-success-tip"></div>

				</div>
				<div class="item-wrap">
					<el-input type="password" v-model="password" placeholder="请输入密码"></el-input>
				</div>
				<div class="item-wrap">
					<el-input type="password" v-model="confimPassword" placeholder="请再次输入密码"></el-input>
				</div>
				<div class="error-msg">
					{{errorTips}}
				</div>

				<div class="m-action">
					<el-button type="primary" style="width:100%;" v-on:click="activeEvent()">激活</el-button>
				</div>
			</div>

			<div class="empty-content"></div>
			<div class="m-signIn-wrap">
				<div class="wrap-problem">有问题请<a id="megiFeedback" href="javascript:void(0);">联系我们</a>，我们将竭诚为您服务。 </div>
				<div class="wrap-have-account">
					<span>已经拥有账号？</span>
				</div>
				<div class="wrap-btn">
					<el-link type="primary" v-on:click="navToLogin()">点击此处登录</el-link>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	export default {
		data() {
			return {
				password: "",
				confimPassword: "",
				errorTips: "",
				infoValidateUrl: this.getFullUrl("/activeinfoes"),
				userRequestUrl: this.getFullUrl("/users"),
				infoId: this.getQueryParam("id"),
				userId: "",
				validateFailStyle: "none",
				validateSuccessStyle: "none"

			}
		},
		mounted: function() {
			//页面载入时
			this.validateId();
		},
		methods: {
			validateId: function() {
				if (!this.infoId) {
					this.validateFailStyle = "block";
					return;
				}

				var url = this.infoValidateUrl + "?id=" + this.infoId;
				var that = this;
				this.request({
					method: "get",
					url: url,
					success: function(response) {
						if (response) {
							that.userId = response.userId;
							that.validateFailStyle = "none";
							that.validateSuccessStyle = "block";
						} else {
							that.validateFailStyle = "block";
							that.validateSuccessStyle = "none";
						}
					},
					failed: function() {
						that.validateFailStyle = "block";
						that.validateSuccessStyle = "none";
					}
				})
			},
			activeEvent: function() {
				if (!this.password) {
					this.errorTips = "密码未必填项";
					return;
				}

				if (this.password != this.confimPassword) {
					this.errorTips = "两次输入的密码不一致";
					return;
				}
				var that = this;
				this.request({
					url: this.userRequestUrl,
					method: "put",
					data: {
						Id:that.userId,
						ActiveInfoId: that.infoId,
						Password: this.password,
						ConfimPassword: this.confimPassword
					},
					success: function(response) {
						if (response && response.success) {
							
							that.$alert('提示', '恭喜您，账号已经激活', {
								confirmButtonText: '确定',
								callback: action => {
									that.navToLogin();
								}
							})

						} else {
							that.errorTips = response && response.message ? response.message : "激活失败";
						}
					},
					failed: function() {
						that.errorTips = "激活失败";
					}
				});
			},
			navToLogin: function() {
				this.$router.push("./");
			}
		}
	}
</script>

<style>
	.active-fail-logo {
		background-image: url(../assets/images/fail-image.png);
		width: 75px;
		height: 75px;
		margin: 0 auto;
		background-repeat: no-repeat;
		background-size: 100% 100%;
	}

	.active-fail-title,
	.active-success-title {
		font-weight: bold;
		color: #489de0;
		font-size: 21px;
		text-align: center;
		margin: 20px 0 10px 0;
		line-height: 25px;
	}

	.active-fail-tip {
		text-align: center;
		line-height: 22px;
		font-weight: bold;
		text-overflow: ellipsis;
		white-space: nowrap;
		overflow: hidden;
	}

	.link-success .item-wrap {
		height: 65px;
		;
	}
</style>
