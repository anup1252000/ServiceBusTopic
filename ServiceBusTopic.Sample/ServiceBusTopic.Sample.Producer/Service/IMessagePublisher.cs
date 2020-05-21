using System.Threading.Tasks;

namespace ServiceBusTopic.Sample.Producer.Service
{
    public interface IMessagePublisher
    {
        Task PublisherAsync<T>(T request); 
    }
}
