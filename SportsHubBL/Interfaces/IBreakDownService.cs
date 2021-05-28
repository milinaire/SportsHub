using SportsHubBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Interfaces
{
    public interface IBreakDownService
    {
        public BreakDownModel GenerateBreakDownModel(int breakDownId, int languageId);

        public IEnumerable<BreakDownModel> GetBreakDowns(int languageId, bool showHidden = false);

        public void AddBreakDown(BreakDownModel model);

        public void UpdateBreakDown(int id, BreakDownModel model);

        public void DeleteBreakDown(int id);
    }
}
