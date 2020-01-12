namespace Beata.Medrek
{
    public class ServerConnectionDetails
    {
        /// <summary>
        /// Default Database Name
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// ServerName TO Connect To
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Value Of Trusted Connection
        /// </summary>
        public string TrustedConnection { get; set; }

        /// <summary>
        /// Multiple Result Set Value
        /// </summary>
        public string AllowMultipleResultSet { get; set; }

        public string ConnectionString
        {
            get {
                 return string.IsNullOrEmpty(AllowMultipleResultSet)?
                    $"Server={ServerName};DataBase={DatabaseName};Trusted_Connection={TrustedConnection};AllowMultipleResultSets={AllowMultipleResultSet}"
                    :$"Server={ServerName};DataBase={DatabaseName};Trusted_Connection={TrustedConnection};";
            }
        }
    }
}
