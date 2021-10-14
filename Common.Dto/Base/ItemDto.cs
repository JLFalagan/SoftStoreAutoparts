using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dto
{
    public class ItemDto : IEntity
    {
        public long Id { get; set; }

        [JsonProperty("t")]
        public string Text { get; set; }

        [JsonIgnore]
        public string Display
        {
            get { return Text; }
        }
    }
}
