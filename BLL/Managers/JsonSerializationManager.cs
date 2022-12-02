using BLL.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;

namespace BLL.Managers
{
    public class JsonSerializationManager<T> : ISerializationManager<T> 
    {
        public string Serialize(T item)
        {
            if (item != null)
                return JsonConvert.SerializeObject(item);
            else return "{}";
        }
        public T Deserialize(string item)
        {
            var schema = GenerateSchema();
            try
            {
                JObject test = JObject.Parse(item);
                if (test.IsValid(schema))
                    return JsonConvert.DeserializeObject<T>(item);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return default(T);
        }
        public JSchema GenerateSchema()
        {
            JSchemaGenerator generator = new JSchemaGenerator();
            return generator.Generate(typeof(T));
        }
      
    }
}
