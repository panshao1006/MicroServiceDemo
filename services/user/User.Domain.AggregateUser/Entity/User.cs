using AutoMapper;
using Core.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using User.Domain.AggregateUser.Repository.PO;
using User.Infrastructure;
using User.Infrastructure.Data;

namespace User.Domain.AggregateUser.Entity
{
    /// <summary>
    /// 用户聚合根 
    /// </summary>
    public class User : BaseAggregateRoot
    {
        /// <summary>
        /// 邮件地址
        /// </summary>
        public string EmailAddress { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { set; get; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { set; get; }

        /// <summary>
        /// 创建类型 1注册 2邀请注册 3邀请
        /// </summary>
        public int CreateType { set; get; }

        /// <summary>
        /// 状态 1 注册未激活 0注册已经激活
        /// </summary>
        public int Status { set; get; }

       

        /// <summary>
        /// 用户组织
        /// </summary>
        public List<OrganizationValueObject> Organizations { set; get; }


        /// <summary>
        /// 激活信息Id
        /// </summary>
        public string ActiveInfoId { set; get; }


        /// <summary>
        /// 激活邮件
        /// </summary>
        public UserActiveInfo UserActiveInfo { set;get;}

        public User()
        {

        }

        /// <summary>
        /// 注册新账号
        /// </summary>
        /// <returns></returns>
        public User CreateUser(int type , EmailTemplate emailTemplate)
        {
            Id = GuidUtility.GetGuid();
            Status = 0;
            //基础数据
            Create();

            //设置激活连接信息
            CreateUserActiveEmail(type, emailTemplate);

            return this;
        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            if(StringUtility.ContainChinese(FirstName) || StringUtility.ContainChinese(LastName))
            {
                return LastName + " " + FirstName;
            }

            return FirstName + " " + LastName;
        }

        /// <summary>
        /// 校验
        /// </summary>
        /// <returns></returns>
        public OperationResult Validate()
        {
            OperationResult result = new OperationResult();

            if(string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                result.Messages.Add("请填写姓和名");
            }

            if(string.IsNullOrEmpty(EmailAddress))
            {
                result.Messages.Add("邮箱未填写");
            }

            result.Success = result.Messages.Count == 0;

            return result;
        }


        /// <summary>
        /// 创建激活邮件内容
        /// </summary>
        /// <param name="type">类型 1 注册 2 邀请注册</param>
        /// <param name="emailTemplate"></param>
        /// <returns></returns>
        public void CreateUserActiveEmail(int type , EmailTemplate emailTemplate)
        {
            this.UserActiveInfo = new UserActiveInfo()
            {
                Id = GuidUtility.GetGuid(),
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = EmailAddress,
                LinkType = type,
                Phone = Phone,
                EmailTemplate = emailTemplate
            };
        }

        /// <summary>
        /// 用户激活
        /// </summary>
        /// <returns></returns>
        public OperationResult ActiveUser()
        {
            var result = new OperationResult();

            if (string.IsNullOrEmpty(Id))
            {
                result.Messages.Add("用户信息不存在");
                return result;
            }

            if (string.IsNullOrWhiteSpace(ActiveInfoId))
            {
                result.Messages.Add("用户激活信息不存在");
                return result;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                result.Messages.Add("密码不能为空");
                return result;
            }

            if (Status == 0)
            {
                result.Messages.Add("用户已经激活");
                return result;
            }

            Status = 0;

            UserActiveInfo.IsDelete = true;

            return result;
        }
    }
}
