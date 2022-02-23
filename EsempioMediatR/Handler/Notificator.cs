using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EsempioMediatR.Request;

namespace EsempioMediatR.Handler
{
    public class Notification1 : INotificationHandler<NotificaR>
    {
        public Task Handle(NotificaR notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notification 1 stampa il messaggio: {notification.Messaggio}");
            return Task.CompletedTask;
        }
    }

    public class Notification2 : INotificationHandler<NotificaR>
    {
        public Task Handle(NotificaR notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notification 2 stampa il messaggio : {notification.Messaggio}");
            return Task.CompletedTask;
        }
    }
}
