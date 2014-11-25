﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.World.Helper
{
    public static class ZaapHelper
    {
        public static Database.Records.ZaapRecord GetZaap(int mapid)
        {
            if (Database.Cache.ZaapCache.Cache.FindAll(x => x.MapID == mapid).Count > 0)
                return Database.Cache.ZaapCache.Cache.FirstOrDefault(x => x.MapID == mapid);
            return null;
        }
    }
}
