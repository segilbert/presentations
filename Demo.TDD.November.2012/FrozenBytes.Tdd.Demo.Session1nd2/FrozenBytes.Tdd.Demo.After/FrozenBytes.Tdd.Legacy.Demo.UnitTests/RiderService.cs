using System;
using StriderCupRacing.Models;

namespace FrozenBytes.Tdd.Legacy.Demo.UnitTests
{
    public class RiderSerivce : IRiderService
    {
        public int GetAge(Rider pxRider, DateTime pdtDateAsAt)
        {
            // No Error Check at this pt

            // 
            return pdtDateAsAt.Year - pxRider.DateOfBirth.Year
                   - (pxRider.DateOfBirth.DayOfYear < pdtDateAsAt.DayOfYear ? 0 : 1);
        }

        public string GetRiderClassification(
            Rider pxRider, int piAge, int currentFirstPlaceFinishes, int currentTopThreeFinishes)
        {
            // No Error Check at this pt
            //if ( piAge < 4 ) throw new Exception("Rider is not of age to race. Rider must be at least 4 years of age.");

            string classification = "{0} {1} - {2}";
            string skillLevel = RiderSkillLevelEnum.Beginner.ToString();

            if (currentFirstPlaceFinishes >= 3 && currentTopThreeFinishes >= 5) skillLevel = RiderSkillLevelEnum.Intermediate.ToString();
            else if (currentFirstPlaceFinishes >= 8 && currentTopThreeFinishes >= 10) skillLevel = RiderSkillLevelEnum.Expert.ToString();

            if (piAge > 3 && piAge <= 6)
                classification = string.Format(classification, pxRider.GenderEnum.ToString(), "6 and under", skillLevel);
            else if (piAge > 6 && piAge < 9)
                classification = string.Format(classification, pxRider.GenderEnum.ToString(), "9 and under", skillLevel);
            else if (piAge > 9 && piAge < 13)
                classification = string.Format(classification, pxRider.GenderEnum.ToString(), "12 and under", skillLevel);
            else if (piAge > 12 && piAge < 15)
                classification = string.Format(classification, pxRider.GenderEnum.ToString(), "14 and under", skillLevel);

            return classification;
        }
    }
}