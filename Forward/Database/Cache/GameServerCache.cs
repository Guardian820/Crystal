﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.RealmServer.Database.Cache
{
    public static class GameServerCache
    {
        public static List<Records.GameServerRecord> Cache = new List<Records.GameServerRecord>();

        public static void Init()
        {
            Cache = Records.GameServerRecord.FindAll().ToList();
        }
    }
}
