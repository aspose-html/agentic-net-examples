// Apply a custom font family to all headings, then render the document to XPS format.

using System;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToXps
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.xps";
                string css = "h1, h2, h3, h4, h5, h6 { font-family: 'MyCustomFont'; }";

                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                IUserAgentService userAgent = configuration.GetService<IUserAgentService>();
                userAgent.UserStyleSheet = css;

                HTMLDocument document = new HTMLDocument(inputPath, configuration);
                XpsSaveOptions options = new XpsSaveOptions();

                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}