

namespace Carrefour.Core.Redis
{
    public class RedisCacheOptions
    {
        //
        // 摘要:
        //     The configuration used to connect to Redis.
        public string Configuration { get; set; }
        //
        // 摘要:
        //     The Redis instance name.
        public string InstanceName { get; set; }
    }
}