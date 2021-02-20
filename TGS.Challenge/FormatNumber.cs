using System;
using System.Globalization;

namespace TGS.Challenge
{
    /*
        Devise a function that takes an input 'n' (integer) and returns a string that is the
        decimal representation of that number grouped by commas after every 3 digits. 
        
        NOTES: You cannot use any built-in formatting functions to complete this task.

        Assume: 0 <= n < 1000000000

        1 -> "1"
        10 -> "10"
        100 -> "100"
        1000 -> "1,000"
        10000 -> "10,000"
        100000 -> "100,000"
        1000000 -> "1,000,000"
        35235235 -> "35,235,235"

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class FormatNumber
    {
        public string Format(int value)
        {
            if (value < 0 || value >= 1000000001)
                throw new ArgumentOutOfRangeException();

            //Because I didn't read the instructions this is not allowed :)
            //var result = string.Format(CultureInfo.InvariantCulture, "{0:N0}",value);

            if (value <= 100)
                return value.ToString(CultureInfo.InvariantCulture);

            //The brute force late night solution
            //return CustomFormatter(value);

            var strValue = value
                .ToString(CultureInfo.InvariantCulture);

            // Because the criteria is fixed for now i.e 0 <= n < 1000000000 I'm avoiding loops
            // C# 8 pattern matching, kinda like it although I'm suspecting its more syntactical sugar 
            // and that at some level it compiles down to basic ifs? :thinking, still cool though :D 
            var result = strValue.Length switch
            {
                4 => strValue.Insert(1, ","),
                5 => strValue.Insert(2, ","),
                6 => strValue.Insert(3, ","),
                7 => strValue
                    .Insert(1, ",")
                    .Insert(5,","),
                8 => strValue
                    .Insert(2, ",")
                    .Insert(6, ",")
            };

            return result;
        }

        private static string CustomFormatter(int value)
        {
            var result = value
                .ToString(CultureInfo.InvariantCulture);

            //1000 -> "1,000"
            if (result.Length == 4)
                return result.Insert(1, ",");

            //10000 -> "10,000" 
            if (result.Length == 5)
                return result.Insert(2, ",");

            //100000 -> "100,000" 
            if (result.Length == 6)
                return result.Insert(3, ",");

            //1000000-> "1,000,000"
            if (result.Length == 7)
            {
                result = result.Insert(1, ",");
                result = result.Insert(5, ",");
                return result;
            }

            //35235235 -> "35,235,235"
            if (result.Length == 8)
            {
                result = result.Insert(2, ",");
                result = result.Insert(6, ",");
                return result;
            }

            return result;
        }
    }
}
