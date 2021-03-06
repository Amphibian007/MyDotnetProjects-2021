using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakaCalculator.Models
{
    public class TakaModel
    {
        [Required(ErrorMessage ="Monthly investment is required")]
        public decimal? MonthlyInvestment { get; set; }

        [Required(ErrorMessage = "Yearly interest rate is required")]
        public decimal? YearlyInterestRate { get; set; }

        [Required(ErrorMessage = "Years required")]
        public decimal? Years { get; set; }

        public decimal CalculateTaka()
        {
            var months = Years.Value * 12;
            var monthlyInterestRate = YearlyInterestRate.Value / 100 / 12;
            decimal futureTaka = 0;
            for(int i = 0; i < months; i++)
            {
                futureTaka = (futureTaka + MonthlyInvestment.Value) * (1 + monthlyInterestRate);
            }
            return futureTaka;
        }

    }
}
