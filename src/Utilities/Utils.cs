using System.Collections.Generic;
using System.IO;

namespace Marcetux.Utilities
{

public static class Utils
{

public static IEnumerable<string> ReadFrom(string file)
{
    string line;
    using (var reader = File.OpenText(file))
    {
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
}

}
}