namespace xofz.TimeKeeper98.Framework
{
    using System;

    public class DateCalculator
    {
        public virtual DateTime StartOfWeek()
        {
            var today = DateTime.Today;
            int daysToSubtract;
            switch (today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    daysToSubtract = 0;
                    break;
                case DayOfWeek.Tuesday:
                    daysToSubtract = 1;
                    break;
                case DayOfWeek.Wednesday:
                    daysToSubtract = 2;
                    break;
                case DayOfWeek.Thursday:
                    daysToSubtract = 3;
                    break;
                case DayOfWeek.Friday:
                    daysToSubtract = 4;
                    break;
                case DayOfWeek.Saturday:
                    daysToSubtract = 5;
                    break;
                case DayOfWeek.Sunday:
                    daysToSubtract = 6;
                    break;
                default: // switch statements shouldn't need a default case if 
                    //all the enum's values have been covered
                    daysToSubtract = 0;
                    break;
            }

            return today.AddDays(-daysToSubtract);
        }

        public virtual DateTime Friday()
        {
            var today = DateTime.Today;

            int daysToAdd;
            switch (today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    daysToAdd = 4;
                    break;
                case DayOfWeek.Tuesday:
                    daysToAdd = 3;
                    break;
                case DayOfWeek.Wednesday:
                    daysToAdd = 2;
                    break;
                case DayOfWeek.Thursday:
                    daysToAdd = 1;
                    break;
                case DayOfWeek.Friday:
                    daysToAdd = 0;
                    break;
                case DayOfWeek.Saturday:
                    daysToAdd = -1;
                    break;
                case DayOfWeek.Sunday:
                    daysToAdd = -2;
                    break;
                default: // switch statements shouldn't need a default case if 
                    //all the enum's values have been covered
                    daysToAdd = 0;
                    break;
            }

            return today.AddDays(daysToAdd);
        }

        public virtual DateTime EndOfWeek()
        {
            var today = DateTime.Today;

            int daysToAdd;
            switch (today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    daysToAdd = 6;
                    break;
                case DayOfWeek.Tuesday:
                    daysToAdd = 5;
                    break;
                case DayOfWeek.Wednesday:
                    daysToAdd = 4;
                    break;
                case DayOfWeek.Thursday:
                    daysToAdd = 3;
                    break;
                case DayOfWeek.Friday:
                    daysToAdd = 2;
                    break;
                case DayOfWeek.Saturday:
                    daysToAdd = 1;
                    break;
                case DayOfWeek.Sunday:
                    daysToAdd = 0;
                    break;
                default: // switch statements shouldn't need a default case if 
                    //all the enum's values have been covered
                    daysToAdd = 0;
                    break;
            }

            return today.AddDays(daysToAdd);
        }
    }
}
