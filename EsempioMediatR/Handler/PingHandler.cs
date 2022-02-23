using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsempioMediatR.Request;
using MediatR;

namespace EsempioMediatR.Handler
{
    public class PingHandler : IRequestHandler<Ping, string>
    {
        //deve ritornare Task<string>
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("risposta!");
        }

        /*
         *  public async Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return  await Task.FromResult("risposta!");
        }
        */
    }
}
