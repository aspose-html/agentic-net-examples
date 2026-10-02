// Create a batch process that applies TimeoutMessageHandler to each HTML document in a directory.

using System;
using System.IO;

public sealed class TimeoutMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(5);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputHtml";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                File.WriteAllText(Path.Combine(inputDir, "sample.html"), "<html><body><h1>Sample</h1></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Add(new TimeoutMessageHandler());

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                    Console.WriteLine($"Processed: {htmlPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}