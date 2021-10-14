using System;
using System.Collections.Generic;


namespace Common.Dto
{ 
    public class ReportDocumentDto : IEntity
    {
        public ReportDocumentDto()
        {
            Landscape = false;
        }

        public long Id { get; set; }

        public long FormatId { get; set; }

        public bool Landscape { get; set; }

        public string Base64Stream { get; set; }

        public string FileExtension { get; set; }

        public string FileName { get; set; }

        public string FullFileName { get; set; }
    }
}
