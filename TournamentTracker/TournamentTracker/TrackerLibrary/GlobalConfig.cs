using System.Collections.Generic;
using System.Configuration;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        // these are the connections to be setup
        public static void InitializeConnections(DatabaseType db)
        {
            // (database == true) is viable as well but we have a bool 
            if (db == DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection= sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                // TODO - Create the Text Connection
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
