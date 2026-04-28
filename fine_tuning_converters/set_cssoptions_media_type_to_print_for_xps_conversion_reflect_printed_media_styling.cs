// Set CssOptions.MediaType to Print for XPS conversion to reflect printed media styling.

using System;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.xps";
            string printCss = "@media print { body { color: red; } }";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.UserStyleSheet = printCss;

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}