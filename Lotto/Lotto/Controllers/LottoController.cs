using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lotto.Filters;
using Lotto.Infrastructure;
using Lotto.Models;

namespace Lotto.Controllers
{
    [Authenticate(AdminAccess = false)]
    public class LottoController : Controller
    {
        IStatisticRepository statRepository;

        public LottoController(IStatisticRepository statRepo)
        {
            statRepository = statRepo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult BasicStatistics()
        {
            return View(new StatisticViewModel());
        }

        [HttpPost]
        public ViewResult BasicStatistics(StatisticViewModel stat)
        {
            return View("BasicStatisticsResults", statRepository.GetStatistics(stat.StartDate, stat.EndDate));
        }

        public ViewResult AllNumbersStatistics()
        {
            return View(new StatisticViewModel());
        }

        [HttpPost]
        public ViewResult AllNumbersStatistics(StatisticViewModel stat)
        {
            return View("AllNumbersStatisticsResults", statRepository.AllNumbersStatistics(stat.StartDate, stat.EndDate));
        }

        public ViewResult BestNumbersStatistics()
        {
            return View(new StatisticViewModel());
        }

        [HttpPost]
        public ViewResult BestNumbersStatistics(StatisticViewModel stat)
        {
            if (stat.NumbersCount == null)
                stat.NumbersCount = 0;

            return View("BestNumbersStatisticsResults", statRepository.BestNumbersStatistics(stat.StartDate, stat.EndDate, stat.NumbersCount.Value));
        }

        public ViewResult WorstNumbersStatistics()
        {
            return View(new StatisticViewModel());
        }

        [HttpPost]
        public ViewResult WorstNumbersStatistics(StatisticViewModel stat)
        {
            if (stat.NumbersCount == null)
                stat.NumbersCount = 0;

            return View("WorstNumbersStatisticsResults", statRepository.WorstNumbersStatistics(stat.StartDate, stat.EndDate, stat.NumbersCount.Value));
        }
    }
}
