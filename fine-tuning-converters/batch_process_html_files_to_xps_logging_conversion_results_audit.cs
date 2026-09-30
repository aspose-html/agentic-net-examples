// Batch process a collection of HTML files to XPS, logging each conversion result for audit purposes.

using System;

class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        System.Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "HtmlFiles";
            string outputDir = "XpsOutput";
            System.IO.Directory.CreateDirectory(inputDir);
            System.IO.Directory.CreateDirectory(outputDir);

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputDir, "*.html"))
            {
                try
                {
                    Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                    Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                    network.MessageHandlers.Add(new LogHandler());

                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                    {
                        string xpsPath = System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".xps");
                        Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, xpsPath);
                        System.Console.WriteLine($"Converted: {htmlPath} -> {xpsPath}");
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Error converting {htmlPath}: {ex.Message}");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Fatal error: " + ex.Message);
        }
    }
}