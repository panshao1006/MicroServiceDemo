<template>
	<div class="m-reg-box">
	   <div class="container form-login-content main-reg  m-send-success">
	       <div class="register-success-logo"></div>
	       <div>
	           <div class="register-title">请查看您的收件箱</div>
	           <div class="register-tip">我们将尽快发送一封激活账户的链接到您的电子邮箱。</div>
	   	
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
	export default{
		data(){
			return {
				
			}
		},
		methods:{
			navToRegister:function(){
				this.$router.push("./");
			}
		}
	}
</script>

<style>
	.register-success-logo{
		background-image: url(../assets/images/send-success.png);
		width: 60px;
		height: 50px;
		margin: 0 auto;
		background-repeat: no-repeat;
		background-size: 100% 100%;
	}
	.register-title{
		font-weight: bold;
		color: #489de0;
		font-size: 21px;
		text-align: center;
		margin: 20px 0 10px 0;
		line-height: 25px;
	}
	.register-tip{
		text-align: center;
		line-height: 22px;
		font-weight: bold;
		text-overflow: ellipsis;
		white-space: nowrap;
		overflow: hidden;
	}
</style>
