using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluffTailRanking.BusinessLayer.BusinessObjects
{
    public class EloCalculator
    {
        public static double CalculateExpetedValue(IEloRateable rateable1, IEloRateable rateable2, int constant = 400)
        {
            return (1 / (1 + Math.Pow(10, ((rateable2.EloRatingNumber - rateable1.EloRatingNumber) / constant))));
        }

        public static double CalculateRating(double pOldRating,int pConstantFactor, double pFinalResult, double pExpectedResult)
        {
           
            double newRating = pOldRating + pConstantFactor * (pFinalResult - pExpectedResult);

            return newRating;
        }

         
    }
}
