using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

namespace Beata.Medrek
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
        public static Staff StaffLogin(this ApplicationDbContext dbContext,string UserName,string Password,out bool LoggedIn)
        {
            // Try Checking UserName And Password
            try
            {
               if (dbContext.Staffs.Any(p => p.UserName == UserName))
                {
                    if (dbContext.Staffs.FirstOrDefault(p => p.UserName == UserName).Password == Password)
                    {
                        LoggedIn = true;
                        return dbContext.Staffs.FirstOrDefault(p => p.UserName == UserName);
                    }
                }
            }

            // TODO: Log Login Information
            catch (Exception e)
            {
                // TODO IMPROTANT :: HANDLE EXCEPTIONS
                throw (e);
            }


            // Return Null and False if Staff Failed To Log In
            LoggedIn = false;
            return null; 
        }


        #region Consider Changing Extension to ApplicationDbContext

        /// <summary>
        /// Staff Logout Extension
        /// </summary>
        /// <param name="appconnection"></param>
        /// <returns></returns>
        public static bool StaffLogout(this ApplicationDbContext dbContext)
        {

            DI.StaffCache.ClearCache();
            return true;
        }

        /// <summary>
        /// Add Staff Extension
        /// </summary>
        /// <param name="appconnection"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        public static bool AddStaff(this ApplicationDbContext dbContext, Staff staff)
        {
            try
            {
                bool staffAlreadyExists = dbContext.Staffs.Any(p => p.UserName == staff.UserName);

                if (!staffAlreadyExists)
                {

                    dbContext.Staffs.Add(staff);
                    dbContext.SaveChanges();
                    return dbContext.Staffs.Any(p => p.UserName == staff.UserName);
                }
            }
            catch (Exception e)
            {
                // TODO: Handle Exceptions
                throw (e);
            }
            return false;
        }

        /// <summary>
        /// Delete Staff Extension
        /// </summary>
        /// <param name="appconnection"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        public static bool DeleteStaff(this ApplicationDbContext dbContext, Staff staff)
        {
            try
            {
                if (!dbContext.Staffs.Any(p => p.UserName == staff.UserName))
                    return false;

                dbContext.Staffs.Remove(staff);
                dbContext.SaveChanges();
                return true;
            }

            catch (Exception e)
            {
                // Handle Exceptions
                throw (e);
            }
        }

        /// <summary>
        /// Edit staff Information Extension
        /// </summary>
        /// <param name="appconnection"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        public static bool EditStaffInfo(this ApplicationDbContext dbContext, Staff staff)
        {
            try
            {

                dbContext.Staffs.Update(staff);
                dbContext.SaveChanges();
                    return true;
                
            }

            catch (Exception e)
            {
                throw (e);
            }
        }  
        #endregion
    }
}
