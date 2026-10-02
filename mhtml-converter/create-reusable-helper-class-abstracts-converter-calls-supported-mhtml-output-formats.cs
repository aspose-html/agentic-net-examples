// Create a reusable helper class that abstracts Converter calls for all supported MHTML output formats.

using System;
using System.IO;

namespace AsposeHtmlMhtmlConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mhtml";
                if (!File.Exists(inputPath))
                {
                    File.WriteAllText(inputPath, "Dummy MHTML content");
                }

                string outputXps = MhtmlConverterHelper.ConvertMhtmlByFormat(inputPath, "XPS");
                Console.WriteLine("XPS output: " + outputXps);

                string outputDocx = MhtmlConverterHelper.ConvertMhtmlByFormat(inputPath, "DOCX");
                Console.WriteLine("DOCX output: " + outputDocx);

                string outputJpeg = MhtmlConverterHelper.ConvertMhtmlByFormat(inputPath, "JPEG");
                Console.WriteLine("JPEG output: " + outputJpeg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public static class MhtmlConverterHelper
    {
        public static string ConvertMhtmlByFormat(string inputPath, string format)
        {
            using (FileStream stream = File.OpenRead(inputPath))
            {
                string outputPath;
                if (string.Equals(format, "XPS", StringComparison.OrdinalIgnoreCase))
                {
                    var options = new Aspose.Html.Saving.XpsSaveOptions();
                    outputPath = Path.Combine(Path.GetDirectoryName(inputPath), Path.GetFileNameWithoutExtension(inputPath) + ".xps");
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                else if (string.Equals(format, "DOCX", StringComparison.OrdinalIgnoreCase))
                {
                    var options = new Aspose.Html.Saving.DocSaveOptions();
                    outputPath = Path.Combine(Path.GetDirectoryName(inputPath), Path.GetFileNameWithoutExtension(inputPath) + ".docx");
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                else if (string.Equals(format, "JPEG", StringComparison.OrdinalIgnoreCase))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    outputPath = Path.Combine(Path.GetDirectoryName(inputPath), Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                else
                {
                    throw new ArgumentException("Unsupported format: " + format);
                }

                return outputPath;
            }
        }
    }
}