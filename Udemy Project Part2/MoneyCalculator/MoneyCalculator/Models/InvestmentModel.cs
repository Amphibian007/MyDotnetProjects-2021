using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyCalculator.Models
{
    public class InvestmentModel
    {
        [Required(ErrorMessage ="This is required man")]
        [Range (1, 3000, ErrorMessage ="Btweeen 1 to 3000")]
        public decimal? MonthlyInvestment { get; set; }
        [Required(ErrorMessage ="This rate is also required man")]
        [Range(3,5, ErrorMessage = "Btweeen 3 to 5")]
        public decimal? YearlyInterestRate { get; set; }
        [Required(ErrorMessage ="Enter your years")]
        [Range(1, 5, ErrorMessage = "Should be less than 5")]
        public int? Years { get; set; }
        public decimal Calculate()
        {
            decimal months = Years.Value * 12;
            decimal monthlyInterestRate = YearlyInterestRate.Value / 100 / 12;
            decimal futureMoney = 0;
            for(int i = 0; i < months; i++)
            {
                futureMoney = (futureMoney + MonthlyInvestment.Value) * (1 + monthlyInterestRate);
            }
            return futureMoney;
        }
    }
}
