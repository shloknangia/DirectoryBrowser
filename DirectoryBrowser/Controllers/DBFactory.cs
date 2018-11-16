using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DirectoryBrowser.Controllers
{
    public class DBFactory
    {
        public static IDataBase Init()
        {
            string name = ConfigurationManager.AppSettings["DataBaseToConnect"];
            if (name == "text")
            {
                return new TextFileDB();
            }
            else if (name.Equals("sql"))
            {
                return new SQLServerDB();

            }
            else
            {
                return null;
            }
        }
    }
}