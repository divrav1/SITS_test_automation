using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Response
{
    public class TranslationUnitResponse
    {
        public List<TranslationUnitResponseListItem> TranslationUnitResponseList { get; set; }
    }

    public class TranslationUnitResponseListItem
    {
        public string Action { get; set; }
        public string ErrorCode { get; set; }
        public string TranslationUnitId { get; set; }
        public string TranslationHash { get; set; }
    }
}
