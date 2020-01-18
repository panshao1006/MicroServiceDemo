<template>
	<div class="m-imain" style="overflow: hidden; height: 550px;" nn="550">
		<el-container>
			<el-header>
				<el-steps :active="active" finish-status="success" simple>
					<el-step title="组织设置"></el-step>
					<el-step title="财务设置"></el-step>
					<el-step title="税率"></el-step>
					<el-step title="会计科目"></el-step>
					<el-step title="期初余额"></el-step>
					<el-step title="完成"></el-step>
				</el-steps>
			</el-header>
			<el-main>
				<div class="setup-form">
					<div class="m-setup-content setup-form-wrapper">
						<div class="m-form m-form-nopadding" id="divOrg">
							<el-row>
								<el-col :span="2"><span class="lbl">显示名称</span></el-col>
								<el-col :span="8">
									<span class="content">
										<el-input></el-input>
									</span>
								</el-col>
							</el-row>
							<el-row>
								<el-col :span="2"><span class="lbl">法定名称</span></el-col>
								<el-col :span="8">
									<span class="content">
										<el-input></el-input>
									</span>
								</el-col>
							</el-row>
							<el-row>
								<el-col :span="2"><span class="lbl">组织类型</span></el-col>
								<el-col :span="8">
									<span class="content">
										<el-select placeholder="请选择">
											<el-option value="1">个体工商户</el-option>
											<el-option value="2">个人独资企业</el-option>
											<el-option value="3">合伙制企业</el-option>
											<el-option value="4">有限责任公司</el-option>
											<el-option value="5">股份有限公司</el-option>
										</el-select>
									</span>
								</el-col>
							</el-row>
							<!-- <div class="row">
								<span class="lbl">公司所属行业</span>
								<span class="content">
									<select class="easyui-combobox mg-data combobox-f combo-f" style="width: 360px; height: 28px; display: none;"
									 data-options="valueField: 'id',textField: 'name',groupField:'group',data: [{id: '1', name: '制造业', group: ''},{id: '2', name: '贸易业（批发和零售）', group: ''},{id: '3', name: '建筑装饰和安装', group: ''},{id: '5', name: '交通运输和仓储物流', group: '服务业'},{id: '6', name: '租赁和商务服务（会计审计营销法律等）', group: '服务业'},{id: '7', name: '研发和专业技术服务', group: '服务业'},{id: '8', name: '信息软件技术服务业', group: '服务业'},{id: '9', name: '住宿和餐饮业', group: '服务业'},{id: '10', name: '文化体育和娱乐业', group: '服务业'},{id: '11', name: '教育和培训', group: '服务业'},{id: '12', name: '卫生和护理', group: '服务业'},{id: '13', name: '其他服务业', group: '服务业'},{id: '14', name: '农林牧渔', group: ''},{id: '15', name: '非盈利组织', group: ''}]"
									 comboname="MOrgDesc"></select><span class="combo" style="width: 358px; height: 26px;"><input type="text"
										 class="combo-text validatebox-text" autocomplete="off" tabindex="9903" style="width: 340px; height: 26px; line-height: 26px;"><span><span
											 class="combo-arrow" style="height: 26px;"></span></span><input type="hidden" class="combo-value" name="MOrgDesc"
										 value=""></span>
								</span>
								<div class="clear"></div>
							</div>
							<div class="row">
								<span class="lbl">国家</span>
								<span class="content">
									<select id="selCountry" class="easyui-combobox mg-data combobox-f combo-f" style="width: 360px; height: 28px; display: none;"
									 data-options="valueField: 'id',textField: 'name',data: [{id: '168', name: '阿尔巴尼亚'},{id: '54', name: '阿尔及利亚'},{id: '74', name: '阿富汗'},{id: '237', name: '阿根廷'},{id: '72', name: '阿联酋'},{id: '219', name: '阿鲁巴岛'},{id: '89', name: '阿曼'},{id: '128', name: '阿塞拜疆'},{id: '7', name: '埃及'},{id: '48', name: '埃塞俄比亚'},{id: '156', name: '爱尔兰'},{id: '142', name: '爱沙尼亚'},{id: '169', name: '安道尔'},{id: '12', name: '安哥拉'},{id: '119', name: '安圭拉(英)'},{id: '218', name: '安提瓜和巴布达'},{id: '172', name: '奥地利'},{id: '183', name: '澳大利亚'},{id: '221', name: '巴巴多斯'},{id: '197', name: '巴布亚新几内亚'},{id: '220', name: '巴哈马'},{id: '97', name: '巴基斯坦'},{id: '212', name: '巴拉圭'},{id: '78', name: '巴勒斯坦'},{id: '65', name: '巴林'},{id: '113', name: '巴拿马'},{id: '240', name: '巴西'},{id: '129', name: '白俄罗斯'},{id: '177', name: '百慕大'},{id: '173', name: '保加利亚'},{id: '181', name: '北美洲其他国家(地区)'},{id: '2', name: '贝宁'},{id: '157', name: '比利时'},{id: '134', name: '冰岛'},{id: '117', name: '波多黎各'},{id: '166', name: '波兰'},{id: '151', name: '波斯尼亚-黑塞哥维那共和'},{id: '239', name: '玻利维亚'},{id: '238', name: '伯利兹'},{id: '30', name: '博茨瓦那'},{id: '241', name: '博内尔'},{id: '95', name: '不丹'},{id: '9', name: '布基纳法索'},{id: '53', name: '布隆迪'},{id: '77', name: '朝鲜'},{id: '58', name: '赤道几内亚'},{id: '206', name: '大洋洲其他国家(地区)'},{id: '159', name: '丹麦'},{id: '161', name: '德国'},{id: '93', name: '东帝汶'},{id: '44', name: '多哥'},{id: '110', name: '多米尼加共和国'},{id: '176', name: '多米尼克'},{id: '130', name: '俄罗斯联邦'},{id: '217', name: '厄瓜多尔'},{id: '10', name: '厄立特里亚'},{id: '162', name: '法国'},{id: '194', name: '法属玻利尼西亚'},{id: '209', name: '法属圭亚那'},{id: '152', name: '梵蒂冈城国'},{id: '14', name: '非洲其他国家(地区)'},{id: '104', name: '菲律宾'},{id: '196', name: '斐济'},{id: '174', name: '芬兰'},{id: '52', name: '佛得角'},{id: '204', name: '盖比群岛'},{id: '57', name: '冈比亚'},{id: '37', name: '刚果'},{id: '208', name: '哥伦比亚'},{id: '108', name: '哥斯达黎加'},{id: '223', name: '格林纳达'},{id: '180', name: '格陵兰'},{id: '126', name: '格鲁吉亚'},{id: '109', name: '古巴'},{id: '123', name: '瓜德罗普'},{id: '210', name: '圭亚那'},{id: '103', name: '哈萨克斯坦'},{id: '225', name: '海地'},{id: '62', name: '韩国'},{id: '153', name: '荷兰'},{id: '122', name: '荷属安德列斯'},{id: '114', name: '荷属安地列斯群岛'},{id: '124', name: '洪都拉斯'},{id: '193', name: '基里巴斯'},{id: '55', name: '吉布提'},{id: '69', name: '吉尔吉斯斯坦'},{id: '17', name: '几内亚'},{id: '33', name: '几内亚(比绍)'},{id: '178', name: '加拿大'},{id: '56', name: '加那利群岛'},{id: '21', name: '加纳'},{id: '20', name: '加蓬'},{id: '96', name: '柬埔寨'},{id: '148', name: '捷克共和国'},{id: '16', name: '津巴布韦'},{id: '1', name: '喀麦隆'},{id: '101', name: '卡塔尔'},{id: '222', name: '开曼群岛'},{id: '29', name: '科摩罗'},{id: '6', name: '科特迪瓦'},{id: '82', name: '科威特'},{id: '154', name: '克罗地亚'},{id: '60', name: '肯尼亚'},{id: '184', name: '库克群岛'},{id: '211', name: '库腊索岛'},{id: '143', name: '拉脱维亚'},{id: '36', name: '莱索托'},{id: '73', name: '老挝'},{id: '81', name: '黎巴嫩'},{id: '144', name: '立陶宛'},{id: '39', name: '利比里亚'},{id: '13', name: '利比亚'},{id: '170', name: '列支敦士登'},{id: '19', name: '留尼汪'},{id: '164', name: '卢森堡'},{id: '4', name: '卢旺达'},{id: '138', name: '罗马尼亚'},{id: '3', name: '马达加斯加'},{id: '84', name: '马尔代夫'},{id: '135', name: '马耳他'},{id: '202', name: '马克萨斯群岛'},{id: '50', name: '马拉维'},{id: '92', name: '马来西亚'},{id: '23', name: '马里'},{id: '150', name: '马其顿'},{id: '192', name: '马绍尔群岛'},{id: '227', name: '马提尼克'},{id: '28', name: '马约特岛'},{id: '8', name: '毛里求斯'},{id: '25', name: '毛里塔尼亚'},{id: '47', name: '梅利利亚'},{id: '179', name: '美国'},{id: '118', name: '美属维尔京群岛'},{id: '87', name: '蒙古'},{id: '228', name: '蒙特塞拉特'},{id: '98', name: '孟加拉国'},{id: '213', name: '秘鲁'},{id: '191', name: '密克罗尼西亚联邦'},{id: '91', name: '缅甸'},{id: '34', name: '民主刚果'},{id: '145', name: '摩尔多瓦'},{id: '49', name: '摩洛哥'},{id: '136', name: '摩纳哥'},{id: '46', name: '莫桑比克'},{id: '111', name: '墨西哥'},{id: '45', name: '纳米比亚'},{id: '38', name: '南非'},{id: '235', name: '南美洲其他国家(地区)'},{id: '185', name: '瑙鲁'},{id: '102', name: '尼泊尔'},{id: '112', name: '尼加拉瓜'},{id: '42', name: '尼日尔'},{id: '51', name: '尼日利亚'},{id: '137', name: '挪威'},{id: '205', name: '诺福克岛'},{id: '132', name: '欧洲其他国家(地区)'},{id: '198', name: '帕劳共和国'},{id: '165', name: '葡萄牙'},{id: '66', name: '日本'},{id: '140', name: '瑞典'},{id: '141', name: '瑞士'},{id: '224', name: '萨巴'},{id: '115', name: '萨尔瓦多'},{id: '189', name: '萨摩亚'},{id: '15', name: '塞卜泰'},{id: '171', name: '塞黑'},{id: '18', name: '塞拉利昂'},{id: '31', name: '塞内加尔'},{id: '158', name: '塞浦路斯'},{id: '5', name: '塞舌尔'},{id: '99', name: '沙特阿拉伯'},{id: '201', name: '社会群岛'},{id: '11', name: '圣多美和普林西比'},{id: '120', name: '圣卢西亚'},{id: '242', name: '圣卢西亚'},{id: '234', name: '圣马丁岛'},{id: '139', name: '圣马力诺'},{id: '236', name: '圣皮埃尔和密克隆'},{id: '233', name: '圣其茨-尼维斯'},{id: '229', name: '圣文森特和格林纳丁斯'},{id: '121', name: '圣文森特和格纳丁斯'},{id: '71', name: '斯里兰卡'},{id: '149', name: '斯洛伐克'},{id: '147', name: '斯洛文尼亚'},{id: '32', name: '斯威士兰'},{id: '59', name: '苏丹'},{id: '214', name: '苏里南'},{id: '188', name: '所罗门群岛'},{id: '24', name: '索马里'},{id: '76', name: '塔吉克斯坦'},{id: '70', name: '泰国'},{id: '22', name: '坦桑尼亚'},{id: '182', name: '汤加'},{id: '231', name: '特克斯和凯科斯群岛'},{id: '230', name: '特立尼达和多巴哥'},{id: '40', name: '突尼斯'},{id: '190', name: '图瓦卢'},{id: '199', name: '土阿莫土群岛'},{id: '200', name: '土布艾群岛'},{id: '146', name: '土耳其'},{id: '100', name: '土库曼斯坦'},{id: '203', name: '瓦利斯和浮图纳'},{id: '187', name: '瓦努阿图'},{id: '125', name: '危地马拉'},{id: '215', name: '委内瑞拉'},{id: '83', name: '文莱'},{id: '26', name: '乌干达'},{id: '131', name: '乌克兰'},{id: '216', name: '乌拉圭'},{id: '64', name: '乌兹别克斯坦'},{id: '167', name: '西班牙'},{id: '43', name: '西撒哈拉'},{id: '155', name: '希腊'},{id: '61', name: '新加坡'},{id: '186', name: '新喀里多尼亚'},{id: '195', name: '新西兰'},{id: '133', name: '匈牙利'},{id: '63', name: '叙利亚'},{id: '226', name: '牙买加'},{id: '127', name: '亚美尼亚'},{id: '88', name: '亚洲其他国家(地区)'},{id: '94', name: '也门共和国'},{id: '80', name: '伊拉克'},{id: '107', name: '伊朗'},{id: '86', name: '以色列'},{id: '163', name: '意大利'},{id: '90', name: '印度'},{id: '85', name: '印度尼西亚'},{id: '160', name: '英国'},{id: '116', name: '英属维尔京群岛'},{id: '232', name: '英属维尔京群岛'},{id: '67', name: '约旦'},{id: '68', name: '越南'},{id: '41', name: '赞比亚'},{id: '27', name: '乍得'},{id: '175', name: '直布罗陀'},{id: '207', name: '智利'},{id: '35', name: '中非共和国'},{id: '106', name: '中国'}]"
									 comboname="MCountryID"></select><span class="combo" style="width: 358px; height: 26px;"><input type="text"
										 class="combo-text validatebox-text" autocomplete="off" tabindex="9904" style="width: 340px; height: 26px; line-height: 26px;"><span><span
											 class="combo-arrow" style="height: 26px;"></span></span><input type="hidden" class="combo-value" name="MCountryID"
										 value="106"></span>
								</span>
							</div>
							<div class="row">
								<span class="lbl">省</span>
								<span class="content">
									<select id="selProvince" class="easyui-combobox mg-data combobox-f combo-f" style="width: 360px; height: 28px; display: none;"
									 data-options="valueField: 'id',textField: 'name',data: [{id: '1', name: '安徽'},{id: '2', name: '北京'},{id: '3', name: '重庆'},{id: '4', name: '福建'},{id: '5', name: '甘肃'},{id: '6', name: '广东'},{id: '7', name: '广西'},{id: '8', name: '贵州'},{id: '9', name: '海南'},{id: '10', name: '河北'},{id: '11', name: '黑龙江'},{id: '12', name: '河南'},{id: '13', name: '香港'},{id: '14', name: '湖北'},{id: '15', name: '湖南'},{id: '16', name: '江苏'},{id: '17', name: '江西'},{id: '18', name: '吉林'},{id: '19', name: '辽宁'},{id: '20', name: '澳门'},{id: '21', name: '内蒙古'},{id: '22', name: '宁夏'},{id: '23', name: '青海'},{id: '26', name: '陕西'},{id: '24', name: '山东'},{id: '27', name: '上海'},{id: '25', name: '山西'},{id: '28', name: '四川'},{id: '29', name: '台湾'},{id: '30', name: '天津'},{id: '32', name: '新疆'},{id: '31', name: '西藏'},{id: '33', name: '云南'},{id: '34', name: '浙江'}]"
									 comboname="MStateID"></select><span class="combo" style="width: 358px; height: 26px;"><input type="text"
										 class="combo-text validatebox-text" autocomplete="off" tabindex="9905" style="width: 340px; height: 26px; line-height: 26px;"><span><span
											 class="combo-arrow" style="height: 26px;"></span></span><input type="hidden" class="combo-value" name="MStateID"
										 value=""></span>
									<input id="txtProvince" class="textbox mg-data" name="MStateID" style="width: 360px; display: none;" maxlength="36">
								</span>
							</div>
							<div class="row">
								<span class="lbl">城市</span>
								<span class="content"><input id="txtCity" class="textbox mg-data" style="width:360px;" name="MCityID" maxlength="36"
									 tabindex="9906"></span>
							</div>
							<div class="row">
								<span class="lbl">街道</span>
								<span class="content"><input id="txtStreet" class="textbox mg-data" style="width:360px;" name="MStreet"
									 maxlength="300" tabindex="9907"></span>
							</div>
							<div class="row">
								<span class="lbl">邮政编码</span>
								<span class="content"><input id="txtPostalNo" class="textbox mg-data" style="width:360px;" name="MPostalNo"
									 maxlength="50" tabindex="9908"></span>
							</div> -->
							<el-row>
								<el-col :span="2"><span class="lbl">语言</span></el-col>
								<el-col :span="8"><span class="content m-org-lang">
										<el-checkbox v-model="checked">English</el-checkbox>
										<el-checkbox v-model="checked">中文简体</el-checkbox>
										
									</span>
								</el-col>
							</el-row>
						</div>
					</div>
				</div>
			</el-main>
			<el-footer>
				<div style="text-align: right;">
					<el-button type="warning">下一步</el-button>
				</div>
			</el-footer>
		</el-container>
	</div>
</template>

<script>
	export default {
		data() {
			return {
				isCollapse: true,
				active: 0,
				//组织版本
				type: 1,
				organizationId: "",
				stepIndex: 1,
			}
		}
	}
</script>

<style>
	.m-imain .el-aside {
		max-width: 200px;
	}

	.m-imain .el-header ,  .m-imain .el-footer{
		background-color: #F5F7FA;
	}

	.setup-form {
		padding-left: 20px;
		padding-top: 10px;
	}
</style>
