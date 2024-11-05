using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Response
{
    public class DueInResponse
    {
        public List<String> textIds { get; set; }
        public int no_of_texts { get; set; }
        public string object_type { get; set; }
        public string ObjShortName { get; set; }
        public int due_in { get; set; }
        public string range { get; set; }
        public int no_of_words { get; set; }
    }
}
