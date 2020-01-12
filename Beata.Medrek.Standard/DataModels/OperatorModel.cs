using System;
using System.Security;

namespace Beata.Medrek.Standard
{
    ///<Summary>
    /// Operator Data Model
    ///<Summary>
    public class OperatorModel
    {
        /// <summary>
        /// Full Name of the Operator
        /// </summary>
        public string Name;

        /// <summary>
        /// Operator Password
        /// </summary>
        public string Password;

        /// <summary>
        /// Operator ID
        /// </summary>
        public string ID;

        /// <summary>
        /// Admin Status Flag sets to true if the Operator has Administrator Rights
        /// </summary>
        public bool IsAdmin;

        /// <summary>
        /// Operator LogIn Time Stamp
        /// </summary>
        public DateTime LogInTime;

        /// <summary>
        /// Location to Operator Image File
        /// TODO: Replace this with Image From DataBase 
        /// </summary>
        public string ImageSource;
    }
}
