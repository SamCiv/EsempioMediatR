using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EsempioMediatR.Request;
using System.Diagnostics;

namespace EsempioMediatR.Handler
{
    public class NotifierTempoHandler : INotificationHandler<DelayNotificationMessage>
    {
        public async Task Handle(DelayNotificationMessage notification, CancellationToken cancellationToken)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            try
            {
                await Task.Delay(notification.TimeInMillis, cancellationToken);
                Console.WriteLine("Task eseguito per tempo!");
            }
            catch (OperationCanceledException ex)
            {
                System.Console.WriteLine("E' passato un tempo di 5 secondi, l'operazione e' stata annullata");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            stopwatch.Stop();

            Console.WriteLine($"E' trascorso un tempo di {stopwatch.Elapsed} dall'avvio dell handler");
            
        }
    }
}
