using EsempioMediatR.Mediator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EsempioMediatR
{
    public class Program
    {

        public static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider serviceProvider = services.BuildServiceProvider(); //viene chiamato il costruttore di App
            serviceProvider.GetService<App>().Run();
        
        }

        //metodo che si occupa di registrare i servizi
        private static void ConfigureServices(IServiceCollection services)
        {
         // ServiceCollection services = new ServiceCollection(); //creo un istanza della ServiceCollection

            //bisogna registrare le dipendenze da usare
            //aggiungo MediatR, che registra tutti gli handlers e pre/post-processor
            services.AddMediatR(typeof(Program));

            //Transient: IoC crea una nuova istanza del tipo specificato ogni qualvolta ce ne sia bisogno
            //registro il MediatorService che gestisce le request nei rispettivi handler
            //IMediatorInterface  e il services mentre MediatorService e l'implementazione della prima
            services.AddTransient<IMediatorInterface, MediatorService>();
            
            //Aggiungo il servizio App
            services.AddTransient<App>();

            //return services;

        }

    }
}