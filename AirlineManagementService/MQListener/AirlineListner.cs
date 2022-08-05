using Models.EventModel;
using Newtonsoft.Json;
using Services.Abstraction;

namespace AirlineManagementService.MQListener
{
    public class AirlineListner : RabbitListener
    {
        private readonly IServiceProvider _serviceProvider;
         
        public AirlineListner(IConfiguration configuration,IServiceProvider service) : base(configuration)
        {
            base.QueueName = configuration["queueName"];
            _serviceProvider = service;
            
        }
        public override bool Process(string message)
        {
            using (var service = _serviceProvider.CreateScope())
            {
                try
                {
                    var _eventService = service.ServiceProvider.GetService<IEventService>();
                    var @event = JsonConvert.DeserializeObject<AirlineEM>(message);
                    return _eventService.UpdateFlightSeats(@event);
                }catch(Exception ex)
                {
                    return false;
                }
                
            }
           
        }
    }
}
