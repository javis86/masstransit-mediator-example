using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace test.mt.mediator.Components
{
    public class AltaMedicaConsumer : IConsumer<ISiniestroAltaMedica>
    {
        private readonly ILogger<AltaMedicaConsumer> _logger;

        public AltaMedicaConsumer(ILogger<AltaMedicaConsumer> logger )
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ISiniestroAltaMedica> context)
        {
            _logger.LogInformation("Alta Medica SiniestroId {SiniestroId}", context.Message.SiniestroId);

            await context.RespondAsync<ISiniestroAltaMedicaStatus>(new { Status = 1});
        }
    }
}