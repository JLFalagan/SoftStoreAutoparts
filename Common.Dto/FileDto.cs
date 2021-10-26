using System;
using System.Collections.Generic;
using System.IO;

namespace Common.Dto
{
    public class FileDto : AuditEntityDto<long>
    {
        public string Name { get; set; }

        public string MimeType { get; set; }

        //public byte[] Content { get; set; }
        public string Base64Content { get; set; }

        public string Description { get; set; }

        public Stream GetStream()
        {
            if (!string.IsNullOrEmpty(this.Base64Content))
            {
                var bytes = System.Convert.FromBase64String(this.Base64Content);
                MemoryStream ms = new MemoryStream(bytes);
                return ms;
            }
            else
                return null;

        }

        public string Path { get; set; }

    }
}
