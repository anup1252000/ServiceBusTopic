using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceBusTopic.Sample.Common;
using ServiceBusTopic.Sample.Producer.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceBusTopic.Sample.Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IMessagePublisher messagePublisher;

        public TopicController(IMessagePublisher messagePublisher)
        {
            this.messagePublisher = messagePublisher;
        }

        // POST api/values
        [HttpPost(template:"product")]
        public async Task SendToProduct([FromBody]Product product)
        {
            await messagePublisher.PublisherAsync(product);
        }

       [HttpPost(template:"order")]
       public async Task SentToOrder([FromBody]Order order)
        {
            await messagePublisher.PublisherAsync(order);
        }
    }
}
