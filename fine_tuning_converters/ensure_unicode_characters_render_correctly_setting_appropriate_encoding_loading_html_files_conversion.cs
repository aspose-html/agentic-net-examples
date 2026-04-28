// Ensure Unicode characters render correctly by setting appropriate encoding when loading HTML files for conversion.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.png";
            string htmlContent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.GetEncoding("utf-8"));
            string baseUri = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(sourcePath));
            ImageSaveOptions options = new ImageSaveOptions();
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}