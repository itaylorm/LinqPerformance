using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace LinqPerformance;

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net80)]
[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Params(1000)]
    public int Size { get; set; }

    private IEnumerable<int>? _items;

    [GlobalSetup]
    public void Setup()
    {
        _items = Enumerable.Range(0, Size).ToArray();
    }

    [Benchmark]
    public int Min() => _items!.Min();

    [Benchmark]
    public int Max() => _items!.Max();

    [Benchmark]
    public int Sum() => _items!.Sum();

    [Benchmark]
    public int Count() => _items!.Count();

    [Benchmark]
    public double Average() => _items!.Average();

}
