using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lotto.Database;
using Lotto.Models;
using HtmlAgilityPack;
using System.Data.Entity;

namespace Lotto.Infrastructure
{
    public class StatisticRepository : IStatisticRepository
    {
        private LottoDbContext dbContext;

        public StatisticRepository()
        {
            dbContext = new LottoDbContext();
        }

        public bool AddStatistic(Statistic stat)
        {
            dbContext.Statistics.Add(stat);
            dbContext.SaveChanges();

            return true;
        }

        

        public IEnumerable<Statistic> LoadStatistics(DateTime dateFrom, DateTime dateTo)
        {
            string url = "http://www.lotto.pl/lotto/wyniki-i-wygrane";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a"))
            {                
            }

            return null;
        }


        public IEnumerable<Statistic> GetStatistics(DateTime dateFrom, DateTime dateTo)
        {
            return dbContext.Statistics.Include(p => p.LuckyNumbers).Where(p => p.Date >= dateFrom && p.Date <= dateTo).ToList();
        }

        public Dictionary<int, int> AllNumbersStatistics(DateTime dateFrom, DateTime dateTo)
        {
            Dictionary<int, int> results = new Dictionary<int, int>(50);
            
            for (int i = 0; i < 50; ++i)
                results.Add(i, 0);

            List<Statistic> scores = dbContext.Statistics.Include(p => p.LuckyNumbers).Where(p => p.Date >= dateFrom && p.Date <= dateTo).ToList();

            foreach (var stat in scores)
                foreach (var number in stat.LuckyNumbers)
                    if(number.Value != null)
                        ++results[(int)number.Value - 1];

            return results;
        }

        public IEnumerable<KeyValuePair<int, int>> BestNumbersStatistics(DateTime dateFrom, DateTime dateTo, int numbersCount)
        {
            Dictionary<int, int> results = AllNumbersStatistics(dateFrom, dateTo);
            IOrderedEnumerable<KeyValuePair<int, int>> sortedResults = results.OrderByDescending(pair => pair.Value);

            return sortedResults.Take(numbersCount);
        }

        public IEnumerable<KeyValuePair<int, int>> WorstNumbersStatistics(DateTime dateFrom, DateTime dateTo, int numbersCount)
        {
            Dictionary<int, int> results = AllNumbersStatistics(dateFrom, dateTo);
            IOrderedEnumerable<KeyValuePair<int, int>> sortedResults = results.OrderBy(pair => pair.Value);

            return sortedResults.Take(numbersCount);
        }
    }
}