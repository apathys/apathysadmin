using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Cache
{
    public class CacheFactory
    {

        private static ICache cache = null;

        private static readonly object lockHelper = new object();

        public static ICache Cache
        {
            get
            {
                if (cache == null)
                {
                    lock (lockHelper)
                    {
                        if (cache == null)
                        {
                            switch (GlobalContent.SystemConfig.CacheProvider)
                            {
                                case "Redis":

                                    break;
                                case "Memory":
                                    cache = new MemoryCacheImp();
                                    break;

                            }
                        }
                    }

                }
                return cache;
            }
        }

    }

}

