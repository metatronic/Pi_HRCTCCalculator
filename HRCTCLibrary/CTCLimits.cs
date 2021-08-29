using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace HRCTCLibrary
{
    public class CTCLimits
    {
        public double BasicPercent { get; set; }
        public double HRAPercent { get; set; }
        public int ConvAmount { get; set; }
        public int SpecialAllowanceAmount { get; set; }
        public int MedicalReimbursementAmount { get; set; }
        public double PFContributionPercent { get; set; }
        public double PFLimitAmount { get; set; }
        public double ESICPercent { get; set; }
        public double ESICLimitAmount { get; set; }
    }
}
