<template>
	<el-container>
		<el-header>
			<el-row :gutter="20">
				<el-col :span="6">
					<div class="grid-content bg-purple">
						<el-dropdown>
							<span class="el-dropdown-link">
								Demo Company<i class="el-icon-arrow-down el-icon--right"></i>
							</span>
							<el-dropdown-menu slot="dropdown">
								<el-dropdown-item>黄金糕</el-dropdown-item>
								<el-dropdown-item>狮子头</el-dropdown-item>
								<el-dropdown-item>螺蛳粉</el-dropdown-item>
								<el-dropdown-item disabled>双皮奶</el-dropdown-item>
								<el-dropdown-item divided>蚵仔煎</el-dropdown-item>
							</el-dropdown-menu>
						</el-dropdown>
					</div>
				</el-col>
				<el-col :span="18">
					<div class="grid-content bg-purple" style="text-align: right;">
						<i class="el-icon-search" title="搜索"></i>
						<i class="el-icon-question" title="帮助"></i>
						<i class="el-icon-files" title="我的文件"></i>
						<i class="el-icon-user" title="用户"></i>
					</div>
				</el-col>

			</el-row>

		</el-header>
		<el-container>
			<el-aside width="80px">
				<el-menu default-active="1-4-1" class="el-menu-vertical-demo" :collapse="isCollapse" background-color="#354960"
				 text-color="#fff" active-text-color="#ffd04b">

					<el-menu-item index="1">
						<i class="el-icon-s-home"></i>
						<span slot="title">仪表盘</span>
					</el-menu-item>

					<el-submenu index="2">
						<template slot="title">
							<i class="el-icon-setting"></i>
							<span slot="title">设置</span>
						</template>
						<el-menu-item-group>
						      <span slot="title"></span>
						      <el-menu-item index="1-1">个人资料</el-menu-item>
						      <el-menu-item index="1-2">账号设置</el-menu-item>
						    </el-menu-item-group>
					</el-submenu>
				</el-menu>
			</el-aside>
			<el-container>
				<el-main>
					<router-view></router-view>
				</el-main>
			</el-container>
		</el-container>
	</el-container>
</template>

<script>
	export default {
		data() {
			return {
				isCollapse: true
			}
		}
	}
</script>

<style>
	.el-container {
		height: 100%;
	}

	.el-header {
		background-color: #449be0;
		height: 75px;
	}
	
	.el-header .el-dropdown {
		padding-top: 20px;
		padding-left: 40px;
	}
	
	.el-header .el-dropdown span {
		color: #fff;
		font-weight: bold;
		font-size: 15px;
	}

	.el-aside {
		background-color: #354960;
		width: 8%;
		min-width: 36px;
		max-width: 62px;
		min-height: 320px;
		height: 100%;
	}

	
</style>
