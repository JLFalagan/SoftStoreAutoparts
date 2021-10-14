using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public abstract class BaseEntityDto : IEntity
    {
        public BaseEntityDto()
        {
            this.Id = GenerateTempId();
        }
        public long Id { get; set; }


        [JsonIgnore]
        public virtual bool IsNew
        {
            get
            {
                return Id <= 0;
            }
        }

        private int GenerateTempId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode()) * -1;
        }

        //public virtual string Display
        //{
        //    get { return ToString(); }
        //}

        //public override string ToString()
        //{
        //    return Id.ToString();
        //}
        public string Display { get; set; }

    }
}
