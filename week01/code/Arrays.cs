using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // first I'll create an array of doubles with the size length
        // then I'll calculate i+1 for each index i from 0 to length-1:
        // result[i] = number * (i + 1).
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        // now it should return the already filled array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {

        // first I will validate the trivial cases, i.e. if the list is empty, it will exit; if amount % n == 0, exit (no rotation).
        // then I'll make a copy of the original list to read elements without corrupting the order.
        // then I'll clear the original list using data.Clear().
        // Insert in the 'data' the last 'k' elements of the copy (keeping order).
        // Then insert the first (n - k) elements of the copy.
        // Exemple: data={1..9}, amount=3 -> k=3 -> add copy[6..8] (7,8,9) after copy[0..5] (1..6).

        if (data == null || data.Count == 0) return;

        int n = data.Count;
        int k = amount % n;
        if (k == 0) return;

        List<int> copy = new List<int>(data);
        data.Clear();

        for (int i = n - k; i < n; i++)
        {
            data.Add(copy[i]);
        }

        for (int i = 0; i < n - k; i++)
        {
            data.Add(copy[i]);
        }
    }
}


   