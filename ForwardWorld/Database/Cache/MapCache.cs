﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.Database.Cache
{
    public static class MapCache
    {
        public static List<Records.MapRecords> Cache = new List<Records.MapRecords>();

        public static void Init()
        {
            Cache = Records.MapRecords.FindAll().ToList();
            foreach (var map in Cache)
            {
                try
                {
                    map.Engine.InitContents();
                }catch(Exception e){}
            }
        }
    }
}
