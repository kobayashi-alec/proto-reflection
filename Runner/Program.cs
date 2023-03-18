using BenchmarkDotNet.Running;

namespace Runner;

public class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<Benchmarks>();
    }
}