﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.Database.Cache
{
    public static class ExpFloorCache
    {
        public static List<Records.ExpFloorRecord> Cache = new List<Records.ExpFloorRecord>();

        public static void Init()
        {
            Cache = Records.ExpFloorRecord.FindAll().ToList();
            Cache = Cache.OrderBy(x => x.ID).ToList();
        }
    }
}
