using ReportGeneratorApp.Abstract;
using ReportGeneratorApp.Interface;
using Assessment4.question2.concrete;

namespace ReportGeneratorApp.Factories
{
    public class ChartReportFactory : ReportFactory
    {
        public override IReportGenerator CreateReport()
        {
            return new Class1();
        }
    }
}