using ReportGeneratorApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4.question2.concrete
{
        public class Class1 : IReportGenerator
    {
            public void GenerateReport()
            {
                Console.WriteLine("Generating chart-based report...");
            }
        }
 }


