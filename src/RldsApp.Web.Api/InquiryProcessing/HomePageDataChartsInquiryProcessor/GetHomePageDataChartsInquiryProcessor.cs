using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RldsApp.Web.Api.Models.BarChart;

namespace RldsApp.Web.Api.InquiryProcessing.HomePageDataChartsInquiryProcessor
{
    public class GetHomePageDataChartsInquiryProcessor : IGetHomePageDataChartsInquiryProcessor
    {
        private readonly IMapper _autoMapper;
        private readonly ITransactionLinkService _linkService;
        private readonly ITransactionsByDateDataProcessor _queryProcessor;


        public GetHomePageDataChartsInquiryProcessor(
            IMapper autoMapper,
            ITransactionLinkService linkService,
            ITransactionsByDateDataProcessor queryProcessor)
        {
            _autoMapper = autoMapper;
            _linkService = linkService;
            _queryProcessor = queryProcessor;
        }

        public HomePageCharts GetHomePageChartsData(DateTime dateTime)
        {
            var transactionEntity = _queryProcessor.GetTransactionsByData(dateTime);
            if (transactionEntity == null)
            {
                throw new RootObjectNotFoundException(Constants.Messages.TransactionNotFound);
            }

            var transactionModel = _autoMapper.Map<List<Transaction>>(transactionEntity);

            return new HomePageCharts()
            {
                Doughnut = ConvertToDoDoughnutChart(transactionModel),
                Bar = ConvertToDoBarChart(transactionModel)
            };
        }

        private DoughnutChart ConvertToDoDoughnutChart(List<Transaction> transactions)
        {
            var rnd = new Random();
            var doughnutChart = new DoughnutChart();

            doughnutChart.Labels = new List<string>() { "Przychody", "Wydatki" };
            doughnutChart.DataSet = new List<decimal>()
            {
                transactions.Where(t=>t.Type.Name == "Incoming transfer").Sum(t=>t.Amount)+rnd.Next(0,100),
                transactions.Where(t=>t.Type.Name == "Outgoing transfer").Sum(t=>t.Amount)+rnd.Next(0,100)
            };

            return doughnutChart;
        }

        private BarChart ConvertToDoBarChart(List<Transaction> transactions)
        {
            var rnd = new Random();
            var barChart = new BarChart();

            barChart.Labels = new List<string>() { "Shopping", "Utilities", "Transportation" };
            barChart.DataSets = new List<DataSet>()
            {
                new DataSet()
                {
                    Label = "Przychody",
                    Data = new List<Decimal>()
                    {
                        transactions.Where(t => t.Category.Name == "Shopping").Sum( t => t.Amount)+rnd.Next(0,100),
                        transactions.Where(t => t.Category.Name == "Utilities").Sum( t => t.Amount )+rnd.Next(0,100),
                        transactions.Where(t => t.Category.Name == "Transportation").Sum(t => t.Amount)+rnd.Next(0,100),
                    }
                    // 4 kategorie [2.4.5.6]
               
                    // Lista 
                },
                new DataSet()
                {
                    Label = "Wydatki",
                    Data = new List<Decimal>()
                    {
                        transactions.Where(t => t.Category.Name == "Shopping").Sum( t => t.Amount)+rnd.Next(0,100),
                        transactions.Where(t => t.Category.Name == "Utilities").Sum( t => t.Amount )+rnd.Next(0,100),
                        transactions.Where(t => t.Category.Name == "Transportation").Sum(t => t.Amount)+rnd.Next(0,100),
                    }
                },
            };
            return barChart;
        }

    }
}
