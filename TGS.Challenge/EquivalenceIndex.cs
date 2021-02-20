using System;

namespace TGS.Challenge
{
    /*
         Given a zero-based integer array of length N, the equivalence index (i) is the index where the sum of all the items to the left of the index
         are equal to the sum of all the items to the right of the index.

         Constraints: 0 <= N <= 100 000

         Example: Given the following array [1, 2, 3, 4, 5, 7, 8, 10, 12]
         Your program should output "6" because 1 + 2 + 3 + 4 + 5 + 7 = 10 + 12

         If no index exists then output -1

         There are accompanying unit tests for this exercise, ensure all tests pass & make
          sure the unit tests are correct too.
       */

    public class EquivalenceIndex
    {
        public int Find(int[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException();

            int centerPointIndex = numbers.Length / 2 - 1;

            //Iterate once to get the totals
            var sumLeft =  SumArrayContents(0, centerPointIndex, numbers);
            var sumRight = SumArrayContents(centerPointIndex + 1, numbers.Length, numbers);

            //Possibility to exit early post center point division
            if (sumLeft == sumRight)
                return centerPointIndex;

            while (sumLeft != sumRight)
            {
                if (sumLeft > sumRight)
                {
                    centerPointIndex = -1;
                    break;
                }

                if (sumLeft == sumRight)
                    break;

                centerPointIndex++;
                // Inc/dec the totals as the cpi moves in the array
                sumLeft += numbers[centerPointIndex - 1];
                sumRight -= numbers[centerPointIndex];
            }

            return centerPointIndex;
        }

        public int SumArrayContents(int start, int end, int[] numbers)
        {
            var result = 0;

            for (var i = start; i < end; i++)
            {
                result += numbers[i];
            }

            return result;
        }
    }
}
