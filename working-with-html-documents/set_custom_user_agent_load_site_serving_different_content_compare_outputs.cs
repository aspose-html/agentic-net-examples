// Set custom user agent, load a site that serves different content, and compare outputs.

using System;
using System.IO;

class CustomUserAgentHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["User-Agent"] = "MyCustomAgent/1.0";
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://httpbin.org/user-agent";
            string defaultPdfPath = "default.pdf";
            string customPdfPath = "custom.pdf";

            // Load with default user agent and convert to PDF
            Aspose.Html.Configuration defaultConfig = new Aspose.Html.Configuration();
            using (Aspose.Html.HTMLDocument defaultDoc = new Aspose.Html.HTMLDocument(url, defaultConfig))
            {
                Aspose.Html.Converters.Converter.ConvertHTML(defaultDoc, new Aspose.Html.Saving.PdfSaveOptions(), defaultPdfPath);
            }

            // Load with custom user agent and convert to PDF
            Aspose.Html.Configuration customConfig = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = customConfig.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CustomUserAgentHandler());

            using (Aspose.Html.HTMLDocument customDoc = new Aspose.Html.HTMLDocument(url, customConfig))
            {
                Aspose.Html.Converters.Converter.ConvertHTML(customDoc, new Aspose.Html.Saving.PdfSaveOptions(), customPdfPath);
            }

            // Compare the generated PDF files
            long defaultSize = new FileInfo(defaultPdfPath).Length;
            long customSize = new FileInfo(customPdfPath).Length;

            if (defaultSize == customSize)
                Console.WriteLine("Outputs are identical (file size).");
            else
                Console.WriteLine($"Outputs differ: default size = {defaultSize} bytes, custom size = {customSize} bytes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}