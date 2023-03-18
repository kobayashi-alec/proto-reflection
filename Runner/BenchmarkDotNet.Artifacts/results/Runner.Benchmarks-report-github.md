``` ini

BenchmarkDotNet=v0.13.5, OS=macOS Ventura 13.2.1 (22D68) [Darwin 22.3.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 7.0.0 (7.0.22.51805), Arm64 RyuJIT AdvSIMD


```
|                                        Method |      Mean |     Error |    StdDev |
|---------------------------------------------- |----------:|----------:|----------:|
|            Benchmark_Using_Dot_Net_Reflection | 77.929 ns | 1.1292 ns | 1.0010 ns |
|          Benchmark_Dot_Net_Reflection_No_Linq | 55.569 ns | 1.0363 ns | 0.9693 ns |
|     Benchmark_Using_Cached_Dot_Net_Reflection |  7.734 ns | 0.0845 ns | 0.0749 ns |
|                 Benchmark_IMessage_Reflection | 11.651 ns | 0.2141 ns | 0.1898 ns |
| Benchmark_Using_Optimised_IMessage_Reflection |  3.218 ns | 0.0378 ns | 0.0316 ns |
