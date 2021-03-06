﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author MonSterC²
//This is a file from Project $safeprojectname$

namespace Crystal.WorldServer.World.Handlers
{
    public static class EnemiesHandler
    {
        public static void RegisterMethod()
        {
            Network.Dispatcher.RegisteredMethods.Add("iA", typeof(EnemiesHandler).GetMethod("AddEnemies"));
            Network.Dispatcher.RegisteredMethods.Add("iD", typeof(EnemiesHandler).GetMethod("DeleteEnemies"));
            Network.Dispatcher.RegisteredMethods.Add("iL", typeof(EnemiesHandler).GetMethod("ShowEnemies"));
        }

        public static void ShowEnemies(World.Network.WorldClient client, string packet = "")
        {
            string enemiesPacket = "iL";
            foreach (int i in client.AccountData.EnemiesIDs)
            {
                if (Helper.AccountHelper.ExistAccountData(i))
                {
                    Database.Records.AccountDataRecord account = Helper.AccountHelper.GetAccountData(i);
                    enemiesPacket += "|" + account.NickName;
                    World.Network.WorldClient player = Helper.WorldHelper.GetClientByAccountNickName(account.NickName);
                    if (player != null)
                    {
                        if (player.AccountData.EnemiesIDs.Contains(client.AccountData.AccountID))
                        {
                            enemiesPacket += player.Character.Pattern.CharacterToEnemiesListKnow;
                        }
                        else
                        {
                            enemiesPacket += player.Character.Pattern.CharacterToEnemiesListUnKnow;
                        }
                    }
                }
            }
            client.Send(enemiesPacket);
        }

        public static void AddEnemies(World.Network.WorldClient client, string packet)
        {
            string addType = packet[2].ToString();
            string nickname;
            Network.WorldClient player;
            switch (addType)
            {
                case "%"://Character name
                    nickname = packet.Substring(3);
                    player = Helper.WorldHelper.GetClientByCharacter(nickname);
                    if (player != null)
                    {
                        client.AccountData.EnemiesIDs.Add(player.AccountData.AccountID);
                    }
                    else
                    {
                        client.Send("cMEf" + nickname);
                    }
                    break;

                case "*":
                    nickname = packet.Substring(3);
                    player = Helper.WorldHelper.GetClientByCharacter(nickname);
                    if (player != null)
                    {
                        client.AccountData.EnemiesIDs.Add(player.AccountData.AccountID);
                    }
                    else
                    {
                        client.Send("cMEf" + nickname);
                    }
                    break;

                default:
                    nickname = packet.Substring(2);
                    player = Helper.WorldHelper.GetClientByCharacter(nickname);
                    if (player != null)
                    {
                        client.AccountData.EnemiesIDs.Add(player.AccountData.AccountID);
                        client.Send("BN");
                    }
                    else
                    {
                        client.Send("cMEf" + nickname);
                    }
                    break;
            }
        }

        public static void DeleteEnemies(World.Network.WorldClient client, string packet)
        {
            string nickname = packet.Substring(3);
            if (Helper.AccountHelper.ExistAccountData(nickname))
            {
                Database.Records.AccountDataRecord account = Helper.AccountHelper.GetAccountData(nickname);
                if (client.AccountData.EnemiesIDs.Contains(account.AccountID))
                {
                    client.AccountData.EnemiesIDs.Remove(account.AccountID);
                    ShowEnemies(client);
                    client.Action.BasicMessage("Vous venez de perdre un ennemie, Triomphe de la paix.", "36BBFD");
                }
            }
        }
    }
}
