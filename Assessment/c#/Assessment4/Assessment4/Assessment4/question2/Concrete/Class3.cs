using ReportGeneratorApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4.question2.concrete
{
    class Class3: IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating summary report...");
        }
    }
}
