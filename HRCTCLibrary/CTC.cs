using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCTCLibrary
{
    public class CTC
    {
        public CTCLimits ctcLimits;
        public int CTCYearly { get; set; }
        public int CTCMonthly
        {
            get
            {
                return Convert.ToInt32(Math.Round(CTCYearly / 12.0));
            }
        }
        public int BasicMonthly
        {
            get
            {
                return Convert.ToInt32(Math.Round(CTCMonthly * ctcLimits.BasicPercent));
            }
        }
        public int BasicYearly
        {
            get
            {
                return Convert.ToInt32(Math.Round(CTCYearly * ctcLimits.BasicPercent));
            }
        }
        public int HRAMonthly
        {
            get
            {
                return Convert.ToInt32(Math.Round(BasicMonthly * ctcLimits.HRAPercent));
            }
        }
        public int HRAYearly
        {
            get
            {
                return Convert.ToInt32(Math.Round(BasicYearly * ctcLimits.HRAPercent));
            }
        }
        public int PFMonthly
        {
            get
            {
                if (BasicMonthly < ctcLimits.PFLimitAmount)
                {
                    return Convert.ToInt32(BasicMonthly * ctcLimits.PFContributionPercent);
                }
                else
                {
                    return Convert.ToInt32(ctcLimits.PFLimitAmount * ctcLimits.PFContributionPercent);
                }
            }
        }
        public int PFYearly
        {
            get
            {
                return PFMonthly * 12;
            }
        }
        public int ConvMonthly
        {
            get
            {
                return ctcLimits.ConvAmount;
            }
        }
        public int ConvYearly
        {
            get
            {
                return ConvMonthly * 12;
            }
        }
        public int MedicalReimbursmentMonthly
        {
            get
            {
                return ctcLimits.MedicalReimbursementAmount;
            }
        }
        public int MedicalReimbursmentYearly
        {
            get
            {
                return MedicalReimbursmentMonthly * 12;
            }
        }
        public int LTAYearly
        {
            get
            {
                return BasicMonthly;
            }
        }
        public int LTAMonthly
        {
            get
            {
                return Convert.ToInt32(Math.Round(LTAYearly / 12.0));
            }
        }
        public int SpecialAllowanceMonthly
        {
            get;set;
        }
        public int SpecialAllowanceYearly
        {
            get;set;           
        }
        public int ESICMonthly
        {
            get;set;
        }
        public int ESICYearly
        {
            get;set;
        }
        public CTC(int _ctc, CTCLimits _ctcLimits)
        {
            CTCYearly = _ctc;
            ctcLimits = _ctcLimits;
            CalculateSP();
        }
        void CalculateSP()
        {
            int specialAllowance = Convert.ToInt32(Math.Round(((CTCMonthly - PFMonthly - LTAMonthly) / (1 + ctcLimits.ESICPercent)) - BasicMonthly - HRAMonthly - ConvMonthly - MedicalReimbursmentMonthly));
            if ((BasicMonthly + HRAMonthly + ConvMonthly + MedicalReimbursmentMonthly + specialAllowance) < ctcLimits.ESICLimitAmount)
            {
                SpecialAllowanceMonthly = specialAllowance;
                SpecialAllowanceYearly = Convert.ToInt32(Math.Round(((CTCYearly - PFYearly - LTAYearly) / (1 + ctcLimits.ESICPercent)) - BasicYearly - HRAYearly - ConvYearly - MedicalReimbursmentYearly));
                ESICMonthly = Convert.ToInt32(Math.Round((CTCMonthly - PFMonthly - LTAMonthly) * (ctcLimits.ESICPercent / (1 + ctcLimits.ESICPercent))));
                ESICYearly = Convert.ToInt32(Math.Round((CTCYearly - PFYearly - LTAYearly) * (ctcLimits.ESICPercent / (1 + ctcLimits.ESICPercent))));
            }
            else
            {
                SpecialAllowanceMonthly = CTCMonthly - BasicMonthly - HRAMonthly - ConvMonthly - MedicalReimbursmentMonthly - PFMonthly - LTAMonthly;
                SpecialAllowanceYearly = CTCYearly - BasicYearly - HRAYearly - ConvYearly - MedicalReimbursmentYearly - PFYearly - LTAYearly;
                ESICMonthly = 0;
                ESICYearly = 0;
            }
        }
        public override string ToString()
        {
            return string.Format($"\tAnnual\tMonthly\n" +
                $"CTC\t{CTCYearly}\t{CTCMonthly}\n" +
                $"BASIC\t{BasicYearly}\t{BasicMonthly}\n" +
                $"HRA\t{HRAYearly}\t{HRAMonthly}\n" +
                $"CONV\t{ConvYearly}\t{ConvMonthly}\n" +
                $"MEDI\t{MedicalReimbursmentYearly}\t{MedicalReimbursmentMonthly}\n" +
                $"PF\t{PFYearly}\t{PFMonthly}\n" +
                $"ESIC\t{ESICYearly}\t{ESICMonthly}\n" +
                $"SP\t{SpecialAllowanceYearly}\t{SpecialAllowanceMonthly}\n" +
                $"LTA\t{LTAYearly}\t{LTAMonthly}\n");
        }        
    }
}
