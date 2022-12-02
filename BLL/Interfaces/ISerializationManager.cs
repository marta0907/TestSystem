using Newtonsoft.Json.Schema;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ISerializationManager<T> 
    {
        /// <summary>
        /// Serialize  Test object into string
        /// </summary>
        /// <param name="item">item that will be serialized</param>
        /// <returns>string</returns>
        public string Serialize(T item);
        /// <summary>
        /// Deserialize string into  Test object 
        /// </summary>
        /// <param name="item">item that will be deserialized</param>
        /// <returns>Test</returns>
        public T Deserialize(string item);
       
        /// <summary>
        /// method that generates json schema for validation json files
        /// </summary>
        /// <returns>json schema</returns>
        public JSchema GenerateSchema();

    }
}
