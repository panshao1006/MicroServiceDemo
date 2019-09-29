using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Common.FieldValidate
{
    public static class FieldValidateExtensions
    {
        /// <summary>
        /// 对DTO类进行一些基本的校验
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static bool Validate<T>(this T t, out List<string> messages) where T : class
        {
            messages = new List<string>();

            var result = true;

            var properties = t.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                List<string> tempMessages = new List<string>();

                if (!ValidateProperty(t, property, out tempMessages))
                {
                    result = false;
                    messages.AddRange(tempMessages);
                }

            }
            return result;
        }

        /// <summary>
        /// 对DTO类进行一些基本的校验,如果值为空，不进行校验
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static bool ValidateNonNull<T>(this T t, out List<string> messages) where T : class
        {
            messages = new List<string>();

            var result = true;

            var properties = t.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //如果是空值字段，就不进行校验
                if (IsNullValueField(property.PropertyType, property.GetValue(t)))
                {
                    continue;
                }

                List<string> tempMessages = new List<string>();

                if (!ValidateProperty(t, property, out tempMessages))
                {
                    result = false;
                    messages.AddRange(tempMessages);
                }

            }
            return result;
        }

        /// <summary>
        /// 是否为空值字段
        /// </summary>
        /// <param name="fieldType"></param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        private static bool IsNullValueField(Type fieldType, object fieldValue)
        {
            if ((typeof(int) == fieldType || typeof(decimal) == fieldType || typeof(Int32) == fieldType) && Convert.ToDecimal(fieldValue) == 0)
            {
                return true;
            }

            if ((typeof(DateTime) == fieldType ) && Convert.ToDateTime(fieldValue) == DateTime.MinValue)
            {
                return true;
            }

            if (typeof(String) == fieldType && (fieldValue == null || string.IsNullOrWhiteSpace(fieldValue.ToString().Trim())))
            {
                return true;
            }

            if(fieldValue == null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 校验字段是否符合设置的属性条件
        /// </summary>
        /// <param name="property"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        private static bool ValidateProperty<T>(T t , PropertyInfo property , out List<string> messages)
        {
            messages = new List<string>();

            var attribute = property.GetCustomAttribute(typeof(FieldValidateAttribute)) as FieldValidateAttribute;

            //如果字段不带这个属性，就不进行校验
            if (attribute == null)
            {
                return true;
            }

            //字段名称
            string propertyName = property.Name;

            //字段的类型
            Type propertyType = property.PropertyType;

            //字段值
            var propertyValue = property.GetValue(t);

            return attribute.IsValidate(propertyName, propertyType, propertyValue, out messages);
        }


        /// <summary>
        /// 校验基础资料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static bool ValidateBaseData<T>(this T t, out List<string> messages) where T : class
        {
            var result = true;

            messages = new List<string>();

            return result;
        }
    }
}
