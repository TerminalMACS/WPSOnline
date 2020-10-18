using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using static WPSOnlineEditing.Mode.WPSEnum;

namespace WPSOnlineEditing.Common
{
    public class WPSSignatureHelper
    {
        /// <summary>
        /// AppId
        /// </summary>
        private static string AppId = ConfigurationManager.AppSettings["WPSAppId"];

        /// <summary>
        /// AppKey
        /// </summary>
        private static string AppSecretKey = ConfigurationManager.AppSettings["WPSAppSecretKey"];

        /// <summary>
        /// 配置AppId和Appkey
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecretKey"></param>
        public static void Config(string appId, string appSecretKey)
        {
            AppId = appId;
            AppSecretKey = appSecretKey;
        }

        /// <summary>
        /// 对字符串进行HMACSH1加密
        /// </summary>
        /// <param name="encryptText"></param>
        /// <returns></returns>
        public static string ToHMACSHA1(string encryptText)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = System.Text.Encoding.Default.GetBytes(AppSecretKey);
            byte[] dataBuffer = System.Text.Encoding.Default.GetBytes(encryptText);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// 对参数签名
        /// </summary>
        /// <param name="paramDic"></param>
        /// <returns>签名后的字符串</returns>
        public static string Signature(Dictionary<string, string> paramDic)
        {
            var sortParam = paramDic.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);
            sortParam.Add("_w_secretkey", AppSecretKey);
            var paramStr = string.Join("", sortParam.Select(p => $"{p.Key}={p.Value}").ToArray());
            var signature = ToHMACSHA1(paramStr);
            sortParam.Remove("_w_secretkey");
            sortParam.Add("_w_signature", HttpUtility.UrlEncode(signature));
            return string.Join("&", sortParam.Select(p => $"{p.Key}={p.Value}").ToArray());
        }

        /// <summary>
        /// 生成签名后iframe用的url
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="fileType"></param>
        /// <param name="paramDic"></param>
        /// <returns></returns>
        // 此处直接读取了配置的appid，所以生成url时不用传递appid
        public static string GenarateUrl(string fileId, FileType fileType, Dictionary<string, string> paramDic = null)
        {
            if (string.IsNullOrEmpty(AppId) || string.IsNullOrEmpty(AppSecretKey))
            {
                throw new ArgumentException("未配置 AppId 和 AppSecretKey");
            }
            if (paramDic == null)
            {
                paramDic = new Dictionary<string, string>();
            }

            paramDic.Add("_w_appid", AppId);
            var paramStr = Signature(paramDic);
            return $"https://wwo.wps.cn/office/{fileType.ToString()}/{fileId}?{paramStr}";
        }
    }
}