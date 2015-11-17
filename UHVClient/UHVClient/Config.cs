using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace UHVClient
{
    public static class Config
    {
        public static string _diskSign = "";

        public static string DatabaseFile = "";
        public static string DataSource
        {
            get
            {
                return string.Format("data source={0};", DatabaseFile);
            }
        }

        public static string SQLSource = "Data Source=.;Initial Catalog=ZZConverter;User ID=sa;Password=123123";
    }
}
