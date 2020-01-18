<template>
	<div class="m-ititle">
		<div class="title">
			<span class="title-text"> 我的美记</span>
			<el-dropdown size="small" @command="navToInitWizard">
				<el-button type="primary">
					新增组织<i class="el-icon-arrow-down el-icon--right"></i>
				</el-button>
				<el-dropdown-menu slot="dropdown">
					<el-dropdown-item command="1">标准版</el-dropdown-item>
					<el-dropdown-item command="2">记账版</el-dropdown-item>
				</el-dropdown-menu>
			</el-dropdown>
		</div>
		<div class="info" id="lastOrgInfo" style="padding:1px 3px;margin-top:10px" lastorgid="dm000000000000000000000000000102">

			<span class="mg-bold">您好，c c，</span> 您上次登录的组织是 <a class="mg-login-info" href="###" onclick="$('#aCreateDemoCompany').trigger('click')">Demo
				Company</a>。
		</div>
	</div>
</template>

<script>
	export default {
		data() {
			return {
				
			}
		},
		methods: {
			navToInitWizard: function(type) {
				if (type == 1) {
					this.$router.push("./initWizard");
				} else {
					this.$confirm('这个版本只提供总账功能，适用于代理记账公司，不提供任何管理需求。是否确认要添加?', '提示', {
						confirmButtonText: '确定',
						cancelButtonText: '取消',
						type: 'warning'
					}).then(() => {
						this.$router.push("./initWizard");
					});
				}

			}
		}
	}
</script>

<style>
	.el-main {
		padding: 0px !important;
	}

	.m-ititle {
		background-color: #f8fcff;
		height: 60px;
		padding-left: 20px;
		top: 10px;
		position: relative;
	}

	.m-ititle,
	.title {
		line-height: 1px !important;
	}

	.title-text {
		font-size: 30px;
		font-weight: bold;
	}

	.m-ititle .el-dropdown {
		padding-left: 30px;
		top: -5px;
	}
</style>
