// Create a PowerShell function that wraps conversion calls and returns the output file path as a string.

using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string sourcePath = "sample.md";
            string outputPath = "output.html";
            string psScriptPath = "ConvertMarkdown.ps1";

            // Create a minimal markdown file
            string markdownContent = "# Hello World\nThis is a sample markdown file.";
            File.WriteAllText(sourcePath, markdownContent);

            // Create PowerShell script with a function that wraps the conversion
            string psScript = $@"
function Convert-Markdown {{
    param([string]$src, [string]$out)
    [Aspose.Html.Converters.Converter]::ConvertMarkdown($src, $out)
    return $out
}}
# Invoke the function with the sample files
$result = Convert-Markdown -src '{sourcePath}' -out '{outputPath}'
Write-Output $result
";
            File.WriteAllText(psScriptPath, psScript);

            // Execute the PowerShell script and capture the output
            var startInfo = new ProcessStartInfo
            {
                FileName = "pwsh",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{psScriptPath}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(startInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                Console.WriteLine("PowerShell function returned: " + output.Trim());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}