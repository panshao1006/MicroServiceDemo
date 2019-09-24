/*
Navicat MySQL Data Transfer

Source Server         : localhost3306
Source Server Version : 50717
Source Host           : localhost:3306
Source Database       : jienorsys

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2019-09-24 16:04:34
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `t_bas_module`
-- ----------------------------
DROP TABLE IF EXISTS `t_bas_module`;
CREATE TABLE `t_bas_module` (
  `MItemID` varchar(36) DEFAULT NULL,
  `MParentID` varchar(36) DEFAULT NULL,
  `MVersionID` varchar(36) DEFAULT NULL,
  `MName` varchar(500) DEFAULT NULL,
  `MPermissonID` varchar(36) DEFAULT NULL COMMENT '模块需要的权限',
  `MLink` varchar(500) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bas_module
-- ----------------------------
INSERT INTO `t_bas_module` VALUES ('10000', '0', '1', '科目', null, 'account', '', '');

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
INSERT INTO `t_bas_organisation` VALUES ('1acc47db-86dd-427e-b785-50d99adca485', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('1fa49ecc-a1d7-4311-a3ed-5b85bfed283f', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('2392d80b-e75d-4879-849a-0de5703685e2', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('460fbcec3c1f41b5b4492e8f2ecc2b7c', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('48caa77d-09ab-4bbc-81b5-555d4a71b04e', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('7ebf1802-8c35-4ca9-8743-4bd05199f1f2', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('acf39a8e-c009-4e95-87e7-596237b1ecca', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('c4e0ddbf-5dca-40d6-a719-ca30484e6d1b', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('ebcf7341-1d24-41a9-9767-97f32f497d6d', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);
INSERT INTO `t_bas_organisation` VALUES ('fdf871c64eab4b0ca1ccbfc25e963d9d', '1', 'Name', null, 'Name', null, '0', null, null, null, null, null, null, null, null, '', '', null, null, null, null);

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
-- Table structure for `t_bas_permissonitem`
-- ----------------------------
DROP TABLE IF EXISTS `t_bas_permissonitem`;
CREATE TABLE `t_bas_permissonitem` (
  `MItemID` varchar(36) NOT NULL,
  `MAppID` varchar(36) DEFAULT NULL,
  `MName` varchar(100) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bas_permissonitem
-- ----------------------------
INSERT INTO `t_bas_permissonitem` VALUES ('10001', '1', '科目', '', '');
INSERT INTO `t_bas_permissonitem` VALUES ('10002', '1', '银行账号', '', '');
INSERT INTO `t_bas_permissonitem` VALUES ('10003', '1', '总账', '', '');
INSERT INTO `t_bas_permissonitem` VALUES ('10004', '1', '固定资产', '', '');
INSERT INTO `t_bas_permissonitem` VALUES ('10005', '1', '用户', '', '');

-- ----------------------------
-- Table structure for `t_sec_group`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_group`;
CREATE TABLE `t_sec_group` (
  `MItemID` varchar(36) DEFAULT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MName` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_group
-- ----------------------------
INSERT INTO `t_sec_group` VALUES ('10000', '0', '管理员组');

-- ----------------------------
-- Table structure for `t_sec_grouppermisson`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_grouppermisson`;
CREATE TABLE `t_sec_grouppermisson` (
  `MItemID` varchar(36) DEFAULT NULL,
  `MGroupID` varchar(36) DEFAULT NULL,
  `MRightType` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_grouppermisson
-- ----------------------------

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
-- Table structure for `t_sec_role`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_role`;
CREATE TABLE `t_sec_role` (
  `MItemID` varchar(36) DEFAULT NULL,
  `MAppID` varchar(36) DEFAULT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MName` varchar(500) DEFAULT NULL,
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_role
-- ----------------------------
INSERT INTO `t_sec_role` VALUES ('10000', '1', '0', '管理员', '', '');

-- ----------------------------
-- Table structure for `t_sec_rolepermisson`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_rolepermisson`;
CREATE TABLE `t_sec_rolepermisson` (
  `MItemID` varchar(36) DEFAULT NULL,
  `MRoleID` varchar(36) DEFAULT NULL,
  `MPermissonID` varchar(36) DEFAULT NULL,
  `MRightType` int(2) DEFAULT NULL COMMENT '权限类型：1可访问 2不可访问',
  `MIsActive` bit(1) DEFAULT NULL,
  `MIsDelete` bit(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_rolepermisson
-- ----------------------------
INSERT INTO `t_sec_rolepermisson` VALUES ('10000', '10000', '10001', '11111', '', '');

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
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_usergroup
-- ----------------------------
INSERT INTO `t_sec_usergroup` VALUES ('7fb8538c31774518b31d67bdb43433af', 'c4e0ddbf-5dca-40d6-a719-ca30484e6d1b', '1', null);
INSERT INTO `t_sec_usergroup` VALUES ('c1f3640a353849478f2cdb6ca73a111a', '460fbcec3c1f41b5b4492e8f2ecc2b7c', '1', null);

-- ----------------------------
-- Table structure for `t_sec_userrole`
-- ----------------------------
DROP TABLE IF EXISTS `t_sec_userrole`;
CREATE TABLE `t_sec_userrole` (
  `MItemID` varchar(36) NOT NULL,
  `MOrgID` varchar(36) DEFAULT NULL,
  `MUserID` varchar(36) DEFAULT NULL,
  `MRoleID` varchar(36) DEFAULT NULL,
  PRIMARY KEY (`MItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sec_userrole
-- ----------------------------
INSERT INTO `t_sec_userrole` VALUES ('27c42c8d4fc34937aa13ae31f3e63b2d', '460fbcec3c1f41b5b4492e8f2ecc2b7c', null, '5');
INSERT INTO `t_sec_userrole` VALUES ('aa43d7166e314e998e27fe596f9fc94e', 'c4e0ddbf-5dca-40d6-a719-ca30484e6d1b', null, '5');
