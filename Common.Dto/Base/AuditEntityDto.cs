using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public abstract class AuditEntityDto : BaseEntityDto
    {
        public AuditEntityDto()
        {
            Enabled = true;
        }

        [JsonIgnore]
        public Guid Guid { get; set; }

        //public byte[] RowVersion { get; set; }

        public bool Enabled { get; set; }

        //public virtual long? CreatorUserId { get; set; }

        //public long? UpdaterUserId { get; set; }

        //public DateTime Created { get; set; }

        //public DateTime? Updated { get; set; }

        //public DateTime? Deleted { get; set; }

    }
}
