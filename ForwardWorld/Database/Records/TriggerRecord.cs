﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Castle.ActiveRecord;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.Database.Records
{
    [ActiveRecord("maps_triggers")]
    public class TriggerRecord : ActiveRecordBase<TriggerRecord>
    {
        [PrimaryKey("ID")]
        public int ID
        {
            get;
            set;
        }

        [Property("MapID")]
        public int MapID
        {
            get;
            set;
        }

        [Property("CellID")]
        public int CellID
        {
            get;
            set;
        }

        [Property("NewMap")]
        public string NewMap
        {
            get;
            set;
        }

        public int NextMap
        {
            get;
            set;
        }

        public int NextCell
        {
            get;
            set;
        }

        public int LevelRequired
        {
            get;
            set;
        }
    }
}
