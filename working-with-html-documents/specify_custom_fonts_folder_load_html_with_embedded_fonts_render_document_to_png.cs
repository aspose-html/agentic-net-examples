// Specify a custom fonts folder, load HTML with embedded fonts, and render the document to PNG.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string fontsFolder = @"C:\CustomFonts";
            string inputHtml = @"C:\Input\sample.html";
            string outputPng = @"C:\Output\result.png";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder, true);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtml, configuration);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPng);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}