<template>
	<div class="m-reg-box">
	    <div class="container form-login-content m-find-pwd">
	        <div class="forgot-logo"></div>
	        <div class="forgot-title">忘记密码?</div>
	        <div class="forgot-tip">重设密码，请先输入Email地址。</div>
	    	
	        <div id="divSendlink" class="main reg">
	            <div class="item-wrap">
	                <el-input v-model="email" placeholder="请输入注册时的邮箱"></el-input>
	            </div>
				<div class="error-message">
					{{errorMessage}}
				</div>
	            <div class="m-action">
	                <el-button type="primary" v-on:click="sendLink()" style="width: 100%;">发送验证链接</el-button>
	            </div>
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
	</div>
</template>

<script>
	export default{
		data(){
			return {
				email:"",
				errorMessage:""
			}
		},
		methods:{
			sendLink:function(){
				this.errorMessage = "";
				if(!this.email){
					this.errorMessage="请输入注册时的邮箱";
					return;
				}
			},
			navToLogin:function(){
				this.$router.push("/");
			}
		}
	}
</script>

<style>
	.forgot-logo{
		background-image: url(../assets/images/find-pwd.png);
		width: 60px;
		height: 50px;
		margin: 0 auto;
		background-repeat: no-repeat;
		background-size: 100% 100%;
	}
	.forgot-title{
		font-weight: bold;
		color: #489de0;
		font-size: 21px;
		text-align: center;
		margin: 20px 0 10px 0;
		line-height: 25px;
	}
	.forgot-tip{
		text-align: center;
		line-height: 22px;
		font-weight: bold;
		text-overflow: ellipsis;
		white-space: nowrap;
		overflow: hidden;
	}
</style>
