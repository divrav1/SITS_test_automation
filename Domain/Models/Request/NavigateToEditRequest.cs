using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Request
{
    public class NavigateToEditRequest
    {
        public string textid { get; set; }
        public string source_locale_code { get; set; }
        public string target_locale_code { get; set; }
        public string object_type_short { get; set; }
        public bool isParentEnabled { get; set; }
    }
}
