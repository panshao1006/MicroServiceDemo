/*
Navicat MySQL Data Transfer

Source Server         : 3307
Source Server Version : 50717
Source Host           : 192.168.188.8:3307
Source Database       : jienorsys

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2019-10-02 18:07:20
*/

SET FOREIGN_KEY_CHECKS=0;

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


