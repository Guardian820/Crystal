﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.Engines.Stats
{
    public class SingleStats
    {
        public int Base = 0;
        public int Items = 0;
        public int Bonus = 0;
        public int Mount = 0;

        public int Total
        {
            get
            {
                return Base + Items + Bonus + Mount;
            }
        }

        public override string ToString()
        {
            return Base + "," + Items + "," + Bonus + "," + Mount;
        }
    }
}
