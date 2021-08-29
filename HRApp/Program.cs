using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRCTCLibrary;
using System.Configuration;
using System.Collections.Specialized;
namespace HRApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CTCLimits ctcLimits = new CTCLimits
            {
                BasicPercent = Convert.ToDouble(ConfigurationManager.AppSettings.Get("BasicPercent")),
                HRAPercent = Convert.ToDouble(ConfigurationManager.AppSettings.Get("HRAPercent")),
                ConvAmount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ConvAmount")),
                MedicalReimbursementAmount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MedicalReimbursementAmount")),
                PFContributionPercent = Convert.ToDouble(ConfigurationManager.AppSettings.Get("PFContributionPercent")),
                PFLimitAmount = Convert.ToDouble(ConfigurationManager.AppSettings.Get("PFLimitAmount")),
                ESICPercent = Convert.ToDouble(ConfigurationManager.AppSettings.Get("ESICPercent")),
                ESICLimitAmount = Convert.ToDouble(ConfigurationManager.AppSettings.Get("ESICLimitAmount"))
            };

            Console.WriteLine("Enter Yearly CTC");
            string input = Console.ReadLine();
            int ctcValue = Convert.ToInt32(input);

            CTC ctc = new CTC(ctcValue, ctcLimits);

            Console.WriteLine(ctc);
            Console.ReadLine();
        }


    }
}
