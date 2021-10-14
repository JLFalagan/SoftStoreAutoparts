using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    [Serializable]
    public class FriendlyException : Exception
    {
        public enum ExceptionLevel
        {
            Warning = 48,
            Information = 64
        }

        public ExceptionLevel Level { get; set; }

        public FriendlyException(string message, ExceptionLevel level = ExceptionLevel.Warning) : base(message) { Level = level; }

        public FriendlyException(string message, Exception innerException, ExceptionLevel level = ExceptionLevel.Warning) : base(message, innerException) { Level = level; }
    }
}
