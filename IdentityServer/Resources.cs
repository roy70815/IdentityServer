using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Resources
    {
        // 設定有哪些API可使用
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("DevApi", "DEV Api", new List<string>{ JwtClaimTypes.Role }),
                new ApiResource("UatApi", "UAT Api", new List<string>{ JwtClaimTypes.Role })
            };
        }

        // 設定API範圍(for Client)
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("DevApi", "DEV Api"),
                new ApiScope("UatApi", "UAT Api")
            };
        }
    }
}
