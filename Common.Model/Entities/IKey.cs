using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Entities
{
    public interface IKey<K>
    {
        public K Id { get; set; }
    }
}
