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
			<el-aside width="55px">Aside</el-aside>
			<el-container>
				<el-main>
					<router-view></router-view>
				</el-main>
			</el-container>
		</el-container>
	</el-container>
</template>
<style>
	html,body{
		height: 100%;
		margin: 0px;
	}
	.el-container{
		height: 100%;
	}
	.el-header {
		background-color: #449be0;
		height: 75px;
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

<script>
	export default {
		data() {
			const item = {
				date: '2016-05-02',
				name: '王小虎',
				address: '上海市普陀区金沙江路 1518 弄'
			};
			return {
				tableData: Array(20).fill(item)
			}
		}
	};
</script>
