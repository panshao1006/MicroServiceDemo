<template>
	<div class="m-reg-box">
	    <div id="register" class="container form-login-content reg">
	        <!--<h1>MEGI</h1>-->
	        <div class="megi-logo">
	    	
	        </div>

	        <div class="lang-bar" style="margin-top: 10px;">
	            切换语言 : English
	        </div>
	        <div id="divUserRegister" class="main" style="">
	            <el-row :gutter=10 class="item-wrap">
	                <el-col :span="12"><el-input v-model="firstName" placeholder="请输入名"></el-input></el-col>
					<el-col :span="12"><el-input v-model="lastName" placeholder="请输入姓"></el-input></el-col>
	            </el-row>
	    	
	            <div class="item-wrap">
	                <el-input v-model="email" placeholder="请输入邮箱"></el-input>
	            </div>
	            <div class="item-wrap">
					<el-input v-model="phone" placeholder="请输入手机号码"></el-input>
				</div>
	            <div class="text-agree-term">
	                <el-checkbox v-model="checked"></el-checkbox>
	                <span>
	                    我已阅读和确认
	                    <a href="Https://static.megichina.com/Content/MEGI_Standard_Terms_of_Use.pdf" target="_blank" class="line">使用条款</a>
	    	
	                </span>
	                <span class="reg-error-image">&nbsp;</span>
	            </div>
	            <div class="error-msg">
					{{errorTips}}
	            </div>
	    	
	            <div class="m-action">
	                <el-button type="primary" style="width:385px;" v-on:click="registerEvent()">注册</el-button>
	            </div>
	    	
	            <div class="m-signIn-wrap">
	                <div class="wrap-problem">有问题请<a id="megiFeedback" href="https://www.megichina.com/contact/" target="_Blank">联系我们</a>，我们将竭诚为您服务。 </div>
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
	export default {
		data(){
			return {
				firstName:"",
				lastName:"",
				phone:"",
				email:"",
				phone:"",
				checked:false,
				errorTips:"",
				langId:"0x7804",
				registerRequestUrl:this.getFullUrl("/users")
			}
		},
		methods:{
			registerEvent:function(){
				this.errorTips = "";
				
				if(!this.checked){
					this.errorTips="请先同意使用条款";
					return;
				}
				
				if(!this.firstName || !this.lastName){
					this.errorTips="请填写姓和名";
					return;
				}
				
				if(!this.email){
					this.errorTips="请填写邮箱";
					return;
				}
				
				if(!this.phone){
					this.errorTips="请填写手机号码";
					return;
				}
				this.request({
					method:"post",
					url:this.registerRequestUrl,
					data:{
						EmailAddress:this.email , 
						FirstName:this.firstName,
						LastName:this.lastName,
						Phone:this.phone,
						LangId:this.langId
					},
					success:this.successEvent,
					failed:this.failedEvent,
				})
			},
			successEvent:function(response){
				if(response && response.success){
					this.navToRegister();
				}else{
					this.errorTips = response && response.message ? response.message:"注册失败";
				}
			},
			failedEvent:function(response){
				this.errorTips = response && response.message ? response.message:"注册失败";
			},
			navToRegister:function(){
				this.$router.push("./RegisterSuccess");
			}
		}
	}
</script>

<style>
	.m-reg-box{
		width: 380px;
		height: 400px;
		position: absolute;
		top: 0;
		left: 0;
		right: 0;
		bottom: 0;
		margin: auto;
	}
	.reg .item-wrap{
		height: 65px;;
	}
	.m-signIn-wrap{
		text-align: center;
	}
</style>
