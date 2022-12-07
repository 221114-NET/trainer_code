
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        int[] originalArr = { 1, 2, 3, 400, -5, 6, 7, -88, 9, 34 };

        int res = FindMin(originalArr);
        Console.WriteLine(res);
    }

    /// <summary>
    /// find the smallest int in the array
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int FindMin(int[] arr)
    {

        // solution 1#
        // int min = arr[0];
        // foreach (int x in arr)
        // {
        //     if (x > min)
        //     {
        //         min = x;
        //     }
        // }

        // solution #2
        int min = arr.Max();
        return min;
    }
}