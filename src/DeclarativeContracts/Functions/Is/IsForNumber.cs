namespace DeclarativeContracts.Functions
{
    public static partial class Is
    {
        public static bool Positive(short elementToCheck) => elementToCheck > 0;
        public static bool Positive(int elementToCheck) => elementToCheck > 0;
        public static bool Positive(long elementToCheck) => elementToCheck > 0;
        public static bool Positive(float elementToCheck) => elementToCheck > 0;
        public static bool Positive(double elementToCheck) => elementToCheck > 0;
        public static bool Positive(decimal elementToCheck) => elementToCheck > 0;

        public static bool Negative(short elementToCheck) => elementToCheck < 0;
        public static bool Negative(int elementToCheck) => elementToCheck < 0;
        public static bool Negative(long elementToCheck) => elementToCheck < 0;
        public static bool Negative(float elementToCheck) => elementToCheck < 0;
        public static bool Negative(double elementToCheck) => elementToCheck < 0;
        public static bool Negative(decimal elementToCheck) => elementToCheck < 0;

        public static bool Zero(short elementToCheck) => elementToCheck == 0;
        public static bool Zero(int elementToCheck) => elementToCheck == 0;
        public static bool Zero(long elementToCheck) => elementToCheck == 0;
        public static bool Zero(float elementToCheck) => elementToCheck == 0;
        public static bool Zero(double elementToCheck) => elementToCheck == 0;
        public static bool Zero(decimal elementToCheck) => elementToCheck == 0;

        public static bool NotZero(short elementToCheck) => elementToCheck != 0;
        public static bool NotZero(int elementToCheck) => elementToCheck != 0;
        public static bool NotZero(long elementToCheck) => elementToCheck != 0;
        public static bool NotZero(float elementToCheck) => elementToCheck != 0;
        public static bool NotZero(double elementToCheck) => elementToCheck != 0;
        public static bool NotZero(decimal elementToCheck) => elementToCheck != 0;

        public static bool One(short elementToCheck) => elementToCheck == 1;
        public static bool One(int elementToCheck) => elementToCheck == 1;
        public static bool One(long elementToCheck) => elementToCheck == 1;
        public static bool One(float elementToCheck) => elementToCheck == 1;
        public static bool One(double elementToCheck) => elementToCheck == 1;
        public static bool One(decimal elementToCheck) => elementToCheck == 1;

        public static bool NotOne(short elementToCheck) => elementToCheck != 1;
        public static bool NotOne(int elementToCheck) => elementToCheck != 1;
        public static bool NotOne(long elementToCheck) => elementToCheck != 1;
        public static bool NotOne(float elementToCheck) => elementToCheck != 1;
        public static bool NotOne(double elementToCheck) => elementToCheck != 1;
        public static bool NotOne(decimal elementToCheck) => elementToCheck != 1;

        public static bool Odd(short numberToCheck) => numberToCheck % 2 != 0;
        public static bool Odd(int numberToCheck) => numberToCheck % 2 != 0;
        public static bool Odd(long numberToCheck) => numberToCheck % 2 != 0;
        public static bool Odd(float numberToCheck) => numberToCheck % 2 != 0;
        public static bool Odd(double numberToCheck) => numberToCheck % 2 != 0;
        public static bool Odd(decimal numberToCheck) => numberToCheck % 2 != 0;

        public static bool Even(short numberToCheck) => numberToCheck % 2 == 0;
        public static bool Even(int numberToCheck) => numberToCheck % 2 == 0;
        public static bool Even(long numberToCheck) => numberToCheck % 2 == 0;
        public static bool Even(float numberToCheck) => numberToCheck % 2 == 0;
        public static bool Even(double numberToCheck) => numberToCheck % 2 == 0;
        public static bool Even(decimal numberToCheck) => numberToCheck % 2 == 0;

        public static bool PowerOfTwo(short numberToCheck) => (numberToCheck != 0) && ((numberToCheck & (numberToCheck - 1)) == 0);
        public static bool PowerOfTwo(int numberToCheck) => (numberToCheck != 0) && ((numberToCheck & (numberToCheck - 1)) == 0);
        public static bool PowerOfTwo(long numberToCheck) => (numberToCheck != 0) && ((numberToCheck & (numberToCheck - 1)) == 0);
    }
}
