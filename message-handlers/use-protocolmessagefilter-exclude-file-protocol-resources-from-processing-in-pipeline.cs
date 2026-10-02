// Use ProtocolMessageFilter to exclude file protocol resources from processing in the pipeline.

using System;

public class FileProtocolExclusionHandler : Aspose.Html.Net.MessageHandler
{
    public FileProtocolExclusionHandler()
    {
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("file", "exclude"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Skip processing file protocol resources
        // Do not call Next to exclude them
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new FileProtocolExclusionHandler());

            string htmlContent = "<html><body><h1>Hello Aspose.HTML</h1><img src=\"file://C:/temp/image.png\" /></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
                string outputPath = "output.mhtml";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}