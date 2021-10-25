using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public abstract class BaseEntityDto<T>
    {
        public virtual T Id { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual bool IsNew { get; set; }
        public virtual string Display { get; set; }

        //public BaseEntityDto()
        //{
        //    this.Id = GenerateTempId();
        //}

        //private int GenerateTempId()
        //{
        //    return Math.Abs(Guid.NewGuid().GetHashCode()) * -1;
        //}

        //[JsonIgnore]
        //public virtual bool IsNew => Id <= 0;
    }
}
