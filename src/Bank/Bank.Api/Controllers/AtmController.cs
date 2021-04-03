using Bank.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtmController : ControllerBase
    {
        private IBus _bus { get; set; }

        public AtmController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("Balance")]
        public async Task<ActionResult<string>> Balance(string accountNumber)
        {
            string messageText = $"Account Number {accountNumber} The time is {DateTimeOffset.Now}";
            await _bus.Publish(new Message { Text = messageText });
            Console.WriteLine(messageText);
            return Ok($"Message Sent Account Number: {accountNumber}");
        }
    }
}
