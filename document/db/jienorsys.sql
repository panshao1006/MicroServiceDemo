/*
Navicat MySQL Data Transfer

Source Server         : localhost3306
Source Server Version : 50717
Source Host           : localhost:3306
Source Database       : jienorsys

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2019-10-09 17:07:27
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `t_bas_emailtemplate`
-- ----------------------------
DROP TABLE IF EXISTS `t_bas_emailtemplate`;
CREATE TABLE `t_bas_emailtemplate` (
  `MItemID` varchar(36) NOT NULL,
  `MType` int(1) DEFAULT NULL,
  `MContent` varchar(2000) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bas_emailtemplate
-- ----------------------------

-- ----------------------------
-- Table structure for `t_bas_module`
-- ----------------------------
DROP TABLE IF EXISTS `t_bas_module`;
CREATE TABLE `t_bas_module` (
  `MItemID` varchar(36) NOT NULL,
  `MParentID` varchar(36) DEFAULT NULL,
  `MVersionID` int(1) DEFAULT NULL,
  `MName` varchar(500) DEFAULT NULL,
  `MPermissonID` varchar(36) DEFAULT NULL COMMENT '模块需要的权限',
  `MLink` varchar(500) DEFAULT NULL,
  `MIndex` int(2) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bas_module
-- ----------------------------
INSERT INTO `t_bas_module` VALUES ('100001', '0', '1', '销售', '100100', '/Sale/', '200', '', '');
INSERT INTO `t_bas_module` VALUES ('100002', '0', '1', '仪表盘', '100100', '/Dashbord/', '100', '', '');

-- ----------------------------
-- Table structure for `t_bas_organisation`
-- ----------------------------
DROP TABLE IF EXISTS `t_bas_organisation`;
CREATE TABLE `t_bas_organisation` (
  `MItemID` varchar(36) NOT NULL,
  `MRegionID` varchar(3) DEFAULT NULL,
  `MName` varchar(50) DEFAULT NULL,
  `MMasterID` varchar(36) DEFAULT NULL,
  `MLegalTradingName` varchar(200) DEFAULT NULL,
  `MOrgTypeID` varchar(36) DEFAULT NULL,
  `MVersionID` int(11) DEFAULT '0',
  `MOrgBusiness` varchar(200) DEFAULT NULL,
  `MDefaulLocaleID` varchar(6) DEFAULT NULL,
  `MCountryID` varchar(36) DEFAULT NULL,
  `MStateID` varchar(36) DEFAULT NULL,
  `MCityID` varchar(36) DEFAULT NULL,
  `MStreet` varchar(300) DEFAULT NULL,
  `MPostalNo` varchar(50) DEFAULT NULL,
  `MExpiredDate` datetime DEFAULT NULL COMMENT '过期时间',
  `MIsActive` bit(1) DEFAULT b'1',
  `MIsDelete` bit(1) DEFAULT b'0',
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of t_bas_organisation
-- ----------------------------
INSERT INTO `t_bas_organisation` VALUES ('5f6e5ea8ad7a4b4581f2c91977c34e1c', null, 'post组织', null, 'post组织', null, '1', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('dd83591faacc4a32944faf29c0a8a1bd', null, 'post组织', null, 'post组织', null, '1', null, null, null, null, null, null, null, null, '', '', null, null, null, null);

-- ----------------------------
-- Table structure for `t_bas_organizationattribute`
-- ----------------------------
DROP TABLE IF EXISTS `t_bas_organizationattribute`;
CREATE TABLE `t_bas_organizationattribute` (
  `MItemID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) NOT NULL,
  `MRegProgress` int(2) NOT NULL,
  `MBaseCurrencyID` varchar(36) DEFAULT NULL,
  `MConversionDate` datetime NOT NULL,
  `MFABeginDate` datetime DEFAULT NULL,
  `MExpiredDate` datetime NOT NULL,
  `MInitBalanceOver` bit(1) NOT NULL,
  `MIsBeta` bit(1) DEFAULT NULL,
  `MIsPaid` bit(1) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bas_organizationattribute
-- ----------------------------
INSERT INTO `t_bas_organizationattribute` VALUES ('98aacbfc6790467b8552281c4da27c2d', '5f6e5ea8ad7a4b4581f2c91977c34e1c', '1', null, '2019-10-03 20:41:06', '0001-01-01 00:00:00', '2019-11-02 20:41:06', '', null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organizationattribute` VALUES ('fd31c74559bb43e5ad70af53e9244adc', 'dd83591faacc4a32944faf29c0a8a1bd', '1', null, '2019-10-03 21:01:18', '0001-01-01 00:00:00', '2019-11-02 21:01:18', '', null, null, '', '', null, null, null, null);

-- ----------------------------
-- Table structure for `t_bas_organizationuser`
-- ----------------------------
DROP TABLE IF EXISTS `t_bas_organizationuser`;
CREATE TABLE `t_bas_organizationuser` (
  `MItemID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MUserID` varchar(36) DEFAULT NULL,
  `MPosition` varchar(100) DEFAULT NULL COMMENT '岗位',
  `MRole` varchar(36) DEFAULT NULL COMMENT '角色',
  `MIsDelete` bit(1) DEFAULT b'0',
  `MIsActive` bit(1) DEFAULT b'1',
  `MUserIsActive` bit(1) DEFAULT b'0' COMMENT '专门用于判断用户是否激活',
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  `MIsArchive` bit(1) DEFAULT b'0' COMMENT '是否归档',
  `IsSelfData` bit(1) DEFAULT b'0',
  PRIMARY KEY (`MItemID`) USING BTREE,
  KEY `idx_OAD_Active_Archive` (`MOrgID`,`MIsActive`,`MIsDelete`,`MUserIsActive`,`MIsArchive`) USING BTREE,
  KEY `idx_AD_MItemID` (`MIsActive`,`MIsDelete`,`MItemID`) USING BTREE,
  KEY `index_name` (`MOrgID`,`MUserID`,`MIsDelete`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='组织与用户关联表';

-- ----------------------------
-- Records of t_bas_organizationuser
-- ----------------------------
INSERT INTO `t_bas_organizationuser` VALUES ('a3f188bd348740998eaae94cef0a9b98', 'dd83591faacc4a32944faf29c0a8a1bd', '79dfc1f3-b524-4093-8d32-8f6af4877463', null, null, '', '', '', null, null, null, null, '', '');

-- ----------------------------
-- Table structure for `t_bas_ornanizationattribute`
-- ----------------------------
DROP TABLE IF EXISTS `t_bas_ornanizationattribute`;
CREATE TABLE `t_bas_ornanizationattribute` (
  `MItemID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) NOT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bas_ornanizationattribute
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sec_group`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_group`;
CREATE TABLE `t_sec_group` (
  `MItemID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MName` varchar(100) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_group
-- ----------------------------
INSERT INTO `t_sec_group` VALUES ('10000', '0', '管理员组', null, null, null, null, null, null);

-- ----------------------------
-- Table structure for `t_sec_grouppermisson`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_grouppermisson`;
CREATE TABLE `t_sec_grouppermisson` (
  `MItemID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MPermissionID` varchar(36) DEFAULT NULL,
  `MGroupID` varchar(36) DEFAULT NULL,
  `MRightType` char(5) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_grouppermisson
-- ----------------------------
INSERT INTO `t_sec_grouppermisson` VALUES ('71f9efba86724b039c4261a278471f1d', 'dd83591faacc4a32944faf29c0a8a1bd', '100100', '10000', '11111', '', '', null, '2019-10-03 21:01:20', null, null);
INSERT INTO `t_sec_grouppermisson` VALUES ('95c1a794bf1e41a487e92943ca257d2a', '5f6e5ea8ad7a4b4581f2c91977c34e1c', '100200', '10000', '11111', '', '', null, '2019-10-03 20:41:06', null, null);
INSERT INTO `t_sec_grouppermisson` VALUES ('bd83ae1a93bb439c8b40abe07dd0a666', 'dd83591faacc4a32944faf29c0a8a1bd', '100200', '10000', '11111', '', '', null, '2019-10-03 21:01:20', null, null);
INSERT INTO `t_sec_grouppermisson` VALUES ('bd8eed9da902455cb60c4ad56b5c059e', '5f6e5ea8ad7a4b4581f2c91977c34e1c', '100100', '10000', '11111', '', '', null, '2019-10-03 20:41:06', null, null);

-- ----------------------------
-- Table structure for `t_sec_grouprole`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_grouprole`;
CREATE TABLE `t_sec_grouprole` (
  `MItemID` varchar(36) DEFAULT NULL,
  `MRoleID` varchar(36) DEFAULT NULL,
  `MGroupID` varchar(36) DEFAULT NULL,
  `MOrgID` varchar(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_grouprole
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sec_group_l`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_group_l`;
CREATE TABLE `t_sec_group_l` (
  `MPKID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MParentID` varchar(36) DEFAULT NULL,
  `MLocaleID` varchar(5) DEFAULT NULL,
  `MName` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`MPKID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_group_l
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sec_orguser`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_orguser`;
CREATE TABLE `t_sec_orguser` (
  `MItemID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MUserID` varchar(36) DEFAULT NULL,
  `MPosition` varchar(100) DEFAULT NULL COMMENT '岗位',
  `MRole` varchar(36) DEFAULT NULL COMMENT '角色',
  `MIsDelete` bit(1) DEFAULT b'0',
  `MIsActive` bit(1) DEFAULT b'1',
  `MUserIsActive` bit(1) DEFAULT b'0' COMMENT '专门用于判断用户是否激活',
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  `MIsArchive` bit(1) DEFAULT b'0' COMMENT '是否归档',
  `IsSelfData` bit(1) DEFAULT b'0',
  PRIMARY KEY (`MItemID`) USING BTREE,
  KEY `idx_OAD_Active_Archive` (`MOrgID`,`MIsActive`,`MIsDelete`,`MUserIsActive`,`MIsArchive`) USING BTREE,
  KEY `idx_AD_MItemID` (`MIsActive`,`MIsDelete`,`MItemID`) USING BTREE,
  KEY `index_name` (`MOrgID`,`MUserID`,`MIsDelete`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='组织与用户关联表';

-- ----------------------------
-- Records of t_sec_orguser
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sec_permissionitem`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_permissionitem`;
CREATE TABLE `t_sec_permissionitem` (
  `MItemID` varchar(36) NOT NULL,
  `MAppID` varchar(36) DEFAULT NULL,
  `MParentID` varchar(36) DEFAULT NULL,
  `MName` varchar(36) DEFAULT NULL,
  `MIndex` int(11) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT b'1',
  `MIsDelete` bit(1) DEFAULT b'0',
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`),
  KEY `idx_AD_MItemID` (`MIsActive`,`MIsDelete`,`MItemID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='业务系统中，所有的需要控制的权限项,比如审核、打印、删除、导出等等。\r\n这里把所有需要控制的操作抽象成权限项。';

-- ----------------------------
-- Records of t_sec_permissionitem
-- ----------------------------
INSERT INTO `t_sec_permissionitem` VALUES ('100100', 'Megi', '0', '销售', '1', '', '', null, null, null, null);
INSERT INTO `t_sec_permissionitem` VALUES ('100200', 'Megi', '0', '采购', '1', '', '', null, null, null, null);

-- ----------------------------
-- Table structure for `t_sec_role`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_role`;
CREATE TABLE `t_sec_role` (
  `MItemID` varchar(36) NOT NULL,
  `MAppID` varchar(36) DEFAULT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MName` varchar(500) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_role
-- ----------------------------
INSERT INTO `t_sec_role` VALUES ('10000', '1', '0', '管理员', '', '', null, null, null, null);

-- ----------------------------
-- Table structure for `t_sec_rolepermission`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_rolepermission`;
CREATE TABLE `t_sec_rolepermission` (
  `MItemID` varchar(36) DEFAULT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MRoleID` varchar(36) DEFAULT NULL,
  `MPermissionID` varchar(36) DEFAULT NULL,
  `MRightType` char(5) DEFAULT NULL COMMENT '权限类型：1可访问 2不可访问',
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_rolepermission
-- ----------------------------
INSERT INTO `t_sec_rolepermission` VALUES ('1cb3ac2fc20d4c05b327f3cfa4b16644', '5f6e5ea8ad7a4b4581f2c91977c34e1c', '10000', '100100', '11111', '', '', null, '2019-10-03 20:41:06', null, null);
INSERT INTO `t_sec_rolepermission` VALUES ('e37c45754b234b5c989e56a78fdd544b', '5f6e5ea8ad7a4b4581f2c91977c34e1c', '10000', '100200', '11111', '', '', null, '2019-10-03 20:41:06', null, null);
INSERT INTO `t_sec_rolepermission` VALUES ('e5eee0d3ee264f30ab3ab8809812e7e0', 'dd83591faacc4a32944faf29c0a8a1bd', '10000', '100100', '11111', '', '', null, '2019-10-03 21:01:20', null, null);
INSERT INTO `t_sec_rolepermission` VALUES ('ecaddd5d858443fdb33345cfdf6bb534', 'dd83591faacc4a32944faf29c0a8a1bd', '10000', '100200', '11111', '', '', null, '2019-10-03 21:01:20', null, null);

-- ----------------------------
-- Table structure for `t_sec_role_l`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_role_l`;
CREATE TABLE `t_sec_role_l` (
  `MPKID` varchar(36) NOT NULL COMMENT '唯一标示',
  `MOrgID` varchar(36) DEFAULT NULL,
  `MParentID` varchar(36) DEFAULT NULL,
  `MLocaleID` varchar(36) DEFAULT NULL,
  `MName` varchar(100) DEFAULT NULL,
  `MDesc` varchar(500) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT b'1',
  `MIsDelete` bit(1) DEFAULT b'0',
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MPKID`),
  KEY `idx_AD_MParentID_MLocaleID` (`MIsActive`,`MIsDelete`,`MParentID`,`MLocaleID`) USING BTREE,
  KEY `index_name` (`MParentID`,`MLocaleID`,`MIsDelete`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='\r\n\r\n';

-- ----------------------------
-- Records of t_sec_role_l
-- ----------------------------
INSERT INTO `t_sec_role_l` VALUES ('101', '0', '1', '0x0009', 'Read Only', 'Read Only', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('102', '0', '1', '0x7804', '查看', '日常数据维护及业务操作', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('103', '0', '1', '0x7C04', '查看', '日常數據維護及業務操作', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('201', '0', '2', '0x0009', 'Invoice Only', 'Invoice Only', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('202', '0', '2', '0x7804', '发票', '处理发票', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('203', '0', '2', '0x7C04', '發票', '處理發票', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('301', '0', '3', '0x0009', 'Standard', 'Standard', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('302', '0', '3', '0x7804', '标准', '标准', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('303', '0', '3', '0x7C04', '標准', '標准', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('401', '0', '4', '0x0009', 'Adviser', 'Adviser', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('402', '0', '4', '0x7804', '代理记账', '代理记账业务', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('403', '0', '4', '0x7C04', '代理記賬', '代理記賬業務', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('501', '0', '5', '0x0009', 'Administrator', 'Administrator', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('502', '0', '5', '0x7804', '管理员', '管理员', '', '', '1', null, '1', null);
INSERT INTO `t_sec_role_l` VALUES ('503', '0', '5', '0x7C04', '管理員', '管理員', '', '', '1', null, '1', null);

-- ----------------------------
-- Table structure for `t_sec_sendlinkinfo`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_sendlinkinfo`;
CREATE TABLE `t_sec_sendlinkinfo` (
  `MItemID` varchar(36) NOT NULL,
  `MEmail` varchar(100) DEFAULT NULL,
  `MPhone` varchar(36) DEFAULT NULL,
  `MFirstName` varchar(36) DEFAULT NULL,
  `MLastName` varchar(36) DEFAULT NULL,
  `MInvitationOrgID` varchar(36) DEFAULT NULL,
  `MInvitationEmail` varchar(100) DEFAULT NULL,
  `MSendDate` datetime DEFAULT NULL,
  `MLinkType` int(11) DEFAULT NULL,
  `MExpireDate` datetime DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT b'1',
  `MIsDelete` bit(1) DEFAULT b'0',
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='记录发送链接信息：如忘记密码，用户注册，用户邀请等';

-- ----------------------------
-- Records of t_sec_sendlinkinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `t_sec_user`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_user`;
CREATE TABLE `t_sec_user` (
  `MItemID` varchar(36) NOT NULL COMMENT '用户帐号',
  `MEmailAddress` varchar(100) DEFAULT NULL COMMENT '电子邮件',
  `MFirstName` varchar(50) DEFAULT NULL,
  `MLastName` varchar(50) DEFAULT NULL,
  `MPassWord` varchar(200) DEFAULT NULL COMMENT '密码',
  `MMobilePhone` varchar(50) DEFAULT NULL COMMENT '移动电话',
  `MQQNumber` varchar(20) DEFAULT NULL COMMENT 'QQ号码',
  `MAppID` varchar(36) DEFAULT NULL COMMENT '系统的全地址 WhenILogIn',
  `MLastLoginDate` datetime DEFAULT NULL COMMENT '最后登陆时间',
  `MLastLoginOrgID` varchar(36) DEFAULT NULL COMMENT '上次登陆的组织',
  `MLastLoginAppID` varchar(36) DEFAULT NULL COMMENT '上次登陆的系统',
  `MLastLoginLCID` varchar(6) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT b'1',
  `MIsChangeEmail` bit(1) DEFAULT b'0' COMMENT '更换邮箱标志：0已更换完成 1：正在更换邮箱',
  `MIsDelete` bit(1) DEFAULT b'0',
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  `MIsTemp` bit(1) DEFAULT b'0' COMMENT '是否临时用户',
  `MPublicProfile` bit(1) DEFAULT b'0',
  `MProfileImage` varchar(255) DEFAULT NULL,
  `MIsInsider` bit(1) DEFAULT b'0',
  `MOrgListShowType` int(11) DEFAULT '1',
  `MDemoOrgID` varchar(45) DEFAULT NULL,
  `MIsHadAddOrgAuth` bit(1) DEFAULT b'0',
  PRIMARY KEY (`MItemID`),
  KEY `index_name` (`MEmailAddress`) USING BTREE,
  KEY `idx_AD_MItemID` (`MIsActive`,`MIsDelete`,`MItemID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_user
-- ----------------------------
INSERT INTO `t_sec_user` VALUES ('79dfc1f3-b524-4093-8d32-8f6af4877463', '591387160@qq.com', 'pan', 'chen', 'megi#123', null, null, null, null, null, null, null, '', '', '', null, null, null, null, '', '', null, '', '1', null, '');

-- ----------------------------
-- Table structure for `t_sec_usergroup`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_usergroup`;
CREATE TABLE `t_sec_usergroup` (
  `MItemID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MGroupID` varchar(36) DEFAULT NULL,
  `MUserID` varchar(36) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_usergroup
-- ----------------------------
INSERT INTO `t_sec_usergroup` VALUES ('76aafc788921484da5f8b9472da85af3', 'dd83591faacc4a32944faf29c0a8a1bd', '10000', null, '', '', null, '2019-10-03 21:01:19', null, null);
INSERT INTO `t_sec_usergroup` VALUES ('cd1db8ceac30421890f11bb915e914be', '5f6e5ea8ad7a4b4581f2c91977c34e1c', '10000', null, '', '', null, '2019-10-03 20:41:06', null, null);

-- ----------------------------
-- Table structure for `t_sec_userrole`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_userrole`;
CREATE TABLE `t_sec_userrole` (
  `MItemID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MUserID` varchar(36) DEFAULT NULL,
  `MRoleID` varchar(36) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_userrole
-- ----------------------------
INSERT INTO `t_sec_userrole` VALUES ('7ba629360252486b8fecb83909f8bc5a', '5f6e5ea8ad7a4b4581f2c91977c34e1c', '79dfc1f3-b524-4093-8d32-8f6af4877463', '10000', '', '', null, '2019-10-03 20:41:06', null, null);
INSERT INTO `t_sec_userrole` VALUES ('dd5478d935704eb7b857bfc8ab528a86', 'dd83591faacc4a32944faf29c0a8a1bd', '79dfc1f3-b524-4093-8d32-8f6af4877463', '10000', '', '', null, '2019-10-03 21:01:19', null, null);

-- ----------------------------
-- Table structure for `t_sys_config`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_config`;
CREATE TABLE `t_sys_config` (
  `MItemID` varchar(36) NOT NULL,
  `MEnvironment` varchar(50) DEFAULT NULL,
  `MAppID` varchar(50) DEFAULT NULL,
  `MKey` varchar(100) DEFAULT NULL,
  `MValue` varchar(500) DEFAULT NULL,
  `MVersion` varchar(11) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sys_config
-- ----------------------------
INSERT INTO `t_sys_config` VALUES ('10001', 'DEV', 'Login.UI', 'GatewayHost', 'http://127.0.0.1:5000/api/v1', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('10002', 'DEV', 'Login.UI', 'MySiteHost', 'http://127.0.0.1:7001', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('20001', 'DEV', 'User.API', 'ConnectionString', 'server=127.0.0.1;database=JieNorSYS;uid=root;pwd=123456;Allow Zero Datetime=True;Port=3306;charset=utf8;pooling=true;Max Pool Size=100', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('20002', 'DEV', 'User.API', 'RabbitMQHost', '127.0.0.1', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('20003', 'DEV', 'User.API', 'RabbitMQUser', 'admin', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('20004', 'DEV', 'User.API', 'RabbitMQPassword', 'admin', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('20005', 'DEV', 'User.API', 'GatewayHost', 'http://127.0.0.1:5000/api/v1', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('20006', 'DEV', 'User.API', 'TokenValidateWhiteList', '/api/v1/sessions|post,get;', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('20007', 'DEV', 'USer.API', 'LogFactoryHost', 'http://127.0.0.1:8001/api/v1/logs', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('20008', 'DEV', 'User.API', 'AppName', 'User.API', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30001', 'DEV', 'Organization.API', 'ConnectionString', 'server=127.0.0.1;database=JieNorSYS;uid=root;pwd=123456;Allow Zero Datetime=True;Port=3306;charset=utf8;pooling=true;Max Pool Size=100', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30002', 'DEV', 'Organization.API', 'RabbitMQHost', '127.0.0.1', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30003', 'DEV', 'Organization.API', 'RabbitMQUser', 'admin', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30004', 'DEV', 'Organization.API', 'RabbitMQPassword', 'admin', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30005', 'DEV', 'Organization.API', 'RedisHost', '127.0.0.1', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30006', 'DEV', 'Organization.API', 'RedisPort', '6379', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30007', 'DEV', 'Organization.API', 'RedisPassword', '123456', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30008', 'DEV', 'Organization.API', 'ReidsDataBaseName', '1', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30009', 'DEV', 'Organization.API', 'StorageMaxOrganiztonCount', '200', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30010', 'DEV', 'Organization.API', 'LogFactoryHost', 'http://127.0.0.1:8001/api/v1/logs', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('30011', 'DEV', 'Organization.API', 'AppName', 'Organization.API', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('40001', 'DEV', 'Log.API', 'ElasticHost', 'http://127.0.0.1:9200', '1.0.0.0', '', '');
INSERT INTO `t_sys_config` VALUES ('50001', 'DEV', 'Common', 'SessionValidateHost', 'http://127.0.0.1:6000/api/v1/sessions', '1.0.0.0', '', '');

-- ----------------------------
-- Table structure for `t_sys_orgstorage`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_orgstorage`;
CREATE TABLE `t_sys_orgstorage` (
  `MItemID` varchar(36) NOT NULL COMMENT '用户帐号',
  `MOrgID` varchar(36) DEFAULT NULL,
  `MStorageID` varchar(36) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT b'1',
  `MIsDelete` bit(1) DEFAULT b'0',
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sys_orgstorage
-- ----------------------------
INSERT INTO `t_sys_orgstorage` VALUES ('1aff4dc94bb1459886ce5e203adbe489', 'dd83591faacc4a32944faf29c0a8a1bd', '10001', '', '', null, null, null, null);
INSERT INTO `t_sys_orgstorage` VALUES ('6f203add4427457dae18d9bbeaa643f9', 'f4becbf3474b4e3c806a0d2cb1533247', '10001', '', '', null, null, null, null);
INSERT INTO `t_sys_orgstorage` VALUES ('796eb48ded164ba9979c45abdc48daf8', '5f6e5ea8ad7a4b4581f2c91977c34e1c', '10001', '', '', null, null, null, null);

-- ----------------------------
-- Table structure for `t_sys_storage`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_storage`;
CREATE TABLE `t_sys_storage` (
  `MItemID` varchar(36) NOT NULL,
  `MServerID` varchar(36) DEFAULT NULL,
  `MDBServerName` varchar(36) DEFAULT NULL,
  `MDBServerPort` varchar(36) DEFAULT NULL,
  `MUserName` varchar(36) DEFAULT NULL,
  `MPassWord` varchar(200) DEFAULT NULL,
  `MConOtherInfo` varchar(100) DEFAULT NULL,
  `MBDName` varchar(200) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT b'1',
  `MIsDelete` bit(1) DEFAULT b'0',
  `MOrgCount` int(11) DEFAULT '0',
  `MCreatorID` varchar(36) DEFAULT NULL,
  `MCreateDate` datetime DEFAULT NULL,
  `MModifierID` varchar(36) DEFAULT NULL,
  `MModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sys_storage
-- ----------------------------
INSERT INTO `t_sys_storage` VALUES ('10001', null, '127.0.0.1', '3306', 'root', '123456', null, 'megibase_100001', '', '', '0', null, null, null, null);
