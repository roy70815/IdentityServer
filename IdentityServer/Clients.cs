using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Clients
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Admin",
                    // IdentityServer提供多種授權方式，這裡使用客戶授權模式
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // from ApiScope, 這裡若ApiScope不同，取Token時會有invalid_scope錯誤
                    AllowedScopes = { "DevApi", "UatApi" },
                    ClientSecrets = { new Secret("adminSecret".Sha256())},
                    // 因admin也要能使用user身份的api，故兩種角色都要加入
                    Claims = new List<ClientClaim>
                    {
                        new ClientClaim(JwtClaimTypes.Role, "admin"),
                        new ClientClaim(JwtClaimTypes.Role, "user")
                    },
                    /* 若無以下這行，Token回傳的欄位名稱會是client_role而不是role, 
                     * 這樣會因對應不到role而導致驗證失敗 */
                    ClientClaimsPrefix = string.Empty
                },
                new Client
                {
                    ClientId = "User",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "UatApi" },
                    ClientSecrets = { new Secret("userSecret".Sha256())},
                    Claims = new List<ClientClaim>
                    {
                        new ClientClaim(JwtClaimTypes.Role, "user")
                    },
                    ClientClaimsPrefix = string.Empty
                }
            };
        }
    }
}
