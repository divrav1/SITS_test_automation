using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Request
{
    public class TranslationUnitRequest
    {
        public string UserID { get; set; }
        public string TextID { get; set; }
        public string TextType_SHORT { get; set; }
        public string Part_ID { get; set; }
        public List<TranslationUnitRequestListItem> TranslationUnitRequestList { get; set; }
    }

    public class TranslationUnitRequestListItem
    {
        public TranslationUnitSettings Settings { get; set; }
        public TranslationUnitDetails TranslationUnit { get; set; }
    }

    public class TranslationUnitSettings
    {
        public string ExistingTUsUpdateMode { get; set; }
    }

    public class TranslationUnitDetails
    {
        public TranslationUnitLanguage Source { get; set; }
        public TranslationUnitLanguage Target { get; set; }
        public string TextType { get; set; }
        public string CreatedBy { get; set; }
        public string CreationDate { get; set; }
        public string UsedBy { get; set; }
        public string UseDate { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class TranslationUnitLanguage
    {
        public string Language { get; set; }
        public string Text { get; set; }
    }
}
