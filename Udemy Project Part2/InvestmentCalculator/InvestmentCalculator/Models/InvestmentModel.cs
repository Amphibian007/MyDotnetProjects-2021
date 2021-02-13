using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentCalculator.Models
{
    public class InvestmentModel
    {
        [Required(ErrorMessage ="This field is required")]     
        [Range(1,10000,ErrorMessage ="Value should be from 1 to 10000")]
        public decimal? MonthlyInvestment { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Range(.1, 5, ErrorMessage = "Value should be from .1 to 5")]
        public decimal? YearlyInterestRate { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Range(1,5,ErrorMessage ="Year should be from less than 5")]
        public int? Years { get; set; }
        public decimal CalculateInvestment()
        {
            int months = Years.Value * 12;
            decimal monthlyInterestRate = YearlyInterestRate.Value / 100 / 12;
            decimal futureValue = 0;
            for(int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment.Value) * (1 + monthlyInterestRate);
            }
            return futureValue;
        }
    }
}
