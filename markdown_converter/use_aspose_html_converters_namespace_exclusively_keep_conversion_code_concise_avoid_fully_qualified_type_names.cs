// Use Aspose.Html.Converters namespace exclusively to keep conversion code concise and avoid fully qualified type names.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string baseUri = "file:///";
            string outputPath = "output.xps";

            XpsSaveOptions options = new XpsSaveOptions();

            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion to XPS completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}