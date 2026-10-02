// Load an HTML file from local storage and convert it to Markdown using default Converter settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string savePath = "output.md";

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>");
            }

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, savePath);
            Console.WriteLine("Conversion completed. Markdown saved at " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}