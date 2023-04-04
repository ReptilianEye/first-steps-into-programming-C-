using System;
using System.Collections.Generic;
// you can also use other imports, for example:

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(int[] A)
    {
        int n = A.Length;
        if (n <= 1)
            return n;
        int[] how_long = new int[n];
        for (int i = 0; i < n; i++)
            how_long[i] = 1;

        int prev = A[0];
        int zero_help = A[1] <= 0 ? 1 : -1;
        int zeros_streak = 0;
        for (int i = 1; i < n; i++)
        {
            if (A[i] == 0)
            {
                if (prev == 0)
                    zeros_streak++;
                else
                    zeros_streak = 1;
                how_long[i] = how_long[i - 1] + 1;
                zero_help = prev <= 0 ? 1 : -1;
            }
            else
            {
                if (prev == 0)
                {
                    if ((zero_help < 0 && A[i] > 0) || (zero_help > 0 && A[i] < 0))
                    {
                        how_long[i] = how_long[i - 1] + 1;
                    }
                    else
                    {
                        how_long[i] = zeros_streak + 1;
                    }
                }
                else
                    zeros_streak = 0;
                if ((prev < 0 && A[i] > 0) || (prev > 0 && A[i] < 0))
                    how_long[i] = how_long[i - 1] + 1;


            }
            prev = A[i];

        }
        int longest = -1;
        foreach (var el in how_long)
            longest = Math.Max(longest, el);

        return longest;

    }

}
