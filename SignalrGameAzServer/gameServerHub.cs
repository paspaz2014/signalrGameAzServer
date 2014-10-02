using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MessageTypes;
using Microsoft.AspNet.SignalR.Hubs;


namespace SignalrGameAzServer
{
    [HubName("paspAzureGameHub")]
    public class gameServerHub : Hub
    {
        static Dictionary<int, myPlayer> _players = new Dictionary<int, myPlayer>();
        static int _playerCount = 0;

        public void SendMessage(string message)
        {
            Clients.All.UpdateMessageR(message);
        }

        public void JoinServer(myPoint pos)
        {
            int id = ++_playerCount;
            myPlayer p =
                new myPlayer(id, pos);
            Clients.Caller.JoinedServer(p);
            Clients.Others.AddOtherPlayer(p);
            foreach (KeyValuePair<int, myPlayer> player in _players)
            {
                Clients.Caller.AddOtherPlayer(player.Value);
            }
            _players.Add(id, p);
        }

        public void UpdatePlayerPosition(myPlayer p)
        {
            Clients.Others.UpdatePosition(p);
            _players[p.PlayerID].Pos = p.Pos;
        }

        public void DeletePlayer(myPlayer p)
        {
            _players.Remove(p.PlayerID);
            Clients.Others.removePlayer(p);
        }
    }
}