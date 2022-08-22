namespace Crafting_Code_Exercises.Exercise3
{
    public static class LeapYearValidator
    {
        public static bool Validate(int year)
        {
            if (year.IsDivisibleBy(400)) return true;
            if (year.IsDivisibleBy(100)) return false;
            return year.IsDivisibleBy(4);
        }

        public static bool IsDivisibleBy(this int yearToTest, int divisor)
        {
            return yearToTest % divisor == 0;
        }
    }
}