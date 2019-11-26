using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressMicroService.Extensions
{
    public static class StringExtension
    {
        //Based on the string comparison by Levenshtein which calculates the number of changes we require to transform one string into another. 
        //This is what will be used when comparing the two city names, the score param is the how similar the strings need to be to register them as the same
        public static bool FuzzyCompare(this string stringA, string stringB, int score, bool compareTrailingWhiteSpace = false, bool compareCapitalisation = false)
        {

            if (!compareTrailingWhiteSpace)
            {
                stringA = stringA.Trim();
                stringB = stringB.Trim();
            }

            if (!compareCapitalisation)
            {
                stringA = stringA.ToLower();
                stringB = stringB.ToLower();
            }

            int lengthA = stringA.Length;
            int lengthB = stringB.Length;
            int[,] distance = new int[lengthA + 1, lengthB + 1];

            if(lengthA == 0)
            {
                return false;
            }

            if(lengthB == 0)
            {
                return false;
            }

            for (int i = 0; i <= lengthA; distance[i, 0] = i++);
            for (int i = 0; i <= lengthB; distance[0, i] = i++);


            for(int i = 1; i <= lengthA; i++)
            {
                for(int j = 1; j <= lengthB; j++)
                {
                     int cost = (stringB[j - 1] == stringA[i - 1]) ? 0 : 1;
  
                     distance[i,j] = Math.Min(
                    Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[lengthA, lengthB] <= score;
        }
    }
}
