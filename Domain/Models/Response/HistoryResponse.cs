using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Response
{
    public class HistoryResponse
    {
        public DraftVersion DraftVersion { get; set; }
        public CurrentVersion CurrentVersion { get; set; }
    }

    public class DraftVersion
    {
        public DateTime UpdatedOn { get; set; }
        public string TranslatedBy { get; set; }
        public string Status { get; set; }
        public int VersionNo { get; set; }
    }

    public class CurrentVersion
    {
        public DateTime UpdatedOn { get; set; }
        public string TranslatedBy { get; set; }
        public string Status { get; set; }
        public int VersionNo { get; set; }
    }
}
