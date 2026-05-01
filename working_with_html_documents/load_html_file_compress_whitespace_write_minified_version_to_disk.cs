// Load an HTML file, compress its whitespace, and write the minified version to disk.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "input.html";
            string outputPath = args.Length > 1 ? args[1] : "output.min.html";

            if (!File.Exists(inputPath))
                throw new FileNotFoundException($"Input file not found: {inputPath}");

            string htmlContent = File.ReadAllText(inputPath);
            string minifiedContent = Regex.Replace(htmlContent, @"\s+", " ").Trim();

            string baseUri = new Uri(Path.GetFullPath(inputPath)).AbsoluteUri;
            HTMLDocument document = new HTMLDocument(minifiedContent, baseUri);
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}