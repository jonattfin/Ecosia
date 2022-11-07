namespace Ecosia.SearchEngine.Application.Extensions;

public static class TaskExtensions
{
    public static async Task<(T1, T2, T3)> ExecuteThreeInParallel<T1, T2, T3>(Task<T1> t1, Task<T2> t2, Task<T3> t3)
    {
        var (t1Result, t2Result, t3Result, _) =
            await ExecuteFourInParallel(t1, t2, t3, Task.FromResult(0));

        return (t1Result, t2Result, t3Result);
    }

    public static async Task<(T1, T2, T3, T4)> ExecuteFourInParallel<T1, T2, T3, T4>(Task<T1> t1, Task<T2> t2,
        Task<T3> t3, Task<T4> t4)
    {
        var (t1Result, t2Result, t3Result, t4Result, _) =
            await ExecuteFiveInParallel(t1, t2, t3, t4, Task.FromResult(0));

        return (t1Result, t2Result, t3Result, t4Result);
    }

    public static async Task<(T1, T2, T3, T4, T5)> ExecuteFiveInParallel<T1, T2, T3, T4, T5>(Task<T1> t1, Task<T2> t2,
        Task<T3> t3, Task<T4> t4, Task<T5> t5)
    {
        var allTasks = Task.WhenAll(t1, t2, t3, t4, t5);

        try
        {
            await allTasks;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw allTasks.Exception;
        }

        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result);
    }
}