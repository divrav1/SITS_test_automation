using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Request
{
    public class ReleaseTextRequest
    {
        public List<TextDetails> Texts { get; set; }
        public string LocaleCode { get; set; }
        public string Status { get; set; }
        public string TranslatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class TextDetails
    {
        public string TextId { get; set; }
        public string ObjectNameShort { get; set; }
    }
}
