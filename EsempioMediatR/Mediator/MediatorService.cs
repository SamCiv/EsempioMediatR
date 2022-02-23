using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsempioMediatR.Request;

namespace EsempioMediatR.Mediator
{
    internal class MediatorService : IMediatorInterface
    {
        private readonly IMediator _mediator; // Send/publish per IMediator sono asincroni.

        //IMediator e inject tramite DI che contiene tutti i tipi di request e i loro rispettivi handlers
        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }


        //Di seguito creo le request che devono essere gestite

        public void OneWay()
        {
            //chiamo la request async, ritorno un Task
            Task task = Task.Run(async () => await _mediator.Send(new OneWayAsync()));
            
            //chiamo OneWaySync, non ritorno nulla
            _mediator.Send(new OneWaySync());
        }

        public string RequestResponse()
        {
            string response = Task.Run<string>(
                async () => await _mediator.Send(new Ping())).Result;
            return response;
        }

        //Caso di una request che viene gestita da piu handlers
        //in tal caso uso publish per notificare la richiesta ai vari Handler
        //passando la request relativa ovvero NotificaR
        //e possibile utilizzare diverse strategie di publish
        public void Notifica(string message)
        {
           
            _mediator.Publish(new NotificaR { Messaggio = message });
        }

        public void DelayedNotify(int millis, CancellationToken cancellationToken)
        {
            _mediator.Publish(new DelayNotificationMessage { TimeInMillis = millis }, cancellationToken);
        }
    }
}
