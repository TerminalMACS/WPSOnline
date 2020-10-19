using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WPSOnlineEditing.Common
{
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举描述内容
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum e)
        {
            var field = e.GetType().GetField(e.ToString());
            object[] objs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return e.ToString();
            var descriptionAttribute = objs[0] as DescriptionAttribute;
            if (descriptionAttribute == null) return e.ToString();
            return descriptionAttribute.Description;
        }
    }
}