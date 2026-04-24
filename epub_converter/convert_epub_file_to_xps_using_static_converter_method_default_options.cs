// Convert an EPUB file to XPS using the static Converter.ConvertEPUB method with default options.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.epub";
            string outputPath = "output.xps";

            FileStream stream = File.OpenRead(inputPath);
            XpsSaveOptions options = new XpsSaveOptions();
            Converter.ConvertEPUB(stream, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}