using MassTransit;
using Microsoft.Extensions.Caching.Memory;
using Store.Domain.Identity;

namespace Store.Infrastructure.Consumers
{
    public class UserStatusConsumer : IConsumer<User>
    {
        private IMemoryCache _cache;

        public UserStatusConsumer(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task Consume(ConsumeContext<User> context)
        {
            _cache.Remove(context.Message.Id);
            _cache.Set(context.Message, context.Message.Id);
        }
    }
}
