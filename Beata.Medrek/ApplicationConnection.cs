using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Beata.Medrek
{
   public class ApplicationConnection
    {
        #region Private Fields

        private bool canConnect = false;

        #endregion

        #region Public Properties

        public ApplicationDbContext applicationConnection { get; private set; }


        #endregion

        #region Constructors
        public ApplicationConnection(ApplicationDbContext appconnect)
        {
            // Dependency Injection 
            applicationConnection = appconnect;

            
            //while (canConnect == false)
            //{
            //    canConnect = StartUpServer(applicationConnection);
            //}
        } 
        #endregion



        #region Helpermethods
        private bool StartUpServer(DbContext context)
        {
            try
            {
                if (context.Database.CanConnect())
                    return true;
            }
            catch
            {
                using(Process process =new Process())
                {
                    var startinfo = new ProcessStartInfo();
                    startinfo.WindowStyle = ProcessWindowStyle.Normal;
                    startinfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
                    startinfo.Verb = "runas";
                    startinfo.Arguments = "sc query bits";
                    process.StartInfo = startinfo;
                    process.Start();
                    process.WaitForExit();
                }           
            }

            return false;
           
        }
        #endregion
    }
}
