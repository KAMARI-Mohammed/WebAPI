using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace chatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task  SendMessage(Messages messages){
            await Clients.All.SendAsync("receiveMessage",messages);
        }
    }
}