using Bank.Messages;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace AccountConsumer
{
    public class EventConsumer :
         IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            Console.WriteLine("Value: {0}", context.Message.Text);
        }
    }
}
