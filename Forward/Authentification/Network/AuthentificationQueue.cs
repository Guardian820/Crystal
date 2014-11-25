﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.RealmServer.Authentification.Network
{
    public class AuthentificationQueue
    {
        private static Timer _refreshTimer = new Timer(1000);
        private static List<AuthentificationClient> WaitingClients = new List<AuthentificationClient>();

        public static void Start()
        {
            _refreshTimer.Enabled = true;
            _refreshTimer.Elapsed += new ElapsedEventHandler(RefreshQueue);
            _refreshTimer.Start();
        }

        public static bool AddClient(AuthentificationClient client)
        {
            lock (Authentification.Manager.AuthentificationManager.Server.Clients)
            {
                if (Authentification.Manager.AuthentificationManager.Server.Clients.FindAll(x => x.Account != null).Count + 1 > Utilities.ConfigurationManager.GetIntValue("MaxConnected"))
                {
                    lock (WaitingClients)
                        WaitingClients.Add(client);
                    return true;
                }
                return false;
            }
        }

        public static int CanAcceptPlayer()
        {
            lock (Authentification.Manager.AuthentificationManager.Server.Clients)
            {
                return Utilities.ConfigurationManager.GetIntValue("MaxConnected") - (Authentification.Manager.AuthentificationManager.Server.Clients.FindAll(x => x.Account != null).Count - WaitingClients.Count);
            }
        }

        private static void RefreshQueue(object sender, ElapsedEventArgs e)
        {
            lock (WaitingClients)
            {
                if (WaitingClients.Count <= 0) return;
                for (int i = 0; i <= WaitingClients.Count - 1; i++)
                {
                    AuthentificationClient client = WaitingClients[i];
                    if (CanAcceptPlayer() > 0)
                    {
                        WaitingClients.Remove(client);
                        client.State = AuthentificationState.OnServerList;
                        client.Handler.SendAccountInformation();
                    }
                    else
                    {
                        client.Send("Af" + (i + 1) + "|" + WaitingClients.Count + "|0|0");
                    }
                }
            }
        }
    }
}
