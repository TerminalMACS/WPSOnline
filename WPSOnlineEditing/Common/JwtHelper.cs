using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPSOnlineEditing.Mode;

namespace WPSOnlineEditing.Common
{
    public static class JwtHelper
    {
        private static string m_Secret = "BFE7E27E-C1F3-41E0-AAD5-7D14AFC6CD2C";
        private static IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
        private static IJsonSerializer serializer = new JsonNetSerializer();
        private static IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        public static string EncodeJwt(JWTModel userInfo)
        {
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            return encoder.Encode(userInfo, m_Secret);
        }

        public static JWTModel DecodeJwt(string token)
        {
            //IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            //IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            //IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
            var userInfo = decoder.DecodeToObject<JWTModel>(token, m_Secret, verify: true);//token为之前生成的字符串
            return userInfo;
        }

    }
}