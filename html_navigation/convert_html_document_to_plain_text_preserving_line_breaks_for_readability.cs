// Convert the HTML document to plain text while preserving line breaks for readability.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToTextExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                string txtPath = "output.txt";
                TextSaveOptions options = new TextSaveOptions();
                Converter.ConvertHTML(htmlPath, options, txtPath);
                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}