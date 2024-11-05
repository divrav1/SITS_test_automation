using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Response
{
    public class NavigateToEditResponse
    {
        public string textid { get; set; }
        public string objectType { get; set; }
        public string sourceSystem { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string usedIn { get; set; }
        public bool isTmAvailable { get; set; }
        public string objNameShort { get; set; }
        public string tag { get; set; }
        public List<TextPart> textpart { get; set; }
    }

    public class TextPart
    {
        public string partId { get; set; }
        public string partName { get; set; }
        public string updatedOn { get; set; }
        public string updatedBy { get; set; }
        public string status { get; set; }
        public int maxCharCount { get; set; }
        public string minimumBaseScore { get; set; }
        public string text { get; set; }
        public string translated_text { get; set; }
    }
}
