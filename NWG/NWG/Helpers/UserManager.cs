using System;
using System.Collections.Generic;
using NWG.Model;

namespace NWG.Helpers
{
    public class UserManager
    {
        public UserManager()
        {
        }

        public List<UserAccount> getAllUser() {

            var userAccountList = new List<UserAccount> { 
            
                new UserAccount{UserName = "Test1", Password = "test1", Role = "dmo"},
                new UserAccount{UserName = "test2", Password = "test2", Role = "dmo"},
                new UserAccount{UserName = "test3", Password = "test3", Role = "dmo"},
                new UserAccount{UserName = "test4", Password = "test4", Role = "dmo"},
                new UserAccount{UserName = "test5", Password = "test5", Role = "dmo"},
                new UserAccount{UserName = "Test6", Password = "test6", Role = "nwgc"},
                new UserAccount{UserName = "test7", Password = "test7", Role = "nwgc"},
                new UserAccount{UserName = "test8", Password = "test8", Role = "nwgc"},
                new UserAccount{UserName = "test9", Password = "test9", Role = "nwgc"},
                new UserAccount{UserName = "test10", Password = "test10", Role = "nwgc"}

            };

            return userAccountList;
        }
    }
}
