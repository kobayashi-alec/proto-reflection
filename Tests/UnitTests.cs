using Runner;
using Xunit;

namespace Tests;

public class UnitTests
{
    [Fact]
    public void Test_That_Reflection_Is_Working()
    {
        var sut = new Benchmarks();

        Assert.Equal("foo", sut.Benchmark_Using_Dot_Net_Reflection());
    }
    
    [Fact]
    public void Test_That_Reflection_No_Linq_Is_Working()
    {
        var sut = new Benchmarks();

        Assert.Equal("foo", sut.Benchmark_Dot_Net_Reflection_No_Linq());
    }
    
    [Fact]
    public void Test_That__Optimised_Reflection_Is_Working()
    {
        var sut = new Benchmarks();

        Assert.Equal("foo", sut.Benchmark_Using_Cached_Dot_Net_Reflection());
    }
    
    [Fact]
    public void Test_That_Proto_Reflection_Is_Working()
    {
        var sut = new Benchmarks();

        Assert.Equal("foo", sut.Benchmark_IMessage_Reflection());
    }
    
    [Fact]
    public void Test_That_Optimised_Proto_Reflection_Is_Working()
    {
        var sut = new Benchmarks();

        Assert.Equal("foo", sut.Benchmark_Using_Optimised_IMessage_Reflection());
    }
}