
using Unisoft_Project.Core.Models;

namespace Unisoft_Project.Core.Contracts
{
    public interface IHighlightService
    {
       
            Dictionary<string, double> CalculateCompletionPercentage(List<HighlightRecord> passes);
            Dictionary<string, double> FindLongestCompletedPass(List<HighlightRecord> passes);
        

    }
}
