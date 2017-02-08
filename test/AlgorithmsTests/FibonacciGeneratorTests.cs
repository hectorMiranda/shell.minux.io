using System;
using Xunit;
using Marcetux.Algorithms;

public class FibonacciGeneratorTests
{
    [Fact]
    public void GeneratorRuns()
    {
        int[] values = {0,1,1,2,3,5,8};
        var generator = new FibonacciGenerator();

        foreach(var digit in generator.Generate(values.Length))
            Assert.Equal(expected, actual);
    }

}