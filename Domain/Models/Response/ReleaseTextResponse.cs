using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS_Test_Automation.Domain.Models.Response
{
    public class ReleaseTextResponse
    {
        public UpdateResult UpdateResult { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class UpdateResult
    {
        public bool IsAcknowledged { get; set; }
        public bool IsModifiedCountAvailable { get; set; }
        public int MatchedCount { get; set; }
        public int ModifiedCount { get; set; }
    }
}
