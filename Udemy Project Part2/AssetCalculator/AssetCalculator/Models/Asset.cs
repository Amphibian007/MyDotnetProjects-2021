using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetCalculator.Models
{
    public class Asset
    {
        [Required(ErrorMessage ="You should enter monthly asset")]
        [Range(1,5000,ErrorMessage ="Between 1 to 5000")]
        public decimal? MonthlyAsset { get; set; }
        [Required(ErrorMessage = "You should enter yearly interest rate")]
        [Range(.1, 6, ErrorMessage = "Between .1 to 6")]
        public decimal? YearlyInterestRate { get; set; }
        [Required(ErrorMessage = "You should enter years")]
        [Range(1, 5, ErrorMessage = "Less than 5")]
        public int? Years { get; set; }
        public decimal Calculate()
        {
            decimal months = Years.Value * 12;
            decimal monthlyInerestRate = YearlyInterestRate.Value / 100 / 12;
            decimal futurValue = 0;
            for(int i=0;i<months; i++)
            {
                futurValue = (futurValue + MonthlyAsset.Value) * (1 + monthlyInerestRate);
            }
            return futurValue;

        }
    }
}
