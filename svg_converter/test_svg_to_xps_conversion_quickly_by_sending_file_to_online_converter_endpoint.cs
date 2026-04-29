// Test SVG to XPS conversion quickly by sending the file to the online converter endpoint.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.svg";
            string outputPath = "output.xps";
            XpsSaveOptions options = new XpsSaveOptions();
            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}