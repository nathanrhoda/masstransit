using Bank.Messages;
using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccountConsumer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
               

                cfg.ReceiveEndpoint("Message", e =>
                {
                    e.Consumer<EventConsumer>();
                });
            });


            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);
            try
            {
                Console.WriteLine("Press enter to exit");

                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                await busControl.StopAsync();
            }
        }              
    }
}
