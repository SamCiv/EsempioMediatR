using EsempioMediatR.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsempioMediatR
{
    public class App
    {
        //readonly, campi che possono essere assegnati uno o piu volte solo nella dichiarazione o in un costruttore della stessa classe.
        private readonly IMediatorInterface _mediatorService;

        //Injection by Constructor Method.
        ////La classe App utilizza un mediator Service, dunque devo utilizzare la sua astrazione per poterlo usare, in modo da rispettare le convenzioni di DI e IoC
        //Attraverso il mediatorService vado a inviare le mie richieste
        public App(IMediatorInterface mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public void Run() //e chiamato da Program.cs
        {
            requestRisposta();
            OneWay(); //richiamo il ONeWay Async e sync
            Notifications();
            Notifica5Secondi(5200);
        }

        //esempio di request con risposta testuale
        private void requestRisposta()
        {
            string risposta = _mediatorService.RequestResponse();
            Console.WriteLine(risposta);
        }

        private void OneWay()
        {
            _mediatorService.OneWay(); // chiamo il oneway                
        }

        private void Notifications()
        {
            _mediatorService.Notifica(DateTime.Now.ToString());
        }

        private void Notifica5Secondi(int timeInMillis)
        {
            CancellationTokenSource sorgente = new CancellationTokenSource();            
            sorgente.CancelAfter(5000);
            CancellationToken token = sorgente.Token;
            
            _mediatorService.DelayedNotify(timeInMillis, token);

            Console.WriteLine("Task terminato entro 5s");
        }


    }
}
