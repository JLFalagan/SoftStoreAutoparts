using Common.Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Common.Model.Process
{
    public abstract class BaseTaskArgs : AuditEntity
    {
        public BaseTaskArgs()
        {
            Dictionary = new Dictionary<string, string>();
            KeyValues = JsonConvert.SerializeObject(Dictionary);
        }

        public BaseTaskArgs(string keyValues)
        {
            KeyValues = keyValues;
            Initialize();
        }

        public void Initialize()
        {
            Dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(KeyValues);
        }

        public string KeyValues { get; private set; }

        public void AddOrUpdate(string key, object value)
        {
            string serializeValue = JsonConvert.SerializeObject(value);
            Dictionary.AddOrUpdate(key, serializeValue);
            KeyValues = JsonConvert.SerializeObject(Dictionary);
        }

        public T Get<T>(string key)
        {
            var serializeValue = Dictionary[key];
            T deserializeValue = JsonConvert.DeserializeObject<T>(serializeValue);
            return deserializeValue;
        }

        public Dictionary<string, string> Dictionary { get; set; }
    }
}
