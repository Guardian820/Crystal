﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.World.Helper
{
    public static class NpcHelper
    {
        public static Database.Records.NpcRecord GetTemplate(int ID)
        {
            return Database.Cache.NpcCache.Cache.FirstOrDefault(x => x.ID == ID);
        }

        public static Database.Records.NpcDialogRecord GetDialog(int ID)
        {
            if (Database.Cache.NpcDialogCache.Cache.FindAll(x => x.ID == ID).Count > 0)
                return Database.Cache.NpcDialogCache.Cache.FirstOrDefault(x => x.ID == ID);
            return null;
        }
    }
}
