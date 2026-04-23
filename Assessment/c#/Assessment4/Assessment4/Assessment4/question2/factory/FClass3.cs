using System;
using ReportGeneratorApp.Abstract;
using ReportGeneratorApp.Interface;
using ReportGeneratorApp.Factories;

namespace ReportGeneratorApp.Question
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Report Type: Chart | Tabular | Summary");
            string userChoice = Console.ReadLine();

            ReportFactory factory = userChoice switch
            {
                "Chart" => new ChartReportFactory(),
                "Tabular" => new TabularReportFactory(),
                "Summary" => new SummaryReportFactory(),
                _ => throw new ArgumentException("Invalid report type")
            };

            IReportGenerator report = factory.CreateReport();
            report.GenerateReport();
        }
    }
}