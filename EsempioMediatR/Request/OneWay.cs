using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EsempioMediatR.Request
{
    //caso Async
    public class OneWayAsync : IRequest //senza tipo restituito
    {

    }

    //caso Sync
    public class OneWaySync : IRequest
    {

    }
}
