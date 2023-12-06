using System.CommandLine;

namespace scl;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Sample app for System.CommandLine");

        var inputFileOption = new Option<FileInfo?>(
            name: "--input",
            description: "The file to read and display on the console.");
        rootCommand.AddOption(inputFileOption);

        var outputFileOption = new Option<FileInfo?>(
            name: "--output",
            description: "The file to read and display on the console.");
        rootCommand.AddOption(outputFileOption);

        rootCommand.SetHandler((input, output) =>
        {
            ReadFile(input, output);
        }, inputFileOption, outputFileOption);

        // rootCommand.SetHandler((inut) =>
        //     {
        //         ReadFile(inut!);
        //     },
        //     fileOption);

        return await rootCommand.InvokeAsync(args);
    }

    static void ReadFile(FileInfo input, FileInfo output)
    {
        File.ReadLines(input.FullName).ToList()
            .ForEach(line => Console.WriteLine(line));
    }
}