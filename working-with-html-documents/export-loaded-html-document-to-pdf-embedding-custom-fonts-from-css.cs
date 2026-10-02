// Export a loaded HTML document to PDF while embedding custom fonts specified in CSS.

using System;

namespace AsposeHtmlPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string fontsFolder = "fonts";
                if (!System.IO.Directory.Exists(fontsFolder))
                {
                    System.IO.Directory.CreateDirectory(fontsFolder);
                }

                // Assume a custom font file named "myfont.ttf" is placed in the fonts folder.

                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.IUserAgentService userAgentService = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
                userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

                string htmlContent = "<!DOCTYPE html><html><head><style>@font-face {font-family: 'MyCustomFont'; src: url('myfont.ttf');} body {font-family: 'MyCustomFont';}</style></head><body><p>Hello, custom font!</p></body></html>";
                string inputPath = "sample.html";
                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath, htmlContent);
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration);

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("PDF conversion completed successfully. Output: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}