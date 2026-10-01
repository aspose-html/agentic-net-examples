// Convert a list of HTML sources to MHTML outputs using MHTMLSaveOptions within a foreach loop.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

public class Program
{
    public static void Main()
    {
        try
        {
            // List of HTML source file paths
            List<string> htmlSources = new List<string>();
            htmlSources.Add("sample1.html");
            htmlSources.Add("sample2.html");

            // Create minimal HTML files if they do not exist
            foreach (string sourcePath in htmlSources)
            {
                if (!File.Exists(sourcePath))
                {
                    string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Content for " + sourcePath + "</h1></body></html>";
                    File.WriteAllText(sourcePath, htmlContent);
                }
            }

            // Convert each HTML file to MHTML
            foreach (string sourcePath in htmlSources)
            {
                string outputPath = Path.ChangeExtension(sourcePath, ".mhtml");
                MHTMLSaveOptions options = new MHTMLSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, "", options, outputPath);
                Console.WriteLine($"Converted '{sourcePath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}