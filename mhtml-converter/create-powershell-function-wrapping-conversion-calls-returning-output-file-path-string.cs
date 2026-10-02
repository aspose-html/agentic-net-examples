// Create a PowerShell function that wraps conversion calls and returns the output file path as a string.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define PowerShell function script
            string scriptPath = "ConvertMarkdown.ps1";
            string functionScript = @"
function Convert-MarkdownToHtml {
    param(
        [string]$sourcePath,
        [string]$outputPath
    )
    [Aspose.Html.Converters.Converter]::ConvertMarkdown($sourcePath, $outputPath)
    return $outputPath
}
";
            // Write the PowerShell script to a file
            File.WriteAllText(scriptPath, functionScript);

            // Create a sample markdown file
            string markdownPath = "sample.md";
            string markdownContent = "# Sample Title\nThis is a sample markdown.";
            File.WriteAllText(markdownPath, markdownContent);

            // Define output HTML path
            string outputPath = "sample.html";

            Console.WriteLine($"PowerShell script created at: {Path.GetFullPath(scriptPath)}");
            Console.WriteLine($"Sample markdown file created at: {Path.GetFullPath(markdownPath)}");
            Console.WriteLine($"You can invoke the PowerShell function to convert markdown to HTML:");
            Console.WriteLine($"    .\\{scriptPath}");
            Console.WriteLine($"    Convert-MarkdownToHtml -sourcePath \"{markdownPath}\" -outputPath \"{outputPath}\"");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}