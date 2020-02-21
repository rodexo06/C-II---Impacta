using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ExemploSignalR
{
    public class ExemploHub : Hub
    {
        public void EnviarMensagemHub(string msg)
        {
            Clients.All.EnviarMensagemClient(msg);
        }
    }
}