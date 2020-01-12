using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beata.Medrek.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Beata.Medrek.Core
{

    public static class StaffManagement
    {
        
        /// <summary>
        /// Staff Login Extension
        /// </summary>
        /// <param name="appconnection"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="LoggedIn"></param>
        /// <returns></returns>
        public static Staff StaffLogin(this ApplicationConnection appconnection,string UserName,string Password,out bool LoggedIn)
        {
            // Try Checking UserName And Password
            try
            {
                if (appconnection.applicationConnection.Staffs.Any(p => p.UserName == UserName))
                {
                    if (appconnection.applicationConnection.Staffs.FirstOrDefault(p => p.UserName == UserName).Password == Password)
                    {
                        LoggedIn = true;
                        return appconnection.applicationConnection.Staffs.FirstOrDefault(p => p.UserName == UserName);

                        // TODO:  Update Application Staff Caching Mechanism
                    }
                }
            }

            // TODO: Log Login Information
            catch { LoggedIn = false;return null;}

            // Returnin Null and False if Staff Failed To Log In
            LoggedIn = false;
            return null; 
        }


        /// <summary>
        /// Staff Logout Extension
        /// </summary>
        /// <param name="appconnection"></param>
        /// <returns></returns>
        public static bool StaffLogout(this ApplicationConnection appconnection)
        {
           
            IoC.ApplicationViewModel.StaffCache.ClearCache();
            return true;
        }

    }
}
