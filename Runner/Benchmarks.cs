using System.Reflection;
using BenchmarkDotNet.Attributes;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Runner;

public class Benchmarks
{
    private readonly HelloRequest _reflectionSut;
    private readonly IMessage _protoSut;
    private static readonly PropertyInfo _cachedPropertyInfo;
    private static readonly IFieldAccessor _cachedFieldAccessor;

    static Benchmarks()
    {
        _cachedPropertyInfo = typeof(HelloRequest)
            .GetProperties()
            .Single(p => p.Name == "Name");

        _cachedFieldAccessor = HelloRequest.Descriptor
            .Fields
            .InFieldNumberOrder()[0]
            .Accessor;
    }


    public Benchmarks()
    {
        _reflectionSut = new HelloRequest
        {
            Name = "foo"
        };

        _protoSut = _reflectionSut;
    }
    

    [Benchmark]
    public string Benchmark_Using_Dot_Net_Reflection()
    {
        return (string) _reflectionSut.GetType()
            .GetProperties()
            .Single(p => p.Name == "Name")
            .GetValue(_reflectionSut)!;
    }

    [Benchmark]
    public string Benchmark_Dot_Net_Reflection_No_Linq()
    {
        var properties = _reflectionSut.GetType().GetProperties();
        PropertyInfo found = null!;
        for (var i = 0; i < properties.Length; i++)
        {
            if (properties[i].Name == "Name")
            {
                found = properties[i];
                break;
            }
        }

        return (string) found!.GetValue(_reflectionSut)!;
    }

    [Benchmark]
    public string Benchmark_Using_Cached_Dot_Net_Reflection()
    {
        return (string) _cachedPropertyInfo.GetValue(_reflectionSut)!;
    }

    [Benchmark]
    public string Benchmark_IMessage_Reflection()
    {
        return (string) _protoSut.Descriptor
            .Fields
            .InFieldNumberOrder()[0]
            .Accessor
            .GetValue(_reflectionSut);
    }

    [Benchmark]
    public string Benchmark_Using_Optimised_IMessage_Reflection()
    {
        return (string) _cachedFieldAccessor.GetValue(_reflectionSut);
    }
}