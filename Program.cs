// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

var summary = BenchmarkRunner.Run<BenchmarkTest>();

Console.ReadLine();

//
// | Method                 | Mean              | Error         | StdDev      
//
// | StringConcatenation    | 4,564,149.7 us    | 17,284.71 us  | 13,494.77 us
// | StringBuilderAppend    | 477.0 us          | 1.57 us       | 1.31 us
// | StringConcatMethod     | 573.8 us          | 4.06 us       | 3.60 us
//
public class BenchmarkTest
{
    [Benchmark]
    public string StringConcatenation()
    {
        var result = "";

        for (int i = 0; i < 100_000; i++)
        {
            result += "Hello";
        }

        return result;
    }

    [Benchmark]
    public string StringBuilderAppend()
    {
        var builder = new StringBuilder();

        for (int i = 0; i < 100_000; i++)
        {
            builder.Append("Hello");
        }

        return builder.ToString();
    }

    [Benchmark]
    public string StringConcatMethod()
    {
        return string.Concat(
            Enumerable.Range(0, 100_000).Select(_ => "Hello")
        );
    }
}