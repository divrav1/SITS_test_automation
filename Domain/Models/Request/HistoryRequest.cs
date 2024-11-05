using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Request
{
    public class HistoryRequest
    {
        public string TextId { get; set; }
        public string SourceLocaleCode { get; set; }
        public string TargetLocaleCode { get; set; }
        public string ObjectTypeShort { get; set; }
        public bool IsParentEnabled { get; set; }
    }
}
