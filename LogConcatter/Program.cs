Console.Write("Enter Path where Log Files are located:");
var path = Console.ReadLine();

var files = Directory.GetFiles(path, "*.log");
var resultFile = Path.Join(path, "Concat.log");
Console.WriteLine("Concatted following files:");
using (var fs = File.OpenWrite(resultFile))
{
    var sortedFiles = files.OrderBy(x =>
    {
        var idx = x.IndexOf('.') + 1;
        var idx2 = x.IndexOf('.', idx);
        if (idx2 <= 0)
            return int.MaxValue;
        return int.MaxValue - int.Parse(x[idx..idx2]);

    });

    foreach (var file in sortedFiles)
    {
        Console.WriteLine(file);
        using var fileFs = File.OpenRead(file);
        fileFs.CopyTo(fs);
    }
}

Console.WriteLine($"Concatted log is at: {resultFile}");
Console.ReadKey();
