using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotto.Models;

namespace Lotto.Infrastructure
{
    public interface IStatisticRepository
    {
        bool AddStatistic(Statistic stat);
        IEnumerable<Statistic> LoadStatistics(DateTime dateFrom, DateTime dateTo);
        IEnumerable<Statistic> GetStatistics(DateTime dateFrom, DateTime dateTo);
        Dictionary<int, int> AllNumbersStatistics(DateTime dateFrom, DateTime dateTo);
        IEnumerable<KeyValuePair<int, int>> BestNumbersStatistics(DateTime dateFrom, DateTime dateTo, int numbersCount);
        IEnumerable<KeyValuePair<int, int>> WorstNumbersStatistics(DateTime dateFrom, DateTime dateTo, int numbersCount);
    }
}
