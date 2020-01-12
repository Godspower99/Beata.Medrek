using System;
using Beata.Medrek.Core;
using Beata.Medrek.SqlServer;
using Microsoft.EntityFrameworkCore;
using Ninject;

namespace Beata.Medrek.Server
{
  public class Program
    {
        public static ServerConnectionDetails connectionDetails => new ServerConnectionDetails
        {
            DatabaseName = "Hospital",
            ServerName = "OTIETE\\SQLEXPRESS",
            AllowMultipleResultSet = "true",
            TrustedConnection = "true"
        };

      public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder().UseSqlServer(connectionDetails.ConnectionString);
            IoC.Kernel.Bind<IApplicationConnection>().ToConstant(new ApplicationConnection(optionsBuilder));
            IoC.AppConnection.
        }
    }
}
