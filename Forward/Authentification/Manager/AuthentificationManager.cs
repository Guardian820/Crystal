﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.RealmServer.Authentification.Manager
{
    public static class AuthentificationManager
    {
        public static Network.AuthentificationServer Server;

        public static void LaunchService()
        {
            Server = new Network.AuthentificationServer(Utilities.ConfigurationManager.GetStringValue("LoginHost"),
                                                                Utilities.ConfigurationManager.GetIntValue("LoginPort"));
        }
    }
}
