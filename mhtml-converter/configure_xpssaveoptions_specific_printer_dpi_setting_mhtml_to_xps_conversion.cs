// Configure XpsSaveOptions to use a specific printer DPI setting during MHTML to XPS conversion.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mht";
            string outputPath = "output.xps";

            if (!File.Exists(sourcePath))
            {
                string simpleHtml = "<html><body><h1>Hello, MHTML!</h1></body></html>";
                File.WriteAllText(sourcePath, simpleHtml);
            }

            using (FileStream stream = File.OpenRead(sourcePath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.3f),
                        Aspose.Html.Drawing.Length.FromInches(5.8f)),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}