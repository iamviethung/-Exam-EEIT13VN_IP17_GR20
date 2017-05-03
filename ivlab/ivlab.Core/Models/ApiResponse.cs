using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ivlab.Core.Services
{
    public class ApiResponse<T>
    {
        [JsonProperty("successful")]
        public bool Successful { get; set; }

        [JsonProperty("errorDesc")]
        public JToken ErrorDesc { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
        
        [JsonProperty("log")]
        public string Log { get; set; }
    }
}