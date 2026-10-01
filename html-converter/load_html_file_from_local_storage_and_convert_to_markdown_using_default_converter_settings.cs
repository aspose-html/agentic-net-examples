// Load an HTML file from local storage and convert it to Markdown using default Converter settings.

using System;
using System.IO;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string savePath = "output.md";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<!DOCTYPE html><html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>");
            }

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, savePath);
            Console.WriteLine("Conversion completed. Markdown saved at " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}