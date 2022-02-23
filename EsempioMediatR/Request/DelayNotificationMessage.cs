using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace EsempioMediatR.Request
{
    public class DelayNotificationMessage : INotification
    {
        public int TimeInMillis { get; set; } //il nostro messaggio contiene il tempo in millisecondi
    }
}
