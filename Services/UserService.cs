using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    public class UserService
    {
        #region Singleton 

        private static UserService instance;
        public static UserService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserService();
                }
                return instance;
            }
        }
        #endregion
        private UserService()
        {

        }

        public User getCurrentUser()
        {
            User currentUser = null;
            using (UserContext context = new UserContext())
            {
                // use for test
                var sid = System.Security.Principal.WindowsIdentity.GetCurrent().User.AccountDomainSid.Value;
                // end use for test
                var lstUsers = context.Users.ToList();
                var CurrentWindowsUser = System.Security.Principal.WindowsIdentity.GetCurrent();
                currentUser = lstUsers.Find(x => x.Identifiant == CurrentWindowsUser.User.AccountDomainSid.Value);
            }

            return currentUser;
        }



    }
}
