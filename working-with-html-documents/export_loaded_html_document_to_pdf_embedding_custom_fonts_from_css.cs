// Export a loaded HTML document to PDF while embedding custom fonts specified in CSS.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPdf = "output.pdf";
            string fontsFolder = "fonts";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><style>@font-face {font-family: 'CustomFont'; src: url('customfont.ttf');} body {font-family: 'CustomFont';}</style></head><body><p>Hello with custom font!</p></body></html>");
            }

            if (!System.IO.Directory.Exists(fontsFolder))
            {
                System.IO.Directory.CreateDirectory(fontsFolder);
            }

            using (Aspose.Html.Configuration configuration = new Aspose.Html.Configuration())
            {
                Aspose.Html.Services.IUserAgentService userAgentService = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
                userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.PdfSaveOptions(), outputPdf);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}