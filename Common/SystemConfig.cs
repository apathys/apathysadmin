using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SystemConfig
    {
        public SystemConfig()
        {
            DBSlowSqlLogTime = 5;
        } 
        public int DBSlowSqlLogTime { get; set; }

        public string LoginProvider { get; set; }

        public string CacheProvider { get; set; }
         

    }
}

