using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class to contain some useful methods to cooperate with strings

namespace CMDGameEngine.Additional
{
    public static class StringPartsAnalyzer
    {
        public static int GetLengthOfTheLongestPart(string[] parts)
        //Returning the longest string from string array
        {
            int maxLength = 0;

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length > maxLength)
                {
                    maxLength = parts[i].Length;
                }
            }

            return maxLength;
        }
    }
}
