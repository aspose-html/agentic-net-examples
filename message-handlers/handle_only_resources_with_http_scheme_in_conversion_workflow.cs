// Use ProtocolMessageFilter to handle only resources with "http" scheme in conversion workflow.

class HttpOnlyHandler : Aspose.Html.Net.MessageHandler
{
    public HttpOnlyHandler()
    {
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("http"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new HttpOnlyHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com");

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
                string outputPath = "output.mhtml";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}