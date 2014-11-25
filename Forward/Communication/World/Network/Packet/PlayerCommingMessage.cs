﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//@Author NightWolf
//This is a file from Project $safeprojectname$

namespace Crystal.RealmServer.Communication.World.Network.Packet
{
    public class PlayerCommingMessage : Protocol.ForwardPacket
    {
        public PlayerCommingMessage(Database.Records.AccountRecord account, string ticket)
            : base(Protocol.ForwardPacketTypeEnum.PlayerCommingMessage)
        {
            Writer.Write(ticket);
            Writer.Write(account.ID);
            Writer.Write(account.Username);
            Writer.Write(account.Password);
            Writer.Write(account.Pseudo);
            Writer.Write(account.SecretQuestion);
            Writer.Write(account.SecretAnswer);
            Writer.Write(account.AdminLevel);
            Writer.Write(account.Points);
        }
    }
}
