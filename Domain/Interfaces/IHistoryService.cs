using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SITS_Test_Automation.Domain.Models.Request;
using SITS_Test_Automation.Domain.Models.Response;

namespace SITS_Test_Automation.Domain.Interfaces
{
    public interface IHistoryService
    {
        Task<HistoryResponse> GetHistoryAsync(HistoryRequest request);
    }
}
