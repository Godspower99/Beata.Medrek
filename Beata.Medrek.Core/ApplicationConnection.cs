using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Beata.Medrek.Core;

namespace Beata.Medrek.Core
{
   public class ApplicationConnection
    {
        #region Private Fields

        private readonly HospitalDatabase _applicationConnection;
        private bool canConnect = false;

        #endregion

        #region Public Properties

        public HospitalDatabase applicationConnection => _applicationConnection;


        #endregion

        #region Constructors
        public ApplicationConnection(DbContextOptionsBuilder optionsBuilder)
        {
           _applicationConnection = new HospitalDatabase(optionsBuilder);

            while (canConnect == false)
            {
               canConnect= StartUpServer(_applicationConnection);
            }
            Task.Run(() => _applicationConnection.Database.OpenConnectionAsync());
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
