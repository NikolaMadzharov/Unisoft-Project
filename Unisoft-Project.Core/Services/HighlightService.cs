using Unisoft_Project.Core.Contracts;
using Unisoft_Project.Core.Models;

namespace Unisoft_Project.Core.Services
{
    public class HighlightService : IHighlightService
    {
        public Dictionary<string, double> CalculateCompletionPercentage(List<HighlightRecord> passes)
        {



            var completedPasses = passes
             .GroupBy(p => p.Receiver)
             .ToDictionary(
                 g => g.Key,
                 g => (double)g.Count(p => p.Result == "complete") / g.Count() * 100);
            


            return completedPasses;

            
        }

       
        public Dictionary<string, double> FindLongestCompletedPass(List<HighlightRecord> passes)
        {
         
            var completedPasses = passes.Where(p => p.Result == "complete").ToList();

            if (completedPasses.Any())
            {
                
                var longestPass = completedPasses.OrderByDescending(p => p.Distance).First();
              
                return new Dictionary<string, double> { { longestPass.Receiver, longestPass.Distance } };
            }

            
            return new Dictionary<string, double>();
        }
    }
}
