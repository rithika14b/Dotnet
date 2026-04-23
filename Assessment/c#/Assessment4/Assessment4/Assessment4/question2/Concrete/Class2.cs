using ReportGeneratorApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4.question2.concrete
{
    class Class2 : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating tabular report...");
        }
    }
}
