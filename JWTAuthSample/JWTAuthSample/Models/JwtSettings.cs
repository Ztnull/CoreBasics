using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthSample.Models
{
    public class JwtSettings
    {
        /// <summary>
        /// token颁发者
        /// </summary>
        public string Issuser { get; set; }
        /// <summary>
        /// token可用的客户端
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 加密的Key
        /// </summary>
        public string SecreKey { get; set; }
    }
}
