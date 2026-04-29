// Use DocSaveOptions to set document language property when converting MHTML to DOCX for localization.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.mhtml";
                string outputPath = "output.docx";

                using (Stream stream = File.OpenRead(inputPath))
                {
                    DocSaveOptions options = new DocSaveOptions();
                    Converter.ConvertMHTML(stream, options, outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}