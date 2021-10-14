using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public interface IEnumerableEntity
    {
        long Number { get; set; }

        string NumeratorName { get; }

        bool Numerate { get; }
    }
}
