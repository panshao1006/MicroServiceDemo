using Core.Common.FieldValidate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.FieldValidate
{
    /// <summary>
    /// 字段属性
    /// </summary>
    public class FieldValidateAttribute : Attribute
    {
        /// <summary>
        /// 字段长度
        /// </summary>
        public int Length { set; get; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public bool Require { set; get; }

        /// <summary>
        /// 是否允许更新
        /// </summary>
        public bool AllowUpdate { set; get; }
        
        public BaseDataType BaseDateType { set; get; }

        public FieldValidateAttribute()
        {

        }

        /// <summary>
        /// 校验是否通过
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldType">字段类型</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="messages">错误消息</param>
        /// <returns></returns>
        public bool IsValidate(string fieldName , Type fieldType , object fieldValue , out List<string> messages)
        {
            bool result = true;

            messages = new List<string>();

            List<string> requireValidateMessages = new List<string>();

            if(!IsRequireValidate(fieldName, fieldType, fieldValue, out requireValidateMessages))
            {
                result = false;
                messages.AddRange(requireValidateMessages);
            }

            return result;
        }


        /// <summary>
        /// 校验必填
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldType"></param>
        /// <param name="fieldValue"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        private bool IsRequireValidate(string fieldName, Type fieldType, object fieldValue, out List<string> messages)
        {
            messages = new List<string>();

            bool result = true;
            
            if ((fieldType == typeof(int) || fieldType == typeof(decimal)) && Convert.ToDecimal(fieldValue) == 0)
            {
                result = false;
                messages.Add($"{fieldName} 必须要大于0");
            }
            else if (fieldType == typeof(DateTime) && (DateTime)fieldValue == DateTime.MinValue)
            {
                result = false;
                messages.Add($"{fieldName} 不能为空");
            }
            else if (fieldType == typeof(String) && (fieldValue ==null || string.IsNullOrWhiteSpace(fieldValue.ToString().Trim())))
            {
                result = false;
                messages.Add($"{fieldName} 不能为空");
            }
            else if(fieldValue == null)
            {
                result = false;
                messages.Add($"{fieldName} 不能为空");
            }


            return result;
        }
    }
}
