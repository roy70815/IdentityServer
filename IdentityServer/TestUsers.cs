using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class TestUsers
    {
        /// <summary>
        /// Define which uses will use this IdentityServer
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestUser> GetUsers()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "10001",
                    Username = "test1@hotmail.com",
                    Password = "test1password"
                },
                new TestUser
                {
                    SubjectId = "10002",
                    Username = "test2@hotmail.com",
                    Password = "test2password"
                },
                new TestUser
                {
                    SubjectId = "10003",
                    Username = "test3@hotmail.com",
                    Password = "test3password"
                }
            };
        }
    }
}
