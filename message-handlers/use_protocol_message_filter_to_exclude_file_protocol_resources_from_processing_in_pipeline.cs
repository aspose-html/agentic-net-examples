// Use ProtocolMessageFilter to exclude file protocol resources from processing in the pipeline.

class FileProtocolExclusionHandler : Aspose.Html.Net.MessageHandler
{
    public FileProtocolExclusionHandler()
    {
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("file", "exclude"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        if (string.Equals(context.Request.RequestUri.Protocol.TrimEnd(':'), "file", System.StringComparison.OrdinalIgnoreCase))
        {
            return;
        }
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new FileProtocolExclusionHandler());

            var request = new Aspose.Html.Net.RequestMessage("https://example.com");
            using (var document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                var options = new Aspose.Html.Saving.MHTMLSaveOptions();
                string outputPath = "output.mhtml";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed: " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}