using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Request
{
    public class DueInRequest
    {
        public String locale_code { get; set; }
        public List<String> object_type { get; set; } = new List<string>();
        public List<String> due_in { get; set; } = new List<string> { "Overdue" };
        public List<String> status { get; set; } = new List<String>();
        public List<String> category { get; set; } = new List<String>();
        public List<String> supportLocaleStatus { get; set; } = new List<String>();
        public String sort { get; set; }

    }
}
