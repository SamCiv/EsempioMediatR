using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsempioMediatR.Mediator
{
    //definisce i metodi del mediatore
    public interface IMediatorInterface
    {
        //request che restituisce una stringa
        string RequestResponse();

        void OneWay();

        void Notifica(string message);

        void DelayedNotify(int millis, CancellationToken cancellationToken);
    }
}
