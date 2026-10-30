// Batch process a collection of HTML files to XPS, logging each conversion result for audit purposes.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDir = "InputHtml";
                System.IO.Directory.CreateDirectory(inputDir);

                // Create a sample HTML file if the folder is empty
                if (System.IO.Directory.GetFiles(inputDir, "*.html").Length == 0)
                {
                    string samplePath = System.IO.Path.Combine(inputDir, "sample.html");
                    System.IO.File.WriteAllText(samplePath, "<html><body><h1>Sample</h1></body></html>");
                }

                foreach (string htmlPath in System.IO.Directory.GetFiles(inputDir, "*.html"))
                {
                    Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                    Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                    network.MessageHandlers.Add(new HTMLConversionLogHandler());

                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                    {
                        string xpsPath = System.IO.Path.ChangeExtension(htmlPath, ".xps");
                        Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, xpsPath);
                        System.Console.WriteLine($"Converted: {htmlPath} -> {xpsPath}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    class HTMLConversionLogHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            Next(context);
            System.Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
        }
    }
}