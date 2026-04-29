// Integrate the conversion library into an ASP.NET MVC application for on‑demand website rendering.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace AsposeHtmlDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                string mhtmlPath = "sample.mhtml";
                using (Stream stream = File.OpenRead(mhtmlPath))
                {
                    byte[] docxBytes = ConvertMhtmlToDocxBytes(stream);
                    string outputPath = "output.docx";
                    File.WriteAllBytes(outputPath, docxBytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static byte[] ConvertMhtmlToDocxBytes(Stream inputStream)
        {
            string tempDocxPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");
            DocSaveOptions options = new DocSaveOptions();
            Converter.ConvertMHTML(inputStream, options, tempDocxPath);
            return File.ReadAllBytes(tempDocxPath);
        }
    }
}