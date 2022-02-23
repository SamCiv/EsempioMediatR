using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsempioMediatR.Request;
using MediatR;

namespace EsempioMediatR.Handler
{
    //in tal caso non richiede risposta
    public class OneWayHandlerAsync : AsyncRequestHandler<OneWayAsync>
    {
        //deve ritornare un Task
        protected override Task Handle(OneWayAsync request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Chiamata OneWayHandler di tipo Async");
            return Task.CompletedTask;
        }        
    }

    public class OneWayHandlerSync : RequestHandler<OneWaySync>
    {
        protected override void Handle(OneWaySync request)
        {
            Console.WriteLine("Chiamata all handler OneWaySync");
            return;
        }
    }
   
}
