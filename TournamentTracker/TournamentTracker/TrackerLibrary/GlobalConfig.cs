using System.Collections.Generic;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        // list is for one or more data sources
        // private set is for only methods within this CLASS
        public static List<IDataConnection> Connections { get; private set; }

        // these are the connections to be setup
        public static void InitializeConnections(bool database, bool textFiles)
        {
            Connections = new List<IDataConnection>();
            // (database == true) is viable as well but we have a bool 
            if (database)
            {
                // TODO - Set up the SQL Connector properly
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }
            if (textFiles)
            {
                // TODO - Create the Text Connection
                TextConnection text = new TextConnection();
                Connections.Add(text);
            }
        }
    }
}
