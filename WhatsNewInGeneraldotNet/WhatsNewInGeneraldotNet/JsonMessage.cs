using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace WhatsNewInGeneraldotNet
{
    public class JsonMessage
    {
        public string Message { get; set; }
    }

    [JsonSerializable(typeof(JsonMessage))]
    public class JsonContext : JsonSerializerContext
    {
        public JsonContext(JsonSerializerOptions? options) : base(options)
        {
        }

        protected override JsonSerializerOptions? GeneratedSerializerOptions => throw new NotImplementedException();

        public override JsonTypeInfo? GetTypeInfo(Type type)
        {
            throw new NotImplementedException();
        }
    }


}
